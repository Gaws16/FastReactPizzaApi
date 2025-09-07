using FastReactPizzaApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Supabase;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsDevelopment())
{
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FastReactPizzaApiDbContext>(options =>
    options.UseNpgsql(connectionString));
    
}
else
{
var supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL") ??
                  throw new Exception("SUPABASE_URL is not setuped as a ENV Variable");
var supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY") ?? throw new ArgumentNullException("SUPABASE_KEY is not setuped as a ENV Variable");

var supabaseOptions = new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true
};
    
builder.Services.AddSingleton(provider=>new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions));
}





// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}