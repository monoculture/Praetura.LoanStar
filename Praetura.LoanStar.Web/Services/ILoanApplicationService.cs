using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Model;

namespace Praetura.LoanStar.Web.Services
{
	public interface ILoanApplicationService
	{
		Task<FindLoanApplicationResponse?> FindLoanApplication(FindLoanApplicationCriteria criteria);

		Task<CreateLoanApplicationResponse> CreateLoanApplication(CreateLoanApplicationRequest request);

		Task<IdempotentResult> CreateLoanApplicationIdempotent(CreateLoanApplicationRequest request, string idempotencyKey);
	}
}
