using Example.TodoWebApp.Bussiness.DTO.TodoDtos;
using Example.TodoWebApp.Bussiness.Interfaces;
using Example.TodoWebApp.UI.Extensions;
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

        [Route("/")]
        [Route("/tasks")]
        public async Task<IActionResult> List()
        {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        [HttpGet("/add-task")]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost("/add-task")]
        public async Task<IActionResult> Create(WorkCreateDto todo)
        {
            return this.ResponseRedirectToAction(await _workService.Create(todo), "List");
        }

        [HttpGet("/update-task/{id:int}")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseRedirectToView(await _workService.GetById<WorkUpdateDto>(id));
        }

        [HttpPost("/update-task/{id:int}")]
        public async Task<IActionResult> Update(WorkUpdateDto todo)
        {
            return this.ResponseRedirectToAction(await _workService.Update(todo), "List");
        }

        [HttpGet("/delete-task/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return this.ResponseRedirectToAction(await _workService.Delete(id), "List");
        }

        [HttpGet("/notfound")]
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
