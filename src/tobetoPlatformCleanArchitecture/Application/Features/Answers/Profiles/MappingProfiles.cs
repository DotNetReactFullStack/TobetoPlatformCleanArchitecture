using Application.Features.Answers.Commands.Create;
using Application.Features.Answers.Commands.Delete;
using Application.Features.Answers.Commands.Update;
using Application.Features.Answers.Queries.GetById;
using Application.Features.Answers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Answers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Answer, CreateAnswerCommand>().ReverseMap();
        CreateMap<Answer, CreatedAnswerResponse>().ReverseMap();
        CreateMap<Answer, UpdateAnswerCommand>().ReverseMap();
        CreateMap<Answer, UpdatedAnswerResponse>().ReverseMap();
        CreateMap<Answer, DeleteAnswerCommand>().ReverseMap();
        CreateMap<Answer, DeletedAnswerResponse>().ReverseMap();
        CreateMap<Answer, GetByIdAnswerResponse>().ReverseMap();
        CreateMap<Answer, GetListAnswerListItemDto>().ReverseMap();
        CreateMap<IPaginate<Answer>, GetListResponse<GetListAnswerListItemDto>>().ReverseMap();
    }
}