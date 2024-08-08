using Library.Controllers;
using Microsoft.AspNetCore.Mvc;
using SchoolShudale.Models;
using System.Diagnostics;

namespace SchoolShudale.Controllers
{
    public class HomeController : BaseController
    {       
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                //TempData[ErrorMessage] = "Page not found or invalid request.";
                return View("Error404");
            }
            if (statusCode == 401)
            {
                //TempData[ErrorMessage] = "Unauthorized access.";
                return View("Error401");
            }

           // TempData[ErrorMessage] = "An error occurred.";
            return View();
        }
    }
}