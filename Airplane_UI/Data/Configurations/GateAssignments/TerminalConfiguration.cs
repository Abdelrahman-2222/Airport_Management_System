using Airplane_UI.Entities.GateAssignments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airplane_UI.Data.Configurations.GateAssignments
{
    public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(t => t.Gates)
                .WithOne(g => g.Terminal)
                .HasForeignKey(g => g.TerminalId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(t => t.BaggageClaims)
                .WithOne(bc => bc.Terminal)
                .HasForeignKey(bc => bc.TerminalId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(t => t.SecurityCheckpoints)
                .WithOne(sc => sc.Terminal)
                .HasForeignKey(sc => sc.TerminalID)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(t => t.CustomsDesks)
                .WithOne(cd => cd.Terminal)
                .HasForeignKey(cd => cd.TerminalID)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
