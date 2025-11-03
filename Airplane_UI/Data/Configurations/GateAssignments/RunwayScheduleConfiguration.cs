using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.GateAssignments
{
    public class RunwayScheduleConfiguration : IEntityTypeConfiguration<RunwaySchedule>
    {
        public void Configure(EntityTypeBuilder<RunwaySchedule> builder)
        {
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Type).IsRequired().HasConversion<string>();
        }
    }
}
