// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     EntityTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using Xunit.Internal;

namespace Web.Data.Abstractions;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Entity))]
public class EntityTests
{

	[Fact]
	public void Entity_WhenCreated_ShouldHaveValidId()
	{
		// Arrange & Act
		var entity = new TestEntity();

		// Assert
		entity.Id.Should().NotBe(MongoDB.Bson.ObjectId.Empty);
	}

	[Fact]
	public void Entity_WhenCreated_ShouldHaveCurrentUtcTime()
	{
		// Arrange & Act
		var entity = new TestEntity();

		// Assert
		entity.CreatedOn.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromSeconds(2));
	}

	[Fact]
	public void Entity_WhenCreated_ShouldHaveNullModifiedOn()
	{
		// Arrange & Act
		var entity = new TestEntity();

		// Assert
		entity.ModifiedOn.Should().BeNull();
	}

	[Fact]
	public void Entity_ModifiedOn_ShouldBeMutable()
	{
		// Arrange
		var entity = new TestEntity();
		var now = DateTimeOffset.UtcNow;

		// Act
		entity.ModifiedOn = now;

		// Assert
		entity.ModifiedOn.Should().Be(now);
	}

	[Fact]
	public void Entity_WhenCreated_ShouldHaveCreatedOnUtcKind()
	{
		// Arrange & Act
		DateTimeOffset now = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);
		var entity = new TestEntity();
		entity.CreatedOn = now;

		// Assert
		entity.CreatedOn.Should().Be(now);
		entity.CreatedOn.Offset.Should().Be(TimeSpan.Zero);
	}

	private class TestEntity : Entity { }

}