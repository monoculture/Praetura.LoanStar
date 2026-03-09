namespace Praetura.LoanStar.Web.Contracts
{
	public class CreateLoanApplicationRequest
	{
		public string Name { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public decimal MonthlyIncome { get; set; }

		public decimal RequestedAmount { get; set; }

		public int TermMonths { get; set; }
	}
}
