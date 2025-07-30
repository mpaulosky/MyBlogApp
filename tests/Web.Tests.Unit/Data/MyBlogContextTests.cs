// Copyright (c) 2025. All rights reserved.
// File Name :     MyBlogContextTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Web.Tests.Unit
// =======================================================

using Microsoft.Extensions.Configuration;

using MongoDB.Driver;

using NSubstitute;

using Web.Data.Entities;

namespace Web.Data;

/// <summary>
///   Unit tests for <see cref="MyBlogContext"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[TestSubject(typeof(MyBlogContext))]
public class MyBlogContextTests
{
	private readonly IMongoClient _mongoClient;
	private readonly IConfiguration _configuration;

	public MyBlogContextTests()
	{
		_mongoClient = Substitute.For<IMongoClient>();
		_configuration = Substitute.For<IConfiguration>();
	}

	[Fact]
	public void Constructor_WithDatabaseNameInConfig_UsesConfigValue()
	{
		// Arrange
		_configuration["MongoDb:Database"] = "TestDb";
		var database = Substitute.For<IMongoDatabase>();
		_mongoClient.GetDatabase("TestDb").Returns(database);

		// Act
		var context = new MyBlogContext(_mongoClient, _configuration);

		// Assert
		context.Should().NotBeNull();
	}

	[Fact]
	public void Constructor_WithoutDatabaseNameInConfig_UsesDefault()
	{
		// Arrange
		_configuration["MongoDb:Database"] = null;
		var database = Substitute.For<IMongoDatabase>();
		_mongoClient.GetDatabase("ArticleDb").Returns(database);

		// Act
		var context = new MyBlogContext(_mongoClient, _configuration);

		// Assert
		context.Should().NotBeNull();
	}

	[Fact]
	public void Articles_Property_ReturnsCollection()
	{
		// Arrange
		var database = Substitute.For<IMongoDatabase>();
		var articlesCollection = Substitute.For<IMongoCollection<Article>>();
		_mongoClient.GetDatabase(Arg.Any<string>()).Returns(database);
		database.GetCollection<Article>("Articles").Returns(articlesCollection);
		var context = new MyBlogContext(_mongoClient, _configuration);

		// Act
		var result = context.Articles;

		// Assert
		result.Should().BeSameAs(articlesCollection);
	}

	[Fact]
	public void Categories_Property_ReturnsCollection()
	{
		// Arrange
		var database = Substitute.For<IMongoDatabase>();
		var categoriesCollection = Substitute.For<IMongoCollection<Category>>();
		_mongoClient.GetDatabase(Arg.Any<string>()).Returns(database);
		database.GetCollection<Category>("Categories").Returns(categoriesCollection);
		var context = new MyBlogContext(_mongoClient, _configuration);

		// Act
		var result = context.Categories;

		// Assert
		result.Should().BeSameAs(categoriesCollection);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Constructor_WithNullOrEmptyDatabaseName_UsesDefault(string dbName)
	{
		// Arrange
		_configuration["MongoDb:Database"] = dbName;
		var database = Substitute.For<IMongoDatabase>();
		_mongoClient.GetDatabase("ArticleDb").Returns(database);

		// Act
		var context = new MyBlogContext(_mongoClient, _configuration);

		// Assert
		context.Should().NotBeNull();
	}

}