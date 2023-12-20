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

namespace Application.Features.AccountClassrooms.Commands.Update;

public class UpdateAccountClassroomCommand : IRequest<UpdatedAccountClassroomResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ClassroomId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountClassroomsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountClassrooms";

    public class UpdateAccountClassroomCommandHandler : IRequestHandler<UpdateAccountClassroomCommand, UpdatedAccountClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountClassroomRepository _accountClassroomRepository;
        private readonly AccountClassroomBusinessRules _accountClassroomBusinessRules;

        public UpdateAccountClassroomCommandHandler(IMapper mapper, IAccountClassroomRepository accountClassroomRepository,
                                         AccountClassroomBusinessRules accountClassroomBusinessRules)
        {
            _mapper = mapper;
            _accountClassroomRepository = accountClassroomRepository;
            _accountClassroomBusinessRules = accountClassroomBusinessRules;
        }

        public async Task<UpdatedAccountClassroomResponse> Handle(UpdateAccountClassroomCommand request, CancellationToken cancellationToken)
        {
            AccountClassroom? accountClassroom = await _accountClassroomRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountClassroomBusinessRules.AccountClassroomShouldExistWhenSelected(accountClassroom);
            accountClassroom = _mapper.Map(request, accountClassroom);

            await _accountClassroomRepository.UpdateAsync(accountClassroom!);

            UpdatedAccountClassroomResponse response = _mapper.Map<UpdatedAccountClassroomResponse>(accountClassroom);
            return response;
        }
    }
}