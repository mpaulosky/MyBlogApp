// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     NavMenuComponentTest.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Web.Tests.Bunit
// =======================================================

using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Components.Layout;

/// <summary>
///   bUnit tests for NavMenuComponent.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(NavMenuComponent))]
public class NavMenuComponentTests : BunitContext
{

	public NavMenuComponentTests()
	{

		Services.AddScoped<CascadingAuthenticationState>();

	}

	[Theory]
	[InlineData(true, false, "Log out")]
	[InlineData(false, false, "Log in")]
	public void Should_Render_NavMenu_Links(bool isAuthorized, bool hasRoles, string expectedText)
	{

		// Arrange
		Helpers.SetAuthorization(this, isAuthorized, hasRoles);

		// Act
		var cut = Render<NavMenuComponent>();

		// Assert
		cut.Markup.Should().Contain("Articles");
		cut.Markup.Should().Contain("Categories");
		cut.Markup.Should().Contain("Contact");
		cut.Markup.Should().Contain("About");
		cut.Markup.Should().Contain("MyBlogApp");
		cut.Markup.Should().Contain(expectedText);
		cut.Markup.Should().Contain("p-1 hover:text-blue-700");

	}

}