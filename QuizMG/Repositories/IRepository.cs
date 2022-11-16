using QuizMG.Models.DTOs;

namespace QuizMG.Repositories
{
	public interface IRepository
	{
		IEnumerable<QuestionDto> GetAll();
		QuestionDto GetById(int questionId);
	}
}