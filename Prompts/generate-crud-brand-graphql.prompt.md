# Task:
Generate a full real-world CRUD GraphQL API for the entity `Brand` in ASP.NET Core using HotChocolate.

# Requirements:
- Entity: `Brand`
- Use `DotNetAutomationDbContext` for EF Core operations
- Use dependency injection for `DotNetAutomationDbContext`
- Use HotChocolate GraphQL best practices
- Organize code in `GraphQL/Brands/` folder with files:
  - `BrandQuery.cs`
  - `BrandMutation.cs`
  - `BrandType.cs`
  - `BrandInput.cs`

# GraphQL Queries:
1. **brands**
   - Get all active brands (where `DeletedOn` is null).
   - EF Query: `AsNoTracking().Where(x => !x.DeletedOn.HasValue)`
   - Response: List of `Brand` wrapped with `ResponseHelper.OK_Result` and localized message.

2. **brand(id: Int!)**
   - Get a brand by `BrandId`.
   - Response: Single `Brand` or error, wrapped with `ResponseHelper` and localized message.

# GraphQL Mutations:
1. **addBrand(input: BrandInput!)**
   - Create a new brand.
   - Set: 
     - `CreatedOn = DateTime.UtcNow`
     - `CreatedBy = User.Identity.Name`
   - Return: Created brand wrapped in a response model with localized message.

2. **updateBrand(id: Int!, input: BrandInput!)**
   - Update an existing brand.
   - Keep: Original `CreatedOn`, `CreatedBy`
   - Update: `Name`, set `UpdatedOn` and `UpdatedBy`
   - Return: Updated brand with localized message.

3. **deleteBrand(id: Int!)**
   - Soft delete a brand by setting:
     - `DeletedOn = DateTime.UtcNow`
     - `DeletedBy = User.Identity.Name`
   - Return: Deleted brand with localized message.

# Input Types:
- `BrandInput`
  - Fields:
    - `Name` (string, required)

# Response Model:
- Use `DefaultResponseMessageModel` for message localization with:
  - `EN` (string): English message
  - `MM` (string): Myanmar message
- All queries and mutations return results wrapped with:
  ```csharp
  ResponseHelper.OK_Result(data, new DefaultResponseMessageModel { EN = "Message", MM = "Myanmar Message" })
  ```
- For errors, use `ResponseHelper.Bad_Request` with appropriate messages.
