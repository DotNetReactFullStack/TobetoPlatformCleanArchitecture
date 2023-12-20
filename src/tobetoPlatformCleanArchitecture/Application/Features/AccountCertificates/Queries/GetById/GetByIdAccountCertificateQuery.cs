using Application.Features.AccountCertificates.Constants;
using Application.Features.AccountCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountCertificates.Constants.AccountCertificatesOperationClaims;

namespace Application.Features.AccountCertificates.Queries.GetById;

public class GetByIdAccountCertificateQuery : IRequest<GetByIdAccountCertificateResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountCertificateQueryHandler : IRequestHandler<GetByIdAccountCertificateQuery, GetByIdAccountCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCertificateRepository _accountCertificateRepository;
        private readonly AccountCertificateBusinessRules _accountCertificateBusinessRules;

        public GetByIdAccountCertificateQueryHandler(IMapper mapper, IAccountCertificateRepository accountCertificateRepository, AccountCertificateBusinessRules accountCertificateBusinessRules)
        {
            _mapper = mapper;
            _accountCertificateRepository = accountCertificateRepository;
            _accountCertificateBusinessRules = accountCertificateBusinessRules;
        }

        public async Task<GetByIdAccountCertificateResponse> Handle(GetByIdAccountCertificateQuery request, CancellationToken cancellationToken)
        {
            AccountCertificate? accountCertificate = await _accountCertificateRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCertificateBusinessRules.AccountCertificateShouldExistWhenSelected(accountCertificate);

            GetByIdAccountCertificateResponse response = _mapper.Map<GetByIdAccountCertificateResponse>(accountCertificate);
            return response;
        }
    }
}