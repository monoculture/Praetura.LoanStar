using Microsoft.AspNetCore.Mvc;
using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Model;
using Praetura.LoanStar.Web.Services;

namespace Praetura.LoanStar.Web.Controllers
{
	[ApiController]
	[Route("loan-applications")]
	[Produces("application/json")]
	public class LoanApplicationController(
		ILoanApplicationService loanApplicationService) : Controller
	{
		[HttpGet("{Id:guid}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		[ProducesResponseType(500)]
		public async Task<ActionResult<FindLoanApplicationResponse>> FindLoanApplication([FromRoute] FindLoanApplicationRequest request)
		{
			var findLoanCriteria = new FindLoanApplicationCriteria(request.Id);

			var result = await loanApplicationService.FindLoanApplication(findLoanCriteria);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<ActionResult<CreateLoanApplicationResponse>> CreateLoanApplication(
			[FromBody] CreateLoanApplicationRequest request)
		{
			var result = await loanApplicationService.CreateLoanApplication(request);

			return CreatedAtAction(nameof(FindLoanApplication), new { id = result.Id }, result);
		}


		[HttpPost]
		[Route("idempotent")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreateLoanApplicationIdempotent(
			[FromBody] CreateLoanApplicationRequest request,
			[FromHeader(Name = "Idempotency-Key")] string idempotencyKey,
			CancellationToken ct)
		{
			var result = await loanApplicationService.CreateLoanApplicationIdempotent(request, idempotencyKey);

			return result switch
			{
				IdempotentResult.Success<CreateLoanApplicationResponse> success
					=> Created($"/loan-applications/{success.Value.Id}", success.Value),
				IdempotentResult.AlreadyProcessed already
					=> StatusCode(already.StatusCode, already.Response),
				IdempotentResult.Conflict conflict
					=> Conflict(conflict.Message),
				IdempotentResult.Failure failure =>
					StatusCode(failure.StatusCode, new { error = failure.Message}),
				_ => StatusCode(500, new { error = "Unknown result" })
			};
		}
	}
}
