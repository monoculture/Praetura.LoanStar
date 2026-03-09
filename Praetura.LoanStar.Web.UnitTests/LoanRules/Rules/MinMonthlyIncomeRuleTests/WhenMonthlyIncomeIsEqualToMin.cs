using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MinMonthlyIncomeRuleTests
{
	public class WhenMonthlyIncomeIsEqualToMin : WhenMonthlyIncomeBase
	{
		public override void GivenThat()
		{
			base.GivenThat();

			LoanApplication.MonthlyIncome = 2000;
		}

		[Test]
		public void ItShouldPassTheRule()
		{
			ClassicAssert.IsTrue(Result.Passed);
		}

		[Test]
		public void ItShouldReturnTheCorrectMessage()
		{
			ClassicAssert.AreEqual(string.Empty, Result.Message);
		}
	}
}
