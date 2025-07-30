---
mode: "agent"
tools: ["changes", "codebase", "editFiles", "problems", "search"]
description: "Get best practices for XUnit unit testing, including data-driven tests"
---

# XUnit Best Practices

Your goal is to help me write effective unit tests with XUnit v3, covering both standard and data-driven testing approaches.

## Project Setup

- Use a separate test project with naming convention `[ProjectName].Tests.Unit` (e.g., `Web.Tests.Unit` for the `Web` project)
- Reference XUnit v3 packages: `xunit.v3.core`, `xunit.v3.assert`, and `xunit.v3.runner.visualstudio`
- Also reference `Microsoft.NET.Test.Sdk`, `FluentAssertions`, `NSubstitute`, and `Moq` packages
- **Do not specify package versions in the `.csproj` file**; manage all versions centrally in `Directory.Packages.props`
- Example from `Web.Tests.csproj`:
  ```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" />
    <PackageReference Include="xunit.v3" />
    <PackageReference Include="xunit.v3.core" />
    <PackageReference Include="xunit.v3.runner.visualstudio" />
    <PackageReference Include="FluentAssertions" />
    <PackageReference Include="NSubstitute" />
    <PackageReference Include="Moq" />
  </ItemGroup>
  ```
- Create test classes that match the classes being tested (e.g., `CalculatorTests` for `Calculator`)

## Test Structure

- Test class attributes are required: `[ExcludeFromCodeCoverage]` and `[TestSubject(typeof(TargetType))]`
- Use `[Fact]` for simple tests and `[Theory]` with `[InlineData]` or `[MemberData]` for data-driven tests
- Strictly follows the Arrange-Act-Assert (AAA) pattern:
  - **Arrange**: Set up test prerequisites and inputs
  - **Act**: Call the method or operation being tested
  - **Assert**: Verify the result using FluentAssertions
- Prefer async test methods (`Task` return type)
- Use NSubstitute or Moq for mocking dependencies
- Require XML documentation comments for all test classes and methods

## Additional Best Practices

- Enforce code coverage analysis
- Enforce StyleCop and `.editorconfig` rules
- Require health checks and structured logging in integration tests
- Reference `Web.Tests.csproj` and its folder structure as a canonical example for test project setup, package references, and organization.