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
		// Arrange & Act
		const string expected = "Publication-Server";
		// Assert
		Services.SERVER.Should().Be(expected);
	}

	/// <summary>
	/// Ensures the DATABASE constant is correct.
	/// </summary>
	[Fact]
	public void DatabaseConstant_ShouldBeExpectedValue()
	{
		const string expected = "PublicationDb";
		Services.DATABASE.Should().Be(expected);
	}

	/// <summary>
	/// Ensures the WEBSITE constant is correct.
	/// </summary>
	[Fact]
	public void WebsiteConstant_ShouldBeExpectedValue()
	{
		const string expected = "Web";
		Services.WEBSITE.Should().Be(expected);
	}

	/// <summary>
	/// Ensures the CACHE constant is correct.
	/// </summary>
	[Fact]
	public void CacheConstant_ShouldBeExpectedValue()
	{
		const string expected = "RedisCache";
		Services.CACHE.Should().Be(expected);
	}
}