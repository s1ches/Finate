using Finate.Domain.BaseEntities;
using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class CandidateForm : FormBase
{
    public bool IsClosed { get; set; }
    
    public List<Experience>? Experiences { get; set; }
    
    public List<Skill>? Skills { get; set; }
}