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

namespace Application.Features.Colleges.Commands.Create;

public class CreateCollegeCommand : IRequest<CreatedCollegeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CollegesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetColleges";

    public class CreateCollegeCommandHandler : IRequestHandler<CreateCollegeCommand, CreatedCollegeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;
        private readonly CollegeBusinessRules _collegeBusinessRules;

        public CreateCollegeCommandHandler(IMapper mapper, ICollegeRepository collegeRepository,
                                         CollegeBusinessRules collegeBusinessRules)
        {
            _mapper = mapper;
            _collegeRepository = collegeRepository;
            _collegeBusinessRules = collegeBusinessRules;
        }

        public async Task<CreatedCollegeResponse> Handle(CreateCollegeCommand request, CancellationToken cancellationToken)
        {
            College college = _mapper.Map<College>(request);

            await _collegeRepository.AddAsync(college);

            CreatedCollegeResponse response = _mapper.Map<CreatedCollegeResponse>(college);
            return response;
        }
    }
}