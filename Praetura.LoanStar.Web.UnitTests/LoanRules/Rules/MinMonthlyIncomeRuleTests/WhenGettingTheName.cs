using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MinMonthlyIncomeRuleTests
{
	public class WhenGettingTheName : WhenAssessingTheBehaviourOf<MinMonthlyIncomeRule>
	{
		public override void GivenThat()
		{
			ItemUnderTest = new MinMonthlyIncomeRule();
		}

		public override void When()
		{

		}

		[Test]
		public void ItShouldReturnTheCorrectName()
		{
			ClassicAssert.AreEqual(nameof(MinMonthlyIncomeRule), ItemUnderTest.Name);
		}
	}
}
