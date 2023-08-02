using AutoMapper;
using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configuration
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

// Endpoints
app.UseEndpoints(endpoints =>
{
    // Admin area route
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    // Default route
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


    // Razor Pages route
    endpoints.MapRazorPages();
});

// Additional Configuration
app.ConfigureAndCheckMigration();
app.ConfigureLocalization();

app.Run();
