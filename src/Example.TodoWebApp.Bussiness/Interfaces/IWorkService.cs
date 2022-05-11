using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Global.BaseObjects.Interfaces;

namespace Example.TodoWebApp.Bussiness.Interfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto work);
        Task<IResponse<IDto>> GetById<IDto>(int id);
        Task<IResponse> Delete(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
