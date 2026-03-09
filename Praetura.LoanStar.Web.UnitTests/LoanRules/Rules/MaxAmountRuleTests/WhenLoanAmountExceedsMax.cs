using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxAmountRuleTests
{
	public class WhenLoanAmountExceedsMax : WhenAssessingTheBehaviourOf<MaxAmountRule>
	{
		private LoanRuleResult _result = null!;
		private readonly LoanApplicationData _loanApplication = LoanDataHelper.CreateLoanData();

		public override void GivenThat()
		{
			_loanApplication.MonthlyIncome = 10;

			_loanApplication.RequestedAmount = 100;

			ItemUnderTest = new MaxAmountRule();
		}

		public override void When()
		{
			_result = ItemUnderTest!.Evaluate(_loanApplication);
		}

		[Test]
		public void ItShouldFailTheRule()
		{
			ClassicAssert.False(_result.Passed);
		}

		[Test]
		public void ItShouldReturnTheCorrectMessage()
		{
			ClassicAssert.AreEqual("Requested amount must be no more than monthly income multiplied by 4", _result.Message);
		}
	}
}
