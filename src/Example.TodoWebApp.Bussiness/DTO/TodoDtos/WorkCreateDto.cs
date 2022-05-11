using Example.TodoWebApp.Bussiness.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Example.TodoWebApp.Bussiness.DTO.TodoDtos
{
    public class WorkCreateDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
