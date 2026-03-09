using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxAmountRuleTests
{
	public class WhenGettingTheName : WhenAssessingTheBehaviourOf<MaxAmountRule>
	{
		public override void GivenThat()
		{
			ItemUnderTest = new MaxAmountRule();
		}

		public override void When()
		{

		}

		[Test]
		public void ItShouldReturnTheCorrectName()
		{
			ClassicAssert.AreEqual(nameof(MaxAmountRule), ItemUnderTest.Name);
		}
	}
}
