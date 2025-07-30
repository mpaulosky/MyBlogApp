// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     AppUserDto.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain
// =======================================================

using System.ComponentModel.DataAnnotations;

namespace Web.Data.Models;

/// <summary>
///   Data Transfer Object (DTO) representing an application user.
/// </summary>
public class AppUserDto
{

	/// <summary>
	///   Parameterless constructor for serialization and test data generation.
	/// </summary>
	public AppUserDto() : this(string.Empty, string.Empty, string.Empty, []) { }

	/// <summary>
	///   Initializes a new instance of the <see cref="AppUserDto" /> class.
	/// </summary>
	/// <param name="id">The unique identifier for the user.</param>
	/// <param name="userName">The username of the user.</param>
	/// <param name="email">The email address of the user.</param>
	/// <param name="roles">The list of roles assigned to the user.</param>
	public AppUserDto(string id, string userName, string email, List<string> roles)
	{
		Id = id;
		UserName = userName;
		Email = email;
		Roles = roles;
	}

	/// <summary>
	///   Gets or sets the unique identifier for the user.
	/// </summary>
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
	public List<string> Roles { get; set; }

	/// <summary>
	///   Gets an empty instance of AppUserDto with default values.
	/// </summary>
	public static AppUserDto Empty => new(string.Empty, string.Empty, string.Empty, []);

}