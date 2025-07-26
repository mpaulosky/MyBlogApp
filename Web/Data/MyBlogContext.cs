// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     MyBlogContext.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web
// =======================================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Web.Data.Entities;

namespace Web.Data;

public class MyBlogContext : DbContext
{

	public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options) { }

	public DbSet<Article> Articles { get; set; }
	public DbSet<Category> Categories { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		modelBuilder
			.Entity<Article>()
			.HasIndex(e => e.Id)
			.IsUnique();

		modelBuilder
				.Entity<Article>()
				.HasIndex(e => e.UrlSlug)
				.IsUnique();

		modelBuilder
				.Entity<Article>()
				.Property(e => e.CreatedOn)
				.HasConversion(new DateTimeOffsetConverter());

		modelBuilder
				.Entity<Article>()
				.Property(e => e.ModifiedOn)
				.HasConversion(new DateTimeOffsetConverter());

		modelBuilder
				.Entity<Article>()
				.Property(e => e.PublishedOn)
				.HasConversion(new DateTimeOffsetConverter());

		modelBuilder
			.Entity<Category>()
			.HasIndex(e => e.Id)
			.IsUnique();

		modelBuilder
				.Entity<Category>()
				.Property(e => e.CreatedOn)
				.HasConversion(new DateTimeOffsetConverter());

		modelBuilder
				.Entity<Category>()
				.Property(e => e.ModifiedOn)
				.HasConversion(new DateTimeOffsetConverter());

	}

}

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTime>
{

	public DateTimeOffsetConverter() : base(
			v => v.UtcDateTime, // Store as UTC DateTime
			v => new DateTimeOffset(v, TimeSpan.Zero)) // Retrieve as DateTimeOffset (UTC)
	{ }

}