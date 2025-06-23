# Task:
1. Add the `Scalar.AspNetCore` NuGet package to the project using Developer PowerShell.
2. Configure the Scalar API documentation in the HTTP request pipeline in `Program.cs`.

# Package to Install:
- `Scalar.AspNetCore`

# Requirements:
- In `Program.cs`, inside the block:
```csharp
if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi(); // for OpenAPI route

    _ = app.MapScalarApiReference("/", options =>
    {
        options.DefaultOpenAllTags = false;
        options.OpenApiRoutePattern = "/openapi/v1.json";
        options.HideClientButton = true;
    });
}
```