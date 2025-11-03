using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.GateAssignments
{
    public class RunwayConfiguration : IEntityTypeConfiguration<Runway>
    {
        public void Configure(EntityTypeBuilder<Runway> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(10);
            builder.Property(r => r.Status).IsRequired().HasConversion<string>();

            builder.HasMany(r => r.RunwaySchedules)
                .WithOne(rs => rs.Runway)
                .HasForeignKey(rs => rs.RunwayId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
