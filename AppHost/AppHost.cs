using static Shared.Services;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis(CACHE);

var postgres = builder.AddPostgres(SERVER)
		.WithDataVolume(isReadOnly: false);

var postgresDb = postgres.AddDatabase(DATABASE);

builder.AddProject<Projects.Web>(WEBSITE)
		.WithExternalHttpEndpoints()
		.WithHttpHealthCheck("/health")
		.WithReference(cache)
		.WaitFor(cache)
		.WithReference(postgresDb)
		.WaitFor(postgresDb);

builder.Build().Run();