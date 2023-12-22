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

namespace Application.Features.AccountRecourses.Commands.Update;

public class UpdateAccountRecourseCommand : IRequest<UpdatedAccountRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecoursesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourses";

    public class UpdateAccountRecourseCommandHandler : IRequestHandler<UpdateAccountRecourseCommand, UpdatedAccountRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseRepository _accountRecourseRepository;
        private readonly AccountRecourseBusinessRules _accountRecourseBusinessRules;

        public UpdateAccountRecourseCommandHandler(IMapper mapper, IAccountRecourseRepository accountRecourseRepository,
                                         AccountRecourseBusinessRules accountRecourseBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseRepository = accountRecourseRepository;
            _accountRecourseBusinessRules = accountRecourseBusinessRules;
        }

        public async Task<UpdatedAccountRecourseResponse> Handle(UpdateAccountRecourseCommand request, CancellationToken cancellationToken)
        {
            AccountRecourse? accountRecourse = await _accountRecourseRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseBusinessRules.AccountRecourseShouldExistWhenSelected(accountRecourse);
            accountRecourse = _mapper.Map(request, accountRecourse);

            await _accountRecourseRepository.UpdateAsync(accountRecourse!);

            UpdatedAccountRecourseResponse response = _mapper.Map<UpdatedAccountRecourseResponse>(accountRecourse);
            return response;
        }
    }
}