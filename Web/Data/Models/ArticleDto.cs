// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ArticleDto.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web.Data.Models;

/// <summary>
///   Data Transfer Object (DTO) representing an article.
/// </summary>
[Serializable]
public class ArticleDto
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public ArticleDto() : this(
			string.Empty, 
			string.Empty, 
			string.Empty, 
			string.Empty, 
			string.Empty, 
			AuthorDto.Empty, 
			CategoryDto.Empty, 
			null, 
			null) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="ArticleDto" /> class with specified values.
	/// </summary>
	/// <param name="title">The title of the article.</param>
	/// <param name="introduction">The introduction of the article.</param>
	/// <param name="content">The main content of the article.</param>
	/// <param name="coverImageUrl">The URL of the cover image for the article.</param>
	/// <param name="urlSlug">The URL slug for the article.</param>
	/// <param name="author">The author associated with the article.</param>
	/// <param name="category">The category associated with the article.</param>
	/// <param name="createdOn">The date and time when the article was created.</param>
	/// <param name="modifiedOn">The date and time when the article was last modified.</param>
	/// <param name="isPublished">A value indicating whether the article is published.</param>
	/// <param name="publishedOn">The date and time when the article was published.</param>
	public ArticleDto(
			string title,
			string introduction,
			string content,
			string coverImageUrl,
			string urlSlug,
			AuthorDto author,
			CategoryDto category,
			DateTimeOffset? createdOn,
			DateTimeOffset? modifiedOn,
			bool isPublished = false,
			DateTimeOffset? publishedOn = null)
	{
		Title = title;
		Introduction = introduction;
		Content = content;
		CoverImageUrl = coverImageUrl;
		UrlSlug = urlSlug;
		Author = author;
		Category = category;
		CreatedOn = createdOn;
		ModifiedOn = modifiedOn;
		IsPublished = isPublished;
		PublishedOn = publishedOn;
	}


	/// <summary>
	///   Gets or sets the title of the ArticleDto.
	/// </summary>
	[BsonElement("title")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(120)]
	public string Title { get; set; }

	/// <summary>
	///   Gets or sets the introduction of the ArticleDto.
	/// </summary>
	[BsonElement("introduction")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(250)]
	public string Introduction { get; set; }

	/// <summary>
	///   Gets or sets the main content of the ArticleDto.
	/// </summary>
	[BsonElement("content")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(5000)]
	public string Content { get; set; }

	/// <summary>
	///   Gets or sets the URL of the cover image for the ArticleDto.
	/// </summary>
	[BsonElement("coverImageUrl")]
	[BsonRepresentation(BsonType.String)]
	[MaxLength(250)]
	public string CoverImageUrl { get; set; }

	/// <summary>
	///   Gets or sets the URL slug for the ArticleDto, used in the ArticleDto's URL.
	/// </summary>
	[BsonElement("urlSlug")]
	[BsonRepresentation(BsonType.String)]
	[Required]
	[MaxLength(120)]
	public string UrlSlug { get; set; }

	/// <summary>
	///   Represents the author entity associated with the ArticleDto.
	/// </summary>
	[BsonElement("author")]
	public AuthorDto Author { get; set; }

	/// <summary>
	///   Represents the category entity associated with the ArticleDto.
	/// </summary>
	[BsonElement("category")]
	public CategoryDto Category { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the ArticleDto was created.
	/// </summary>
	[BsonElement("createdOn")]
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? CreatedOn { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the ArticleDto was last modified.
	/// </summary>
	[BsonElement("modifiedOn")]
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? ModifiedOn { get; set; }

	/// <summary>
	///   Gets or sets a value indicating whether the ArticleDto is published.
	/// </summary>
	[BsonElement("isPublished")]
	[BsonRepresentation(BsonType.Boolean)]
	public bool IsPublished { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the ArticleDto was published.
	/// </summary>
	[BsonElement("publishedOn")]
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? PublishedOn { get; set; }

	public static ArticleDto Empty { get; } = new(
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			string.Empty,
			AuthorDto.Empty,
			CategoryDto.Empty,
			null,
			null
	);

}