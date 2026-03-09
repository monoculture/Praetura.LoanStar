using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MaxTermLengthRuleTests
{
	public class WhenLoanTermIsEqualToMaxAllowedTermLength : WhenLoanTermBase
	{
		public override void GivenThat()
		{
			base.GivenThat();

			LoanApplication.TermMonths = 60;
		}

		[Test]
		public void ItShouldPassTheRule()
		{
			ClassicAssert.IsTrue(Result.Passed);
		}

		[Test]
		public void ItShouldReturnNoMessage()
		{
			ClassicAssert.AreEqual(string.Empty, Result.Message);
		}
	}
}
