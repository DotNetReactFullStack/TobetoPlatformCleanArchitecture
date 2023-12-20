using Application.Features.Colleges.Constants;
using Application.Features.Colleges.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Colleges.Constants.CollegesOperationClaims;

namespace Application.Features.Colleges.Queries.GetById;

public class GetByIdCollegeQuery : IRequest<GetByIdCollegeResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCollegeQueryHandler : IRequestHandler<GetByIdCollegeQuery, GetByIdCollegeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;
        private readonly CollegeBusinessRules _collegeBusinessRules;

        public GetByIdCollegeQueryHandler(IMapper mapper, ICollegeRepository collegeRepository, CollegeBusinessRules collegeBusinessRules)
        {
            _mapper = mapper;
            _collegeRepository = collegeRepository;
            _collegeBusinessRules = collegeBusinessRules;
        }

        public async Task<GetByIdCollegeResponse> Handle(GetByIdCollegeQuery request, CancellationToken cancellationToken)
        {
            College? college = await _collegeRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _collegeBusinessRules.CollegeShouldExistWhenSelected(college);

            GetByIdCollegeResponse response = _mapper.Map<GetByIdCollegeResponse>(college);
            return response;
        }
    }
}