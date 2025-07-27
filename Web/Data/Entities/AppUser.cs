// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AppUser.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web
// =======================================================

using System.ComponentModel.DataAnnotations;

namespace Web.Data.Entities;

public class AppUser
{

/// <summary>
///  Initializes a new instance of the <see cref="AppUser"/> class with default values.
/// </summary>
/// <param name="id"></param>
/// <param name="userName"></param>
/// <param name="email"></param>
/// <param name="roles"></param>
	public AppUser(string id, string userName, string email, List<string>? roles)
	{

		Id = id;
		UserName = userName;
		Email = email;
		Roles = roles ?? [];

	}

	/// <summary>
	///   Gets or sets the id of the user.
	/// </summary>
	public string Id { get; set; }

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
	///   Gets an empty instance of AppUser with default values.
	/// </summary>
	public static readonly AppUser Empty = new(string.Empty, string.Empty, string.Empty, new List<string>());

}