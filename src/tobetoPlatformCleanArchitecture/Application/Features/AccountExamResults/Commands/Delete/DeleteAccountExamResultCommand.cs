using Application.Features.AccountExamResults.Constants;
using Application.Features.AccountExamResults.Constants;
using Application.Features.AccountExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountExamResults.Constants.AccountExamResultsOperationClaims;

namespace Application.Features.AccountExamResults.Commands.Delete;

public class DeleteAccountExamResultCommand : IRequest<DeletedAccountExamResultResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountExamResultsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountExamResults";

    public class DeleteAccountExamResultCommandHandler : IRequestHandler<DeleteAccountExamResultCommand, DeletedAccountExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountExamResultRepository _accountExamResultRepository;
        private readonly AccountExamResultBusinessRules _accountExamResultBusinessRules;

        public DeleteAccountExamResultCommandHandler(IMapper mapper, IAccountExamResultRepository accountExamResultRepository,
                                         AccountExamResultBusinessRules accountExamResultBusinessRules)
        {
            _mapper = mapper;
            _accountExamResultRepository = accountExamResultRepository;
            _accountExamResultBusinessRules = accountExamResultBusinessRules;
        }

        public async Task<DeletedAccountExamResultResponse> Handle(DeleteAccountExamResultCommand request, CancellationToken cancellationToken)
        {
            AccountExamResult? accountExamResult = await _accountExamResultRepository.GetAsync(predicate: aer => aer.Id == request.Id, cancellationToken: cancellationToken);
            await _accountExamResultBusinessRules.AccountExamResultShouldExistWhenSelected(accountExamResult);

            await _accountExamResultRepository.DeleteAsync(accountExamResult!);

            DeletedAccountExamResultResponse response = _mapper.Map<DeletedAccountExamResultResponse>(accountExamResult);
            return response;
        }
    }
}