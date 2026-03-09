using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.Model;

namespace Praetura.LoanStar.Web.Workers
{
	public class LoanApplicationProcessor(
		ILogger<LoanApplicationProcessor> logger,
		IServiceScopeFactory scopeFactory) : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			logger.LogInformation("Loan application processing started.");

			while (!stoppingToken.IsCancellationRequested)
			{
				try
				{
					await ProcessApplications(stoppingToken);
				}
				catch (Exception ex)
				{
					logger.LogError(ex, "Error processing applications");
				}

				var timer = new PeriodicTimer(TimeSpan.FromSeconds(60));

				while (await timer.WaitForNextTickAsync(stoppingToken))
				{
					await ProcessApplications(stoppingToken);
				}
			}
		}

		private async Task ProcessApplications(CancellationToken token)
		{
			using var scope = scopeFactory.CreateScope();

			var dbContext = scope.ServiceProvider.GetRequiredService<LoanDbContext>();

			var ruleEngine = scope.ServiceProvider.GetRequiredService<ILoanRulesEngine>();

			var applicationList = dbContext.LoanApplications
				.OrderBy(x => x.CreatedAt)
				.Where(x => x.Status == LoanApplicationState.Pending)
				.Take(100)
				.ToList();

			foreach (var application in applicationList)
			{
				await using var transaction = await dbContext.Database.BeginTransactionAsync(token);

				try
				{
					var summary = ruleEngine.Evaluate(application);

					application.ReviewedAt = DateTime.UtcNow;
					application.Status = summary.HasPassed ? LoanApplicationState.Approved : LoanApplicationState.Rejected;

					foreach (var summaryItem in summary)
					{
						var decisionData = new DecisionLogEntryData
						{
							Id = Guid.NewGuid(),
							Passed = summaryItem.Pass,
							Message = summaryItem.Message,
							EvaluatedAt = DateTime.UtcNow,
							RuleName = summaryItem.RuleName,
							LoanApplicationId = application.Id
						};

						dbContext.DecisionLogEntries.Add(decisionData);
					}

					await dbContext.SaveChangesAsync(token);

					await transaction.CommitAsync(token);
				}
				catch (Exception e)
				{
					await transaction.RollbackAsync(token);
				}
			}
		}
	}
}
