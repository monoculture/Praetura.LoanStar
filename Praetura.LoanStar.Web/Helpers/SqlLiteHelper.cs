
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Praetura.LoanStar.Web.Helpers
{
	internal static class SqlLiteHelper
	{
		internal static bool IsUniqueConstraintViolation(DbUpdateException ex, bool excludePrimaryKey = false)
		{
			return ex?.InnerException is SqliteException sqliteEx &&
			       sqliteEx.SqliteExtendedErrorCode switch
			       {
				       2067 => true, 
				       1555 when !excludePrimaryKey => true, // is primary-key violation
				       _ => false
			       };
		}
	}
}
