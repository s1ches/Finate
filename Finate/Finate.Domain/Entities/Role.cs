using Microsoft.AspNetCore.Identity;

namespace Finate.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public List<Privilege> Privileges { get; set; } = [];
}