using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Features.AccountCollegeMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCollegeMetadatas.Constants.AccountCollegeMetadatasOperationClaims;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.AccountCollegeMetadatas.Commands.Create;

public class CreateAccountCollegeMetadataCommand : IRequest<CreatedAccountCollegeMetadataResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime? GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollegeMetadatasOperationClaims.Create, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollegeMetadatas";

    public class CreateAccountCollegeMetadataCommandHandler : IRequestHandler<CreateAccountCollegeMetadataCommand, CreatedAccountCollegeMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly AccountCollegeMetadataBusinessRules _accountCollegeMetadataBusinessRules;

        public CreateAccountCollegeMetadataCommandHandler(IMapper mapper, IAccountCollegeMetadataRepository accountCollegeMetadataRepository,
                                         AccountCollegeMetadataBusinessRules accountCollegeMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _accountCollegeMetadataBusinessRules = accountCollegeMetadataBusinessRules;
        }

        public async Task<CreatedAccountCollegeMetadataResponse> Handle(CreateAccountCollegeMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollegeMetadata accountCollegeMetadata = _mapper.Map<AccountCollegeMetadata>(request);
            await _accountCollegeMetadataBusinessRules.AccountCollegeMetadataGraduationYearMustBeOlderThanStartingYear(accountCollegeMetadata);
            await _accountCollegeMetadataRepository.AddAsync(accountCollegeMetadata);

            CreatedAccountCollegeMetadataResponse response = _mapper.Map<CreatedAccountCollegeMetadataResponse>(accountCollegeMetadata);
            return response;
        }
    }
}