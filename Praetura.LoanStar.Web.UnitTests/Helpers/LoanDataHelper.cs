using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.UnitTests.Helpers
{
	public static class LoanDataHelper
	{
		public static LoanApplicationData CreateLoanData()
		{
			var data = new LoanApplicationData
			{
				Id = Guid.NewGuid(),
				Status = "Pending",
				MonthlyIncome = 100,
				CreatedAt = DateTime.UtcNow,
				Email = "user@domain.tld",
				Name = "Boaty McBoat Face",
				RequestedAmount = 10000,
				TermMonths = 666
			};

			return data;
		}
	}
}
