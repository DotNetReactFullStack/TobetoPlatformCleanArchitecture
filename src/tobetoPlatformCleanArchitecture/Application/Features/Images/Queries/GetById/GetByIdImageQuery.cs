using Application.Features.Images.Constants;
using Application.Features.Images.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Images.Constants.ImagesOperationClaims;

namespace Application.Features.Images.Queries.GetById;

public class GetByIdImageQuery : IRequest<GetByIdImageResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdImageQueryHandler : IRequestHandler<GetByIdImageQuery, GetByIdImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly ImageBusinessRules _imageBusinessRules;

        public GetByIdImageQueryHandler(IMapper mapper, IImageRepository imageRepository, ImageBusinessRules imageBusinessRules)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _imageBusinessRules = imageBusinessRules;
        }

        public async Task<GetByIdImageResponse> Handle(GetByIdImageQuery request, CancellationToken cancellationToken)
        {
            Image? image = await _imageRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _imageBusinessRules.ImageShouldExistWhenSelected(image);

            GetByIdImageResponse response = _mapper.Map<GetByIdImageResponse>(image);
            return response;
        }
    }
}