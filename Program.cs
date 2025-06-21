var builder = WebApplication.CreateBuilder(args);

// 1. Register controllers (in addition to Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Enable Swagger in Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// (Optional) if you’re going to add [Authorize] later
// app.UseAuthorization();

// 3. Map all controllers
app.MapControllers();

// 4. (You can still keep your minimal endpoint too if you like)
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] {
        "Freezing", "Bracing", "Chilly", "Cool",
        "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    return Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        )
    ).ToArray();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
