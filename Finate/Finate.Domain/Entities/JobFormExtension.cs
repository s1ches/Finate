using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class JobFormExtension
{
    public Guid Id { get; set; }
    
    public Guid FormId { get; set; }

    public Form Form { get; set; } = default!;
    
    public string? Statement { get; set; }
    
    public JobType JobType { get; set; }
    
    public int Applied { get; set; }
    
    public DateTime? ApplicationEndDate { get; set; }

    public List<JobFormDescriptionPart> DescriptionParts { get; set; } = [];
}