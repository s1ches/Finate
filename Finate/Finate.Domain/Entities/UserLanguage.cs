using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class UserLanguage
{
    public Guid Id { get; set; }
    
    public Guid FormId { get; set; }
    
    public Language Language { get; set; }
}