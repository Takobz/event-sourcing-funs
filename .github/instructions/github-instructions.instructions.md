---
applyTo: '**'
---

This repository has source code for a .NET Core/5+ application.
The code has four main layers that mimic the Clean Architecture pattern:
- **Domain**: Contains the core business logic and domain entities.
- **Application**: Contains application logic, use cases, and interfaces.
- **Infrastructure**: Contains implementations of interfaces, data access, and external services.
- **Presentation**: Contains the user interface, such as ASP.NET Core controllers or Razor pages.

Whenever you generate suggestions or code make sure you keep in mind the separation of concerns and the Clean Architecture principles.
