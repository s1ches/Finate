namespace Finate.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    
    public Guid FormId { get; set; }
    
    public string TagName { get; set; }
}