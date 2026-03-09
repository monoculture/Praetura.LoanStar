using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Praetura.LoanStar.Web.Data.Configurations;

public class LoanApplicationConfiguration : IEntityTypeConfiguration<LoanApplicationData>
{
    public void Configure(EntityTypeBuilder<LoanApplicationData> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_loan_application");

        builder.ToTable("LoanApplication");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CreatedAt).HasColumnType("datetime");
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.MonthlyIncome).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
        builder.Property(e => e.RequestedAmount).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.ReviewedAt).HasColumnType("datetime");
        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
