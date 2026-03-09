using Microsoft.EntityFrameworkCore;

namespace Praetura.LoanStar.Web.Data;

public class LoanDbContext(DbContextOptions<LoanDbContext> options) : DbContext(options)
{
	public virtual DbSet<DecisionLogEntryData> DecisionLogEntries { get; set; }

    public virtual DbSet<IdempotencyEntryData> IdempotencyEntries { get; set; }

    public virtual DbSet<LoanApplicationData> LoanApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.DecisionLogEntryConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.IdempotencyEntryConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.LoanApplicationConfiguration());
    }
}
