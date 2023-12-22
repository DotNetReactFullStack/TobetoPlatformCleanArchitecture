using Application.Features.AccountRecourses.Constants;
using Application.Features.AccountRecourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountRecourses.Constants.AccountRecoursesOperationClaims;

namespace Application.Features.AccountRecourses.Commands.Create;

public class CreateAccountRecourseCommand : IRequest<CreatedAccountRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecoursesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourses";

    public class CreateAccountRecourseCommandHandler : IRequestHandler<CreateAccountRecourseCommand, CreatedAccountRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseRepository _accountRecourseRepository;
        private readonly AccountRecourseBusinessRules _accountRecourseBusinessRules;

        public CreateAccountRecourseCommandHandler(IMapper mapper, IAccountRecourseRepository accountRecourseRepository,
                                         AccountRecourseBusinessRules accountRecourseBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseRepository = accountRecourseRepository;
            _accountRecourseBusinessRules = accountRecourseBusinessRules;
        }

        public async Task<CreatedAccountRecourseResponse> Handle(CreateAccountRecourseCommand request, CancellationToken cancellationToken)
        {
            AccountRecourse accountRecourse = _mapper.Map<AccountRecourse>(request);

            await _accountRecourseRepository.AddAsync(accountRecourse);

            CreatedAccountRecourseResponse response = _mapper.Map<CreatedAccountRecourseResponse>(accountRecourse);
            return response;
        }
    }
}