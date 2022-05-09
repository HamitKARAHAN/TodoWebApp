using Microsoft.AspNetCore.Mvc;

namespace Example.TodoWebApp.UI.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult List()
        {

            return View();
        }
    }
}
