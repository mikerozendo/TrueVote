using Microsoft.EntityFrameworkCore;

namespace TrueVote.Web.Repositories;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}