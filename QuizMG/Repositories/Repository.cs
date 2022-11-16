using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizMG.Data;
using QuizMG.Models.DTOs;

namespace QuizMG.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<QuestionDto> GetAll()
        {
            try
            {
                var questions = _dbContext.Questions;
                var mappedQuestions = _mapper.Map<IEnumerable<QuestionDto>>(questions);
                return mappedQuestions;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public QuestionDto GetById(int questionId)
        {
            try
            {
                var question = _dbContext.Questions.FirstOrDefault(p => p.QstNmb == questionId);
                var result = _mapper.Map<QuestionDto>(question);
                if( question == null)
                {
                    result.ErrorMessage = "Question not found";    
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

