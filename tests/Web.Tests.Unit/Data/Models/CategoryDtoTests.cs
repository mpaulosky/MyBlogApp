// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     CategoryDtoTests.cs
// Company :       mpaulosky
// Author :        Matthew
// Solution Name : MyBlogApp
// Project Name :  Domain.Tests.Unit
// =======================================================

using MongoDB.Bson;

namespace Web.Data.Models;

[ExcludeFromCodeCoverage]
public class CategoryDtoTests
{
	[Fact]
	public void CategoryDto_ParameterlessConstructor_ShouldSetDefaultValues()
	{
		var dto = new CategoryDto(ObjectId.Empty);
		dto.Id.Should().Be(ObjectId.Empty);
		dto.Name.Should().BeEmpty();
		dto.CreatedOn.Should().BeNull();
		dto.ModifiedOn.Should().BeNull();
	}

	[Fact]
	public void CategoryDto_Empty_ShouldReturnEmptyInstance()
	{
		var dto = CategoryDto.Empty;
		dto.Id.Should().Be(ObjectId.Empty);
		dto.Name.Should().BeEmpty();
		dto.CreatedOn.Should().BeNull();
		dto.ModifiedOn.Should().BeNull();
	}

	[Fact]
	public void CategoryDto_Constructor_ShouldSetProperties()
	{
		var id = ObjectId.GenerateNewId();
		var name = "Test Category";
		var createdOn = DateTimeOffset.UtcNow.AddDays(-1);
		var modifiedOn = DateTimeOffset.UtcNow;
		var dto = new CategoryDto(id, name, createdOn, modifiedOn);
		dto.Id.Should().Be(id);
		dto.Name.Should().Be(name);
		dto.CreatedOn.Should().Be(createdOn);
		dto.ModifiedOn.Should().Be(modifiedOn);
	}

	[Fact]
	public void CategoryDto_Properties_ShouldBeMutable()
	{
		var dto = new CategoryDto(ObjectId.Empty, "OldName", null, null);
		var newId = ObjectId.GenerateNewId();
		var newName = "NewName";
		var newCreatedOn = DateTimeOffset.UtcNow.AddDays(-2);
		var newModifiedOn = DateTimeOffset.UtcNow.AddDays(-1);

		dto.Id = newId;
		dto.Name = newName;
		dto.CreatedOn = newCreatedOn;
		dto.ModifiedOn = newModifiedOn;

		dto.Id.Should().Be(newId);
		dto.Name.Should().Be(newName);
		dto.CreatedOn.Should().Be(newCreatedOn);
		dto.ModifiedOn.Should().Be(newModifiedOn);
	}
}
