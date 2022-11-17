using QuizMG.Models.DTOs;

namespace QuizMG.Repositories
{
    public interface IRepository
    {
        QuestionDto GetById(int questionId);
    }
}