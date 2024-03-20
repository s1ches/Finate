using Finate.Domain.BaseEntities;

namespace Finate.Domain.Entities;

public class CandidateForm : FormBase
{
    public bool IsClosed { get; set; }

    public List<Experience>? Experiences { get; set; } = [];
}