# login-crud-dotnet-api

A simple .NET 8 Web API implementing CRUD operations for a login entity.

## How to Run
1. Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.
2. Navigate to the project folder.
3. Run:
   ```bash
   dotnet run
   ```
4. API will be available at `https://localhost:5001/api/login` (Swagger UI at `/swagger`).

## Endpoints
- `GET /api/login` → List all users
- `GET /api/login/{id}` → Get user by ID
- `POST /api/login` → Create user
- `PUT /api/login/{id}` → Update user
- `DELETE /api/login/{id}` → Delete user
