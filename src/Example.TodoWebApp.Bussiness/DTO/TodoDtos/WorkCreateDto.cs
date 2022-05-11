using System.ComponentModel.DataAnnotations;

namespace Example.TodoWebApp.Bussiness.DTO.TodoDtos
{
    public class WorkCreateDto
    {
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
