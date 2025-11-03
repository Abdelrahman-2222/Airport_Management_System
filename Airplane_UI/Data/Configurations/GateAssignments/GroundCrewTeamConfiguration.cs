using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.GateAssignments
{
    public class GroundCrewTeamConfiguration : IEntityTypeConfiguration<GroundCrewTeam>
    {
        public void Configure(EntityTypeBuilder<GroundCrewTeam> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).IsRequired().HasMaxLength(100).HasColumnName("TaskName");
        }
    }
}
