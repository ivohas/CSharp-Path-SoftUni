using Library.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SchoolShudale.Controllers
{
    public class CreateController : BaseController
    {
        public IActionResult Schedule()
        {
            return View();
        }
    }
}
