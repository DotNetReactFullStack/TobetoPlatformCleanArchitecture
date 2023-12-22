using Application.Features.AccountRecourses.Constants;
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

namespace Application.Features.AccountRecourses.Commands.Delete;

public class DeleteAccountRecourseCommand : IRequest<DeletedAccountRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecoursesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourses";

    public class DeleteAccountRecourseCommandHandler : IRequestHandler<DeleteAccountRecourseCommand, DeletedAccountRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseRepository _accountRecourseRepository;
        private readonly AccountRecourseBusinessRules _accountRecourseBusinessRules;

        public DeleteAccountRecourseCommandHandler(IMapper mapper, IAccountRecourseRepository accountRecourseRepository,
                                         AccountRecourseBusinessRules accountRecourseBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseRepository = accountRecourseRepository;
            _accountRecourseBusinessRules = accountRecourseBusinessRules;
        }

        public async Task<DeletedAccountRecourseResponse> Handle(DeleteAccountRecourseCommand request, CancellationToken cancellationToken)
        {
            AccountRecourse? accountRecourse = await _accountRecourseRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseBusinessRules.AccountRecourseShouldExistWhenSelected(accountRecourse);

            await _accountRecourseRepository.DeleteAsync(accountRecourse!);

            DeletedAccountRecourseResponse response = _mapper.Map<DeletedAccountRecourseResponse>(accountRecourse);
            return response;
        }
    }
}