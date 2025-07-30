// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AppUserTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

namespace Web.Data.Entities;

/// <summary>
///   Unit tests for the <see cref="AppUser" /> entity.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(AppUser))]
public class AppUserTests
{

	[Fact]
	public void AppUser_ParameterlessConstructor_ShouldSetDefaultValues()
	{

		// Arrange & Act
		var user = new AppUser();

		// Assert
		user.Id.Should().BeEmpty();
		user.UserName.Should().BeEmpty();
		user.Email.Should().BeEmpty();
		user.Roles.Should().BeEmpty();

	}

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
		var user = AppUser.Empty;

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
		const string id = "user-2";
		const string userName = "NullRoleUser";
		const string email = "nullrole@example.com";

		// Act
		var user = new AppUser(id, userName, email, null);

		// Assert
		user.Id.Should().Be(id);
		user.UserName.Should().Be(userName);
		user.Email.Should().Be(email);
		user.Roles.Should().BeNull();
	}

	[Fact]
	public void AppUser_Properties_ShouldBeMutable()
	{
		// Arrange
		var user = new AppUser("id", "name", "email", ["Role1"])
		{
			// Act
			Id = "new-id",
			UserName = "new-name",
			Email = "new-email",
			Roles = ["Role2", "Role3"]
		};

		// Assert
		user.Id.Should().Be("new-id");
		user.UserName.Should().Be("new-name");
		user.Email.Should().Be("new-email");
		user.Roles.Should().BeEquivalentTo(new[] { "Role2", "Role3" });
	}

}