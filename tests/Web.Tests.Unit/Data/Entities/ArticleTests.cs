// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using MongoDB.Bson;

using Web.Data.Models;

namespace Web.Data.Entities;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(Article))]
public class ArticleTests
{

	private static readonly DateTimeOffset _staticDate = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	[Fact]
	public void Article_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		// Act
		var article = new Article();

		// Assert
		article.Title.Should().BeEmpty();
		article.Introduction.Should().BeEmpty();
		article.Content.Should().BeEmpty();
		article.CoverImageUrl.Should().BeEmpty();
		article.UrlSlug.Should().BeEmpty();
		article.Category.Should().BeEquivalentTo(CategoryDto.Empty);
		article.Author.Should().BeEquivalentTo(AuthorDto.Empty);
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();
	}

	[Fact]
	public void Article_Empty_ShouldReturnEmptyInstance()
	{
		// Act
		var article = Article.Empty;

		// Assert
		article.Title.Should().BeEmpty();
		article.Introduction.Should().BeEmpty();
		article.Content.Should().BeEmpty();
		article.CoverImageUrl.Should().BeEmpty();
		article.UrlSlug.Should().BeEmpty();
		article.Category.Should().BeEquivalentTo(CategoryDto.Empty);
		article.Author.Should().BeEquivalentTo(AuthorDto.Empty);
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();
	}

	[Theory]
	[InlineData("Test Title", "Test Intro", "Test Content", "https://test.com/image.jpg", "test-title")]
	[InlineData("Another Title", "Another Intro", "Another Content", "https://test.com/another.jpg", "another-title")]
	public void Article_Constructor_ShouldSetProperties(
			string title,
			string introduction,
			string content,
			string coverImageUrl,
			string urlSlug)
	{

		// Arrange
		var category = new CategoryDto(ObjectId.GenerateNewId(), "test", _staticDate, _staticDate);
		var author = new AuthorDto("author-1", "AuthorName", "author@email.com", ["Writer"]);

		// Act
		var article = new Article(title, introduction, content, coverImageUrl, urlSlug, category, author);

		// Assert
		article.Title.Should().Be(title);
		article.Introduction.Should().Be(introduction);
		article.Content.Should().Be(content);
		article.CoverImageUrl.Should().Be(coverImageUrl);
		article.UrlSlug.Should().Be(urlSlug);
		article.Category.Should().Be(category);
		article.Author.Should().Be(author);
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();
	}

	[Fact]
	public void Article_Constructor_WithPublished_ShouldSetPublishedProperties()
	{

		// Arrange
		var category = new CategoryDto(ObjectId.GenerateNewId(), "Science", _staticDate, _staticDate);
		var author = new AuthorDto("author-1", "AuthorName", "author@email.com", ["Writer"]);
		var publishedOn = _staticDate;

		// Act
		var article = new Article(
				"Published Title",
				"Published Intro",
				"Published Content",
				"cover.jpg",
				"published-title",
				category,
				author,
				true,
				publishedOn
		);

		// Assert
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(publishedOn);
		article.Category.Should().Be(category);
		article.Author.Should().Be(author);
	}

	[Fact]
	public void Article_Properties_ShouldBeMutable()
	{
		// Arrange
		var article = new Article();
		var newCategory = new CategoryDto(ObjectId.GenerateNewId(), "Science", _staticDate, _staticDate);
		var newAuthor = new AuthorDto("id", "name", "mail", ["Role1"]);
		var newPublishedOn = _staticDate;

		// Act
		article.Title = "New Title";
		article.Introduction = "New Intro";
		article.Content = "New Content";
		article.CoverImageUrl = "new-cover.jpg";
		article.UrlSlug = "new-title";
		article.Category = newCategory;
		article.Author = newAuthor;
		article.IsPublished = true;
		article.PublishedOn = newPublishedOn;

		// Assert
		article.Title.Should().Be("New Title");
		article.Introduction.Should().Be("New Intro");
		article.Content.Should().Be("New Content");
		article.CoverImageUrl.Should().Be("new-cover.jpg");
		article.UrlSlug.Should().Be("new-title");
		article.Category.Should().Be(newCategory);
		article.Author.Should().Be(newAuthor);
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(newPublishedOn);
	}

}