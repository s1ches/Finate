namespace Finate.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    
    public string TagName { get; set; } = default!;

    public List<Form> Forms { get; set; } = [];
}