using Example.TodoWebApp.Bussiness.Interfaces;

namespace Example.TodoWebApp.Bussiness.DTO.TodoDtos
{
    public class WorkListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsCompleted { get; set; }
    }
}