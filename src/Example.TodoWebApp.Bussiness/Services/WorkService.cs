using AutoMapper;
using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.UnitofWork;
using FluentValidation;

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

        public async Task Create(WorkCreateDto work)
        {
            var validationResult = _createValidator.Validate(work);
            if (validationResult.IsValid)
            {
                await _unitofWork.GetRepository<Work>().Create(_mapper.Map<Work>(work));
                await _unitofWork.SaveChanges();
            }
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            return _mapper.Map<List<WorkListDto>>(await _unitofWork.GetRepository<Work>().GetAll());
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id));
        }

        public async Task Delete(int id)
        {
            var todo = await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if(todo != null)
            {
                _unitofWork.GetRepository<Work>().Delete(todo);
                await _unitofWork.SaveChanges();
            }
        }

        public async Task Update(WorkUpdateDto dto)
        {
            var validationResult = _updateValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var todo = await _unitofWork.GetRepository<Work>().Find(dto.Id);
                if(todo != null)
                {
                    _unitofWork.GetRepository<Work>().Update(_mapper.Map<Work>(dto), todo);
                    await _unitofWork.SaveChanges();
                }
            }
        }
    }
}
