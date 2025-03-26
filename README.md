Warehouse Application - ASP.NET Core Application

Overview

The WarehouseApp is a robust and scalable application built using ASP.NET Core 9. It incorporates industry-standard design principles and patterns to ensure maintainability, scalability, and testability. This application is a great example of how to implement the Mediator pattern and SOLID principles in an ASP.NET Core environment.

Key Features
- Mediator Pattern: Utilizes the Mediator design pattern for handling communication between different parts of the application, allowing for loose coupling and better maintainability.
- SOLID Principles: Follows the SOLID principles to ensure clean, maintainable, and testable code.
- ASP.NET Core Best Practices: Built using ASP.NET Core 9 with an emphasis on scalability, performance, and security.
- Modular Architecture: Divided into well-defined layers (Domain, Application, Infrastructure, Web API) to ensure separation of concerns.

---

Table of Contents

- Technologies
- Architecture
- Mediator Pattern
- SOLID Principles
- Installation
- Usage
- Contributing
- License

---

Technologies

This project uses the following technologies:
- **ASP.NET Core 9**
- **Entity Framework Core 9** for data access
- **MediatR 10** for implementing the Mediator pattern
- **AutoMapper** for object mapping
- **Dependency Injection** for decoupling services
- **Swagger** for API documentation

---

Architecture

The project is organized into several core layers to promote clean architecture and separation of concerns:
- **Domain**: Contains the core business models and entities.
- **Application**: Implements business logic and uses MediatR for handling requests and responses.
- **Infrastructure**: Deals with external concerns like database access, file storage, and external APIs.
- **Web API**: Exposes the core functionality of the application to users via HTTP endpoints.

---

Mediator Pattern

The Mediator pattern is used in this project to reduce dependencies between the components of the application. It allows requests and commands to be passed through a Mediator object instead of communicating directly with each other.

Why MediatR?
- Loose Coupling: By using MediatR, different parts of the application don’t need to reference each other directly, which helps to reduce interdependencies.
- Single Responsibility: Each request handler focuses only on handling a single request, making the application easier to maintain and extend.
- Improved Testability: It’s easier to test the individual request handlers as they are decoupled from other components.

In this project, MediatR is used to handle commands and queries between different parts of the application. Here is an example of how a command handler looks:

```csharp
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Quantity = request.Quantity,
            Price = request.Price
        };

        await _productRepository.AddAsync(product);
        return true;
    }
}
