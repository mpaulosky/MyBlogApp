// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleTests.cs
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
[TestSubject(typeof(Article))]
public class ArticleTests
{

	private static readonly DateTime _staticDate = new(2025, 1, 1);

	[Fact]
	public void Article_WhenCreated_ShouldHaveEmptyProperties()
	{

		// Arrange & Act
		var article = new Article(
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				Author.Empty.Id,
				Category.Empty.Id,
				Category.Empty,
				Author.Empty
		);

		// Assert
		article.Title.Should().BeEmpty();
		article.Introduction.Should().BeEmpty();
		article.CoverImageUrl.Should().BeEmpty();
		article.UrlSlug.Should().BeEmpty();
		article.Author.Should().BeEquivalentTo(Author.Empty);
		article.Category.Name.Should().Be(Category.Empty.Name);
		article.Category.Id.Should().Be(Category.Empty.Id);
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();
		article.ModifiedOn.Should().BeNull();

	}

	[Fact]
	public void Article_Empty_ShouldReturnEmptyInstance()
	{

		// Arrange & Act
		var article = Article.Empty;

		// Assert
		article.Title.Should().BeEmpty();
		article.Introduction.Should().BeEmpty();
		article.CoverImageUrl.Should().BeEmpty();
		article.UrlSlug.Should().BeEmpty();
		article.Author.Should().BeEquivalentTo(Author.Empty);
		article.Category.Name.Should().Be(Category.Empty.Name);
		article.Category.Id.Should().Be(Category.Empty.Id);
		article.IsPublished.Should().BeFalse();
		article.PublishedOn.Should().BeNull();
		article.ModifiedOn.Should().BeNull();

	}

	[Theory]
	[InlineData("Test Title", "Test Intro", "Content Test Title", "https://test.com/image.jpg", "https://test.com/test_title")]
	[InlineData("Another Title", "Another Intro", "Content Another Title", "https://test.com/another.jpg", "https://test.com/another_title")]
	public void Article_WhenPropertiesSet_ShouldHaveCorrectValues(
			string title,
			string introduction,
			string content,
			string coverImageUrl,
			string urlSlug)
	{

		// Arrange & Act
		var article = new Article(
				title,
				introduction,
				content,
				coverImageUrl,
				urlSlug,
				Author.Empty.Id,
				Category.Empty.Id,
				Category.Empty,
				Author.Empty
				);

		// Assert
		article.Title.Should().Be(title);
		article.Introduction.Should().Be(introduction);
		article.Content.Should().Be(content);
		article.CoverImageUrl.Should().Be(coverImageUrl);
		article.UrlSlug.Should().Be(urlSlug);
		article.Author.Should().BeEquivalentTo(Author.Empty);
		article.IsPublished.Should().BeFalse(); // Default value
		article.PublishedOn.Should().BeNull(); // Default value
		article.ModifiedOn.Should().BeNull(); // Default value

	}

	[Fact]
	public void Article_WhenPublished_ShouldSetPublishedProperties()
	{

		// Arrange
		const string title = "Published Article";
		const string introduction = "This is a published article.";
		const string content = "Full content of the article.";
		const string coverImageUrl = "https://example.com/cover.jpg";
		const string urlSlug = "published_article";
		const bool isPublished = true;
		var publishedOn = _staticDate;
		var author = Author.Empty;
		var category = Category.Empty;

		var article = new Article(
				title,
				introduction,
				content,
				coverImageUrl,
				urlSlug,
				author.Id,
				category.Id,
				category,
				author,
				isPublished,
				publishedOn
		);

		// Assert
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(publishedOn);
		article.Author.Should().BeEquivalentTo(author);
		article.CreatedOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(2));

	}

	[Fact]
	public void Article_Constructor_ShouldSetAllProperties()
	{
		// Arrange
		var title = "Test Title";
		var intro = "Test Intro";
		var content = "Test Content";
		var cover = "cover.jpg";
		var slug = "test-title";
		var authorId = "author-1";
		var categoryId = Guid.NewGuid();
		var category = new Category("Tech");
		var author = new Author(authorId, "AuthorName", "author@email.com", new List<string> { "Writer" });
		var isPublished = true;
		var publishedOn = DateTime.UtcNow;

		// Act
		var article = new Article(title, intro, content, cover, slug, authorId, categoryId, category, author, isPublished, publishedOn);

		// Assert
		article.Title.Should().Be(title);
		article.Introduction.Should().Be(intro);
		article.Content.Should().Be(content);
		article.CoverImageUrl.Should().Be(cover);
		article.UrlSlug.Should().Be(slug);
		article.AuthorId.Should().Be(authorId);
		article.CategoryId.Should().Be(categoryId);
		article.Category.Should().Be(category);
		article.Author.Should().Be(author);
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(publishedOn);
	}

	[Fact]
	public void Article_Properties_ShouldBeMutable()
	{
		// Arrange
		var article = new Article("a", "b", "c", "d", "e", "f", Guid.NewGuid(), Category.Empty, Author.Empty);
		const string newTitle = "New Title";
		var newIntro = "New Intro";
		const string newContent = "New Content";
		const string newCover = "new-cover.jpg";
		const string newSlug = "new-title";
		const string newAuthorId = "new-author";
		var newCategoryId = Guid.NewGuid();
		var newCategory = new Category("NewCat");
		var newAuthor = new Author("id", "name", "mail", new List<string>());
		const bool newPublished = true;
		var newPublishedOn = DateTime.UtcNow;

		// Act
		article.Title = newTitle;
		article.Introduction = newIntro;
		article.Content = newContent;
		article.CoverImageUrl = newCover;
		article.UrlSlug = newSlug;
		article.AuthorId = newAuthorId;
		article.CategoryId = newCategoryId;
		article.Category = newCategory;
		article.Author = newAuthor;
		article.IsPublished = newPublished;
		article.PublishedOn = newPublishedOn;

		// Assert
		article.Title.Should().Be(newTitle);
		article.Introduction.Should().Be(newIntro);
		article.Content.Should().Be(newContent);
		article.CoverImageUrl.Should().Be(newCover);
		article.UrlSlug.Should().Be(newSlug);
		article.AuthorId.Should().Be(newAuthorId);
		article.CategoryId.Should().Be(newCategoryId);
		article.Category.Should().Be(newCategory);
		article.Author.Should().Be(newAuthor);
		article.IsPublished.Should().BeTrue();
		article.PublishedOn.Should().Be(newPublishedOn);
	}

}