# Task: GraphQL CRUD Operations for Brand Entity with Name Conflict Checking

## Objective
Create a set of GraphQL queries and mutations for full CRUD operations on the `Brand` entity using HotChocolate in ASP.NET Core, with additional logic to check for name conflicts (duplicate brand names).

## Requirements
- Use HotChocolate GraphQL in ASP.NET Core.
- Exclude soft-deleted records (where `DeletedOn` is not null) from queries.
- Return the following fields: `Id`, `Name`, `CreatedOn`, `CreatedBy`, `UpdatedOn`, `UpdatedBy`.
- **Check for name conflicts:**
  - On create: Do not allow creation if a non-deleted brand with the same name exists.
  - On update: Do not allow update if another non-deleted brand with the same name exists.
- Return a meaningful error or null if a conflict is detected.

## Operations

### Query: Get All Brands
- **Name:** `GetBrands`
- **Description:** Retrieve all brands that are not soft-deleted.
- **Return:** List of Brand objects (see fields above)

### Mutation: Create Brand
- **Name:** `createBrand`
- **Input:**
  - `Name` (string)
  - `CreatedBy` (string)
- **Behavior:**
  - Set `CreatedOn = DateTime.UtcNow`
  - **Check:** If a non-deleted brand with the same name exists, return null or error.
- **Return:** Created Brand object or null/error if conflict

### Mutation: Update Brand
- **Name:** `updateBrand`
- **Input:**
  - `id` (int)
  - `Name` (string)
  - `UpdatedBy` (string)
- **Behavior:**
  - Set `UpdatedOn = DateTime.UtcNow`
  - **Check:** If another non-deleted brand with the same name exists, return null or error.
- **Return:** Updated Brand object or null/error if conflict

### Mutation: Delete Brand (Soft Delete)
- **Name:** `deleteBrand`
- **Input:**
  - `id` (int)
  - `deletedBy` (string)
- **Behavior:**
  - Set `DeletedOn = DateTime.UtcNow`
  - Set `DeletedBy = deletedBy`
- **Return:** Boolean (true if deleted, false if not found/soft-deleted)

## Example GraphQL Types
- Query type: `BrandsQuery` (in `GraphQL/Brands/BrandsQuery.cs`)
- Mutation type: `BrandsMutation` (in `GraphQL/Brands/BrandsMutation.cs`)
- Input type: `BrandInput`
- Output type: `BrandDto`

## Example Queryquery {
  GetBrands {
    id
    name
    createdOn
    createdBy
    updatedOn
    updatedBy
  }
}
## Example Mutationmutation {
  createBrand(input: { name: "BrandX", createdBy: "admin" }) {
    id
    name
    createdOn
    createdBy
  }
}
---

This prompt ensures a robust, real-world GraphQL CRUD API for the Brand entity, with name conflict checking and a clear folder structure for maintainability.
