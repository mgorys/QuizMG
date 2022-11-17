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
        public IEnumerable<QuestionDto> GetAll()
        {
            return _repository.GetAll();
        }
        public QuestionDto GetById(int questionId)
        {
            var result = _repository.GetById(questionId);
            return result;
        }
        public QuestionDto CheckAnswer(int questionId, string answered)
        {
            var result = _repository.GetById(questionId);
            if (answered != null)
            {
                if (answered == "Lifebelt")
                {
                    result.ErrorMessage = "Correct answer was";
                    result.GoodAnswer = true;
                    result.AfterAnswer = true;
                }
                else
                {

                    if (result.Answer == answered)
                    {
                        result.ErrorMessage = "Correct answer";
                        result.GoodAnswer = true;
                        result.AfterAnswer = true;
                    }
                    else
                    {
                        result.ErrorMessage = "Wrong answer. Correct answer was";
                        result.AfterAnswer = true;
                    }
                }
            }
            return result;
        }
    }

}
