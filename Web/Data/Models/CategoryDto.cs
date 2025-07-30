// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDto.cs
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
///   Represents a data transfer object for a category.
/// </summary>
[Serializable]
public class CategoryDto
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public CategoryDto(ObjectId empty) : this(ObjectId.Empty, string.Empty, null, null) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="CategoryDto" /> class.
	/// </summary>
	/// <param name="id"></param>
	/// <param name="name">The name of the category.</param>
	/// <param name="createdOn">The date the category was created.</param>
	/// <param name="modifiedOn">The date the category was last modified.</param>
	public CategoryDto(
			ObjectId id,
			string name,
			DateTimeOffset? createdOn,
			DateTimeOffset? modifiedOn)
	{
		Id = id;
		Name = name;
		CreatedOn = createdOn;
		ModifiedOn = modifiedOn;
	}

	/// <summary>
	///   Gets or sets the unique identifier for the category.
	/// </summary>
	[Required(ErrorMessage = "Id is required")]
	public ObjectId Id { get; set; }

	/// <summary>
	///   Gets the name of the category.
	/// </summary>
	[Required(ErrorMessage = "Name is required")]
	[Length(3, 80, ErrorMessage = "Name must be between 3 and 80 characters long")]
	public string Name { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the category was created.
	/// </summary>
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? CreatedOn { get; set; }

	/// <summary>
	///   Gets or sets the date and time when the category was last modified.
	/// </summary>
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? ModifiedOn { get; set; }

	/// <summary>
	///   Gets an empty category instance.
	/// </summary>
	/// <param name="empty">An empty ObjectId.</param>
	/// <returns>An empty <see cref="CategoryDto" /> instance.</returns>
	public static CategoryDto Empty => new(ObjectId.Empty, string.Empty, null, null);

}