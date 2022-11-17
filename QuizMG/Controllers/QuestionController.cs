using Microsoft.AspNetCore.Mvc;
using QuizMG.Services;

namespace QuizMG.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public QuestionController(IQuestionService questionService, IHttpContextAccessor httpContextAccessor)
        {
            _questionService = questionService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index([FromRoute] int id, string answered)
        {
            if (id == 1)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Lifebelt", 1);
            }
            if (answered == "Lifebelt")
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Lifebelt", 0);
            }
            ViewBag.Id = id;
            var result = _questionService.Process(id, answered);

            return View(result);
        }
    }
}
