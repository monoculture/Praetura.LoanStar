using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxAmountRuleTests
{
	public class WhenLoanAmountIsLessThanMax : WhenAssessingTheBehaviourOf<MaxAmountRule>
	{
		private LoanRuleResult _result = null!;
		private readonly LoanApplicationData _loanApplication = LoanDataHelper.CreateLoanData();

		public override void GivenThat()
		{
			_loanApplication.MonthlyIncome = 10;
			_loanApplication.RequestedAmount = 30;

			ItemUnderTest = new MaxAmountRule();
		}

		public override void When()
		{
			_result = ItemUnderTest!.Evaluate(_loanApplication);
		}

		[Test]
		public void ItShouldPassTheRule()
		{
			ClassicAssert.True(_result.Passed);
		}

		[Test]
		public void ItShouldReturnTheCorrectMessage()
		{
			ClassicAssert.AreEqual(string.Empty, _result.Message);
		}
	}
}
