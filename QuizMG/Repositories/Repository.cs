using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizMG.Data;
using QuizMG.Exceptions;
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
        public QuestionDto GetById(int questionId)
        {
            try
            {
                var question = _dbContext.Questions.FirstOrDefault(p => p.QstNmb == questionId);
                var result = _mapper.Map<QuestionDto>(question);

                return result;
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Problem with database. Sorry.");
            }
        }
    }
}

