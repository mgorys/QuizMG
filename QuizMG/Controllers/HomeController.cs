using Microsoft.AspNetCore.Mvc;
using QuizMG.Models;
using QuizMG.Models.DTOs;
using QuizMG.Services;
using System.Diagnostics;

namespace QuizMG.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService _questionService;

        public HomeController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
      
        
        public IActionResult Index()
        {
            IEnumerable<QuestionDto> result = _questionService.GetAll();

            return View(result);
        }
      

    }
}
