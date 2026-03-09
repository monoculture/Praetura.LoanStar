namespace Praetura.LoanStar.Web.LoanRules
{
	public class LoanRuleSummaryItem(string ruleName, bool pass, string message)
	{
		public bool Pass { get; } = pass;

		public string RuleName { get; } = ruleName;

		public string Message { get; } = message;
	}
}
