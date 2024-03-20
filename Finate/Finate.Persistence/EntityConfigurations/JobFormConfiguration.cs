using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class JobFormConfiguration : IEntityTypeConfiguration<JobForm>
{
    public void Configure(EntityTypeBuilder<JobForm> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.IsActive);
        builder.HasIndex(x => x.ProfessionName);
        builder.HasIndex(x => x.Rating);

        builder.HasMany(x => x.DescriptionParts)
            .WithOne(y => y.JobForm)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Skills)
            .WithOne(y => y.JobForm)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Tags)
            .WithOne(y => y.JobForm)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Languages)
            .WithOne(y => y.JobForm)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.ProfessionName)
            .HasMaxLength(40);
    }
}