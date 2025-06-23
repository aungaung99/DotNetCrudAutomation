# Task:
1. Add the `Scalar.AspNetCore` NuGet package to the project using Developer PowerShell.
2. Configure the Scalar API documentation in the HTTP request pipeline in `Program.cs`.

# Package to Install:
- `Scalar.AspNetCore`

# Task:
Ensure that the `global using Scalar.AspNetCore` statement exists in the project.

# Requirements:
1. Check if the file `Global.cs` exists in the project root or main project folder.
2. If it exists:
   - Add the line `global using Scalar.AspNetCore` if it's not already included.
3. If it does **not** exist:
   - Create a new file named `Global.cs` in the main project folder.
   - Add the following content:

```csharp
global using Scalar.AspNetCore;
```

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
