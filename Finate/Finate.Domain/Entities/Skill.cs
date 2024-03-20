using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Skill
{
    public Guid Id { get; set; }
    
    public Guid? CandidateFormId { get; set; }

    public CandidateForm? CandidateForm { get; set; }
    
    public Guid? JobFormId { get; set; }

    public JobForm? JobForm { get; set; }
    
    public SkillType SkillType { get; set; }
    
    public bool IsTopSkill { get; set; }

    public string SkillName { get; set; } = default!;
}