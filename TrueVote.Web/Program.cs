using Microsoft.EntityFrameworkCore;
using TrueVote.Web.Repositories;
using TrueVote.Web.Repositories.Interfaces;
using TrueVote.Web.Services;
using TrueVote.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContextPool<ApplicationDbContext>(
    options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseLazyLoadingProxies(false)
    .UseChangeTrackingProxies(false));


builder.Services.AddScoped<ISubmitVoteService, SubmitVoteService>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();


var app = builder.Build();
    
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Votes}/{action=Index}/{id?}");

app.Run();