using Airplane_API.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.GateAssignments
{
    public class GateAssignmentConfiguration : IEntityTypeConfiguration<GateAssignment>
    {
        public void Configure(EntityTypeBuilder<GateAssignment> builder)
        {
            builder.HasKey(ga => ga.Id);
        }
    }
}
