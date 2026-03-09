using Microsoft.AspNetCore.HttpLogging;
using Praetura.LoanStar.Web.Extensions;

namespace Praetura.LoanStar.Web.Configuration
{
	public static class LoggingConfiguration
	{
		public static IServiceCollection RegisterLogging(this IServiceCollection services, IConfiguration settings)
		{
			services.AddLogging(builder =>
			{
				builder.ClearProviders();

				builder.AddSimpleConsole(x =>
				{
					x.SingleLine = true;
					x.IncludeScopes = false;
				});
			});


			if (settings.GetEnableHttpLogging())
			{
				services.AddHttpLogging(o =>
				{
					o.CombineLogs = true;
					o.LoggingFields = HttpLoggingFields.RequestQuery
					                  | HttpLoggingFields.RequestMethod
					                  | HttpLoggingFields.RequestPath
					                  | HttpLoggingFields.RequestBody
					                  | HttpLoggingFields.ResponseStatusCode
					                  | HttpLoggingFields.ResponseBody
					                  | HttpLoggingFields.Duration;
				});
			}

			return services;
		}

		public static WebApplication ApplyLogging(this WebApplication app, IConfiguration settings)
		{
			if (settings.GetEnableHttpLogging())
			{
				app.UseHttpLogging();
			}

			return app;
		}
	}
}
