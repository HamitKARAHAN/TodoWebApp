using Example.TodoWebApp.Bussiness.Interfaces;

namespace Example.TodoWebApp.Bussiness.DTO.TodoDtos
{
    public class WorkUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
