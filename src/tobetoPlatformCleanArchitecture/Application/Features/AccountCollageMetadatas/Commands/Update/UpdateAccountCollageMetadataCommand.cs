using Application.Features.AccountCollageMetadatas.Constants;
using Application.Features.AccountCollageMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCollageMetadatas.Constants.AccountCollageMetadatasOperationClaims;

namespace Application.Features.AccountCollageMetadatas.Commands.Update;

public class UpdateAccountCollageMetadataCommand : IRequest<UpdatedAccountCollageMetadataResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollageMetadatasOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollageMetadatas";

    public class UpdateAccountCollageMetadataCommandHandler : IRequestHandler<UpdateAccountCollageMetadataCommand, UpdatedAccountCollageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
        private readonly AccountCollageMetadataBusinessRules _accountCollageMetadataBusinessRules;

        public UpdateAccountCollageMetadataCommandHandler(IMapper mapper, IAccountCollageMetadataRepository accountCollageMetadataRepository,
                                         AccountCollageMetadataBusinessRules accountCollageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollageMetadataRepository = accountCollageMetadataRepository;
            _accountCollageMetadataBusinessRules = accountCollageMetadataBusinessRules;
        }

        public async Task<UpdatedAccountCollageMetadataResponse> Handle(UpdateAccountCollageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollageMetadata? accountCollageMetadata = await _accountCollageMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollageMetadataBusinessRules.AccountCollageMetadataShouldExistWhenSelected(accountCollageMetadata);
            accountCollageMetadata = _mapper.Map(request, accountCollageMetadata);

            await _accountCollageMetadataRepository.UpdateAsync(accountCollageMetadata!);

            UpdatedAccountCollageMetadataResponse response = _mapper.Map<UpdatedAccountCollageMetadataResponse>(accountCollageMetadata);
            return response;
        }
    }
}