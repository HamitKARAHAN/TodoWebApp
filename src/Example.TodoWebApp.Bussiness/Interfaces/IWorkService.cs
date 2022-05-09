using Example.TodoWebApp.Bussiness.DTO.TodoDtos;

namespace Example.TodoWebApp.Bussiness.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto work);
        Task<WorkListDto> GetById(object id);
        Task Remove(object id);
        Task Update(WorkUpdateDto dto);
    }
}
