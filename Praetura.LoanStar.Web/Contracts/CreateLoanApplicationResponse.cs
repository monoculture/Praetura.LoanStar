namespace Praetura.LoanStar.Web.Contracts
{
	public class CreateLoanApplicationResponse
	{
		public Guid Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Status { get; set; } = string.Empty;
	}
}
