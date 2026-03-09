namespace Praetura.LoanStar.Web.Model
{
	public class FindLoanApplicationCriteria(Guid loanApplicationId)
	{
		public Guid LoanApplicationId { get;  } = loanApplicationId;
	}
}
