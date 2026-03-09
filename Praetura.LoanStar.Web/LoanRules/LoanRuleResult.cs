namespace Praetura.LoanStar.Web.LoanRules
{
	public class LoanRuleResult(bool passed, string message)
	{
		public bool Passed { get; init; } = passed;

		public string Message { get; init; } = message;

		public static LoanRuleResult Pass()
		{
			return new LoanRuleResult(true, string.Empty);
		}

		public static LoanRuleResult Fail(string message)
		{
			return new LoanRuleResult(false, message);
		}
	}
}
