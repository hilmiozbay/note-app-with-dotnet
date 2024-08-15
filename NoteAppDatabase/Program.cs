using Microsoft.EntityFrameworkCore;
using Proje5.Models;

using Proje5.Utility;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped<IRepository<Account>, Repository<Account>>();
//builder.Services.AddScoped<IRepository<Notes>, Repository<Notes>>();
//builder.Services.AddScoped<IRepository<Users>, Repository<Users>>();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout (adjust as needed)
    options.Cookie.HttpOnly = true; // Set the HttpOnly property of the session cookie
    options.Cookie.IsEssential = true; // Make the session cookie essential for the application
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use session middleware
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
