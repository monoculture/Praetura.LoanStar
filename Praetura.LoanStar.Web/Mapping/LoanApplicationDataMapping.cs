using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.Mapping
{
	public static class LoanApplicationDataMapping
	{
		public static FindLoanApplicationResponse ToFindLoanResponse(this LoanApplicationData applicationData)
		{
			var response = new FindLoanApplicationResponse
			{
				Id = applicationData.Id,
				Status = applicationData.Status,
				CreatedAt = applicationData.CreatedAt,
				DecisionLogEntries = applicationData.DecisionLogEntries.ToDecisionLogEntryDto()
			};

			return response;
		}

		public static CreateLoanApplicationResponse ToCreateLoanApplicationResponse(this LoanApplicationData applicationData)
		{
			var response = new CreateLoanApplicationResponse
			{
				Id = applicationData.Id,
				CreatedAt = DateTime.UtcNow,
				Status = applicationData.Status,
			};

			return response;
		}

		
	}
}
