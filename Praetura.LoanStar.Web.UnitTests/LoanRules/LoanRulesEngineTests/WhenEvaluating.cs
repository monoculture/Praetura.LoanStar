using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.UnitTests.Helpers;

namespace Praetura.LoanStar.Web.UnitTests.LoanRules.LoanRulesEngineTests
{
	public class WhenEvaluating : WhenAssessingTheBehaviourOf<LoanRulesEngine>
	{
		private LoanRuleSummary _result = [];

		private readonly Mock<ILoanRule> _rule1 = new();
		private readonly Mock<ILoanRule> _rule2 = new();
		private readonly Mock<ILoanRule> _rule3 = new();

		private readonly LoanApplicationData _applicationData = LoanDataHelper.CreateLoanData();

		public override void GivenThat()
		{
			_rule1.Setup(r => r.Evaluate(It.IsAny<LoanApplicationData>())).Returns(new LoanRuleResult(true, string.Empty));
			_rule2.Setup(r => r.Evaluate(It.IsAny<LoanApplicationData>())).Returns(new LoanRuleResult(true, string.Empty));
			_rule3.Setup(r => r.Evaluate(It.IsAny<LoanApplicationData>())).Returns(new LoanRuleResult(true, string.Empty));

			var rules = new List<ILoanRule> { _rule1.Object, _rule2.Object, _rule3.Object };

			ItemUnderTest = new LoanRulesEngine(rules);
		}

		public override void When()
		{
			_result = ItemUnderTest.Evaluate(_applicationData);
		}

		[Test]
		public void ItEvaluatesRule1()
		{
			_rule1.Verify(r => r.Evaluate(_applicationData), Times.Once());
		}

		[Test]
		public void ItEvaluatesRule2()
		{
			_rule2.Verify(r => r.Evaluate(_applicationData), Times.Once());
		}

		[Test]
		public void ItEvaluatesRule3()
		{
			_rule3.Verify(r => r.Evaluate(_applicationData), Times.Once());
		}

		[Test]
		public void ItReturnsTheSummary()
		{
			ClassicAssert.NotNull(_result);
		}
	}
}
