using System.Text.Json.Serialization;
using Praetura.LoanStar.Web.Extensions;

namespace Praetura.LoanStar.Web.Configuration
{
	public static class SwaggerConfiguration
	{
		public static IServiceCollection RegisterSwagger(this IServiceCollection services, IConfiguration settings)
		{
			if (!settings.GetSwaggerEnabled())
			{
				return services;
			}

			services.AddEndpointsApiExplorer();

			services.ConfigureHttpJsonOptions(options => { options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

			services.AddSwaggerGen(_ => { });

			return services;
		}

		public static WebApplication ApplySwagger(this WebApplication app, IConfiguration settings)
		{
			if (settings.GetSwaggerEnabled())
			{
				app.UseSwagger();

				app.UseSwaggerUI(options =>
				{
					options.EnableTryItOutByDefault();
					options.EnablePersistAuthorization();
					options.DefaultModelsExpandDepth(-1);
				});
			}

			return app;
		}
	}
}
