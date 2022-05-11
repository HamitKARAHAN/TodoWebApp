using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.UnitofWork;

namespace Example.TodoWebApp.Bussiness.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitofWork _unitofWork;

        public WorkService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task Create(WorkCreateDto work)
        {
            await _unitofWork.GetRepository<Work>().Create(new()
            {
                Description = work.Description,
                Title = work.Title,
                IsCompleted = work.IsCompleted,
               
            });
            await _unitofWork.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var response = await _unitofWork.GetRepository<Work>().GetAll();
            var workList = new List<WorkListDto>();
            if(response != null && response.Count > 0)
            {
                foreach (var work in response)
                {
                    workList.Add(new()
                    {
                        Id = work.Id,
                        Description = work.Description,
                        Title = work.Title,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var workItem = await _unitofWork.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (workItem != null)
            {
                return new()
                {
                    Description =workItem.Description,
                    Title = workItem.Title,
                    IsCompleted = workItem.IsCompleted
                };
            }
            return null;
        }

        public async Task Remove(object id)
        {
            var work = await _unitofWork.GetRepository<Work>().GetById(id);
            _unitofWork.GetRepository<Work>().Delete(work);
            await _unitofWork.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _unitofWork.GetRepository<Work>().Update(new()
            {
                Description=dto.Description,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted,
                Title = dto.Title
            });
            await _unitofWork.SaveChanges();
        }
    }
}
