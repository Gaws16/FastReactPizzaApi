using FastReactPizzaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FastReactPizzaApi.Infrastructure;

public class FastReactPizzaApiDbContext : DbContext
{
    public FastReactPizzaApiDbContext(DbContextOptions<FastReactPizzaApiDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
}