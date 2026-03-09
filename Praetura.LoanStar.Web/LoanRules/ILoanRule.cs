using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules
{
	public interface ILoanRule
	{
		string Name { get; }

		LoanRuleResult Evaluate(LoanApplicationData loanApplication);
	}
}
