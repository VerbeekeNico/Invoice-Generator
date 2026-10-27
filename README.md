A personal portfolio project exploring the development and deployment of
a full-stack application using ASP.NET Core, C#, Entity
Framework Core, Angular, Docker, and Azure.

The project is a work in progress. The current deployed frontend
presents work items retrieved from a .NET Web API. The backend also
contains the beginnings of an invoicing domain, including business,
customer, invoice, and invoice-line entities.
Purpose

The goal of this project is to build a practical full-stack application
while demonstrating skills in backend development, API design, frontend
integration, database access, containerisation, and CI/CD. It is also a
place to explore technologies beyond my main professional background in
.NET development.
Current functionality
- Angular frontend displaying work items in a table.
- ASP.NET Core Web API with endpoints to create, retrieve, update, and
  delete work items.
- SQL Server access through Entity Framework Core.
- A layered backend structure separating the API, business logic,
  contracts, domain model, and infrastructure.
- Docker-based builds for the backend and frontend.
- GitHub Actions workflows for building and deploying the
  applications.
- Deployment to Azure Container Apps, with the frontend and backend
  hosted separately.
The application is under active development; not every invoicing feature
or production concern is complete.

Technology stack
Backend
- C#
- ASP.NET Core Web API
- Entity Framework Core
- Microsoft SQL Server
- Dependency injection
Frontend
- Angular
- TypeScript
- HTML and CSS
Delivery and hosting
- Docker
- GitHub Actions
- GitHub Container Registry (GHCR)
- Azure Container Apps
- Azure-hosted SQL database

Current scope and next steps
This is a portfolio project, not a finished commercial invoicing
product. Areas for further development include:
- Adding explicit frontend loading and error states.
- Improving operational resilience and database connection handling.
- Adding Create, Update and Delete functionality
- Adding in client side validation
- Implement some form of authentication and authorization.
- Improving setup documentation and configuration management.
