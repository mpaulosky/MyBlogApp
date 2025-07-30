// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using MongoDB.Bson;

namespace Web.Data.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Category))]
public class CategoryTests
{

	private static readonly DateTime _staticDate = new(2025, 1, 1);

	[Fact]
	public void Category_WhenCreated_ShouldHaveEmptyProperties()
	{

		// Arrange & Act
		var category = new Category(string.Empty);

		// Assert
		category.Name.Should().BeEmpty();
		category.Id.Should().NotBe(ObjectId.Empty);

	}

	[Fact]
	public void Category_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		// Act
		var category = new Category();

		// Assert
		category.Name.Should().BeEmpty();
		category.Id.Should().NotBeNull();
	}

	[Fact]
	public void Category_Empty_ShouldReturnEmptyInstance()
	{

		// Arrange & Act
		var category = Category.Empty;

		// Assert
		category.Id.Should().Be(MongoDB.Bson.ObjectId.Empty);
		category.Name.Should().BeEmpty();
	}

	[Theory]
	[InlineData("Test Name")]
	[InlineData("Another Name")]
	public void Category_Constructor_ShouldSetName(
			string name)
	{

		// Act
		var category = new Category(name);

		// Assert
		category.Name.Should().Be(name);
		category.Id.Should().NotBeNull();
	}

	[Fact]
	public void Category_Properties_ShouldBeMutable()
	{
		// Arrange
		var category = new Category("OldName");
		var newName = "NewName";

		// Act
		category.Name = newName;

		// Assert
		category.Name.Should().Be(newName);
		category.Id.Should().NotBeNull(); // Id should remain unchanged
	}

}