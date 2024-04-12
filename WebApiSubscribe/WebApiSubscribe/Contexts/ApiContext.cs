using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiSubscribe.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribers { get; set; }
}
