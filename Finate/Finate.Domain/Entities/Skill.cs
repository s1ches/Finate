using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Skill
{
    public Guid Id { get; set; }

    public List<Form> Forms { get; set; } = [];
    
    public SkillType SkillType { get; set; }
    
    public bool IsTopSkill { get; set; }

    public string SkillName { get; set; } = default!;
}