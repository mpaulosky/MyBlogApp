// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Entity.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : TailwindBlog
// Project Name :  Domain
// =======================================================

using System.ComponentModel.DataAnnotations;

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
	[Key]
	[Required]
	public Guid Id { get; protected init; } = Guid.CreateVersion7();

	/// <summary>
	///   Gets the date and time when this entity was created.
	/// </summary>
	[Required(ErrorMessage = "A Created On Date is required")]
	[Display(Name = "Created On")]
	public DateTimeOffset CreatedOn { get; protected init; } = DateTime.UtcNow;

	/// <summary>
	///   Gets or sets the date and time when this entity was last modified.
	/// </summary>
	[Display(Name = "Modified On")]
	public DateTimeOffset? ModifiedOn { get; set; }

}