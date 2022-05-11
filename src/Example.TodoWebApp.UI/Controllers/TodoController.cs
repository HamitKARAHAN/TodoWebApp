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
            await _workService.Create(todo);
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _workService.GetById<WorkUpdateDto>(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto todo)
        {
            await _workService.Update(todo);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _workService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
