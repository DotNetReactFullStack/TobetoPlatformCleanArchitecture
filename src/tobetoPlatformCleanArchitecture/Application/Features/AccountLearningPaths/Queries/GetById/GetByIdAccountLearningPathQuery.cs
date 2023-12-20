using Application.Features.AccountLearningPaths.Constants;
using Application.Features.AccountLearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;

namespace Application.Features.AccountLearningPaths.Queries.GetById;

public class GetByIdAccountLearningPathQuery : IRequest<GetByIdAccountLearningPathResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountLearningPathQueryHandler : IRequestHandler<GetByIdAccountLearningPathQuery, GetByIdAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public GetByIdAccountLearningPathQueryHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository, AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<GetByIdAccountLearningPathResponse> Handle(GetByIdAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate: alp => alp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLearningPathBusinessRules.AccountLearningPathShouldExistWhenSelected(accountLearningPath);

            GetByIdAccountLearningPathResponse response = _mapper.Map<GetByIdAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}