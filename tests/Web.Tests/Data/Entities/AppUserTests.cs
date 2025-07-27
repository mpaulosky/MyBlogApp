// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AppUserTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using JetBrains.Annotations;

namespace Web.Data.Entities;

/// <summary>
///   Unit tests for the <see cref="AppUser" /> entity.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(AppUser))]
public class AppUserTests
{

	[Fact]
	public void AppUser_Constructor_WithParameters_ShouldSetProperties()
	{

		// Arrange
		var id = "user-1";
		var userName = "TestUser";
		var email = "test@example.com";
		var roles = new List<string> { "Admin", "Editor" };

		// Act
		var user = new AppUser(id, userName, email, roles);

		// Assert
		user.Id.Should().Be(id);
		user.UserName.Should().Be(userName);
		user.Email.Should().Be(email);
		user.Roles.Should().BeEquivalentTo(roles);
		
	}

	[Fact]
	public void AppUser_Empty_ShouldReturnEmptyInstance()
	{

		// Arrange & Act
		var user = Author.Empty;

		// Assert
		user.Id.Should().BeEmpty();
		user.UserName.Should().BeEmpty();
		user.Email.Should().BeEmpty();
		user.Roles.Should().BeEmpty();

	}

	[Fact]
	public void AppUser_Constructor_WithNullRoles_ShouldSetEmptyRoles()
	{
		// Arrange
		var id = "user-2";
		var userName = "NullRoleUser";
		var email = "nullrole@example.com";

		// Act
		var user = new AppUser(id, userName, email, null);

		// Assert
		user.Id.Should().Be(id);
		user.UserName.Should().Be(userName);
		user.Email.Should().Be(email);
		user.Roles.Should().NotBeNull();
		user.Roles.Should().BeEmpty();
	}

	[Fact]
	public void AppUser_Properties_ShouldBeMutable()
	{
		// Arrange
		var user = new AppUser("id", "name", "email", new List<string> { "Role1" });

		// Act
		user.Id = "new-id";
		user.UserName = "new-name";
		user.Email = "new-email";
		user.Roles = new List<string> { "Role2", "Role3" };

		// Assert
		user.Id.Should().Be("new-id");
		user.UserName.Should().Be("new-name");
		user.Email.Should().Be("new-email");
		user.Roles.Should().BeEquivalentTo(new[] { "Role2", "Role3" });
	}

}