# LoanStar

*At LoanStar we believe everyone deserves terrible financial decisions at record speed....*

## What is this?

LoanStar is a sample application designed to demonstrate how a candidate would approach 
implementing a simple loan‑processing system.

## How do I run it?

The project has no prerequisites other than having version 8 of the .NET SDK installed. 
The database is implemented in SQLite and is included in the project, so you should be able 
to clone the repository and open the solution file in Visual Studio, or alternatively build 
and run it from the command line.

## How could it be improved?

This approach works well for a small system, but if we needed to handle millions of records, 
I’d separate the scheduler into its own service. Instead of processing records directly, the 
scheduler would break the workload into batches and enqueue a work item for each batch.

The processor would then be implemented as an independent service, hosted in Docker, with autoscaling 
enabled so additional processors can be spun up as demand increases.

In a real-world scenario, evaluating each application would likely involve calling multiple third‑party 
systems which means the rate limiting step is most likely goign to be waiting for those systems 
to respond.

Combined with the fact that each task is independent, this makes the workload an ideal candidate 
for multithreading and / or horizontal scaling.

If a task fails, I would classify the error as either terminal or transitory. If the error is terminal, 
the task is marked as failed and moved to the dead‑letter queue. If the error appears to be transitory, 
the system would retry it using exponential backoff until the maximum retry count is reached.

We want to avoid a situation where batches gradually become filled with unprocessable tasks, never completing 
and wasting the available processor time.


