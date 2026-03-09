using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MinMonthlyIncomeRuleTests
{
	public abstract class WhenMonthlyIncomeBase : WhenAssessingTheBehaviourOf<MinMonthlyIncomeRule>
	{
		protected LoanRuleResult Result = null!;

		protected readonly LoanApplicationData LoanApplication = LoanDataHelper.CreateLoanData();

		public override void GivenThat()
		{
			ItemUnderTest = new MinMonthlyIncomeRule();
		}

		public override void When()
		{
			Result = ItemUnderTest.Evaluate(LoanApplication);
		}
	}
}
