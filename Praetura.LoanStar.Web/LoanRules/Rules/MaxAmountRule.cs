using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules.Rules
{
	public class MaxAmountRule : ILoanRule
	{
		private const int MaxIncomeMultiple = 4;
		private const string FailureMessage = "Requested amount must be no more than monthly income multiplied by {0}";

		public string Name => nameof(MaxAmountRule);

		public LoanRuleResult Evaluate(LoanApplicationData loanApplication)
		{
			var maximumLoanAmount = loanApplication.MonthlyIncome * MaxIncomeMultiple;

			return loanApplication.RequestedAmount <= maximumLoanAmount ? 
				LoanRuleResult.Pass() : 
				LoanRuleResult.Fail(string.Format(FailureMessage, MaxIncomeMultiple));
		}
	}
}
