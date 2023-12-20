using Application.Features.Recourses.Constants;
using Application.Features.Recourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Recourses.Constants.RecoursesOperationClaims;

namespace Application.Features.Recourses.Commands.Create;

public class CreateRecourseCommand : IRequest<CreatedRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }

    public string[] Roles => new[] { Admin, Write, RecoursesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourses";

    public class CreateRecourseCommandHandler : IRequestHandler<CreateRecourseCommand, CreatedRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseRepository _recourseRepository;
        private readonly RecourseBusinessRules _recourseBusinessRules;

        public CreateRecourseCommandHandler(IMapper mapper, IRecourseRepository recourseRepository,
                                         RecourseBusinessRules recourseBusinessRules)
        {
            _mapper = mapper;
            _recourseRepository = recourseRepository;
            _recourseBusinessRules = recourseBusinessRules;
        }

        public async Task<CreatedRecourseResponse> Handle(CreateRecourseCommand request, CancellationToken cancellationToken)
        {
            Recourse recourse = _mapper.Map<Recourse>(request);

            await _recourseRepository.AddAsync(recourse);

            CreatedRecourseResponse response = _mapper.Map<CreatedRecourseResponse>(recourse);
            return response;
        }
    }
}