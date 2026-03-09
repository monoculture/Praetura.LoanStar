using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MinMonthlyIncomeRuleTests
{
	internal class WhenMonthlyIncomeIsMoreThanMin : WhenMonthlyIncomeBase
	{
		public override void GivenThat()
		{
			base.GivenThat();

			LoanApplication.MonthlyIncome = 5000;
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
