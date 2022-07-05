using WebMinAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<FilmDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("FilmDBConn"));
});



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


//Minimal API kullanýmý
app.MapGet("/", () => "Merhaba Minimal API");
app.MapGet("/liste", () => new List<Personel> { 
    new Personel { PersonelID=111, Ad="Cevdet", Soyad="Korkmaz" },
    new Personel { PersonelID=115, Ad="Selami", Soyad="Korkmaz" },
    new Personel { PersonelID=117, Ad="Cavit", Soyad="Korkmaz" }
});

app.MapPost("/ekle", (Personel p) => p.PersonelID + "Nolu personel eklendi.. " + DateTime.Now);

app.MapGet("/filmler", (FilmDBContext db) => db.Filmlers.ToList());

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//       new WeatherForecast
//       (
//           DateTime.Now.AddDays(index),
//           Random.Shared.Next(-20, 55),
//           summaries[Random.Shared.Next(summaries.Length)]
//       ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}