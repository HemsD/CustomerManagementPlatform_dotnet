# CustomerManagementPlatform_dotnet
ASP.NET Core Web API for Customer Management using Entity Framework Core, In-Memory Database, Repository Pattern, Service Layer, Dependency Injection, and Global Exception Handling.

Customer Management Platform (.NET)

Project Overview

Customer Management Platform is a RESTful ASP.NET Core Web API built using a layered architecture. The application allows users to create customers while preventing duplicate customer registrations based on email address.

The project demonstrates enterprise backend development practices including:

* ASP.NET Core Web API
* Entity Framework Core
* Repository Pattern
* Service Layer
* Dependency Injection
* Custom Exception Handling Middleware
* Unit Testing using xUnit and Moq
* Docker Containerization

⸻

Project Architecture

Client (Postman)
        │
        ▼
CustomerController
        │
        ▼
CustomerService
        │
        ▼
CustomerRepository
        │
        ▼
ApplicationDbContext
        │
        ▼
Entity Framework Core
        │
        ▼
In-Memory Database

Each layer has a single responsibility, making the application easier to maintain, test, and extend.

⸻

Technologies Used

* C#
* ASP.NET Core 10
* Entity Framework Core
* In-Memory Database
* Dependency Injection
* xUnit
* Moq
* Docker
* Git & GitHub

⸻

Features

* Create Customer API
* Duplicate Email Validation
* Repository Pattern
* Service Layer
* Dependency Injection
* Global Exception Handling Middleware
* Unit Testing
* Dockerized Application

⸻

Project Structure

Lowes.CustomerManagement
│
├── Controllers
│     └── CustomerController.cs
│
├── Services
│     ├── ICustomerService.cs
│     └── CustomerService.cs
│
├── Repositories
│     ├── ICustomerRepository.cs
│     └── CustomerRepository.cs
│
├── Data
│     └── ApplicationDbContext.cs
│
├── Models
│     └── Customer.cs
│
├── Exceptions
│     └── CustomerAlreadyExistsException.cs
│
├── Middleware
│     └── ExceptionHandlingMiddleware.cs
│
├── Program.cs
│
├── Dockerfile
│
└── README.md

⸻

Design Decisions

Layered Architecture

The project follows a layered architecture:

* Controller Layer
* Service Layer
* Repository Layer
* Data Layer

This separation improves maintainability, readability, and testability.

⸻

Repository Pattern

Database operations are isolated inside repositories.

Benefits:

* Keeps controllers clean
* Makes database logic reusable
* Makes unit testing easier
* Allows changing the database implementation without affecting business logic

⸻

Service Layer

Business logic is implemented in the service layer.

Example:

Before creating a customer, the service checks whether the email already exists.

If a duplicate email is found, a custom exception is thrown.

⸻

Dependency Injection

Dependency Injection is used throughout the application.

Interfaces are injected instead of concrete classes.

Example:

ICustomerRepository
        ↓
CustomerRepository
ICustomerService
        ↓
CustomerService

Benefits:

* Loose coupling
* Easier testing
* Better maintainability

⸻

Global Exception Handling

A custom middleware handles application exceptions globally.

Current implementation includes:

* 409 Conflict for duplicate customers
* 500 Internal Server Error for unexpected exceptions

This avoids repetitive try-catch blocks inside controllers.

⸻

REST API

Create Customer

POST

/customers

Sample Request

{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@example.com"
}

Success Response

{
    "customerId": 1,
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@example.com"
}

Duplicate Customer Response

{
    "message": "Customer with email already exists"
}

HTTP Status

409 Conflict

⸻

Unit Testing

The project includes unit tests using:

* xUnit
* Moq

Current test scenarios include:

* Customer creation succeeds when email does not exist.

The repository is mocked using Moq, allowing business logic to be tested independently without requiring a real database.

⸻

Docker & Containerization

The application has been containerized using Docker.

Docker Workflow

Source Code
        │
        ▼
Dockerfile
        │
        ▼
docker build
        │
        ▼
Docker Image
        │
        ▼
docker run
        │
        ▼
Docker Container
        │
        ▼
ASP.NET Core API

A multi-stage Docker build is used.

Build Stage

* Restores NuGet packages
* Publishes the application

Runtime Stage

* Uses the lightweight ASP.NET Runtime image
* Copies only the published output
* Produces a smaller and production-ready Docker image

⸻

Running the Application Locally

Clone the repository.

git clone <repository-url>

Navigate to the project.

cd Lowes.CustomerManagement

Restore packages.

dotnet restore

Run the application.

dotnet run

⸻

Running with Docker

Build Docker Image

docker build -t customer-api .

Run Docker Container

docker run -d -p 8080:8080 --name customer-api-container customer-api

Verify Running Containers

docker ps

View Logs

docker logs customer-api-container

Stop Container

docker stop customer-api-container
