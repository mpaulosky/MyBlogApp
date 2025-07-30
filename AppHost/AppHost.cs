using Aspire.Hosting;

using static Shared.Services;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis(CACHE);

// Add MongoDB Atlas resource with environment variable

var mongoDb = builder.AddMongoDB("mongodb")
    .WithEnvironment("ConnectionStrings__MongoDb", builder.Configuration["MongoDb:ConnectionStrings"])
    .WithEnvironment("DatabaseName__MongoDb", builder.Configuration["MongoDb:DatabaseName"]);

builder.AddProject<Projects.Web>(WEBSITE)
	.WithExternalHttpEndpoints()
	.WithHttpHealthCheck("/health")
	.WithReference(cache)
	.WaitFor(cache)
	.WithReference(mongoDb)
	.WaitFor(mongoDb);

builder.Build().Run();