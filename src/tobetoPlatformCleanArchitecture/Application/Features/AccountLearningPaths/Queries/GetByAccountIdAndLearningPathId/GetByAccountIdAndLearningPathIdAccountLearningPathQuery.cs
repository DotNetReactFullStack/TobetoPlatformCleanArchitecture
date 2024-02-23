using Application.Features.AccountLearningPaths.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;


namespace Application.Features.AccountLearningPaths.Queries.GetListByLearningPathId;
public class GetByAccountIdAndLearningPathIdAccountLearningPathQuery : IRequest<GetByAccountIdAndLearningPathIdAccountLearningPathResponse>//, ISecuredRequest
{
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public class GetByAccountIdAndLearningPathIdAccountLearningPathQueryHandler : IRequestHandler<GetByAccountIdAndLearningPathIdAccountLearningPathQuery, GetByAccountIdAndLearningPathIdAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public GetByAccountIdAndLearningPathIdAccountLearningPathQueryHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository, AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<GetByAccountIdAndLearningPathIdAccountLearningPathResponse> Handle(GetByAccountIdAndLearningPathIdAccountLearningPathQuery request, CancellationToken cancellationToken)
        {
            AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate: alp => alp.AccountId == request.AccountId && alp.LearningPathId == request.LearningPathId , cancellationToken: cancellationToken, include: alp => alp.Include(alp => alp.LearningPath));
            await _accountLearningPathBusinessRules.AccountLearningPathShouldExistWhenSelected(accountLearningPath);

            GetByAccountIdAndLearningPathIdAccountLearningPathResponse response = _mapper.Map<GetByAccountIdAndLearningPathIdAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }


}
