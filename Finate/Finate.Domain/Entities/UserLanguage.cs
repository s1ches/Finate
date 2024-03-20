using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class UserLanguage
{
    public Guid Id { get; set; }
    
    public Guid? CandidateFormId { get; set; }
    
    public CandidateForm? CandidateForm { get; set; }
    
    public Guid? JobFormId { get; set; }
    
    public JobForm? JobForm { get; set; }
    
    public Language Language { get; set; }
}