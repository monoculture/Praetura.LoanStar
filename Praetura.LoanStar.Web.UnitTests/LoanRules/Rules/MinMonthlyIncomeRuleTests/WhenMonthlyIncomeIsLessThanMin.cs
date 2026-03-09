using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.Rules.MinMonthlyIncomeRuleTests
{
	public class WhenMonthlyIncomeIsLessThanMin : WhenMonthlyIncomeBase
	{
		public override void GivenThat()
		{
			base.GivenThat();

			LoanApplication.MonthlyIncome = 500;
		}


		[Test]
		public void ItShouldFailTheRule()
		{
			ClassicAssert.IsFalse(Result.Passed);
		}

		[Test]
		public void ItShouldReturnTheCorrectMessage()
		{
			ClassicAssert.AreEqual("Monthly income must be at least: 2000", Result.Message);
		}
	}
}
