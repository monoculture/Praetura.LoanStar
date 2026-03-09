using System.Reflection;
using FluentValidation;
using Praetura.LoanStar.Web.Configuration;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Praetura.LoanStar.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var settings = builder.Configuration;

			builder.Services.AddControllers();

			builder.Services
				.RegisterDb(settings)
				.RegisterSwagger(settings)
				.RegisterLogging(settings)
				.RegisterServices(settings)
				.RegisterWorkers(settings)
				.AddFluentValidationAutoValidation()
				.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			var app = builder.Build()
				.ApplySwagger(settings)
				.ApplyLogging(settings);

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}


