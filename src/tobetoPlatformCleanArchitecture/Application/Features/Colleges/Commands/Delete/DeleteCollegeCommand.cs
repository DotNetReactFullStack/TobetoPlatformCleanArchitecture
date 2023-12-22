using Application.Features.Colleges.Constants;
using Application.Features.Colleges.Constants;
using Application.Features.Colleges.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Colleges.Constants.CollegesOperationClaims;

namespace Application.Features.Colleges.Commands.Delete;

public class DeleteCollegeCommand : IRequest<DeletedCollegeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CollegesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetColleges";

    public class DeleteCollegeCommandHandler : IRequestHandler<DeleteCollegeCommand, DeletedCollegeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;
        private readonly CollegeBusinessRules _collegeBusinessRules;

        public DeleteCollegeCommandHandler(IMapper mapper, ICollegeRepository collegeRepository,
                                         CollegeBusinessRules collegeBusinessRules)
        {
            _mapper = mapper;
            _collegeRepository = collegeRepository;
            _collegeBusinessRules = collegeBusinessRules;
        }

        public async Task<DeletedCollegeResponse> Handle(DeleteCollegeCommand request, CancellationToken cancellationToken)
        {
            College? college = await _collegeRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _collegeBusinessRules.CollegeShouldExistWhenSelected(college);

            await _collegeRepository.DeleteAsync(college!);

            DeletedCollegeResponse response = _mapper.Map<DeletedCollegeResponse>(college);
            return response;
        }
    }
}