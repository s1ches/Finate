namespace Finate.Domain.Entities;

public class UserLanguage
{
    public Guid Id { get; set; }
    public string Language { get; set; } = default!;

    public List<Form> Forms { get; set; } = [];
}