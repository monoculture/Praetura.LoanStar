using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.Helpers;
using Praetura.LoanStar.Web.Mapping;
using Praetura.LoanStar.Web.Model;

namespace Praetura.LoanStar.Web.Services
{
	public class LoanApplicationService(
		ILogger<LoanApplicationService> logger,
		LoanDbContext dbContext) : ILoanApplicationService
	{
		public async Task<FindLoanApplicationResponse?> FindLoanApplication(FindLoanApplicationCriteria criteria)
		{
			var applicationData = await dbContext.LoanApplications
				.Where(x => x.Id == criteria.LoanApplicationId)
				.Include(x => x.DecisionLogEntries)
				.AsNoTracking()
				.SingleOrDefaultAsync();

			var response = applicationData?.ToFindLoanResponse();

			return response;
		}
		public async Task<CreateLoanApplicationResponse> CreateLoanApplication(CreateLoanApplicationRequest request)
		{
			var applicationData = request.ToLoanApplicationData();

			dbContext.LoanApplications.Add(applicationData);

			await dbContext.SaveChangesAsync();

			var response = applicationData.ToCreateLoanApplicationResponse();

			return response;
		}

		public async Task<IdempotentResult> CreateLoanApplicationIdempotent(
			CreateLoanApplicationRequest request, string idempotencyKey)
		{
			if (string.IsNullOrWhiteSpace(idempotencyKey))
				return new IdempotentResult.Failure("Idempotency-Key is required", 400);

			await using var transaction = await dbContext.Database.BeginTransactionAsync();

			try
			{
				var idempotencyEntryData = await dbContext.IdempotencyEntries
					.AsNoTracking()
					.FirstOrDefaultAsync(e => e.IdempotencyKey== idempotencyKey);

				if (idempotencyEntryData is not null)
				{
					if (idempotencyEntryData is { Status: IdempotencyState.Succeeded })
					{
						var deserialized = JsonSerializer.Deserialize<CreateLoanApplicationResponse>(idempotencyEntryData.ResponseBody);

						return new IdempotentResult.AlreadyProcessed(deserialized!, idempotencyEntryData.ResponseStatusCode ?? 200);
					}

					if (idempotencyEntryData.Status is IdempotencyState.Started or IdempotencyState.InProgress)
					{
						return new IdempotentResult.Conflict();
					}

					return new IdempotentResult.Failure("Previous attempt failed – use a new key", 409);
				}

				idempotencyEntryData = new IdempotencyEntryData
				{
					Id = Guid.NewGuid(),
					CreatedAt = DateTime.UtcNow,
					IdempotencyKey = idempotencyKey,
					Status = IdempotencyState.InProgress
				};

				dbContext.IdempotencyEntries.Add(idempotencyEntryData);

				await dbContext.SaveChangesAsync();

				var applicationData = request.ToLoanApplicationData();

				dbContext.LoanApplications.Add(applicationData);

				await dbContext.SaveChangesAsync();

				var responseDto = applicationData.ToCreateLoanApplicationResponse();

				idempotencyEntryData.ResponseStatusCode = 201;
				idempotencyEntryData.CompletedAt = DateTime.UtcNow;
				idempotencyEntryData.Status = IdempotencyState.Succeeded;
				idempotencyEntryData.ResponseBody = JsonSerializer.Serialize(responseDto);

				await dbContext.SaveChangesAsync();

				await transaction.CommitAsync();

				var result = new IdempotentResult.Success<CreateLoanApplicationResponse>(responseDto, 201);

				return result;
			}
			catch (DbUpdateException ex) when (SqlLiteHelper.IsUniqueConstraintViolation(ex))
			{
				await transaction.RollbackAsync();

				logger.LogError(ex, ex.Message);

				return new IdempotentResult.Conflict("Another request is processing this key");
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();

				logger.LogError(ex, ex.Message);

				return new IdempotentResult.Failure("Internal error", 500);
			}
		}
	}
}
