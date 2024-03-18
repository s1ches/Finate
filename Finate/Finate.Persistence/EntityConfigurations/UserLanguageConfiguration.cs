using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
{
    public void Configure(EntityTypeBuilder<UserLanguage> builder)
    {
        throw new NotImplementedException();
    }
}