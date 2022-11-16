using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuizMG.Models.DTOs;

namespace QuizMG.Models.Profiles
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();
        }
    }
}
