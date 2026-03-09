namespace Praetura.LoanStar.Web.Model
{
	public abstract record  IdempotentResult
	{
		public sealed record Success<T>(T Value, int StatusCode) : IdempotentResult;

		public sealed record Failure(string Message, int StatusCode) : IdempotentResult;

		public sealed record AlreadyProcessed(object Response, int StatusCode) : IdempotentResult;

		public sealed record Conflict(string Message = "Request is already being processed") : IdempotentResult;
	}
}
