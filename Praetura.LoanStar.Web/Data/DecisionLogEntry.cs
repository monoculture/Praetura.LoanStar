namespace Praetura.LoanStar.Web.Data;

public class DecisionLogEntryData
{
    public Guid Id { get; set; }

    public Guid LoanApplicationId { get; set; }

    public string RuleName { get; set; }

    public bool Passed { get; set; }

    public string Message { get; set; }

    public DateTime EvaluatedAt { get; set; }

    public virtual LoanApplicationData LoanApplication { get; set; }
}
