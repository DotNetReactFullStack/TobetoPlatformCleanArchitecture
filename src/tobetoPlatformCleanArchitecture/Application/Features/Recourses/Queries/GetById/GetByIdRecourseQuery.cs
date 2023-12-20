using Application.Features.Recourses.Constants;
using Application.Features.Recourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Recourses.Constants.RecoursesOperationClaims;

namespace Application.Features.Recourses.Queries.GetById;

public class GetByIdRecourseQuery : IRequest<GetByIdRecourseResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRecourseQueryHandler : IRequestHandler<GetByIdRecourseQuery, GetByIdRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseRepository _recourseRepository;
        private readonly RecourseBusinessRules _recourseBusinessRules;

        public GetByIdRecourseQueryHandler(IMapper mapper, IRecourseRepository recourseRepository, RecourseBusinessRules recourseBusinessRules)
        {
            _mapper = mapper;
            _recourseRepository = recourseRepository;
            _recourseBusinessRules = recourseBusinessRules;
        }

        public async Task<GetByIdRecourseResponse> Handle(GetByIdRecourseQuery request, CancellationToken cancellationToken)
        {
            Recourse? recourse = await _recourseRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseBusinessRules.RecourseShouldExistWhenSelected(recourse);

            GetByIdRecourseResponse response = _mapper.Map<GetByIdRecourseResponse>(recourse);
            return response;
        }
    }
}