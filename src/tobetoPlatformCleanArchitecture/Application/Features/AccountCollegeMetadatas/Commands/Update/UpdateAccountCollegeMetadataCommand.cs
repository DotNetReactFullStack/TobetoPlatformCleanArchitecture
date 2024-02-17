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

namespace Application.Features.AccountCollegeMetadatas.Commands.Update;

public class UpdateAccountCollegeMetadataCommand : IRequest<UpdatedAccountCollegeMetadataResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime? GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollegeMetadatasOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollegeMetadatas";

    public class UpdateAccountCollegeMetadataCommandHandler : IRequestHandler<UpdateAccountCollegeMetadataCommand, UpdatedAccountCollegeMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly AccountCollegeMetadataBusinessRules _accountCollegeMetadataBusinessRules;

        public UpdateAccountCollegeMetadataCommandHandler(IMapper mapper, IAccountCollegeMetadataRepository accountCollegeMetadataRepository,
                                         AccountCollegeMetadataBusinessRules accountCollegeMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _accountCollegeMetadataBusinessRules = accountCollegeMetadataBusinessRules;
        }

        public async Task<UpdatedAccountCollegeMetadataResponse> Handle(UpdateAccountCollegeMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollegeMetadata? accountCollegeMetadata = await _accountCollegeMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollegeMetadataBusinessRules.AccountCollegeMetadataShouldExistWhenSelected(accountCollegeMetadata);
            accountCollegeMetadata = _mapper.Map(request, accountCollegeMetadata);

            await _accountCollegeMetadataRepository.UpdateAsync(accountCollegeMetadata!);

            UpdatedAccountCollegeMetadataResponse response = _mapper.Map<UpdatedAccountCollegeMetadataResponse>(accountCollegeMetadata);
            return response;
        }
    }
}