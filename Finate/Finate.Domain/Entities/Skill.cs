using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Skill
{
    public Guid Id { get; set; }
    
    public Guid CandidateFormId { get; set; }
    
    public SkillType SkillType { get; set; }
    
    public bool IsTopSkill { get; set; }
}