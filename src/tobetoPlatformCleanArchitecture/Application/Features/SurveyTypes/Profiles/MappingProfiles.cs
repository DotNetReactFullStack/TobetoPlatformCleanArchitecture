using Application.Features.SurveyTypes.Commands.Create;
using Application.Features.SurveyTypes.Commands.Delete;
using Application.Features.SurveyTypes.Commands.Update;
using Application.Features.SurveyTypes.Queries.GetById;
using Application.Features.SurveyTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SurveyTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SurveyType, CreateSurveyTypeCommand>().ReverseMap();
        CreateMap<SurveyType, CreatedSurveyTypeResponse>().ReverseMap();
        CreateMap<SurveyType, UpdateSurveyTypeCommand>().ReverseMap();
        CreateMap<SurveyType, UpdatedSurveyTypeResponse>().ReverseMap();
        CreateMap<SurveyType, DeleteSurveyTypeCommand>().ReverseMap();
        CreateMap<SurveyType, DeletedSurveyTypeResponse>().ReverseMap();
        CreateMap<SurveyType, GetByIdSurveyTypeResponse>().ReverseMap();
        CreateMap<SurveyType, GetListSurveyTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<SurveyType>, GetListResponse<GetListSurveyTypeListItemDto>>().ReverseMap();
    }
}