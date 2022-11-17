using Microsoft.AspNetCore.Mvc;
using QuizMG.Models;
using QuizMG.Models.DTOs;
using QuizMG.Services;
using System.Diagnostics;

namespace QuizMG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
