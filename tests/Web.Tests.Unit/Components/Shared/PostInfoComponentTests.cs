// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     PostInfoComponentTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Web.Tests.Bunit
// =======================================================

using MongoDB.Bson;

using Web.Data.Models;

namespace Web.Components.Shared;

/// <summary>
///   bUnit tests for PostInfoComponent.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(PostInfoComponent))]
public class PostInfoComponentTests : BunitContext
{

	private static readonly DateTimeOffset _staticDate = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	[Fact]
	public void Should_Render_Author_And_Category()
	{
		// Arrange
		const string title = "Test Title";
		const string intro = "Test Intro";
		const string content = "Test Content";
		const string cover = "cover.jpg";
		const string slug = "test-title";
		var author = new AuthorDto("author-1", "AuthorName", "author@email.com", ["Writer"]);
		var category = new CategoryDto(ObjectId.GenerateNewId(), "Test Category", _staticDate, _staticDate);
		var createdOn = _staticDate;
		var modifiedOn = _staticDate;
		const bool isPublished = true;
		var publishedOn = _staticDate;

		var dto = new ArticleDto(title, intro, content, cover, slug, author, category, createdOn, modifiedOn, isPublished, publishedOn);

		const string expectedHtml =
				"""
				<div class="flex gap-4 border-t border-gray-200 pt-4">
				  <div>Author: AuthorName</div>
				  <div>Created: 1/1/2025</div>
				  <div>Published: 1/1/2025</div>
				  <div>Categories: Test Category</div>
				</div>
				""";

		// Act
		var cut = Render<PostInfoComponent>(parameters => parameters
				.Add(p => p.Article, dto));

		// Assert
		cut.MarkupMatches(expectedHtml);

	}

	[Fact]
	public void Renders_With_Default_Parameters()
	{
		var cut = Render<PostInfoComponent>();
		cut.Markup.Should().NotBeNullOrWhiteSpace();
	}

}