using System.Globalization;

namespace Praetura.LoanStar.Web.Extensions
{
	public static class ConfigExtensions
	{

		private const string EnableSwaggerKey = "ENABLE_SWAGGER";
		private const string EnableHttpLogging = "ENABLE_HTTP_LOGGING";
		private const string DbConnectionStringKey = "DB_CONNECTION_STRING";
		private const string EnableLoanApplicationProcessor = "ENABLE_LOAN_APPLICATION_PROCESSOR";

		public static bool GetEnableLoanApplicationProcessor(this IConfiguration configuration)
		{
			return configuration.GetRequiredValue<bool>(EnableLoanApplicationProcessor);
		}

		public static bool GetSwaggerEnabled(this IConfiguration configuration)
		{
			return configuration.GetRequiredValue<bool>(EnableSwaggerKey);
		}

		public static string GetDbConnectionString(this IConfiguration configuration)
		{
			return configuration.GetRequiredValue<string>(DbConnectionStringKey);
		}

		public static bool GetEnableHttpLogging(this IConfiguration configuration)
		{
			return configuration.GetRequiredValue<bool>(EnableHttpLogging);
		}

		public static T GetRequiredValue<T>(this IConfiguration configuration, string key)
		{
			var value = configuration[key];

			if (string.IsNullOrWhiteSpace(value))
			{
				throw new InvalidOperationException(
					$"Required configuration setting '{key}' is missing or has no value.");
			}

			return (T)System.Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
		}
	}
}
