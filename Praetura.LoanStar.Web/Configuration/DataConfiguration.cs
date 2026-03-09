using Microsoft.EntityFrameworkCore;
using Praetura.LoanStar.Web.Data;
using Praetura.LoanStar.Web.Extensions;

namespace Praetura.LoanStar.Web.Configuration
{
	public static class DataConfiguration
	{
		public static IServiceCollection RegisterDb(this IServiceCollection services, IConfiguration settings)
		{
			services.AddDbContext<LoanDbContext, LoanDbContext>((provider, options) =>
			{
				options.EnableDetailedErrors();
				options.EnableSensitiveDataLogging();
				options.UseSqlite(settings.GetDbConnectionString());
			});

			return services;
		}
	}
}
