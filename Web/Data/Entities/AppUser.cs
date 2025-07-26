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
	///   Gets or sets the id of the user.
	/// </summary>
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

}