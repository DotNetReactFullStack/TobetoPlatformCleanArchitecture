using Application.Features.AccountExamResults.Constants;
using Application.Features.AccountExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountExamResults.Constants.AccountExamResultsOperationClaims;

namespace Application.Features.AccountExamResults.Queries.GetById;

public class GetByIdAccountExamResultQuery : IRequest<GetByIdAccountExamResultResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountExamResultQueryHandler : IRequestHandler<GetByIdAccountExamResultQuery, GetByIdAccountExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountExamResultRepository _accountExamResultRepository;
        private readonly AccountExamResultBusinessRules _accountExamResultBusinessRules;

        public GetByIdAccountExamResultQueryHandler(IMapper mapper, IAccountExamResultRepository accountExamResultRepository, AccountExamResultBusinessRules accountExamResultBusinessRules)
        {
            _mapper = mapper;
            _accountExamResultRepository = accountExamResultRepository;
            _accountExamResultBusinessRules = accountExamResultBusinessRules;
        }

        public async Task<GetByIdAccountExamResultResponse> Handle(GetByIdAccountExamResultQuery request, CancellationToken cancellationToken)
        {
            AccountExamResult? accountExamResult = await _accountExamResultRepository.GetAsync(predicate: aer => aer.Id == request.Id, cancellationToken: cancellationToken);
            await _accountExamResultBusinessRules.AccountExamResultShouldExistWhenSelected(accountExamResult);

            GetByIdAccountExamResultResponse response = _mapper.Map<GetByIdAccountExamResultResponse>(accountExamResult);
            return response;
        }
    }
}