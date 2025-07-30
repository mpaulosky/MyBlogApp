// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Entity.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web.Data.Abstractions;

/// <summary>
///   Base class for all entities in the domain model.
/// </summary>
[Serializable]
public abstract class Entity
{

	/// <summary>
	///   Gets the unique identifier for this entity.
	/// </summary>
	[BsonId]
	public ObjectId Id { get; protected init; } = ObjectId.GenerateNewId();

	/// <summary>
	///   Gets the date and time when this entity was created.
	/// </summary>
	[Required(ErrorMessage = "A Created On Date is required")]
	[Display(Name = "Created On")]
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

	/// <summary>
	///   Gets or sets the date and time when this entity was last modified.
	/// </summary>
	[Display(Name = "Modified On")]
	[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
	public DateTimeOffset? ModifiedOn { get; set; }

}