using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finate.Application.Interfaces;

/// <summary>
/// Интерфейс БД контекста
/// </summary>
public interface IDbContext
{
    public DbSet<Skill> Skills { get; set; }

    public DbSet<SocialNetwork> SocialNetworks { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<UserLanguage> UserLanguages { get; set; }

    public DbSet<CandidateForm> CandidateForms { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<JobForm> JobForms { get; set; }

    public DbSet<JobFormDescriptionPart> JobFormDescriptionParts { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken token);
}