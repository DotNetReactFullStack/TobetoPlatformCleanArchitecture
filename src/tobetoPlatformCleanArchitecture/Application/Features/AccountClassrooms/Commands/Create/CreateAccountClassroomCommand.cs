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

namespace Application.Features.AccountClassrooms.Commands.Create;

public class CreateAccountClassroomCommand : IRequest<CreatedAccountClassroomResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int ClassroomId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountClassroomsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountClassrooms";

    public class CreateAccountClassroomCommandHandler : IRequestHandler<CreateAccountClassroomCommand, CreatedAccountClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountClassroomRepository _accountClassroomRepository;
        private readonly AccountClassroomBusinessRules _accountClassroomBusinessRules;

        public CreateAccountClassroomCommandHandler(IMapper mapper, IAccountClassroomRepository accountClassroomRepository,
                                         AccountClassroomBusinessRules accountClassroomBusinessRules)
        {
            _mapper = mapper;
            _accountClassroomRepository = accountClassroomRepository;
            _accountClassroomBusinessRules = accountClassroomBusinessRules;
        }

        public async Task<CreatedAccountClassroomResponse> Handle(CreateAccountClassroomCommand request, CancellationToken cancellationToken)
        {
            AccountClassroom accountClassroom = _mapper.Map<AccountClassroom>(request);

            await _accountClassroomRepository.AddAsync(accountClassroom);

            CreatedAccountClassroomResponse response = _mapper.Map<CreatedAccountClassroomResponse>(accountClassroom);
            return response;
        }
    }
}