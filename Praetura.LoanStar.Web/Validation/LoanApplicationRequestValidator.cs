using FluentValidation;
using Praetura.LoanStar.Web.Contracts;

namespace Praetura.LoanStar.Web.Validation
{
	public class LoanApplicationRequestValidator : AbstractValidator<CreateLoanApplicationRequest>
	{
		public LoanApplicationRequestValidator()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty()
				.MaximumLength(255);

			RuleFor(x => x.Email)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.MaximumLength(255);

			RuleFor(x => x.MonthlyIncome)
				.GreaterThan(0);

			RuleFor(x => x.RequestedAmount)
				.GreaterThan(0);

			RuleFor(x => x.TermMonths)
				.GreaterThan(0);

		}
	}
}
