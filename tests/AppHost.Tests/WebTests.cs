using System.Net;

using Aspire.Hosting.Testing;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AppHost;

public class WebTests
{

	private static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(30);

	[Fact(Skip = "Requires a running Aspire application with a web resource.")]
	public async Task GetWebResourceRootReturnsOkStatusCode()
	{
		// Arrange
		var cancellationToken = TestContext.Current.CancellationToken;

		var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.AppHost>(cancellationToken);

		appHost.Services.AddLogging(logging =>
		{
			logging.SetMinimumLevel(LogLevel.Debug);

			// Override the logging filters from the app's configuration
			logging.AddFilter(appHost.Environment.ApplicationName, LogLevel.Debug);
			logging.AddFilter("Aspire.", LogLevel.Debug);

			// To output logs to the xUnit.net ITestOutputHelper, consider adding a package from https://www.nuget.org/packages?q=xunit+logging
		});

		appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
		{
			clientBuilder.AddStandardResilienceHandler();
		});

		await using var app = await appHost.BuildAsync(cancellationToken).WaitAsync(_defaultTimeout, cancellationToken);
		await app.StartAsync(cancellationToken).WaitAsync(_defaultTimeout, cancellationToken);

		// Act
		var httpClient = app.CreateHttpClient("web");

		await app.ResourceNotifications.WaitForResourceHealthyAsync("web", cancellationToken)
				.WaitAsync(_defaultTimeout, cancellationToken);

		var response = await httpClient.GetAsync("/", cancellationToken);

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
	}

}