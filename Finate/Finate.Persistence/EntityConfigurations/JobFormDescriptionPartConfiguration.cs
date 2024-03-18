using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class JobFormDescriptionPartConfiguration : IEntityTypeConfiguration<JobFormDescriptionPart>
{
    public void Configure(EntityTypeBuilder<JobFormDescriptionPart> builder)
    {
        throw new NotImplementedException();
    }
}