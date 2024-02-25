using Application.Features.Addresses.Constants;
using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Addresses.Constants.AddressesOperationClaims;
using Application.Features.AccountCapabilities.Constants;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.Addresses.Commands.Update.UpdateAddressInformation;

public class UpdateAddressInformationCommand : IRequest<UpdatedAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public string[] Roles => new[] { Admin, Write, AddressesOperationClaims.Create, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAddresses";

    public class UpdateAddressInformationCommandHandler : IRequestHandler<UpdateAddressInformationCommand, UpdatedAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public UpdateAddressInformationCommandHandler(IMapper mapper, IAddressRepository addressRepository,
                                         AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<UpdatedAddressResponse> Handle(UpdateAddressInformationCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: a => a.AccountId == request.AccountId, cancellationToken: cancellationToken);
            await _addressBusinessRules.AddressShouldExistWhenSelected(address);
            address = _mapper.Map(request, address);

            await _addressRepository.UpdateAsync(address!);

            UpdatedAddressResponse response = _mapper.Map<UpdatedAddressResponse>(address);
            return response;
        }
    }
}