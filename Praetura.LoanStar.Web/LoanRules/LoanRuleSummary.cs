namespace Praetura.LoanStar.Web.LoanRules
{
	public class LoanRuleSummary : List<LoanRuleSummaryItem>
	{
		public bool HasPassed => !FailedRules.Any();

		public List<LoanRuleSummaryItem> FailedRules
		{
			get { return this.Where(x => !x.Pass).ToList(); }
		}
	}
}
