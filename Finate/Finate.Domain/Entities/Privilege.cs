using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Privilege
{
    public Guid Id { get; set; }
    
    public Guid RoleId { get; set; }
    
    public PrivilegeType PrivilegeType { get; set; }
}