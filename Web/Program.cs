using Web.Components;
using Web.Data;
using static Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisOutputCache(CACHE);

builder.AddNpgsqlDbContext<MyBlogContext>(DATABASE);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	using var scope = app.Services.CreateScope();

	var context = scope.ServiceProvider.GetRequiredService<MyBlogContext>();
	await context.Database.EnsureCreatedAsync();

}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseStaticFiles();

app.UseOutputCache();

app.MapDefaultEndpoints();

app.MapStaticAssets();

app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

app.Run();