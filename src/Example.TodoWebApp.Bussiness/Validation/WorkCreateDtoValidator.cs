using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Example.TodoWebApp.Bussiness.Validation
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title field is required!")
                .Must(title => !string.IsNullOrEmpty(title) && Regex.IsMatch(title, @"^[a-zA-Z0-9\s]+$"))
                .WithMessage("Title field cannot include these characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description field is required!")
                .Must(Description => !string.IsNullOrEmpty(Description) && Regex.IsMatch(Description, @"^[a-zA-Z0-9\s]+$"))
                .WithMessage("Description field cannot include these characters");
        }
    }
}
