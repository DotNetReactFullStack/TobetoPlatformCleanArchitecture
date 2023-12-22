using Application.Features.Recourses.Constants;
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

namespace Application.Features.Recourses.Commands.Delete;

public class DeleteRecourseCommand : IRequest<DeletedRecourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RecoursesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourses";

    public class DeleteRecourseCommandHandler : IRequestHandler<DeleteRecourseCommand, DeletedRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseRepository _recourseRepository;
        private readonly RecourseBusinessRules _recourseBusinessRules;

        public DeleteRecourseCommandHandler(IMapper mapper, IRecourseRepository recourseRepository,
                                         RecourseBusinessRules recourseBusinessRules)
        {
            _mapper = mapper;
            _recourseRepository = recourseRepository;
            _recourseBusinessRules = recourseBusinessRules;
        }

        public async Task<DeletedRecourseResponse> Handle(DeleteRecourseCommand request, CancellationToken cancellationToken)
        {
            Recourse? recourse = await _recourseRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseBusinessRules.RecourseShouldExistWhenSelected(recourse);

            await _recourseRepository.DeleteAsync(recourse!);

            DeletedRecourseResponse response = _mapper.Map<DeletedRecourseResponse>(recourse);
            return response;
        }
    }
}