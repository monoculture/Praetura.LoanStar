using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules.Rules
{
	public class MinMonthlyIncomeRule : ILoanRule
	{
		private const decimal MinimumIncome = 2000;
		private const string FailureMessage = "Monthly income must be at least: {0}";

		public string Name => nameof(MinMonthlyIncomeRule);

		public LoanRuleResult Evaluate(LoanApplicationData loanApplication)
		{
			return loanApplication.MonthlyIncome >= MinimumIncome ? 
				LoanRuleResult.Pass() : 
				LoanRuleResult.Fail(string.Format(FailureMessage, MinimumIncome));
		}
	}
}
