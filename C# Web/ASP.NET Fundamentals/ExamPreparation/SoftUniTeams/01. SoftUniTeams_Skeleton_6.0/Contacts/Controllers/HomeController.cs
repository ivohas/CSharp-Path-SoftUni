using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}