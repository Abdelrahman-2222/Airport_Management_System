using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.GateAssignments
{
    public class GateConfiguration : IEntityTypeConfiguration<Gate>
    {
        public void Configure(EntityTypeBuilder<Gate> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GateNumber).IsRequired().HasMaxLength(5);
            builder.Property(g => g.Status).IsRequired().HasConversion<string>();

            builder.HasMany(g => g.GateAssignments)
                .WithOne(ga => ga.Gate)
                .HasForeignKey(ga => ga.GateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
