using QuizMG.Models.DTOs;
using QuizMG.Repositories;
using System.Numerics;

namespace QuizMG.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository _repository;
        public QuestionService(IRepository repository)
        {
            _repository = repository;
        }
        public QuestionDto Process(int questionId, string answered)
        {
            var result = _repository.GetById(questionId);
            if (answered != null)
            {
                if (answered == "50/50")
                {
                    FiftyFifty(result);
                    return result;
                }
                else if (answered == "Swap")
                {
                    result = _repository.GetById(16);
                    result.ErrorMessage = "Correct answer was";
                }
                else if (answered == "Jump")
                {
                    result.ErrorMessage = "Correct answer was";
                    result.AfterAnswer = true;
                }
                else if (result.Answer == answered)
                {
                    result.ErrorMessage = "Correct answer";
                    result.AfterAnswer = true;
                }
                else
                {
                    result.AfterAnswer = true;
                    result.ErrorMessage = "Wrong answer. Correct answer was";
                    return result;
                }
                result.GoodAnswer = true;
            }
            return result;
        }
        private QuestionDto FiftyFifty(QuestionDto result)
        {

            var first = result.Option1;
            var second = result.Option2;
            var third = result.Option3;
            var fourth = result.Option4;
            if (result.Answer == first)
            {
                var array = FalseMixer(second, third, fourth);
                result.Option2 = array[0];
                result.Option3 = array[1];
                result.Option4 = array[2];
            }

            if (result.Answer == second)
            {
                var array = FalseMixer(first, third, fourth);
                result.Option1 = array[0];
                result.Option3 = array[1];
                result.Option4 = array[2];
            }

            if (result.Answer == third)
            {
                var array = FalseMixer(first, second, fourth);
                result.Option1 = array[0];
                result.Option2 = array[1];
                result.Option4 = array[2];
            }
            if (result.Answer == fourth)
            {
                var array = FalseMixer(first, second, third);
                result.Option1 = array[0];
                result.Option2 = array[1];
                result.Option3 = array[2];

            }
            return result;
        }
        private string[] FalseMixer(string falseFirst, string falseSecond, string falseThird)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 4);
            switch (number % 3)
            {
                case 0:
                    falseFirst = falseFirst.ToString().Insert(0, "Wrong: ");
                    falseSecond = falseSecond.ToString().Insert(0, "Wrong: ");
                    break;
                case 1:
                    falseFirst = falseFirst.ToString().Insert(0, "Wrong: ");
                    falseThird = falseThird.ToString().Insert(0, "Wrong: ");
                    break;
                case 2:
                    falseSecond = falseSecond.ToString().Insert(0, "Wrong: ");
                    falseThird = falseThird.ToString().Insert(0, "Wrong: ");
                    break;
            }
            string[] array = { falseFirst, falseSecond, falseThird };
            return array;
        }

    }
}
