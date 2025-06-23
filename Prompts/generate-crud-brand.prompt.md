# Task:
Generate a full real-world CRUD API controller in ASP.NET Core for the entity `Brand`.

# Requirements:
- Controller Name: `BrandController`
- Route: `[Route("api/[controller]")]`
- Use `[ApiController]`
- Use **primary constructor for dependency injection**:
```csharp
   public BrandController(DotNetAutomation context) : ControllerBase
```
- Use `DotNetAutomation` for EF Core operations
- Entity: `Brand`
### 🔹 GET /api/brand

- Purpose: Get all active (non-deleted) brands
- Filter: `!x.DeletedOn.HasValue`
- Use `AsNoTracking()`
- Response: 
  - ✅ 200 OK → list of brands
  - ❌ 404 NotFound if none
- Use:
  - `[EndpointSummary("Get all Brands")]`
  - `[EndpointDescription("Retrieve all non-deleted Brand records.")]`

---

### 🔹 POST /api/brand

- Purpose: Create a new brand
- Input: Brand
- Fill:
  - `CreatedOn = DateTime.UtcNow`
  - `CreatedBy = User.Identity.Name`
- Save to `context.Brands`
- Response:
  - ✅ 200 OK: "Brand have been added!" / "Brand ထပ်ထည့်ပြီးပါပြီ။"
  - ❌ 400 Bad Request: "Brand cannot added!" / "Brand ထည့်မရပါ။"
- Use:
  - `[EndpointSummary("Create new Brand")]`
  - `[EndpointDescription("Create and store a new Brand with CreatedBy and CreatedOn.")]`

---

### 🔹 PUT /api/brand

- Purpose: Update existing brand
- Find existing by `BrandId`
- Keep:
  - Original `CreatedBy`, `CreatedOn`
- Update other fields
- Fill:
  - `UpdatedOn = DateTime.UtcNow`
  - `UpdatedBy = User.Identity.Name`
- Save using `context.Brands.Update(model)`
- Response:
  - ✅ 200 OK: "Brand have been updated!" / "Brand ပြင်ပြီးပါပြီ။"
  - ❌ 400 Bad Request: "Brand cannot updated!" / "Brand ပြင်မရပါ။"
  - ❌ 404 Not Found: "Brand not found!" / "Brand မရှိပါ။"
- Use:
  - `[EndpointSummary("Update Brand")]`
  - `[EndpointDescription("Update an existing Brand and set audit fields.")]`

---

### 🔹 DELETE /api/brand/{id}

- Purpose: Soft-delete the brand by `id`
- Set:
  - `DeletedOn = DateTime.UtcNow`
  - `DeletedBy = User.Identity.Name`
- Save using `context.Brands.Update(model)`
- Response:
  - ✅ 200 OK: "Brand have been deleted!" / "Brand ဖျက်ပြီးပါပြီ။"
  - ❌ 400 Bad Request: "Brand cannot deleted!" / "Brand ဖျက်မရပါ။"
  - ❌ 404 Not Found: "Brand not found!" / "Brand မတွေ့ပါ။"
- Use:
  - `[EndpointSummary("Delete Brand")]`
  - `[EndpointDescription("Soft delete a Brand by setting DeletedBy and DeletedOn.")]`

---

# Common Attributes:
- Add `[Produces("application/json")]` to all methods
- Add appropriate `[ProducesResponseType(typeof(DefaultResponseModel), StatusCodes.X)]`
- Return `ResponseHelper.OK_Result`, `Bad_Request`, or `NotFound_Request` with localized `DefaultResponseMessageModel`

---

# Localized Response Format Example:
```csharp
new DefaultResponseMessageModel
{
    EN = "Brand have been added!",
    MM = "Brand ထပ်ထည့်ပြီးပါပြီ။"
}