using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Praetura.LoanStar.Web.Data.Configurations;

public class IdempotencyEntryConfiguration : IEntityTypeConfiguration<IdempotencyEntryData>
{
    public void Configure(EntityTypeBuilder<IdempotencyEntryData> builder)
    {
        builder.HasKey(e => e.Id).HasName("PK_Idempotency");

        builder.ToTable("IdempotencyEntry");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.CompletedAt).HasColumnType("datetime");
        builder.Property(e => e.CreatedAt).HasColumnType("datetime");
        builder.Property(e => e.IdempotencyKey)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);
        builder.Property(e => e.ResponseBody).IsUnicode(false);
        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasDefaultValueSql("((0))")
            .HasAnnotation("Relational:DefaultConstraintName", "DF_Idempotency_State");
    }
}
