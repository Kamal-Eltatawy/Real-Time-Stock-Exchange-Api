# Real-Time Stock Exchange Web API
---
This repository contains the backend implementation of a Real-Time Stock Exchange Web API.

Backend Technology
The backend of this project is developed using the following technologies:

ASP.NET Core Web API: ASP.NET Core is a cross-platform, high-performance framework for building web APIs.
Entity Framework Core: Entity Framework Core is used for data access and database management.
Swagger: Swagger is integrated to provide API documentation and testing capabilities.
Design Patterns.


The project utilizes several design patterns to maintain code quality and scalability:

Repository Pattern: The repository pattern is employed to abstract away data access logic and provide a consistent interface for accessing data.

Dependency Injection (DI): Dependency Injection is used to promote loose coupling and facilitate unit testing by injecting dependencies into classes rather than hardcoding them.

Clean Architecture
The project follows the principles of Clean Architecture to achieve separation of concerns and maintainability:

Domain Layer: Contains entities, domain services, and business logic representing the core domain of the application.
Infrastructure Layer: Includes implementation details such as data access, external services, and cross-cutting concerns.
Application Layer: Implements use cases and orchestrates interactions between the domain and infrastructure layers.
Presentation Layer: Consists of controllers for handling incoming HTTP requests and serving responses.
Getting Started
To get started with the project, follow these steps:

Clone the repository: git clone https://github.com/Kamal-eltatawy/Real-Time-Stock-Exchange-Api.git
Navigate to the project directory: cd real-time-stock-exchange-api
Restore dependencies: dotnet restore
Configure your database connection in appsettings.json
Apply database migrations: dotnet ef database update
Run the application: dotnet run
