// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AuthorTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

namespace Web.Data.Entities;

/// <summary>
///   Unit tests for the <see cref="Author" /> entity.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(Author))]
public class AuthorTests
{


	[Fact]
	public void Author_Constructor_ShouldSetProperties()
	{
		// Arrange & Act
		var author = new Author("author-1", "TestUser", "test@example.com", new List<string> { "Admin" });

		// Assert
		author.Id.Should().Be("author-1");
		author.UserName.Should().Be("TestUser");
		author.Email.Should().Be("test@example.com");
		author.Roles.Should().ContainSingle().Which.Should().Be("Admin");
	}


	[Fact]
	public void Author_Empty_ShouldReturnEmptyInstance()
	{
		// Act
		var author = Author.Empty;

		// Assert
		author.Id.Should().BeEmpty();
		author.UserName.Should().BeEmpty();
		author.Email.Should().BeEmpty();
		author.Roles.Should().BeEmpty();
	}
	[Fact]
	public void Author_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		// Act
		var author = new Author();

		// Assert
		author.Id.Should().BeEmpty();
		author.UserName.Should().BeEmpty();
		author.Email.Should().BeEmpty();
		author.Roles.Should().BeEmpty();
	}

	[Fact]
	public void Author_Constructor_ShouldSetAllProperties()
	{
		// Arrange
		var id = "author-2";
		var userName = "AuthorUser";
		var email = "author2@example.com";
		var roles = new List<string> { "Writer", "Editor" };

		// Act
		var author = new Author(id, userName, email, roles);

		// Assert
		author.Id.Should().Be(id);
		author.UserName.Should().Be(userName);
		author.Email.Should().Be(email);
		author.Roles.Should().BeEquivalentTo(roles);
	}

	[Fact]
	public void Author_Properties_ShouldBeMutable()
	{
		// Arrange
		var author = new Author("id", "name", "mail", new List<string> { "Role1" });

		// Act
		author.Id = "new-id";
		author.UserName = "new-name";
		author.Email = "new-email";
		author.Roles = new List<string> { "Role2", "Role3" };

		// Assert
		author.Id.Should().Be("new-id");
		author.UserName.Should().Be("new-name");
		author.Email.Should().Be("new-email");
		author.Roles.Should().BeEquivalentTo(new[] { "Role2", "Role3" });
	}

}