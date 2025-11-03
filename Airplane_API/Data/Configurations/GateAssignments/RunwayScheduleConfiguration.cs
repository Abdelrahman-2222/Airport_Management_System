using Airplane_API.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_API.Data.Configurations.GateAssignments
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
