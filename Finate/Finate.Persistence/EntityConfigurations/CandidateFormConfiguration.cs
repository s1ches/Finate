using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class CandidateFormConfiguration : IEntityTypeConfiguration<CandidateForm>
{
    public void Configure(EntityTypeBuilder<CandidateForm> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.ProfessionName);
        builder.HasIndex(x => x.Rating);
        
        builder.HasMany(x => x.Experiences)
            .WithOne(y => y.CandidateForm)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Skills)
            .WithOne(y => y.CandidateForm)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Tags)
            .WithOne(y => y.CandidateForm)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Languages)
            .WithOne(y => y.CandidateForm)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}