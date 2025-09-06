using Microsoft.EntityFrameworkCore;

namespace FastReactPizzaApi.Infrastructure;

public class FastReactPizzaApiDbContext : DbContext
{
    public FastReactPizzaApiDbContext(DbContextOptions<FastReactPizzaApiDbContext> options) : base(options)
    {
        
    }
}