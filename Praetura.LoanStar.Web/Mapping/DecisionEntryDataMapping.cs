using Praetura.LoanStar.Web.Contracts;
using Praetura.LoanStar.Web.Data;

namespace Praetura.LoanStar.Web.Mapping
{
	public static class DecisionEntryDataMapping
	{
		public static DecisionLogEntryDto ToDecisionLogEntryDto(this DecisionLogEntryData data)
		{
			var logEntryDto = new DecisionLogEntryDto
			{
				Id = data.Id,
				Message = data.Message,
				Passed = data.Passed,
				Rule = data.RuleName,
				EvaluatedAt = data.EvaluatedAt
			};

			return logEntryDto;
		}

		public static List<DecisionLogEntryDto> ToDecisionLogEntryDto(this IEnumerable<DecisionLogEntryData> data)
		{
			return data.Select(x => x.ToDecisionLogEntryDto()).ToList();
		}
	}
}
