using Microsoft.AspNetCore.Identity;

namespace Finate.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
    
    public DateTime? BirthDay { get; set; }

    public List<SocialNetwork> SocialNetworks { get; set; } = [];
}