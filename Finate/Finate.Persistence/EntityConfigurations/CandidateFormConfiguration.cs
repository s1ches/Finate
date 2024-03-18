using Finate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finate.Persistence.EntityConfigurations;

public class CandidateFormConfiguration : IEntityTypeConfiguration<CandidateForm>
{
    public void Configure(EntityTypeBuilder<CandidateForm> builder)
    {
        throw new NotImplementedException();
    }
}