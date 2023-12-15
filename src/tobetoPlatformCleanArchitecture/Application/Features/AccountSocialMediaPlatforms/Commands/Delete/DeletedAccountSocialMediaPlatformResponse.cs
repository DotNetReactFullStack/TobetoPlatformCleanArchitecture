using Core.Application.Responses;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Delete;

public class DeletedAccountSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
}