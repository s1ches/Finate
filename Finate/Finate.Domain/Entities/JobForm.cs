using Finate.Domain.BaseEntities;
using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class JobForm : FormBase
{
    public string? Statement { get; set; }
    
    public JobType JobType { get; set; }
    
    public int Applied { get; set; }
    
    public DateTime? ApplicationEndDate { get; set; }

    public List<JobFormDescriptionPart> DescriptionParts { get; set; } = [];
}