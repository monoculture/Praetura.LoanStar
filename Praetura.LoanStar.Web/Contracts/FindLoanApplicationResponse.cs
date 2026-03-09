namespace Praetura.LoanStar.Web.Contracts
{
	public class FindLoanApplicationResponse
	{
		public Guid Id { get; set; }

		public DateTime CreatedAt { get; set; }

		public string Status { get; set; } = string.Empty;


		public List<DecisionLogEntryDto> DecisionLogEntries { get; set; } = [];
	}
}
