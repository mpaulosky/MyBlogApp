// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Author.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Web.Data.Entities;

/// <summary>
///   Domain entity representing an application user.
/// </summary>
[Serializable]
public class Author
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public Author() : this(string.Empty, string.Empty, string.Empty, []) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="Author" /> class.
	/// </summary>
	/// <param name="id">The users Id</param>
	/// <param name="userName">The username of the user.</param>
	/// <param name="email">The email address of the user.</param>
	/// <param name="roles">The list of roles assigned to the user.</param>
	public Author(string id, string userName, string email, List<string> roles)
	{
		Id = id;
		UserName = userName;
		Email = email;
		Roles = roles;
	}

	/// <summary>
	///   Gets or sets the id of the user.
	/// </summary>
	[BsonElement("id")]
	[BsonRepresentation(BsonType.String)]
	[Display(Name = "Author ID")]
	public string Id { get; set; }

	/// <summary>
	///   Gets or sets the username of the user.
	/// </summary>
	[BsonElement("userName")]
	[BsonRepresentation(BsonType.String)]
	[Display(Name = "User Name")]
	public string UserName { get; set; }

	/// <summary>
	///   Gets or sets the email address of the user.
	/// </summary>
	[BsonElement("email")]
	[BsonRepresentation(BsonType.String)]
	[Display(Name = "Email Address")]
	public string Email { get; set; }

	/// <summary>
	///   Gets or sets the list of roles assigned to the user.
	/// </summary>
	[BsonElement("roles")]
	[Display(Name = "User Roles")]
	public List<string> Roles { get; set; }

	/// <summary>
	///   Gets an empty instance of Author with default values.
	/// </summary>
	public static Author Empty => new(string.Empty, string.Empty, string.Empty, []);

}