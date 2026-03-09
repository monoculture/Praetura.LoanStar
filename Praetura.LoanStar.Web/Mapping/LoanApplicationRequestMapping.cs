using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.Model;

namespace Praetura.LoanStar.Web.Mapping
{
	public static class LoanApplicationRequestMapping
	{
		public static LoanApplicationData ToLoanApplicationData(this CreateLoanApplicationRequest request)
		{
			var applicationData = new LoanApplicationData
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Email = request.Email,
				CreatedAt = DateTime.UtcNow,
				TermMonths = request.TermMonths,
				MonthlyIncome = request.MonthlyIncome,
				Status = LoanApplicationState.Pending,
				RequestedAmount = request.RequestedAmount
			};

			return applicationData;
		}
	}
}
