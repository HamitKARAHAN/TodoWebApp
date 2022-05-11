using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example.TodoWebApp.UI.Controllers
{
    public class TodoController : Controller
    {
        private readonly IWorkService _workService;

        public TodoController(
                IWorkService workService
            )
        {
            _workService = workService;
        }

        public async Task<IActionResult> List()
        {
            
            return View(await _workService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto todo)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(todo);
                return RedirectToAction("List");
            }
            return View(todo);
        }

        public async Task<IActionResult> Update(int id)
        {
            var todo = await _workService.GetById(id);

            return View(new WorkUpdateDto()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto todo)
        {
            if (ModelState.IsValid)
            {
                await _workService.Update(todo);
                return RedirectToAction("List");
            }
            return View(todo);
        }
    }
}
