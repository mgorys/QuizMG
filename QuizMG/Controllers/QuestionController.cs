using Microsoft.AspNetCore.Mvc;
using QuizMG.Services;

namespace QuizMG.Controllers
{
	public class QuestionController : Controller
	{
		private readonly IQuestionService _questionService;

		public QuestionController(IQuestionService questionService)
		{
			_questionService = questionService;
		}

        public IActionResult Index([FromRoute] int id, string answered)
        {
            ViewBag.Id = id;
            var result = _questionService.CheckAnswer(id,answered);

            return View(result);
        }
    }
}
