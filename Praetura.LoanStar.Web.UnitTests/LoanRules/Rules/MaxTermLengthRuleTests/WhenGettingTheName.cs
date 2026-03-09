using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.LoanRules.Rules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxTermLengthRuleTests
{
	public class WhenGettingTheName : WhenAssessingTheBehaviourOf<MinMaxTermLengthRule>
	{
		public override void GivenThat()
		{
			ItemUnderTest = new MinMaxTermLengthRule();
		}

		public override void When()
		{

		}

		[Test]
		public void ItShouldReturnTheCorrectName()
		{
			ClassicAssert.AreEqual(nameof(MinMaxTermLengthRule), ItemUnderTest.Name);
		}
	}
}
