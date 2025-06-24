# Task: GraphQL CRUD Operations for Color Entity with Name Conflict Checking

## Objective
Create a set of GraphQL queries and mutations for full CRUD operations on the `Color` entity using HotChocolate in ASP.NET Core, with additional logic to check for name conflicts (duplicate color names).

## Requirements
- Use HotChocolate GraphQL in ASP.NET Core.
- Exclude soft-deleted records (where `DeletedOn` is not null) from queries.
- Return the following fields: `Id`, `Name`, `CreatedOn`, `CreatedBy`, `UpdatedOn`, `UpdatedBy`.
- **Check for name conflicts:**
  - On create: Do not allow creation if a non-deleted color with the same name exists.
  - On update: Do not allow update if another non-deleted color with the same name exists.
- Return a meaningful error or null if a conflict is detected.

## Operations

### Query: Get All Colors
- **Name:** `GetColors`
- **Description:** Retrieve all colors that are not soft-deleted.
- **Return:** List of Color objects (see fields above)

### Mutation: Create Color
- **Name:** `createColor`
- **Input:**
  - `Name` (string)
  - `CreatedBy` (string)
- **Behavior:**
  - Set `CreatedOn = DateTime.UtcNow`
  - **Check:** If a non-deleted color with the same name exists, return null or error.
- **Return:** Created Color object or null/error if conflict

### Mutation: Update Color
- **Name:** `updateColor`
- **Input:**
  - `id` (int)
  - `Name` (string)
  - `UpdatedBy` (string)
- **Behavior:**
  - Set `UpdatedOn = DateTime.UtcNow`
  - **Check:** If another non-deleted color with the same name exists, return null or error.
- **Return:** Updated Color object or null/error if conflict

### Mutation: Delete Color (Soft Delete)
- **Name:** `deleteColor`
- **Input:**
  - `id` (int)
  - `deletedBy` (string)
- **Behavior:**
  - Set `DeletedOn = DateTime.UtcNow`
  - Set `DeletedBy = deletedBy`
- **Return:** Boolean (true if deleted, false if not found/soft-deleted)

## Example GraphQL Types
- Query type: `ColorsQuery` (in `GraphQL/Colors/ColorsQuery.cs`)
- Mutation type: `ColorsMutation` (in `GraphQL/Colors/ColorsMutation.cs`)
- Input type: `ColorInput`
- Output type: `ColorDto`

## Example Query
```graphql
query {
  GetColors {
    id
    name
    createdOn
    createdBy
    updatedOn
    updatedBy
  }
}
```
## Example Mutation
```graphql
mutation {
  createColor(input: { name: "Red", createdBy: "admin" }) {
    id
    name
    createdOn
    createdBy
  }
}
```
---

This prompt ensures a robust, real-world GraphQL CRUD API for the Color entity, with name conflict checking and a clear folder structure for maintainability.
