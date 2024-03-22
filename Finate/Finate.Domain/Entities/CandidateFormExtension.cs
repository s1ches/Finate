namespace Finate.Domain.Entities;

public class CandidateFormExtension
{
    public Guid Id { get; set; }
    
    public Guid FormId { get; set; }

    public Form Form { get; set; } = default!;
    
    public bool IsClosed { get; set; }

    public List<Experience>? Experiences { get; set; } = [];
}