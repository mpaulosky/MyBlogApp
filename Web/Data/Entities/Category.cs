// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Categories.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Web.Data.Abstractions;

namespace Web.Data.Entities;

/// <summary>
///   Represents a blog category that can be assigned to posts.
/// </summary>
[Serializable]
public class Category : Entity
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public Category() : this(string.Empty) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="Category" /> class.
	/// </summary>
	/// <param name="name">The name of the category.</param>
	public Category(string name)
	{
		Name = name;
	}

	/// <summary>
	///   Gets or sets the name of the category.
	/// </summary>
	[BsonElement("name")]
	[BsonRepresentation(BsonType.String)]
	public string Name { get; set; }

	/// <summary>
	///   Gets the name of the category.
	/// </summary>
	public static Category Empty => new(string.Empty) { Id = ObjectId.Empty };

}