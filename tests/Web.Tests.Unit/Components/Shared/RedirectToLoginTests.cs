// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     RedirectToLoginTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Web.Tests.Bunit
// =======================================================

using Bunit.TestDoubles;

using Microsoft.Extensions.DependencyInjection;

namespace Web.Components.Shared;

/// <summary>
///   Unit tests for the RedirectToLogin component.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(RedirectToLogin))]
public class RedirectToLoginTests : BunitContext
{

	[Fact]
	public void RedirectToLoginComponent_RendersCorrectly()
	{

		// Arrange
		var navMan = Services.GetRequiredService<BunitNavigationManager>();

		// Act
		Render<RedirectToLogin>();

		// Assert
		navMan.Uri.Should().EndWith("/Account/LoginComponent");

	}

}