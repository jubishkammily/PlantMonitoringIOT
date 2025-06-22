using PlantMonitorApi.Data;
using PlantMonitorApi.Infrastructure;



var builder = WebApplication.CreateBuilder(args);


// rgus will open up the url to use it outside the local machine . means connected in the same lan
builder.WebHost.UseUrls(
  "http://0.0.0.0:5000",   // all IPv4
  "http://[::]:5000"       // all IPv6
);


builder.Services.AddPlantMonitoringInfrastructure("Data Source=PlantMonitoringIOT.db");

builder.Services.AddCors(opts => {
    opts.AddDefaultPolicy(policy => {
        policy
          .AllowAnyMethod()
          .AllowAnyHeader()
          .WithOrigins("http://localhost:5173");
    });
});

// 1. Register controllers (in addition to Swagger)
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();


//This makes sure on startup your SQLite file and tables are created.

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

// 2. Enable Swagger in Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors();

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
