using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules.Rules
{
	public class MinMaxTermLengthRule : ILoanRule
	{
		private const int MinimumTerm = 12;
		private const int MaximumTerm = 60;

		private const string FailureMessage = "Term must be between {0} and {1} months.";

		public string Name => nameof(MinMaxTermLengthRule);

		public LoanRuleResult Evaluate(LoanApplicationData loanApplication)
		{
			return loanApplication.TermMonths is >= MinimumTerm and <= MaximumTerm ? 
				LoanRuleResult.Pass() : 
				LoanRuleResult.Fail(string.Format(FailureMessage, MinimumTerm, MaximumTerm));
		}
	}
}
