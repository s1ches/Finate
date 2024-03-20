using Finate.Domain.Entities;
using Finate.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
{
    public void Configure(EntityTypeBuilder<UserLanguage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.CandidateForm)
            .WithMany(y => y.Languages)
            .HasForeignKey(z => z.CandidateFormId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.JobForm)
            .WithMany(y => y.Languages)
            .HasForeignKey(z => z.JobFormId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Language)
            .HasConversion(e => e.ToString(), 
                s => (Language)Enum.Parse(typeof(Language), s));
    }
}