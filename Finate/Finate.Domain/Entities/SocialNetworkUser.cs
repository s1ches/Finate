namespace Finate.Domain.Entities;

public class SocialNetworkUser
{
    public Guid Id { get; set; }

    public Guid SocialNetworkId { get; set; }
    
    public Guid UserId { get; set; }

    public string Link { get; set; } = default!;
}