# Architecture Comparison
Each of the three architectures - Layered Architecture, Onion Architecture, and Hexagonal Architecture - is a way of organizing and structuring code in an application, but they differ from each other in some key aspects.

## Layered Architecture
Layered Architecture is an architecture that separates the application into layers, where each layer performs specific tasks. The business logic is in the upper layers, and the infrastructure layers (such as databases, web servers, etc.) are in the lower layers. Layers can only interact with layers below, which makes the application more modular and easily testable.

## Onion Architecture
Onion Architecture is a more modern architecture that pays great attention to inversion of dependencies and the use of interfaces. In this architecture, the application is divided into smaller components called cores. Each core represents a separate module of business logic that depends only on its internal abstractions and is unaware of external abstractions. Cores can only interact with each other through interfaces, making the application more flexible and scalable.

## Hexagonal Architecture
Hexagonal Architecture is another modern architecture that also pays great attention to inversion of dependencies and the separation of business logic and infrastructure. In this architecture, business logic is at the heart of the application and surrounded by various adapter layers that provide interaction with the external world. Unlike Layered Architecture, where layers can call layers below, in Hexagonal Architecture all calls enter and exit through adapters, making the application more independent of external systems and more testable.

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

Each of these architectures has its advantages and disadvantages, and the right choice depends on the specific requirements and features of the project.
