// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AuthorDto.cs
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
///   Data Transfer Object (DTO) representing an author user.
/// </summary>
[Serializable]
public class AuthorDto
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public AuthorDto() : this(string.Empty, string.Empty, string.Empty, []) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="AuthorDto" /> class.
	/// </summary>
	/// <param name="id">The unique identifier for the user.</param>
	/// <param name="userName">The username of the user.</param>
	/// <param name="email">The email address of the user.</param>
	/// <param name="roles">The list of roles assigned to the user.</param>
	public AuthorDto(string id, string userName, string email, List<string> roles)
	{
		Id = id;
		UserName = userName;
		Email = email;
		Roles = roles;
	}

	/// <summary>
	///   Gets or sets the unique identifier for the user.
	/// </summary>
	[Display(Name = "Author ID")]
	[Required(ErrorMessage = "Id is required")]
	[BsonRepresentation(BsonType.String)]
	public string Id { get; init; }

	/// <summary>
	///   Gets or sets the username of the user.
	/// </summary>
	[Display(Name = "User Name")]
	public string UserName { get; set; }

	/// <summary>
	///   Gets or sets the email address of the user.
	/// </summary>
	[Display(Name = "Email Address")]
	public string Email { get; set; }

	/// <summary>
	///   Gets or sets the list of roles assigned to the user.
	/// </summary>
	[Display(Name = "User Roles")]
	public List<string>? Roles { get; set; }

	/// <summary>
	///   Gets an empty instance of AuthorDto with default values.
	/// </summary>
	public static AuthorDto Empty => new(string.Empty, string.Empty, string.Empty, []);

}