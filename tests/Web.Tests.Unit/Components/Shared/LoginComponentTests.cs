// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     LoginComponentTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Web.Tests.Unit
// =======================================================

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Components.Shared;

/// <summary>
///   Unit tests for the LoginComponent component.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(LoginComponent))]
public class LoginComponentTests : BunitContext
{

	[Theory]
	[InlineData(true, false, "Log out")]
	[InlineData(false, false, "Log in")]
	public void LoginComponent_RendersCorrectly(bool isAuthorized, bool hasRoles, string expectedText)
	{
		// Arrange
		Helpers.SetAuthorization(this, isAuthorized, hasRoles);

		// Act
		var cut = Render<LoginComponent>();

		// Assert
		cut.MarkupMatches(
				$"""<a href="Account/{(isAuthorized ? "Logout" : "Login")}">{expectedText}</a>"""); // Update selector as needed

	}

}