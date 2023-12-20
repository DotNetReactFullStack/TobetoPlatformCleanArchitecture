using Application.Features.ForeignLanguageLevels.Constants;
using Application.Features.ForeignLanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ForeignLanguageLevels.Constants.ForeignLanguageLevelsOperationClaims;

namespace Application.Features.ForeignLanguageLevels.Queries.GetById;

public class GetByIdForeignLanguageLevelQuery : IRequest<GetByIdForeignLanguageLevelResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdForeignLanguageLevelQueryHandler : IRequestHandler<GetByIdForeignLanguageLevelQuery, GetByIdForeignLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

        public GetByIdForeignLanguageLevelQueryHandler(IMapper mapper, IForeignLanguageLevelRepository foreignLanguageLevelRepository, ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
        }

        public async Task<GetByIdForeignLanguageLevelResponse> Handle(GetByIdForeignLanguageLevelQuery request, CancellationToken cancellationToken)
        {
            ForeignLanguageLevel? foreignLanguageLevel = await _foreignLanguageLevelRepository.GetAsync(predicate: fll => fll.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageLevelBusinessRules.ForeignLanguageLevelShouldExistWhenSelected(foreignLanguageLevel);

            GetByIdForeignLanguageLevelResponse response = _mapper.Map<GetByIdForeignLanguageLevelResponse>(foreignLanguageLevel);
            return response;
        }
    }
}