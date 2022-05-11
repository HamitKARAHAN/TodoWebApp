using Example.TodoWebApp.Bussiness.DTO.TodoDtos;

namespace Example.TodoWebApp.Bussiness.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto work);
        Task<IDto> GetById<IDto>(int id);
        Task Delete(int id);
        Task Update(WorkUpdateDto dto);
    }
}
