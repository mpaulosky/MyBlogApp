using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

var configuration = builder.Configuration;

// Add Output Cache
builder.AddRedisOutputCache(CACHE);
builder.Services.AddOutputCache();

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

// Add MongoDB client
builder.Services.AddSingleton<IMongoClient>(sp =>
{
	var connectionString = configuration["MongoDb:ConnectionStrings"];
	return new MongoClient(connectionString);
});

// Add MongoDB context
builder.Services.AddScoped<MyBlogContext>(provider =>
{
	var mongoClient = provider.GetRequiredService<IMongoClient>();
	return new MyBlogContext(mongoClient, configuration);
});

// Add Health Checks
builder.Services.AddHealthChecks();

// Add Auth0 authentication
builder.Services.AddAuthentication( /* options */)
		.AddAuth0WebAppAuthentication(options =>
		{
			options.Domain = configuration["Auth0:Domain"] ?? string.Empty;
			options.ClientId = configuration["Auth0:ClientId"] ?? string.Empty;
		});

// Add Authorization Policies
builder.Services.AddAuthorization(options =>
{
	// Define policies
	options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
});

// Add CORS policy
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy => policy
			.WithOrigins("https://localhost:7126")
			.AllowAnyHeader()
			.AllowAnyMethod());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapGet("/Account/LoginComponent", async (HttpContext httpContext, string returnUrl = "/") =>
{
	var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
			.WithRedirectUri(returnUrl)
			.Build();

	await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async httpContext =>
{
	var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
			.WithRedirectUri("/")
			.Build();

	await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.UseStatusCodePages(async context =>
{

	var response = context.HttpContext.Response;

	if (response.StatusCode == 404)
	{
		context.HttpContext.Response.Redirect("/error/404");
	}
	else if (response.StatusCode == 401)
	{
		context.HttpContext.Response.Redirect("/error/401");
	}
	else if (response.StatusCode == 403)
	{
		context.HttpContext.Response.Redirect("/error/403");
	}

	// ...other codes as needed
	await Task.CompletedTask;

});

app.Run();