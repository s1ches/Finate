using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class JobFormConfiguration : IEntityTypeConfiguration<JobForm>
{
    public void Configure(EntityTypeBuilder<JobForm> builder)
    {
        throw new NotImplementedException();
    }
}