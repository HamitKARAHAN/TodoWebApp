using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.Data.Domains;
using Example.TodoWebApp.Data.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Image = work.Image,
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
                        Image = work.Image,
                        Title = work.Title,
                        IsComplated = work.IsComplated,
                    });
                }
            }
            return workList;
        }
    }
}
