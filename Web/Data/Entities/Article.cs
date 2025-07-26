// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Article.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web
// =======================================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Web.Data.Abstractions;

namespace Web.Data.Entities;

public class Article : Entity
{

	/// <summary>
	///   Initializes a new instance of the <see cref="Article" /> class with specified values.
	/// </summary>
	/// <param name="title">The title of the article.</param>
	/// <param name="introduction">The introduction of the article.</param>
	/// <param name="content">The main content of the article.</param>
	/// <param name="coverImageUrl">The URL of the cover image for the article.</param>
	/// <param name="urlSlug">The URL slug for the article.</param>
	/// <param name="authorId">The author ID of the article.</param>
	/// <param name="categoryId">The category ID of the article.</param>
	/// <param name="category">The category associated with the article.</param>
	/// <param name="author">The author associated with the article.</param>
	/// <param name="isPublished">A value indicating whether the article is published.</param>
	/// <param name="publishedOn">The date and time when the article was published.</param>
	public Article(
			string title,
			string introduction,
			string content,
			string coverImageUrl,
			string urlSlug,
			string authorId,
			Guid categoryId,
			Category category,
			Author author,
			bool isPublished = false,
			DateTime? publishedOn = null)
	{
		Title = title;
		Introduction = introduction;
		Content = content;
		CoverImageUrl = coverImageUrl;
		UrlSlug = urlSlug;
		AuthorId = authorId;
		CategoryId = categoryId;
		Category = category;
		Author = author;
		IsPublished = isPublished;
		PublishedOn = publishedOn;
	}
	
	/// <summary>
	///   Initializes a new instance of the <see cref="Article"/> class for EF.
	/// </summary>
	internal Article()
	{
	}

	/// <summary>
	///   Gets or sets the title of the article.
	/// </summary>
	[Required]
	[MaxLength(120)]
	public string Title { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the introduction of the article.
	/// </summary>
	[MaxLength(250)]
	public string Introduction { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the main content of the article.
	/// </summary>
	[Required]
	[MaxLength(5000)]
	public string Content { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the URL of the cover image for the article.
	/// </summary>
	[MaxLength(250)]
	public string CoverImageUrl { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the URL slug for the article, used in the article's URL.
	/// </summary>
	[Required]
	[MaxLength(120)]
	public string UrlSlug { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the author ID of the article.
	/// </summary>
	[Required]
	[ForeignKey(nameof(Author))]
	[MaxLength(36)] // Assuming AuthorId is a GUID stored as a string
	public string AuthorId { get; set; } = string.Empty;

	/// <summary>
	///   Represents the author entity associated with the article.
	///   This property defines the relationship between an article and its author.
	///   It establishes a navigational property that links the article to the author who created it.
	/// </summary>
	public Author Author { get; set; } = Author.Empty;

	/// <summary>
	///   Gets or sets the category ID of the article.
	/// </summary>
	[ForeignKey(nameof(Category))]
	public Guid CategoryId { get; set; }

	/// <summary>
	///   Represents the category entity associated with the article.
	///   This property defines the relationship between an article and its category.
	///   It establishes a navigational property that links the article to the category under which it is published.
	/// </summary>
	public Category Category { get; set; } = Category.Empty;

	/// <summary>
	///   Gets or sets a value indicating whether the article is published.
	/// </summary>
	public bool IsPublished { get; set; }


	/// <summary>
	///   Gets or sets the date and time when the article was published.
	///   This property is nullable and will only have a value for published articles.
	/// </summary>
	public DateTimeOffset? PublishedOn { get; set; }

}