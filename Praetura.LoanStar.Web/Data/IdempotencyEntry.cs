
namespace Praetura.LoanStar.Web.Data;

public class IdempotencyEntryData
{
    public Guid Id { get; set; }

    public string IdempotencyKey { get; set; }

    public string Status { get; set; }

    public string ResponseBody { get; set; }

    public int? ResponseStatusCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }
}
