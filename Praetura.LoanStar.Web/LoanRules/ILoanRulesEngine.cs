using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.LoanRules
{
	public interface ILoanRulesEngine
	{
		LoanRuleSummary Evaluate(LoanApplicationData loanApplication);
	}
}
