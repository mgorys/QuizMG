using QuizMG.Models.DTOs;

namespace QuizMG.Services
{
    public interface IQuestionService
    {
        QuestionDto Process(int questionId, string answered);
    }
}