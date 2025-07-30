// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ServiceTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Shared.Tests
// =======================================================

using System.Diagnostics.CodeAnalysis;

using FluentAssertions;

using JetBrains.Annotations;

namespace Shared;

/// <summary>
/// Unit tests for the <see cref="Services"/> static class constants.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(Services))]
public class ServiceTests
{

	/// <summary>
	/// Ensures the SERVER constant is correct.
	/// </summary>
	[Fact]
	public void ServerConstant_ShouldBeExpectedValue()
	{

		// Arrange
		const string expected = "Article-Server";

		// Act
		var actual = Services.SERVER;

		// Assert
		actual.Should().Be(expected);
		
	}

	/// <summary>
	/// Ensures the DATABASE constant is correct.
	/// </summary>
	[Fact]
	public void DatabaseConstant_ShouldBeExpectedValue()
	{

		// Arrange
		const string expected = "ArticleDb";

		// Act
		const string actual = Services.DATABASE;

		// Assert
		actual.Should().Be(expected);
		
	}

	/// <summary>
	/// Ensures the CONNECTION constant is correct.
	/// </summary>
	[Fact]
	public void SqlConnectionConstant_ShouldBeExpectedValue()
	{

		// Arrange
		const string expected = "ArticleConnection";

		// Act
		const string actual = Services.SQLCONNECTION;

		// Assert
		actual.Should().Be(expected);
		
	}

	/// <summary>
	/// Ensures the WEBSITE constant is correct.
	/// </summary>
	[Fact]
	public void WebsiteConstant_ShouldBeExpectedValue()
	{

		// Arrange
		const string expected = "Web";

		// Act
		const string actual = Services.WEBSITE;

		// Assert
		actual.Should().Be(expected);
		
	}

	/// <summary>
	/// Ensures the CACHE constant is correct.
	/// </summary>
	[Fact]
	public void CacheConstant_ShouldBeExpectedValue()
	{

		// Arrange
		const string expected = "RedisCache";

		// Act
		const string actual = Services.CACHE;

		// Assert
		actual.Should().Be(expected);
		
	}
	

}