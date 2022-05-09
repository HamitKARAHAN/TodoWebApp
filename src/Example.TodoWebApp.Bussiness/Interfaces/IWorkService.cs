using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Bussiness.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto work);
    }
}
