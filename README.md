# Real-Time Stock Exchange Web API
---
This repository contains the backend implementation of a Real-Time Stock Exchange Web API.

**Backend Technology**:
The backend of this project is developed using the following technologies:

1- **ASP.NET Core Web API**: ASP.NET Core is a cross-platform, high-performance framework for building web APIs.
2- **Entity Framework Core**: Entity Framework Core is used for data access and database management.
3- **Swagger***: Swagger is integrated to provide API documentation and testing capabilities.
Design Patterns.


**The project utilizes several design patterns to maintain code quality and scalability**:

1- **Repository Pattern**: The repository pattern is employed to abstract away data access logic and provide a consistent interface for accessing data.

2- **Dependency Injection (DI)**: Dependency Injection is used to promote loose coupling and facilitate unit testing by injecting dependencies into classes rather than hardcoding them.

**Clean Architecture**
The project follows the principles of Clean Architecture to achieve separation of concerns and maintainability:

1-**Domain Layer**: This layer encapsulates entities, domain services, and business logic, representing the core domain of the application. Entities are objects representing real-world concepts, while domain services encapsulate domain logic that doesn't naturally fit within the entities themselves.

2-**Domain Services Layer**: This layer contains domain services that encapsulate domain logic and operations that are not specific to any single entity. These services operate on multiple entities or orchestrate interactions between entities, enforcing business rules and ensuring consistency within the domain.

3-**Infrastructure Layer**: The infrastructure layer deals with implementation details such as data access, external services, and cross-cutting concerns like logging and caching. It includes repositories for accessing data from storage, external service clients, and other infrastructure components.

4-**Application Layer**: The application layer implements use cases and orchestrates interactions between the domain and infrastructure layers. It defines application-specific logic and workflows, handling incoming requests, executing business logic, and coordinating data access and persistence.

5-**Presentation Layer**: The presentation layer consists of controllers responsible for handling incoming HTTP requests and serving responses. It translates external requests into actions within the application layer and formats responses for client consumption. This layer typically includes controllers for web APIs, user interfaces, or other interfaces.
Getting Started
To get started with the project, follow these steps:

Clone the repository: git clone https://github.com/Kamal-eltatawy/Real-Time-Stock-Exchange-Api.git
Navigate to the project directory: cd real-time-stock-exchange-api
Restore dependencies: dotnet restore
Configure your database connection in appsettings.json
Apply database migrations: dotnet ef database update
Run the application: dotnet run
