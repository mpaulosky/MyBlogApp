# Contributing to This Project

Thank you for taking the time to consider contributing to our project.

The following is a set of guidelines for contributing to the project. These are mostly guidelines, not rules, and can be
changed in the future. Please submit your suggestions with a pull-request to this document.

- [Contributing to this Project](#contributing-to-this-project)
    - [Code of Conduct](#code-of-conduct)
        - [What should I know before I get started](#what-should-i-know-before-i-get-started)
            - [Project Folder Structure](#project-folder-structure)
            - [Design Decisions](#design-decisions)
            - [How can I contribute](#how-can-i-contribute)
            - [Create an Issue](#create-an-issue)
            - [Respond to an Issue](#respond-to-an-issue)
            - [Write code](#write-code)
            - [Write documentation](#write-documentation)

## Code of Conduct

We have adopted a code of conduct from the Contributor Covenant. Contributors to this project are expected to adhere to
this code. Please report unwanted behavior to [Matthew Paulosky](mailto:matthew.paulosky@outlook.com)

## What should I know before I get started

This project is a practice project to build a BlazorServer application library and MongoDb projects.

### Project Folder Structure

This project is designed to be built and run primarily with Visual Studio 2022 or JetBrains Rider. The folders are
configured so that they will support editing and working in other editors and on non-Windows operating systems. We
encourage you to develop with these other environments, because we would like to be able to support developers who use
those tools as well. The folders are configured as follows:

```bash
/docs                                   -- Contributor and User Documentation
/.github                                -- GitHub Actions and workflows
/Directory.Packages.props               -- Centralized NuGet package versions
/src
  AppHost/                              -- Aspire App Host (Orchestration, environment config)
  Web/                                  -- Blazor Server UI (Interactive/Stream rendering, Middleware, Auth)
  Common/                               -- Shared domain models, DTOs, utilities
  Domain/                               -- Domain logic, CQRS abstractions, vertical slice handlers
  Persistence.MongoDb/                  -- MongoDb Data Access (repositories, context)
  ServiceDefaults/                      -- Default services, DI, cross-cutting concerns
  MyMediator/                           -- CQRS/Mediator implementation
/tests
  Web.Tests.Bunit/                      -- Blazor component/unit tests (bUnit)
  Persistence.MongoDb.Tests.Integration/-- MongoDb integration tests (TestContainers)
  Architecture.Tests/                   -- Architecture rules/tests
  Common.UnitTests/                     -- Common library unit tests
  Domain.UnitTests/                     -- Domain logic unit tests
  Web.UnitTests/                        -- Web layer unit tests
  ServiceDefaults.UnitTests/            -- ServiceDefaults unit tests
  MyMediator.UnitTests/                 -- Mediator unit tests
README.md                               -- Solution overview and instructions
LICENSE                                 -- License
CODE_OF_CONDUCT.md                      -- Contributor Covenant
.editorconfig                           -- Coding style and conventions
```

All official versions of the project are built and delivered with GitHub Actions and linked in the main README.md
and [releases tab in GitHub](https://github.com/mpaulosky/AspireBlog/releases).

### Design Decisions

Design for this project is ultimately decided by the project team
lead, [Matthew Paulosky](mailto:matthew.paulosky@outlook.com). The following project tenets are adhered to when making
decisions:

1. Use the latest stable version of .NET.
1. Use the latest stable version of Aspire.
1. Use the latest stable version of C#.
1. Use the latest stable version of TailwindCSS.
1. Use the latest stable version of Blazor.
1. Use the latest stable version of MongoDb.
1. Use BlazorServer for the UI.
1. Use MongoDb for data.
1. Use EF Core to access the data.

### How can I contribute

We are always looking for help on this project. There are several ways that you can help:
This means one of several types of contributions:

1. [Create an Issue](#create-an-issue)
1. [Respond to an Issue](#respond-to-an-issue)
1. [Write code](#write-code)
1. [Write documentation](#write-documentation)

### Create an Issue

Create a [New Issue Here](https://github.com/mpaulosky/AspireBlog/issues).

1. If you are reporting a `Bug` that you have found. Be sure to add the `Bug` label so that we can triage and track it.
1. If you are reporting an `Enhancement` that you think would improve the project. Be sure to add the `Enhancement`
   label so we can track it.

### Respond to an Issue

[Fork the Repository to your GitHub account](https://github.com/mpaulosky/AspireBlog/fork).

1. Create a new Branch from the develop branch with a reference to the existing Issue number.
1. Work on the issue.
1. Create Unit, Integration tests for any code that require them. We use [xUnit](https://www.nuget.org/packages/xunit/)
   to test our code and [bUnit](https://www.nuget.org/packages/bunit/) to test our blazor components.
1. When you are done Create a Pull Request from your branch to the develop branch.
1. Submit the Pull Request.

Any code that is written to support a blazor component or new functionality are required to be accompanied with unit
tests at the time the pull request is submitted. Pull requests without unit tests will be delayed and asked for unit
tests to prove their functionality.

### Write code

All code should have an assigned issue that matches it. This way we can prevent contributors from working on the same
feature at the same time.

Code for components' features should also include some definition in the `/docs` folder so that our users can
identify and understand which feature is supported.

### Write documentation

The documentation for the project is always needed. We are always looking for help to add content to the `/docs`
section of the repository with proper links back through to the main `/README.md`.