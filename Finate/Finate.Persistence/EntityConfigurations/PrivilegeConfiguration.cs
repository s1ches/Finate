using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class PrivilegeConfiguration : IEntityTypeConfiguration<Privilege>
{
    public void Configure(EntityTypeBuilder<Privilege> builder)
    {
        throw new NotImplementedException();
    }
}