using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Praetura.LoanStar.Web.Data.Configurations;

public class DecisionLogEntryConfiguration : IEntityTypeConfiguration<DecisionLogEntryData>
{
    public void Configure(EntityTypeBuilder<DecisionLogEntryData> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_decision_entry");

        builder.ToTable("DecisionLogEntry");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.EvaluatedAt).HasColumnType("datetime");
        builder.Property(e => e.Message)
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.RuleName)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);

        builder.HasOne(d => d.LoanApplication).WithMany(p => p.DecisionLogEntries)
            .HasForeignKey(d => d.LoanApplicationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_DecisionLogEntry_LoanApplication");
    }
}
