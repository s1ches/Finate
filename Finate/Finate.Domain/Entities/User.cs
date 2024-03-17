using Microsoft.AspNetCore.Identity;

namespace Finate.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public DateTime? BirthDay { get; set; }

    public List<SocialNetwork> SocialNetworks { get; set; } = [];
}