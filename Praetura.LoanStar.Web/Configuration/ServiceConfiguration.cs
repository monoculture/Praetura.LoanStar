using System.Reflection;
using Praetura.LoanStar.Web.LoanRules;
using Praetura.LoanStar.Web.Services;

namespace Praetura.LoanStar.Web.Configuration
{
	public static class ServiceConfiguration
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration settings)
		{
			services.AddScoped<ILoanRulesEngine, LoanRulesEngine>();
			services.AddScoped<ILoanApplicationService, LoanApplicationService>();

			RegisterRules(services, settings);

			return services;
		}

		private static void RegisterRules(IServiceCollection services, IConfiguration settings)
		{
			var types = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t => typeof(ILoanRule).IsAssignableFrom(t) &&
				            t.IsClass &&
				            !t.IsAbstract);

			foreach (var type in types)
			{
				services.AddScoped(typeof(ILoanRule), type);
			}
		}
	}
}
