# RestaurantsAPI

A scalable RESTful API for restaurant management, developed following **Clean Architecture** principles and using ASP.NET Core 9.

## Features

- **Restaurant Management**: Full CRUD operations for restaurants.
- **User Management**: Authentication and authorization using ASP.NET Identity.
- **Database Seeding**: Populate the database with initial data for realistic testing.
- **Pagination & Sorting**: Efficient handling of large datasets.
- **Advanced Logging**: Integrated with Serilog for API event tracking.
- **Global Exception Handling**: Middleware for centralized error handling and informative client feedback.
- **Automated Documentation**: Swagger integration for API documentation.
- **Automated Testing**: Unit and integration tests to ensure quality and prevent regressions.

## Technologies Used

- **.NET Core 9**: Main framework for application development.
- **Entity Framework Core**: ORM for database management.
- **SQL Server**: Relational database for data storage.
- **Swagger**: Interactive API documentation.
- **Serilog**: Advanced logging for monitoring requests and errors.
- **Fluent Validation**: Efficient DTO validation.

## Testing Libraries

- **xUnit**: Unit testing framework for .NET.
- **Moq**: Mocking library for unit testing.
- **FluentAssertions**: Library for readable and expressive test assertions.

## Patterns and Best Practices

- **Clean Architecture**: Separation of responsibilities into distinct layers (Domain, Application, Infrastructure, API) for maintainability and testability.
- **CQRS (Command Query Responsibility Segregation)**: Separating read (query) and write (command) operations using MediatR.
- **Repository Pattern**: Abstraction layer for database access management.
- **Dependency Injection**: Managing dependencies for modular and testable code.
- **Global Exception Handling**: Centralized error management to provide standardized responses to clients.

## Project Structure

- **src/**: Application source code.
  - **Restaurants.API/**: Exposes API endpoints and handles HTTP requests.
  - **Restaurants.Application/**: Business logic implementation, including CQRS.
  - **Restaurants.Domain/**: Core domain entities and interfaces.
  - **Restaurants.Infrastructure/**: Data access, database configurations, and infrastructure services.
- **tests/**: Unit and integration tests for the application.
