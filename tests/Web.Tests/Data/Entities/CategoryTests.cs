// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Domain.Tests.Unit
// =======================================================

using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using JetBrains.Annotations;

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
		category.Id.Should().NotBe(Guid.Empty);

	}

	[Fact]
	public void Category_Empty_ShouldReturnEmptyInstance()
	{

		// Arrange & Act
		var category = Category.Empty;

		// Assert
		category.Id.Should().Be(Guid.Empty);
		category.Name.Should().BeEmpty();
		category.CreatedOn.Should().BeCloseTo(DateTime.Now, TimeSpan.FromDays(1));
		category.ModifiedOn.Should().BeNull();

	}

	[Theory]
	[InlineData("Test Name")]
	[InlineData("Another Name")]
	public void Category_WhenPropertiesSet_ShouldHaveCorrectValues(
			string name)
	{

		// Arrange & Act
		var category = new Category(name);

		// Assert
		category.Id.Should().NotBe(Guid.Empty);
		category.Name.Should().NotBeEmpty();
		category.Name.Should().Be(name);
		category.CreatedOn.Should().BeCloseTo(DateTimeOffset.Now, TimeSpan.FromDays(1));
		category.ModifiedOn.Should().BeNull(); // Default value

	}

	[Fact]
	public void Category_Constructor_ShouldSetNameAndInitializeArticles()
	{
		// Arrange
		var name = "Tech";

		// Act
		var category = new Category(name);

		// Assert
		category.Name.Should().Be(name);
		category.Articles.Should().NotBeNull();
		category.Articles.Should().BeEmpty();
	}

	[Fact]
	public void Category_Properties_ShouldBeMutable()
	{
		// Arrange
		var category = new Category("OldName");
		const string newName = "NewName";
		var articles = new List<Article> { };

		// Act
		category.Name = newName;
		category.Articles = articles;

		// Assert
		category.Name.Should().Be(newName);
		category.Articles.Should().BeSameAs(articles);
	}

}