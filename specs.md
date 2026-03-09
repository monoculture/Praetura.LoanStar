# .NET Developer Technical Task

**Tech Stack**: .NET (8+), ASP.NET Core, EF Core  
**Database**: EF In-Memory or SQLite  

**Estimated time**: 3–4 hours for the core requirements and one optional feature. You're welcome to spend more time if you want to, but don't feel you need to. We'd rather see a well-structured solution than a comprehensive one. Regardless of how much you implement, please complete the README section at the bottom.

---

## Scenario

You are building part of a loan origination service. This system accepts loan applications via a REST API and processes them in the background based on eligibility rules. Structure it as you would a production service.

---

## Core Requirements

### API Endpoints

#### `POST /loan-applications`
Accepts:
```json
{
  "name": "Alice Example",
  "email": "alice@example.com",
  "monthlyIncome": 3500,
  "requestedAmount": 8000,
  "termMonths": 36
}
```

Returns:
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "status": "Pending",
  "createdAt": "2025-05-27T10:30:00Z"
}
```

The API should validate input on submission. Reject requests with missing or obviously invalid data (e.g. null fields, negative amounts, malformed email). This is separate from the eligibility assessment, which happens in the background.

#### `GET /loan-applications/{id}`
Returns the full application record, including decision log entries if you implement the data model extension below.

### Expected HTTP Status Codes
- `201 Created` – POST success  
- `200 OK` – GET success  
- `400 Bad Request` – Validation errors  
- `404 Not Found` – Invalid or missing application ID  

---

### Eligibility Rules
Loan applications are assessed in the background with the following rules:
- Monthly income must be at least £2,000  
- Requested amount must be no more than monthly income multiplied by 4  
- Term must be between 12 and 60 months  

---

### Background Processing
Implement a background job using `BackgroundService` or `IHostedService`:
- Runs periodically (e.g. every 60 seconds)  
- Processes unreviewed loan applications  
- Applies eligibility rules and updates status to `"Approved"` or `"Rejected"`  
- Adds a `ReviewedAt` timestamp  

**Notes:**
- Use cancellation tokens appropriately  
- Handle exceptions gracefully. The service should not crash  
- Consider what happens if processing fails part-way through  

---

### Data Model

```csharp
LoanApplication
{
  Id (GUID),
  Name,
  Email,
  MonthlyIncome (decimal),
  RequestedAmount (decimal),
  TermMonths (int),
  Status (string),
  CreatedAt (DateTime),
  ReviewedAt (DateTime?)
}

DecisionLogEntry
{
  Id (GUID),
  LoanApplicationId (GUID),
  RuleName (string),
  Passed (bool),
  Message (string),
  EvaluatedAt (DateTime)
}
```

Each eligibility rule check should produce a `DecisionLogEntry` linked to the application.

---

### Unit Testing
Include at least one unit test for the eligibility logic. More is fine, but one good test is enough.

---

## Optional Features
Choose **one** of the following, whichever is closest to your experience.

### Idempotency
- Support a client-supplied `Idempotency-Key` header for POST requests  
- Prevent duplicate submissions from being stored or processed  

### Logging and Observability
- Use `ILogger` to log:  
  - Incoming requests  
  - Validation errors  
  - Background job activity  
  - Decision outcomes  
- Support and log `X-Correlation-ID` if provided  

### Outbox Pattern (Simulated)
- On loan approval or rejection, write a message to an `Outbox` table  
- Simulate publishing via console or log output  
- Mark message as "published" once handled  

---

## Architecture Notes
Please include a short section in your README addressing:
- What would you change if this system had to handle **5,000,000 applications per day?**
- What shortcuts or trade-offs did you make, and what would you do differently with more time?

---

## How to Submit
- GitHub repository (preferred), or a `.zip` file with the full source code  
- Include a `README.md` with instructions on how to run the project  
- Clearly label endpoints  
