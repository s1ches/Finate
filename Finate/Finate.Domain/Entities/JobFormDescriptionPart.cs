using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class JobFormDescriptionPart
{
    public Guid Id { get; set; }
    
    public Guid JobFormId { get; set; }

    public JobForm JobForm { get; set; } = default!;
    
    public DescriptionPartType DescriptionPartType { get; set; }

    public string Content { get; set; } = default!;
}