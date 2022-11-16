using QuizMG.Models.DTOs;

namespace QuizMG.Services
{
    public interface IQuestionService
    {
        QuestionDto CheckAnswer(int questionId, string answered);
        IEnumerable<QuestionDto> GetAll();
        QuestionDto GetById(int questionId);
    }
}