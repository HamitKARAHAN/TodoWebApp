using Example.TodoWebApp.Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example.TodoWebApp.UI.Controllers
{
    public class TodoController : Controller
    {
        private readonly IWorkService _workService;

        public TodoController(IWorkService workService)
        {
            _workService = workService;
        }

        public IActionResult List()
        {
            return View();
        }
    }
}
