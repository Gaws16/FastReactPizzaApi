using FastReactPizzaApi.Dtos;
using FastReactPizzaApi.Infrastructure;
using FastReactPizzaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FastReactPizzaApi.Endpoints;

public static class PizzaEndpoints
{
    public static void MapPizzaEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/pizzas")
                                .WithTags("Pizzas");

        group.MapGet("/", async (FastReactPizzaApiDbContext dbContext) =>
        new ApiResponse<List<Pizza>>
            {
                Status = 0,
                Data = await dbContext.Pizzas
                    .AsNoTracking()
                    .ToListAsync()
                
            }
            
        );

    }
}