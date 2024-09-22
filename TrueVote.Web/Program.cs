using Microsoft.EntityFrameworkCore;
using TrueVote.Web;
using TrueVote.Web.Hubs;
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


builder.Services.AddSignalR();
builder.Services.AddScoped<ISubmitVoteService, SubmitVoteService>();
builder.Services.AddScoped<IReceivedVotesRepository, ReceivedVotesRepository>();
builder.Services.AddScoped<IVotationDetailsService, VotationDetailsService>();
builder.Services.AddScoped<IVoteOptionsDetailsRepository, VoteOptionsDetailsRepository>();


builder.Services.AddDataSeed();

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

app.MapHub<VoteCreatedNotificationHub>("/hubs/vote");
app.Run();