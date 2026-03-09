using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules
{
	public class LoanRulesEngine(IEnumerable<ILoanRule> ruleList) : ILoanRulesEngine
	{
		public LoanRuleSummary Evaluate(LoanApplicationData loanApplication)
		{
			if (loanApplication == null)
			{
				throw new ArgumentNullException(nameof(loanApplication));
			}

			var summary = new LoanRuleSummary();

			foreach (var rule in ruleList)
			{
				var result = rule.Evaluate(loanApplication);

				var summaryItem = new LoanRuleSummaryItem(
					rule.Name,
					result.Passed,
					result.Message);

				summary.Add(summaryItem);
			}

			return summary;
		}
	}
}
