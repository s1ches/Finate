using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Experience
{
    public Guid Id { get; set; }
    
    public Guid CandidateFormId { get; set; }

    public string ProfessionName { get; set; } = default!;
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }

    public string PlaceName { get; set; } = default!;
    
    public string? About { get; set; }
    
    public ExperienceType ExperienceType { get; set; }
}