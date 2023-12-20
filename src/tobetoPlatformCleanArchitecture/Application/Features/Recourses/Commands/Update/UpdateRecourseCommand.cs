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

namespace Application.Features.Recourses.Commands.Update;

public class UpdateRecourseCommand : IRequest<UpdatedRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
    public DateTime PublishedDate { get; set; }

    public string[] Roles => new[] { Admin, Write, RecoursesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourses";

    public class UpdateRecourseCommandHandler : IRequestHandler<UpdateRecourseCommand, UpdatedRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseRepository _recourseRepository;
        private readonly RecourseBusinessRules _recourseBusinessRules;

        public UpdateRecourseCommandHandler(IMapper mapper, IRecourseRepository recourseRepository,
                                         RecourseBusinessRules recourseBusinessRules)
        {
            _mapper = mapper;
            _recourseRepository = recourseRepository;
            _recourseBusinessRules = recourseBusinessRules;
        }

        public async Task<UpdatedRecourseResponse> Handle(UpdateRecourseCommand request, CancellationToken cancellationToken)
        {
            Recourse? recourse = await _recourseRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseBusinessRules.RecourseShouldExistWhenSelected(recourse);
            recourse = _mapper.Map(request, recourse);

            await _recourseRepository.UpdateAsync(recourse!);

            UpdatedRecourseResponse response = _mapper.Map<UpdatedRecourseResponse>(recourse);
            return response;
        }
    }
}