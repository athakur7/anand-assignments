# WebApiInAsp.netcoreMvcDemo

## Overview
`WebApiInAsp.netcoreMvcDemo` is an ASP.NET Core `.NET 8` application that combines:

- MVC support (`AddControllersWithViews`)
- REST APIs for employees
- ASP.NET Core Identity (`IdentityUser`, `IdentityRole`)
- JWT authentication and role-based authorization
- Swagger UI with Bearer token support
- SQL Server persistence via EF Core
- Excel export via `ClosedXML`
- Employee image upload support

---

## Tech Stack

- `.NET 8`
- `ASP.NET Core`
- `Entity Framework Core 8`
- `ASP.NET Core Identity`
- `JWT Bearer Authentication`
- `Swashbuckle.AspNetCore`
- `ClosedXML`
- `SQL Server`

---

## Project Structure

- `Program.cs` — service registration, auth config, middleware pipeline
- `Models/EmpContext.cs` — EF Core DbContext + Identity + role seeding
- `Controllers/AuthenticationContrller.cs` — register/login + JWT generation
- `Controllers/AdminController.cs` — admin-only protected endpoint
- `Controllers/EmpController.cs` — employee CRUD + search + pagination + export
- `EmployeeService.cs` — employee business logic
- `IEmployee.cs` — service contract
- `Models/Employee.cs` — employee entity
- `Models/EmployeeBasicDto.cs` — employee list DTO
- `Models/EmployeeUpdateDto.cs` — employee update DTO
- `Models/RegisterUser.cs`, `Models/LoginModel.cs`, `Models/Response.cs` — auth models
- `Migrations/*` — EF Core migrations
- `appsettings.json` — DB/JWT configuration

---

## Configuration (`appsettings.json`)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "constring": "Server=localhost,1433;Database=EmpDb;User Id=sa;Password=Anand@123;Encrypt=False;TrustServerCertificate=True;"
  },
  "JWT": {
    "ValidAudience": "https://localhost:7267",
    "ValidIssuer": "https://localhost:7267",
    "Secret": "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyrsss"
  }
}
```

---

## Startup Flow (`Program.cs`)

1. Registers `HttpContextAccessor`
2. Configures `EmpContext` with SQL Server (`constring`)
3. Registers Identity with EF stores
4. Configures JWT Bearer authentication
5. Registers `IEmployee` -> `EmployeeService`
6. Adds controllers/views + Swagger
7. Adds Swagger Bearer security definition/requirement
8. Middleware order:
   - `UseHttpsRedirection()`
   - `UseStaticFiles()`
   - `UseRouting()`
   - `UseAuthentication()`
   - `UseAuthorization()`
9. Maps API controllers and MVC route

---

## Database Design

`EmpContext : IdentityDbContext<IdentityUser>`

### Tables

- Custom:
  - `employees`
- Identity:
  - `AspNetUsers`
  - `AspNetRoles`
  - `AspNetUserRoles`
  - `AspNetUserClaims`
  - `AspNetRoleClaims`
  - `AspNetUserLogins`
  - `AspNetUserTokens`

### Seeded Roles

- `Admin`
- `User`
- `HR`

---

## Authentication & Authorization

### Register

`POST /api/Authentication/register?role={role}`

Body:

```json
{
  "username": "anand",
  "email": "anand@test.com",
  "password": "Admin@123"
}
```

Behavior:
- Checks existing email
- Creates Identity user
- Verifies role exists
- Adds role to user

Typical responses:
- `200 OK` (success)
- `403 Forbidden` (user exists)
- `500 InternalServerError` (role missing/create failure)

### Login

`POST /api/Authentication/login`

Body:

```json
{
  "username": "anand",
  "password": "Admin@123"
}
```

Behavior:
- Validates credentials
- Loads user roles
- Creates JWT with name/JTI/role claims

Response:

```json
{
  "token": "<jwt-token>",
  "expiration": "2028-04-01T04:35:44Z"
}
```

---

## Protected Admin Endpoint

`GET /api/Admin/employees`

Controller has: `[Authorize(Roles = "Admin")]`

- No token -> `401 Unauthorized`
- Non-admin token -> `403 Forbidden`
- Admin token -> `200 OK`

Sample response:

```json
[
  "santosh",
  "Ali",
  "sita"
]
```

---

## Employee API Endpoints

- `GET /api/Emp?page=1&pageSize=5`
- `GET /api/Emp/{id}`
- `GET /api/Emp/basic?page=1&pageSize=5&search={term}`
- `POST /api/Emp` (`multipart/form-data`)
- `PUT /api/Emp/{id}` (`multipart/form-data`)
- `DELETE /api/Emp/{id}`
- `GET /api/Emp/export/excel?search={term}`

### Employee fields

- `firstName`
- `lastName`
- `email`
- `age`
- `image` (optional file)

### Image behavior

- Stored in `wwwroot/uploads`
- Default image used when file not provided
- Old image deleted on update/delete (except default)
- API returns absolute image URLs

---

## Swagger Testing

1. Run app and open `/swagger`
2. Register user with `role=Admin`
3. Login and copy token
4. Click `Authorize`
5. Enter `Bearer <token>`
6. Call `GET /api/Admin/employees`

---

## Run Locally

### Prerequisites

- .NET 8 SDK
- SQL Server reachable at `localhost,1433`
- Valid DB credentials in `appsettings.json`

### Commands

```powershell
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

Swagger URL (current profile):

- `https://localhost:7230/swagger`

---

## Sample cURL

### Register

```bash
curl -X POST "https://localhost:7230/api/Authentication/register?role=Admin" \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"anand\",\"email\":\"anand@test.com\",\"password\":\"Admin@123\"}"
```

### Login

```bash
curl -X POST "https://localhost:7230/api/Authentication/login" \
  -H "Content-Type: application/json" \
  -d "{\"username\":\"anand\",\"password\":\"Admin@123\"}"
```

### Admin API

```bash
curl -X GET "https://localhost:7230/api/Admin/employees" \
  -H "Authorization: Bearer <TOKEN>"
```

---

## NuGet Packages

- `Microsoft.AspNetCore.Authentication.JwtBearer` `8.0.24`
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` `8.0.24`
- `Microsoft.EntityFrameworkCore` `8.0.24`
- `Microsoft.EntityFrameworkCore.SqlServer` `8.0.24`
- `Microsoft.EntityFrameworkCore.Tools` `8.0.24`
- `Swashbuckle.AspNetCore` `6.6.2`
- `ClosedXML` `0.105.0`
- `Microsoft.VisualStudio.Web.CodeGeneration.Design` `8.0.23`

---

## Notes

- Keep DB password and JWT secret out of public repositories.
- JWT expiry is currently long (`AddYears(2)` in auth controller).
- File name `AuthenticationContrller.cs` has spelling typo, but class/routing works.
