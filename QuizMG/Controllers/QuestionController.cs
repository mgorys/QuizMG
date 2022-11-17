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
            ViewBag.Id = id;
            if (id == 1 && answered == null)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Jump", 1);
                _httpContextAccessor.HttpContext.Session.SetInt32("50/50", 1);
                _httpContextAccessor.HttpContext.Session.SetInt32("Swap", 1);
            }
            if (answered == "50/50")
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("50/50", 0);
            } 
            if (answered == "Swap")
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Swap", 0);
                _httpContextAccessor.HttpContext.Session.SetInt32("SkippedId", id);
            }
            if (answered == "Jump")
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Jump", 0);
            }
            var result = _questionService.Process(id, answered);

            return View(result);
        }
    }
}
