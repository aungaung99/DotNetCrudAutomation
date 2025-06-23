# DotNetCrudAutomation

A modern ASP.NET Core project for real-world CRUD automation using Entity Framework Core and best practices for API development.

## Features
- .NET 9, C# 13, ASP.NET Core Web API
- Entity Framework Core with SQL Server
- Scalar.AspNetCore for enhanced OpenAPI documentation
- Real-world CRUD API for Brand entity
- Localized, structured API responses
- Soft-delete support and audit fields

## Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server (local or remote)

### Database Setup
1. Update your connection string in `appsettings.json` or user secrets:
   - Key: `DefaultConnection`
2. Scaffold the database context and entities (already included):dotnet ef dbcontext scaffold "Server=.;Database=DotNetAutomation;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --namespace DotNetCrudAutomation.Entities --context-dir Data --context DotNetAutomationDbContext --context-namespace DotNetCrudAutomation.Data --data-annotations --no-onconfiguring -f
### Build & Run# Restore dependencies
 dotnet restore
# Build the project
 dotnet build
# Run the API
 dotnet run
### API Endpoints
#### Brand CRUD
- `GET    /api/brand`   - Get all active brands
- `POST   /api/brand`   - Create a new brand
- `PUT    /api/brand`   - Update an existing brand
- `DELETE /api/brand/{id}` - Soft-delete a brand

All endpoints return localized, structured responses using `DefaultResponseModel` and `DefaultResponseMessageModel`.

### OpenAPI & Scalar API Docs
- OpenAPI/Swagger: `/openapi`
- Scalar API Reference: `/` (development only)

### Project Structure
- `Controllers/` - API controllers (BrandController, etc.)
- `Entities/`    - EF Core entity models
- `Data/`        - DbContext and data access
- `Helper/`      - Response helpers
- `Model/`       - Response models

### Technologies Used
- ASP.NET Core 9
- Entity Framework Core 9 (SQL Server)
- Scalar.AspNetCore

## License
MIT