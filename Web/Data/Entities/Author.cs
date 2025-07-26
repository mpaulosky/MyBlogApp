// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     Author.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web
// =======================================================

using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities;

/// <summary>
///   Represents an author/user in the system.
/// </summary>
public class Author
{
	/// <summary>
	///   Initializes a new instance of the <see cref="Author"/> class.
	/// </summary>
	/// <param name="id">The author ID.</param>
	/// <param name="userName">The username.</param>
	/// <param name="email">The email address.</param>
	/// <param name="roles">The list of roles.</param>
	private Author(string id, string userName, string email, List<string> roles)
	{
		Id = id;
		UserName = userName;
		Email = email;
		Roles = roles;
	}

	/// <summary>
	///   Initializes a new instance of the <see cref="Author"/> class for EF.
	/// </summary>
	internal Author()
	{
	}

	/// <summary>
	///   Gets or sets the id of the user.
	/// </summary>
	[Display(Name = "Author ID")]
	public string Id { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the username of the user.
	/// </summary>
	[Display(Name = "User Name")]
	public string UserName { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the email address of the user.
	/// </summary>
	[Display(Name = "Email Address")]
	public string Email { get; set; } = string.Empty;

	/// <summary>
	///   Gets or sets the list of roles assigned to the user.
	/// </summary>
	[Display(Name = "User Roles")]
	public List<string> Roles { get; set; } = [];

	/// <summary>
	///   Gets an empty instance of Author with default values.
	/// </summary>
	public static readonly Author Empty = new(string.Empty, string.Empty, string.Empty, new List<string>());

}