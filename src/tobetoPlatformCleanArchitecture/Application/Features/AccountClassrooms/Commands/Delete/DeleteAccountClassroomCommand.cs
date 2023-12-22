using Application.Features.AccountClassrooms.Constants;
using Application.Features.AccountClassrooms.Constants;
using Application.Features.AccountClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountClassrooms.Constants.AccountClassroomsOperationClaims;

namespace Application.Features.AccountClassrooms.Commands.Delete;

public class DeleteAccountClassroomCommand : IRequest<DeletedAccountClassroomResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountClassroomsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountClassrooms";

    public class DeleteAccountClassroomCommandHandler : IRequestHandler<DeleteAccountClassroomCommand, DeletedAccountClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountClassroomRepository _accountClassroomRepository;
        private readonly AccountClassroomBusinessRules _accountClassroomBusinessRules;

        public DeleteAccountClassroomCommandHandler(IMapper mapper, IAccountClassroomRepository accountClassroomRepository,
                                         AccountClassroomBusinessRules accountClassroomBusinessRules)
        {
            _mapper = mapper;
            _accountClassroomRepository = accountClassroomRepository;
            _accountClassroomBusinessRules = accountClassroomBusinessRules;
        }

        public async Task<DeletedAccountClassroomResponse> Handle(DeleteAccountClassroomCommand request, CancellationToken cancellationToken)
        {
            AccountClassroom? accountClassroom = await _accountClassroomRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountClassroomBusinessRules.AccountClassroomShouldExistWhenSelected(accountClassroom);

            await _accountClassroomRepository.DeleteAsync(accountClassroom!);

            DeletedAccountClassroomResponse response = _mapper.Map<DeletedAccountClassroomResponse>(accountClassroom);
            return response;
        }
    }
}