// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using MongoDB.Bson;

namespace Web.Data.Models;

[ExcludeFromCodeCoverage]
[TestSubject(typeof(ArticleDto))]
public class ArticleDtoTests
{

	private static readonly DateTimeOffset _staticDate = new(2025, 1, 1, 0, 0, 0, TimeSpan.Zero);

	[Fact]
	public void ArticleDto_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		var dto = new ArticleDto();
		dto.Title.Should().BeEmpty();
		dto.Introduction.Should().BeEmpty();
		dto.Content.Should().BeEmpty();
		dto.CoverImageUrl.Should().BeEmpty();
		dto.UrlSlug.Should().BeEmpty();
		dto.Category.Should().BeEquivalentTo(CategoryDto.Empty);
		dto.Author.Should().BeEquivalentTo(AuthorDto.Empty);
		dto.CreatedOn.Should().BeNull();
		dto.ModifiedOn.Should().BeNull();
		dto.IsPublished.Should().BeFalse();
		dto.PublishedOn.Should().BeNull();
	}

	[Fact]
	public void ArticleDto_Empty_ShouldReturnEmptyInstance()
	{
		var dto = ArticleDto.Empty;
		dto.Title.Should().BeEmpty();
		dto.Introduction.Should().BeEmpty();
		dto.Content.Should().BeEmpty();
		dto.CoverImageUrl.Should().BeEmpty();
		dto.UrlSlug.Should().BeEmpty();
		dto.Category.Should().BeEquivalentTo(CategoryDto.Empty);
		dto.Author.Should().BeEquivalentTo(AuthorDto.Empty);
		dto.CreatedOn.Should().BeNull();
		dto.ModifiedOn.Should().BeNull();
		dto.IsPublished.Should().BeFalse();
		dto.PublishedOn.Should().BeNull();
	}

	[Fact]
	public void ArticleDto_Constructor_ShouldSetProperties()
	{
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

		var dto = new ArticleDto(title, intro, content, cover, slug, author, category, createdOn, modifiedOn, isPublished,
				publishedOn);

		dto.Title.Should().Be(title);
		dto.Introduction.Should().Be(intro);
		dto.Content.Should().Be(content);
		dto.CoverImageUrl.Should().Be(cover);
		dto.UrlSlug.Should().Be(slug);
		dto.Category.Should().Be(category);
		dto.Author.Should().Be(author);
		dto.CreatedOn.Should().Be(createdOn);
		dto.ModifiedOn.Should().Be(modifiedOn);
		dto.IsPublished.Should().BeTrue();
		dto.PublishedOn.Should().Be(publishedOn);
	}

	[Fact]
	public void ArticleDto_Properties_ShouldBeMutable()
	{
		var dto = new ArticleDto();
		var newCategory = new CategoryDto(ObjectId.GenerateNewId(), "Science", _staticDate, _staticDate);
		var newAuthor = new AuthorDto("id", "name", "mail", ["Role1"]);
		var newCreatedOn = _staticDate;
		var newModifiedOn = _staticDate;
		var newPublishedOn = _staticDate;

		dto.Title = "New Title";
		dto.Introduction = "New Intro";
		dto.Content = "New Content";
		dto.CoverImageUrl = "new-cover.jpg";
		dto.UrlSlug = "new-title";
		dto.Category = newCategory;
		dto.Author = newAuthor;
		dto.CreatedOn = newCreatedOn;
		dto.ModifiedOn = newModifiedOn;
		dto.IsPublished = true;
		dto.PublishedOn = newPublishedOn;

		dto.Title.Should().Be("New Title");
		dto.Introduction.Should().Be("New Intro");
		dto.Content.Should().Be("New Content");
		dto.CoverImageUrl.Should().Be("new-cover.jpg");
		dto.UrlSlug.Should().Be("new-title");
		dto.Category.Should().Be(newCategory);
		dto.Author.Should().Be(newAuthor);
		dto.CreatedOn.Should().Be(newCreatedOn);
		dto.ModifiedOn.Should().Be(newModifiedOn);
		dto.IsPublished.Should().BeTrue();
		dto.PublishedOn.Should().Be(newPublishedOn);
	}

}