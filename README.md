# .NET Global Exception Handling Demo

## Overview

This project demonstrates centralized exception handling in an ASP.NET Core Minimal API using custom middleware.

In production systems, exceptions can occur due to database failures, network issues, external service outages, or unexpected application behavior.

Instead of handling errors separately in every endpoint, a centralized middleware approach provides consistent responses and improves maintainability.

---

## Problem

Without centralized exception handling:

- Error handling logic gets duplicated
- APIs return inconsistent responses
- Maintenance becomes difficult as applications grow

---

## Solution

A global exception middleware intercepts unhandled exceptions and returns a standardized error response.

This approach:

- Centralizes error handling
- Improves API consistency
- Reduces duplicated code
- Simplifies maintenance

---

## Implementation

The middleware wraps incoming requests inside a try-catch block.

Core logic:

```csharp
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;

        await context.Response.WriteAsJsonAsync(new
        {
            message = "Something went wrong.",
            error = ex.Message
        });
    }
});
```

---

## How to Run

1. Clone the repository
2. Navigate to the project folder
3. Run the application

Command:

dotnet run

The API starts locally and exposes the test endpoint.

---

## How to Test

Open the following endpoint in a browser or API client:

/error

The endpoint intentionally throws an exception.

Expected response:

- Status Code: 500
- Standardized JSON error response

Example:

{
  "message": "Something went wrong.",
  "error": "Database connection failed"
}

---

## Tech Stack

- .NET 8
- ASP.NET Core Minimal API
- Custom Middleware

---

## Real-World Use Cases

This pattern is commonly used in:

- Enterprise APIs
- Microservices
- Internal backend systems
- Financial applications
- E-commerce platforms

---

## Key Takeaway

Production systems should fail gracefully.

Centralized exception handling helps create reliable APIs by ensuring that unexpected failures are handled consistently and predictably.
