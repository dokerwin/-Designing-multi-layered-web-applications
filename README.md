# Architecture Comparison
Layered Architecture, Onion Architecture, and Hexagonal Architecture - is a way of organizing and structuring code in an application, but they differ from each other in some key aspects.

## Layered Architecture
Layered Architecture is an architecture that separates the application into layers, where each layer performs specific tasks. The business logic is in the upper layers, and the infrastructure layers (such as databases, web servers, etc.) are in the lower layers. Layers can only interact with layers below, which makes the application more modular and easily testable.

Here's an example of what this project structure might look like in a C# solution:

![image](https://user-images.githubusercontent.com/70201621/222955455-059cfb50-de8e-49da-99b0-39abe4067d7b.png)

Each layer is represented as a folder within the solution. The subfolders within each layer represent the various components and classes that make up that layer. The Tests folder contains separate test projects for each layer, with each project containing unit tests for that layer.

In Layered Architecture, the application layer is part of the service layer, which is responsible for implementing the business logic of the system. The service layer contains the application logic, data access logic, and any other technical concerns. The service layer is often divided into multiple sub-layers such as application, domain, and infrastructure.

## Onion Architecture
Onion Architecture is a more modern architecture that pays great attention to inversion of dependencies and the use of interfaces. In this architecture, the application is divided into smaller components called cores. Each core represents a separate module of business logic that depends only on its internal abstractions and is unaware of external abstractions. Cores can only interact with each other through interfaces, making the application more flexible and scalable.

## Hexagonal Architecture
Hexagonal Architecture is another modern architecture that also pays great attention to inversion of dependencies and the separation of business logic and infrastructure. In this architecture, business logic is at the heart of the application and surrounded by various adapter layers that provide interaction with the external world. Unlike Layered Architecture, where layers can call layers below, in Hexagonal Architecture all calls enter and exit through adapters, making the application more independent of external systems and more testable.

Here's an example project structure for a Hexagonal Architecture in C#:

![image](https://user-images.githubusercontent.com/70201621/222955693-609cdbfa-f041-445d-a273-3a3c9958e123.png)

#### Application Layer:
This layer contains the application-specific business logic and services that use the domain layer via ports. It includes ports, services, and DTOs that expose the application's functionality to external clients.

#### Domain Layer:
This layer contains the core business logic and rules of the application, independent of the application's details. It consists of entities, value objects, exceptions, ports, and services that model the problem domain.

#### Infrastructure Layer:
This layer contains the implementation details for the application, including data access, external libraries, services, and adapters that connect the ports of the application layer to the ports of the domain layer.

#### Presentation Layer:
This layer is responsible for interacting with the user and handling user input/output. It typically contains controllers, views, and DTOs that map to the entities in the domain layer.

#### Tests:
This folder contains separate test projects for each layer, with each project containing unit tests for that layer.

This architecture emphasizes the separation of concerns between the layers, which allows for more flexibility and maintainability. The Domain Layer is the heart of the system and is isolated from the infrastructure and application layers, which enables the system to evolve and change over time. The Infrastructure Layer acts as an adapter that connects the ports of the application and domain layers.

### Benefits of Hexagonal Architecture
#### Plug & play
We can add or remove adapter based on our development, like we can replace Rest adapter with GraphQL or gRPC adapter. The rest of the logic will be remain the same

#### Testability
As it decoupled all layers, so it is easy to write a test case for each components

#### Adaptability/Enhance
Adding a new way to interact with applications is very easy

#### Sustainability
We can keep all third party libraries in Infrastructure layer and hence maintainence will be easy

#### Database Independent
Since database is separated from data access, it is quite easy to switch database providers

#### Clean code
As business logic is away from presentation layer, it is easy to implement UI (like React, Angular or Blazor)

#### Well organized
Project is well organized for better understanding and for onboarding for new joinee to project

### Disadvantages of Hexagonal Architecture
 
Domain layer will be heavy

Lots of logic will be implemented in Domain layer (sometimes called as Core layer)

# Wrapping up
Layered architecture, hexagonal architecture, and onion architecture are all design patterns that can be used in a variety of projects, depending on the specific requirements and constraints of the project at hand. Here are some examples of projects that could benefit from each architecture:

### Layered Architecture:

Small to medium-sized applications that have a simple architecture and do not require a lot of complexity, such as a blogging platform or a basic e-commerce website
Applications that require a clear separation of concerns between different layers, such as a three-tier web application with a presentation layer, business logic layer, and data access layer.

### Hexagonal Architecture:

Large applications that require integration with external systems, such as banking or financial applications
Complex applications that require a clear separation of concerns between different layers, such as a healthcare application that interfaces with electronic medical records and medical devices.

### Onion Architecture:

Highly modular and maintainable applications that require a high degree of flexibility and scalability, such as enterprise applications that handle supply chain management or customer relationship management
Applications that require a clear separation of concerns between different layers, such as a mobile app that needs to separate the user interface from the application logic.
It's important to note that the choice between these architectures depends on the specific needs of the project. In some cases, a combination of these architectures may be used to achieve the desired outcomes.

Each of these architectures has its advantages and disadvantages, and the right choice depends on the specific requirements and features of the project.
