// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Article.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Web.Data.Abstractions;
using Web.Data.Models;

namespace Web.Data.Entities;

/// <summary>
///   Represents an article in the blog system.
/// </summary>
[Serializable]
public class Article : Entity
{

	// Parameterless constructor for serialization and test data generation.
	public Article() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, CategoryDto.Empty, AuthorDto.Empty, false, null) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="Article" /> class with specified values.
	/// </summary>
	/// <param name="title">The title of the article.</param>
	/// <param name="introduction">The introduction of the article.</param>
	/// <param name="content">The main content of the article.</param>
	/// <param name="coverImageUrl">The URL of the cover image for the article.</param>
	/// <param name="urlSlug">The URL slug for the article.</param>
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
			CategoryDto category,
			AuthorDto author,
			bool isPublished = false,
			DateTimeOffset? publishedOn = null)
	{
		Title = title;
		Introduction = introduction;
		Content = content;
		CoverImageUrl = coverImageUrl;
		UrlSlug = urlSlug;
		Category = category;
		Author = author;
		IsPublished = isPublished;
		PublishedOn = publishedOn;
	}

	/// <summary>
	///   Gets or sets the title of the article.
	/// </summary>
	[BsonElement("title")]
	[BsonRepresentation(BsonType.String)]
	public string Title { get; set; }

	/// <summary>
	///   Gets or sets the introduction of the article.
	/// </summary>
	[BsonElement("introduction")]
	[BsonRepresentation(BsonType.String)]
	public string Introduction { get; set; }

	/// <summary>
	///   Gets or sets the main content of the article.
	/// </summary>
	[BsonElement("content")]
	[BsonRepresentation(BsonType.String)]
	public string Content { get; set; }

	/// <summary>
	///   Gets or sets the URL of the cover image for the article.
	/// </summary>
	[BsonElement("coverImageUrl")]
	[BsonRepresentation(BsonType.String)]
	public string CoverImageUrl { get; set; }

	/// <summary>
	///   Gets or sets the URL slug for the article, used in the article's URL.
	/// </summary>
	[BsonElement("urlSlug")]
	[BsonRepresentation(BsonType.String)]
	public string UrlSlug { get; set; }

	/// <summary>
	///   Represents the author entity associated with the article.
	/// </summary>
	[BsonElement("author")]
	public AuthorDto Author { get; set; }

	/// <summary>
	///   Represents the category entity associated with the article.
	/// </summary>
	[BsonElement("category")]
	public CategoryDto Category { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether the article is published.
	/// </summary>
	[BsonElement("isPublished")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsPublished { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the article was published.
	/// </summary>
	[BsonElement("publishedOn")]
	[BsonRepresentation(BsonType.DateTime)]
	public DateTimeOffset? PublishedOn { get; set; }

	public static Article Empty { get; } = new(
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			CategoryDto.Empty,
			AuthorDto.Empty,
			false,
			null
	);

}