using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}