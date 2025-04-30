# Product Catalog API

A .NET-based RESTful API for managing product catalogs with authentication and authorization capabilities.

## Project Structure

The solution follows Clean Architecture principles and is organized into the following projects:

- **ProductCatalogAPI.Api**: API endpoints and configuration
- **ProductCatalogAPI.Application**: Business logic and application services
- **ProductCatalogAPI.Domain**: Core domain entities
- **ProductCatalogAPI.Infrastructure**: Data access and external services
- **ProductCatalogAPI.Identity**: Authentication and authorization

## Features

- Product management (CRUD operations)
- JWT-based authentication
- Role-based authorization (Admin/User roles)
- Exception handling middleware
- Swagger/OpenAPI documentation
- Entity Framework Core with SQL Server
- CORS support
- Serilog for structured logging

## Technical Stack

- .NET 9.0
- Entity Framework Core 9.0
- SQL Server
- JWT Authentication
- Swagger/OpenAPI
- MediatR for CQRS pattern
- FluentValidation

## Getting Started

1. **Prerequisites**
   - .NET 9.0 SDK
   - SQL Server (LocalDB or higher)

2. **Database Setup**
   - Update the connection string in `appsettings.json`
   - Run Entity Framework migrations:
     ```bash
     dotnet ef database update --project ProductCatalogAPI.Infrastructure
     dotnet ef database update --project ProductCatalogAPI.Identity
     ```

3. **Running the Application**
   ```bash
   dotnet run --project ProductCatalogAPI.Api
   ```