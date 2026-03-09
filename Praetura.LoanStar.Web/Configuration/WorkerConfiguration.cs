using Praetura.LoanStar.Web.Extensions;
using Praetura.LoanStar.Web.Workers;

namespace Praetura.LoanStar.Web.Configuration
{
	public static class WorkerConfiguration
	{
		public static IServiceCollection RegisterWorkers(this IServiceCollection services, IConfiguration settings)
		{
			if (settings.GetEnableLoanApplicationProcessor())
			{
				services.AddHostedService<LoanApplicationProcessor>();
			}

			return services;
		}
	}
}
