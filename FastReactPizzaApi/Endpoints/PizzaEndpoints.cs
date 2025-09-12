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
            {
                var pizzas = await dbContext.Pizzas
                    .AsNoTracking()
                    .ToListAsync();
                return ApiResponse<List<Pizza>>.Success(pizzas);
            } 
            
        );

    }
}