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

namespace Application.Features.Colleges.Commands.Update;

public class UpdateCollegeCommand : IRequest<UpdatedCollegeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CollegesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetColleges";

    public class UpdateCollegeCommandHandler : IRequestHandler<UpdateCollegeCommand, UpdatedCollegeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;
        private readonly CollegeBusinessRules _collegeBusinessRules;

        public UpdateCollegeCommandHandler(IMapper mapper, ICollegeRepository collegeRepository,
                                         CollegeBusinessRules collegeBusinessRules)
        {
            _mapper = mapper;
            _collegeRepository = collegeRepository;
            _collegeBusinessRules = collegeBusinessRules;
        }

        public async Task<UpdatedCollegeResponse> Handle(UpdateCollegeCommand request, CancellationToken cancellationToken)
        {
            College? college = await _collegeRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _collegeBusinessRules.CollegeShouldExistWhenSelected(college);
            college = _mapper.Map(request, college);

            await _collegeRepository.UpdateAsync(college!);

            UpdatedCollegeResponse response = _mapper.Map<UpdatedCollegeResponse>(college);
            return response;
        }
    }
}