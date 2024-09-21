using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ApplicationDbContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseLazyLoadingProxies(false)
    .UseChangeTrackingProxies(false));

var app = builder.Build();
    
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();