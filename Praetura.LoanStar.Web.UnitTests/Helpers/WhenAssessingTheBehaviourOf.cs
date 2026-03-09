using NUnit.Framework;

namespace Praetura.LoanStar.Web.UnitTests.Helpers
{
	[TestFixture]
	public abstract class WhenAssessingTheBehaviourOf<T> 
	{
		protected WhenAssessingTheBehaviourOf() 
		{
			GivenThat();
			When();
		}

		public T? ItemUnderTest { get; set; } = default;

		public abstract void GivenThat();


		public abstract void When();
	}
}
