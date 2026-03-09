namespace Praetura.LoanStar.Web.Contracts
{
	public class DecisionLogEntryDto
	{
		public Guid Id { get; set; }

		public string Rule { get; set; }

		public bool Passed { get; set; }

		public string Message { get; set; }

		public DateTime EvaluatedAt { get; set; }
	}
}
