using Application.Features.AccountClassrooms.Constants;
using Application.Features.AccountClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountClassrooms.Constants.AccountClassroomsOperationClaims;

namespace Application.Features.AccountClassrooms.Queries.GetById;

public class GetByIdAccountClassroomQuery : IRequest<GetByIdAccountClassroomResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountClassroomQueryHandler : IRequestHandler<GetByIdAccountClassroomQuery, GetByIdAccountClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountClassroomRepository _accountClassroomRepository;
        private readonly AccountClassroomBusinessRules _accountClassroomBusinessRules;

        public GetByIdAccountClassroomQueryHandler(IMapper mapper, IAccountClassroomRepository accountClassroomRepository, AccountClassroomBusinessRules accountClassroomBusinessRules)
        {
            _mapper = mapper;
            _accountClassroomRepository = accountClassroomRepository;
            _accountClassroomBusinessRules = accountClassroomBusinessRules;
        }

        public async Task<GetByIdAccountClassroomResponse> Handle(GetByIdAccountClassroomQuery request, CancellationToken cancellationToken)
        {
            AccountClassroom? accountClassroom = await _accountClassroomRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountClassroomBusinessRules.AccountClassroomShouldExistWhenSelected(accountClassroom);

            GetByIdAccountClassroomResponse response = _mapper.Map<GetByIdAccountClassroomResponse>(accountClassroom);
            return response;
        }
    }
}