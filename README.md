# Architecture Comparison
Layered Architecture, Onion Architecture, and Hexagonal Architecture - is a way of organizing and structuring code in an application, but they differ from each other in some key aspects.
The aim of this study is to analyze three different architectures: Layered Architecture (MVC), Clean Architecture (Onion Architecture), and Hexagon (Ports & Adapters). The study seeks to understand and compare these architectures in terms of their benefits, applications, and impact on software development.

The research methods employed in this study involved conducting a review of articles, publications, and online documentation related to Layered Architecture (MVC), Clean Architecture (Onion Architecture), and Hexagon (Ports & Adapters) available on the internet. Various use cases were analyzed, and the benefits and drawbacks of each architecture were compared. Best practices and recommendations for implementation were identified.

Furthermore, to assess and understand the practical aspects of these architectures, a custom solution was developed and tested. Prototypes of applications were implemented, adhering to the principles and recommendations of each architecture. Functional, performance, and scalability testing were conducted to evaluate their impact on software development.

By combining literature review and hands-on testing, this study provides insights into these three architectures, presenting both theoretical foundations and practical implications of their application.

## Layered Architecture
Layered Architecture is an architecture that separates the application into layers, where each layer performs specific tasks. The business logic is in the upper layers, and the infrastructure layers (such as databases, web servers, etc.) are in the lower layers. Layers can only interact with layers below, which makes the application more modular and easily testable.

Here's an example of structure.

![image](https://github.com/dokerwin/-Designing-multi-layered-web-applications/assets/70201621/a3511494-726a-4b5e-a8e2-abd7af147f48)

Each layer is represented as a folder within the solution. The subfolders within each layer represent the various components and classes that make up that layer. The Tests folder contains separate test projects for each layer, with each project containing unit tests for that layer.

Presentation Layer:
Responsible for handling user interactions, displaying the user interface, and capturing user input.
Contains controllers, views, view models, and client-side scripts.
Communicates with the Business Logic Layer.
Business Logic Layer:

Business Logic/Application Layer: 
Implements the business rules and logic of the application.
Contains services, business entities, and business-specific validation.
Acts as an intermediary between the Presentation Layer and the Data Access Layer.
References the Data Access Layer.
Data Access Layer:

Data Access Layer:
Provides data access and persistence functionality.
Contains repositories, data models, and database access code (e.g., using Entity Framework, ADO.NET, etc.).
Handles interactions with the underlying data storage (database, external APIs, etc.).
Does not have dependencies on other layers.
Cross-cutting Concerns:

Shared (optional)
Contains shared code, utilities, and cross-cutting concerns used across multiple layers.
May include logging, exception handling, validation, serialization, and other common functionalities.
Referenced by other layers as needed.


### Advantages:

- Separation of concerns: Each layer has a specific responsibility, which makes it easier to understand and maintain the system.
- Modularity: The modular structure of the system makes it easier to add or remove functionality without affecting other parts of the system.
- Reusability: The layers can be reused in other systems, which can save time and effort.
- Scalability: The layered architecture can be easily scaled up or down to handle changing requirements.
- Testing: The layered architecture makes it easier to test each layer in isolation, which can reduce the overall testing effort.

### Disadvantages:

- Performance: The use of multiple layers can add overhead, which can affect the performance of the system.
- Complexity: The layered architecture can add complexity to the system, which can make it harder to understand and maintain.
- Tight coupling: The layers can be tightly coupled, which can make it harder to change one layer without affecting other layers.
- Duplication of code: The layers can result in duplication of code, which can make the system harder to maintain.

## Onion/Clean Architecture
Onion Architecture is a more modern architecture that pays great attention to inversion of dependencies and the use of interfaces. In this architecture, the application is divided into smaller components called cores. Each core represents a separate module of business logic that depends only on its internal abstractions and is unaware of external abstractions. Cores can only interact with each other through interfaces, making the application more flexible and scalable.

![image](https://github.com/dokerwin/-Designing-multi-layered-web-applications/assets/70201621/27bb587f-0e01-4142-a859-f6ce343d4b5e)

Here's an example project structure for a Onion Architecture generated by ChatGPT:

![image](https://user-images.githubusercontent.com/70201621/225133518-ef819286-5757-4951-964c-2422bd7f8069.png)

**Domain: Contains the core business logic.**
Entities, ValueObjects, Enums: Domain model classes representing the main business concepts.
Interfaces: Defines contracts for repositories and services that will be implemented in the Infrastructure layer.
Domain layerd should not know about the world outside. The best solution do not have references to anothers projects or dependencies to some framework. 

**Application: Holds the application's use cases and orchestrates the flow of data between the Domain and Infrastructure layers.**
UseCases: Contains input ports, output ports, and implementations of the use cases.
Exceptions: Custom exceptions that may occur within the Application layer.
Mappers: Optional mapping logic to transform between domain entities and DTOs.

**Infrastructure: Implements the interfaces defined in the Domain layer and handles external concerns.**
Persistence: Contains the data access layer, including repositories, database context, and migrations.
ExternalServices: Contains code to communicate with external systems like APIs or messaging systems.
Logging: Contains logging-related code.

**Presentation: The layer responsible for presenting the data and handling user interactions.**
API: Contains the RESTful API controllers, middleware, and DTOs (Data Transfer Objects).
Web: Contains the MVC-based web application views, controllers, and view models.
tests: Contains the unit tests and integration tests for the application.

## Advantages of the Onion architecture:
- Separation of concerns: The architecture helps separate different responsibilities of the application into distinct layers, making it easier to understand and maintain the codebase.
- Dependency inversion: The inner layers define interfaces that outer layers implement, promoting the Dependency Inversion Principle, which leads to a more flexible and maintainable system.
- Testability: Due to the separation of concerns and dependency inversion, it becomes easier to write unit tests and integration tests, ensuring the reliability of the application.
- Scalability: The modular nature of Onion Architecture makes it easier to scale individual components of the application as the need arises.
- Flexibility: Changes to the infrastructure, such as switching databases or introducing new external services, can be done with minimal impact on the core business logic.
- Technology agnostic: The architecture does not impose any specific technology or framework, allowing developers to choose the most appropriate tools for their needs.

## Disadvantages of the Onion architecture:
- Complexity: The architecture introduces additional complexity, which may be an overkill for small projects or prototypes that do not require a high degree of maintainability or flexibility.
- Learning curve: Developers unfamiliar with Onion Architecture may require time to understand and adapt to the concepts and structure, which can slow down the initial development process.
- More boilerplate: The architecture can lead to more boilerplate code, such as interfaces and mappings, which might be seen as additional overhead.
- Performance overhead: The abstraction layers may introduce a small performance overhead due to the increased number of components and interfaces.

Use the architecture only if necessary. It is not recommended to start a startup with this type of architecture because of the complexity.
How to decide not to use Clean Architecture. See below:

1. 𝗪𝗵𝗲𝗻 𝘆𝗼𝘂 𝗵𝗮𝘃𝗲 𝗮 𝘀𝗺𝗮𝗹𝗹, 𝘀𝗶𝗺𝗽𝗹𝗲 𝗽𝗿𝗼𝗷𝗲𝗰𝘁
The Clean Architecture is designed for **complex** systems with multiple layers and components. If you have a small, straightforward project that doesn't require much separation of concerns, using the Clean Architecture may be overkill. It will add unnecessary complexity and overhead to your project and may hinder your development process.

2. 𝗪𝗵𝗲𝗻 𝘆𝗼𝘂 𝗮𝗿𝗲 𝘄𝗼𝗿𝗸𝗶𝗻𝗴 𝗼𝗻 𝗮 𝘁𝗶𝗴𝗵𝘁 𝗱𝗲𝗮𝗱𝗹𝗶𝗻𝗲
Clean Architecture is not a quick or easy solution. It requires a significant amount of upfront planning and design and may require you to refactor your code multiple times as you progress. If you are working on a tight deadline, you may not have the time or resources to implement the Clean Architecture properly. In this case, it may be better to choose a simpler, more agile approach.

3. 𝗪𝗵𝗲𝗻 𝘆𝗼𝘂 𝗵𝗮𝘃𝗲 𝗹𝗶𝗺𝗶𝘁𝗲𝗱 𝗿𝗲𝘀𝗼𝘂𝗿𝗰𝗲𝘀 𝗼𝗿 𝗲𝘅𝗽𝗲𝗿𝘁𝗶𝘀𝗲
Clean Architecture is not a beginner-friendly approach. It requires a deep understanding of software design principles and patterns, as well as experience with complex systems. If you are new to software development, or if you don't have the expertise or resources to implement the Clean Architecture properly, it may not be the right choice for your project.

**My recomendation** is to start all projects with layer architecture for projects where idea are not fully defined or uncertain in terms of profitability. By starting with a monolith service and n-tier architecture, the focus is on delivering functionality quickly and efficiently. This allows the business to validate the potential value and viability of the feature before investing in a more refined architecture.

The choice of a monolith service and n-tier architecture provides a simple and straightforward way to implement the feature. This approach allows for rapid development and easier maintenance on first stage.

This recommendation is aligned with an evolutionary and pragmatic approach to software development, where quick iterations and validation of features are prioritized. It allows the business to minimize upfront investment while still delivering value to customers. The subsequent rewrite with clean architecture provides an opportunity for long-term sustainability and scalability once the profitability or viability of the feature is established.

## Hexagonal Architecture
Hexagonal Architecture is another modern architecture that also pays great attention to inversion of dependencies and the separation of business logic and infrastructure. In this architecture, bussiness logic is at the heart of the application and surrounded by various adapter layers that provide interaction with the external world. Unlike Layered Architecture, where layers can call layers below, in Hexagonal Architecture all calls enter and exit through adapters, making the application more independent of external systems and more testable.

Here's an example project structure for a Hexagonal Architecture generated by ChatGPT:

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

### Opinion

In my opinion, Hexagonal Architecture is a great choice for complex applications with evolving requirements. It allows for modular and flexible development, making it easier to understand and maintain the codebase. With clear separation of concerns and easy integration with external systems, Hexagonal Architecture promotes testability and technology independence. While it may introduce some complexity, the benefits of scalability, adaptability, and testability make it worth considering for projects that require these qualities.

# Practical example 

## Promotions microservice

I will show you the difference between architectures based on the examples below.

First of all let’s see why microservice is needed. The best option to show the use cases of the microservice. See below. 

Primary Actor: Shopper

Goal: The primary goal of this use case is to apply promotions to a basket and calculate the total price after applying the promotions.

## Precondition:

The Shopper has added items to their basket.
Postcondition:
The Shopper can see the updated total price of their basket after applying the promotions.

## Basic Flow:

1. The Shopper selects the items they want to purchase and adds them to their basket.
2. The Shopper selects the "Finish and Pay" option in the user interface.
3. The Application Service (acting as the controller) receives the request to apply promotions and sends it to the promotion service.
4. The promotion service fetches the available promotions from the promotion repository.
5. The promotion service applies the eligible promotions to the basket.
6. The promotion service calculates the new total price of the basket after applying the promotions.
7. The promotion service returns the updated basket with the applied promotions and total price to the Application Service.
8. The Application Service sends the updated basket with the applied promotions and total price to the user interface.
9. The Shopper sees the updated basket with the applied promotions and total price in the user interface.
##  Alternate Flows:

4a. If there are no promotions available, the promotion service skips the promotion application step and proceeds to step 6.\
5a. If there are no eligible promotions for the items in the basket, the promotion service skips the promotion application step and proceeds to step 6.\
6a. If the basket does not meet the minimum requirements for a promotion, the promotion service skips the promotion application step and proceeds to step 7.\
6b. If the basket qualifies for multiple promotions, the promotion service applies all the eligible promotions and calculates the new total price.\
7a. If an error occurs while applying the promotions, the promotion service sends an error message to the Application Service.\
8a. If an error occurs while processing the request, the Application Service sends an error message to the user interface.

##  Use case name: Manage Promotions

### Primary Actor: Admin

## Basic Flow:

1. The Admin opens the "Promotions" section in the admin panel.
2. The Admin selects the "Add Promotion" option and provides the promotion details.
3. The Application Service (acting as the controller) receives the request to add a new promotion and sends it to the promotion service.
4. The promotion service validates the promotion details and adds the new promotion to the promotion repository.
5. The promotion service returns a success message to the Application Service.
6. The Application Service sends the success message to the user interface.
7. The Admin selects the "Edit Promotion" option and selects a promotion to edit.
8. The Admin modifies the promotion details and saves the changes.
9. The Application Service receives the request to update the promotion and sends it to the promotion service.
10. The promotion service validates the updated promotion details and updates the promotion in the promotion repository.
11. The promotion service returns a success message to the Application Service.
12. The Application Service sends the success message to the user interface.
13. The Admin selects the "Delete Promotion" option and selects a promotion to delete.
14. The Application Service receives the request to delete the promotion and sends it to the promotion service.
15. The promotion service deletes the selected promotion from the promotion repository.
16. The promotion service returns a success message to the Application Service.
17. The Application Service sends the success message to the user interface.
18. The Admin sees the updated list of promotions in the admin panel.

## Structural difference
Let's see difference in project implementation of the architecture with Domain Driven Desing pattern. The DDD was specifically added to the solutions to show you that all these architectures have a lot in common when DDD is used. 

## Layered architecture 

![image](https://user-images.githubusercontent.com/70201621/225133027-109780c1-dae3-489f-ae09-57c1823ef542.png)

### Presentation layer:
- Layered.Api

### Bussiness layer:
- Layered.Domain
- Layered.Application

### Data access layer:
- Layered.Infrastructure

## Onion architecture 

![image](https://user-images.githubusercontent.com/70201621/225133225-4d904a18-bed9-4195-be63-3f082b0af939.png)

### Core(Domain) layer:
- Onion.Domain.Model
- Onion.Domain.Services

### Application layer:
- Onion.Application

### Infastructure layer:
- Onion.Infrastructure
- Onion.EntityFramework    
- Onion.Api 

## Hexagonal architecture (Ports and adapters)

![image](https://user-images.githubusercontent.com/70201621/225132942-5a889ac3-1786-4cb7-b9b0-a4f692d67a61.png)

#### Hexagon

### Core(Domain) layer
- Hexagonal.Domain.Model
- Hexagonal.Domain.Services
### Application layer
- Hexagonal.Application

#### Infastructure (Adapters):
- Hexagonal.Infrastructure 
- Hexagonal.EF.Adapter - Driven
- Hexagonal.Grps.Adapter - Driver
- Hexagonal.Rest.Adapter  - Driver
- **Hexagonal.Startup**

# Wrapping up
Layered architecture, hexagonal architecture, and onion architecture are all design patterns that can be used in a variety of projects, depending on the specific requirements and constraints of the project at hand. Here are some examples of projects that could benefit from each architecture:

### Layered Architecture:

Small to medium-sized applications that have a simple architecture and do not require a lot of complexity, such as a blogging platform or a basic e-commerce website
Applications that require a clear separation of concerns between different layers, such as a three-tier web application with a presentation layer, business logic layer, and data access layer.
Testing in a layered architecture typically involves testing each layer in isolation to ensure that it is functioning correctly and also testing the interactions between layers to ensure that the data is flowing correctly. This approach allows for a clear separation of concerns and makes it easier to isolate and fix bugs.

### Hexagonal Architecture:

Large applications that require integration with external systems, such as banking or financial applications
Complex applications that require a clear separation of concerns between different layers, such as a healthcare application that interfaces with electronic medical records and medical devices.
Testing in a hexagonal architecture requires testing the core domain and its interactions with the adapters and ports. This approach allows for more flexibility in terms of how the system communicates with external systems, but can also make testing more complex.

### Onion Architecture:

Highly modular and maintainable applications that require a high degree of flexibility and scalability, such as enterprise applications that handle supply chain management or customer relationship management
Applications that require a clear separation of concerns between different layers, such as a mobile app that needs to separate the user interface from the application logic.
It's important to note that the choice between these architectures depends on the specific needs of the project. In some cases, a combination of these architectures may be used to achieve the desired outcomes.
Testing in an onion architecture is similar to testing in a layered architecture, but with an added emphasis on testing the core layer. This layer is critical to the functioning of the system, and so it is important to ensure that it is well-tested and functioning correctly.


Each of these architectures has its advantages and disadvantages, and the right choice depends on the specific requirements and features of the project.

