using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using Microsoft.AspNetCore.Identity;
  
var builder = WebApplication.CreateBuilder(args);

// Add session state
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<SportsProContext>()
	.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
// Add EF Core DI
builder.Services.AddDbContext<SportsProContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("SportsProContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
	await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
		

