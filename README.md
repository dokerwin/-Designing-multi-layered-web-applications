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

Goal: The primary goal of this use case is to manage promotions for the shop.

### Precondition:

The Admin is logged in to the admin panel.
Postcondition:

The Admin has added, edited or deleted a promotion.
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

## Alternate Flows:

4a. If the promotion details are invalid, the promotion service sends an error message to the Application Service.\
9a. If the updated promotion details are invalid, the promotion service sends an error message to the Application Service.\
15a. If the promotion is being used by existing orders or baskets, the promotion service sends an error message to the Application Service and prevents the promotion from being deleted.


## Project structural difference
Let's see difference in project implementation of the architecture with Domain Driven Desing pattern. The DDD was special added to the solutions to show you that all these architectures have a lot of common when the DDD is used.


## Layered architecture 

We can see here three main layers - 

Presentation layer:
    Layered.Api

Bussiness layer:
    Layered.Domain
    Layered.Application

Data access layer:
    Layered.Infrastructure


## Onion architecture 

We can see here three main layers - 

Core(Domain) layer:
    Onion.Domain.Model
    Onion.Domain.Services

Application layer:
    Onion.Application

Infastructure layer:
    Onion.Infrastructure
    Onion.EntityFramework    
    Onion.Api 

## Hexagonal architecture (Ports and adapters)

We can see here three main layers - 

Hexagon
    Core(Domain) layer:
        Hexagonal.Domain.Model
        Hexagonal.Domain.Services

    Application layer:
        Hexagonal.Application

Infastructure layer:
    Hexagonal.Infrastructure
        Hexagonal.EF.Adapter
        Hexagonal.Grps.Adapter
        Hexagonal.Rest.Adapter  
    Hexagonal.Startup





