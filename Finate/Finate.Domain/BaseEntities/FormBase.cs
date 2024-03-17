using Finate.Domain.Enums;

namespace Finate.Domain.BaseEntities;

public class FormBase
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public string ProfessionName { get; set; }
    
    public string PlaceAddress { get; set; }
    
    public int Salary { get; set; }
    
    public Currency Currency { get; set; }
    
    public string? Description { get; set; }
    
    public Gender Gender { get; set; }
    
    public Level? Level { get; set; }
    
    public double Rating { get; set; }
    
    public bool IsBlocked { get; set; }
    
    public int Views { get; set; }
    
    public DateTime CreateDate { get; set; }

    public List<Language> Languages { get; set; } = [];
}