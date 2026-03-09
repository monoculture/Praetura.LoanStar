using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxTermLengthRuleTests
{
	public class WhenLoanTermIsGreaterThanMaxAllowedTermLength : WhenLoanTermBase
	{
		public override void GivenThat()
		{
			base.GivenThat();

			LoanApplication.TermMonths = 80;
		}

		[Test]
		public void ItShouldFailTheRule()
		{
			ClassicAssert.IsFalse(Result.Passed);
		}

		[Test]
		public void ItShouldReturnTheCorrectMessage()
		{
			ClassicAssert.AreEqual("Term must be between 12 and 60 months.", Result.Message);
		}
	}
}
