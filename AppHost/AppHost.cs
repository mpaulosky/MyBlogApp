using static Shared.Services;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis(CACHE);

var pgServer = builder.AddPostgres(SERVER)
		.WithLifetime(ContainerLifetime.Persistent)
		.WithDataVolume($"{SERVER}-data")
		.WithPgAdmin(config =>
		{
			config.WithImageTag("latest");
			config.WithLifetime(ContainerLifetime.Persistent);
		});

var postgresDb = pgServer.AddDatabase(DATABASE);

builder.AddProject<Projects.Web>(WEBSITE)
		.WithExternalHttpEndpoints()
		.WithHttpHealthCheck("/health")
		.WithReference(cache)
		.WaitFor(cache)
		.WithReference(postgresDb)
		.WaitFor(postgresDb);

builder.Build().Run();