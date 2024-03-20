namespace Finate.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    
    public Guid? CandidateFormId { get; set; }
    
    public CandidateForm? CandidateForm { get; set; }
    
    public Guid? JobFormId { get; set; }
    
    public JobForm? JobForm { get; set; }

    public string TagName { get; set; } = default!;
}