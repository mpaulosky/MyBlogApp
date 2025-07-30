// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AuthorDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

namespace Web.Data.Models;

[ExcludeFromCodeCoverage]
public class AuthorDtoTests
{
	[Fact]
	public void AuthorDto_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		var dto = new AuthorDto();
		dto.Id.Should().BeEmpty();
		dto.UserName.Should().BeEmpty();
		dto.Email.Should().BeEmpty();
		dto.Roles.Should().BeEmpty();
	}

	[Fact]
	public void AuthorDto_Empty_ShouldReturnEmptyInstance()
	{
		var dto = AuthorDto.Empty;
		dto.Id.Should().BeEmpty();
		dto.UserName.Should().BeEmpty();
		dto.Email.Should().BeEmpty();
		dto.Roles.Should().BeEmpty();
	}

	[Fact]
	public void AuthorDto_Constructor_ShouldSetProperties()
	{
		var id = "author-1";
		var userName = "TestUser";
		var email = "test@example.com";
		var roles = new List<string> { "Admin", "Editor" };
		var dto = new AuthorDto(id, userName, email, roles);
		dto.Id.Should().Be(id);
		dto.UserName.Should().Be(userName);
		dto.Email.Should().Be(email);
		dto.Roles.Should().BeEquivalentTo(roles);
	}

	[Fact]
	public void AuthorDto_Properties_ShouldBeMutable()
	{
		var dto = new AuthorDto("id", "name", "email", new List<string> { "Role1" });
		dto.UserName = "new-name";
		dto.Email = "new-email";
		dto.Roles = new List<string> { "Role2", "Role3" };
		dto.UserName.Should().Be("new-name");
		dto.Email.Should().Be("new-email");
		dto.Roles.Should().BeEquivalentTo(new[] { "Role2", "Role3" });
	}
}