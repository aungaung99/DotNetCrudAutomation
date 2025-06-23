# CRUD API Controller Generation Prompt

This prompt guides you to generate a real-world CRUD API controller for the `Brand` entity in ASP.NET Core, following best practices for dependency injection, response formatting, and endpoint documentation.

## Step-by-Step Instructions

### 1. Controller Setup
- **Controller Name:** `BrandController`
- **Route:** `[Route("api/[controller]")]`
- **Attributes:** `[ApiController]`
- **Dependency Injection:** Use primary constructor for injecting `DotNetAutomationDbContext`:
  ```csharp
  public BrandController(DotNetAutomationDbContext context) : ControllerBase
  ```

### 2. Endpoints

#### GET /api/brand
- **Purpose:** Get all active (non-deleted) brands
- **Filter:** `!x.DeletedOn.HasValue`
- **EF Core:** Use `AsNoTracking()`
- **Response:**
  - 200 OK: List of brands
  - 404 NotFound: If none found
- **Attributes:**
  - `[EndpointSummary("Get all Brands")]`
  - `[EndpointDescription("Retrieve all non-deleted Brand records.")]`

#### POST /api/brand
- **Purpose:** Create a new brand
- **Input:** Brand
- **Audit Fields:**
  - `CreatedOn = DateTime.UtcNow`
  - `CreatedBy = User.Identity.Name`
- **Response:**
  - 200 OK: "Brand have been added!" / "Brand ထပ်ထည့်ပြီးပါပြီ။"
  - 400 Bad Request: "Brand cannot added!" / "Brand ထည့်မရပါ။"
- **Attributes:**
  - `[EndpointSummary("Create new Brand")]`
  - `[EndpointDescription("Create and store a new Brand with CreatedBy and CreatedOn.")]`

#### PUT /api/brand
- **Purpose:** Update existing brand
- **Find:** By `BrandId`
- **Keep:** Original `CreatedBy`, `CreatedOn`
- **Update:** Other fields, set `UpdatedOn` and `UpdatedBy`
- **Response:**
  - 200 OK: "Brand have been updated!" / "Brand ပြင်ပြီးပါပြီ။"
  - 400 Bad Request: "Brand cannot updated!" / "Brand ပြင်မရပါ။"
  - 404 Not Found: "Brand not found!" / "Brand မရှိပါ။"
- **Attributes:**
  - `[EndpointSummary("Update Brand")]`
  - `[EndpointDescription("Update an existing Brand and set audit fields.")]`

#### DELETE /api/brand/{id}
- **Purpose:** Soft-delete the brand by `id`
- **Set:**
  - `DeletedOn = DateTime.UtcNow`
  - `DeletedBy = User.Identity.Name`
- **Response:**
  - 200 OK: "Brand have been deleted!" / "Brand ဖျက်ပြီးပါပြီ။"
  - 400 Bad Request: "Brand cannot deleted!" / "Brand ဖျက်မရပါ။"
  - 404 Not Found: "Brand not found!" / "Brand မတွေ့ပါ။"
- **Attributes:**
  - `[EndpointSummary("Delete Brand")]`
  - `[EndpointDescription("Soft delete a Brand by setting DeletedBy and DeletedOn.")]`

### 3. Common Requirements
- Add `[Produces("application/json")]` to all methods
- Add appropriate `[ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.X)]`
- Return `ResponseHelper.OK_Result`, `Bad_Request`, or `NotFound_Request` with localized `DefaultResponseMessageModel`

### 4. Localized Response Format Example
```csharp
new DefaultResponseMessageModel
{
    EN = "Brand have been added!",
    MM = "Brand ထပ်ထည့်ပြီးပါပြီ။"
}
```

---

This prompt ensures a robust, well-documented, and localized CRUD API controller for the Brand entity.
