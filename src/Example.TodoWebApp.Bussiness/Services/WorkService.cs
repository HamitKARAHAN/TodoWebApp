using AutoMapper;
using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Extensions;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.UnitofWork;
using Example.TodoWebApp.Global.BaseObjects.Concrete;
using Example.TodoWebApp.Global.BaseObjects.Interfaces;
using FluentValidation;
using static Example.TodoWebApp.Global.Utils.Enums;

namespace Example.TodoWebApp.Bussiness.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createValidator;
        private readonly IValidator<WorkUpdateDto> _updateValidator;

        public WorkService(
                IUnitofWork unitofWork,
                IMapper mapper, IValidator<WorkCreateDto> createValidator,
                IValidator<WorkUpdateDto> updateValidator
            )
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto work)
        {
            var validationResult = _createValidator.Validate(work);
            if (validationResult.IsValid)
            {
                await _unitofWork.GetRepository<Work>().Create(_mapper.Map<Work>(work));
                await _unitofWork.SaveChanges();
                return new BaseResponseModel<WorkCreateDto>(ResponseType.Success, work);
            }
            return new BaseResponseModel<WorkCreateDto>(ResponseType.ValidationError, work, validationResult.ConvertToCustomValidator());
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var todoList = _mapper.Map<List<WorkListDto>>(await _unitofWork.GetRepository<Work>().GetAll());
            return new BaseResponseModel<List<WorkListDto>>(ResponseType.Success, todoList);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var todo = _mapper.Map<IDto>(await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (todo != null)
            {
                return new BaseResponseModel<IDto>(ResponseType.Success, todo);
            }
            return new BaseResponseModel<IDto>(ResponseType.NotFound, $"Task couldn't found. Task id {id}");
        }

        public async Task<IResponse> Delete(int id)
        {
            var todo = await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (todo != null)
            {
                _unitofWork.GetRepository<Work>().Delete(todo);
                await _unitofWork.SaveChanges();
                return new BaseResponseModel(ResponseType.Success);
            }
            return new BaseResponseModel(ResponseType.NotFound, $"Task couldn't found. Task id : {id}");
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {
            var validationResult = _updateValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var todo = await _unitofWork.GetRepository<Work>().Find(dto.Id);
                if (todo != null)
                {
                    _unitofWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto), todo);
                    await _unitofWork.SaveChanges();
                    return new BaseResponseModel<WorkUpdateDto>(ResponseType.Success, dto);
                }
                return new BaseResponseModel<WorkUpdateDto>(ResponseType.NotFound, $"Task couldn't found. Task id : {dto.Id}");
            }
            return new BaseResponseModel<WorkUpdateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidator());
        }
    }
}
