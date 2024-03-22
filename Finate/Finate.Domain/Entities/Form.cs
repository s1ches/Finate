using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

public class Form
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; } = default!;

    public string ProfessionName { get; set; } = default!;

    public string PlaceAddress { get; set; } = default!;
    
    public int Salary { get; set; }

    public string Currency { get; set; } = default!;
    
    public string? Description { get; set; }
    
    public Gender Gender { get; set; }
    
    public Level? Level { get; set; }
    
    public double Rating { get; set; }
    
    public bool IsBlocked { get; set; }
    
    public int Views { get; set; }
    
    public DateTime CreateDate { get; set; }

    public List<UserLanguage>? Languages { get; set; } = [];

    public List<Tag> Tags { get; set; } = [];
    
    public List<Skill>? Skills { get; set; } = [];
    
    public bool IsActive { get; set; }
}