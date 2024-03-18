using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class SocialNetwork
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public SocialNetworkType SocialNetworkType { get; set; }

    public string Link { get; set; } = default!;
}