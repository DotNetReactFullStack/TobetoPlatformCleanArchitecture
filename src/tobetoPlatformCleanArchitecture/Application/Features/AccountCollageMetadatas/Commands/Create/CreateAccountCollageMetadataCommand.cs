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

namespace Application.Features.AccountCollageMetadatas.Commands.Create;

public class CreateAccountCollageMetadataCommand : IRequest<CreatedAccountCollageMetadataResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollageMetadatasOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollageMetadatas";

    public class CreateAccountCollageMetadataCommandHandler : IRequestHandler<CreateAccountCollageMetadataCommand, CreatedAccountCollageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
        private readonly AccountCollageMetadataBusinessRules _accountCollageMetadataBusinessRules;

        public CreateAccountCollageMetadataCommandHandler(IMapper mapper, IAccountCollageMetadataRepository accountCollageMetadataRepository,
                                         AccountCollageMetadataBusinessRules accountCollageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollageMetadataRepository = accountCollageMetadataRepository;
            _accountCollageMetadataBusinessRules = accountCollageMetadataBusinessRules;
        }

        public async Task<CreatedAccountCollageMetadataResponse> Handle(CreateAccountCollageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollageMetadata accountCollageMetadata = _mapper.Map<AccountCollageMetadata>(request);

            await _accountCollageMetadataRepository.AddAsync(accountCollageMetadata);

            CreatedAccountCollageMetadataResponse response = _mapper.Map<CreatedAccountCollageMetadataResponse>(accountCollageMetadata);
            return response;
        }
    }
}