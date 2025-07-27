// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     EntityTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using JetBrains.Annotations;

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
		entity.Id.Should().NotBe(Guid.Empty);

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

	private class TestEntity : Entity { }

}