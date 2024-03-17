namespace Finate.Domain.Entities;

public class SocialNetwork
{
    public Guid Id { get; set; }

    public string NetworkImagePath { get; set; } = default!;

    public string NetworkName { get; set; } = default!;
}