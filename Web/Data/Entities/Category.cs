// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Category.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web
// =======================================================

using System.ComponentModel.DataAnnotations;

using Web.Data.Abstractions;

namespace Web.Data.Entities;

/// <summary>
///   Represents a blog category.
/// </summary>
public class Category : Entity
{
	/// <summary>
	///   Initializes a new instance of the <see cref="Category"/> class.
	/// </summary>
	/// <param name="name">The name of the category.</param>
	public Category(string name)
	{
		Name = name;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="Category"/> class for EF.
	/// </summary>
	internal Category()
	{
	}

	/// <summary>
	///   Gets or sets the name of the category.
	/// </summary>
	[Required(ErrorMessage = "Name is required")]
	[MaxLength(80)]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the articles in this category.
	/// </summary>
	public ICollection<Article> Articles { get; set; } = new List<Article>();

	/// <summary>
	///   Gets an empty category instance.
	/// </summary>
	public static readonly Category Empty =
		new Category(string.Empty)
		{
			Id = Guid.Empty
		};
}