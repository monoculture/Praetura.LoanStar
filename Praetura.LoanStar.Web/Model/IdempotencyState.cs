namespace Praetura.LoanStar.Web.Model
{
	internal static class IdempotencyState
	{

		public const string Started = "Started";
		public const string Succeeded = "Succeeded";
		public const string InProgress = "InProgress";
	}
}
