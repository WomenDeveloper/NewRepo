using WebApp.Models;
using WebApp.CustomMiddlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//IoC
//Her kullanýmda yeni nesne olusturulur....
//builder.Services.AddTransient<IEntity<Product>, Product>();
//builder.Services.AddTransient<Manager>();

//Her istekte, bir tane nene olusturulur...
//builder.Services.AddScoped<IEntity<Product>, Product>();
//builder.Services.AddScoped<Manager>();

//Tum ugulama icin bir tane olusturulur...
builder.Services.AddSingleton<IEntity<Product>, Product>();
builder.Services.AddSingleton<Manager>();


//Session Kullanýmý için gerekli
builder.Services.AddHttpContextAccessor();
//builder.Services.AddSession();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(20); });



//builder.Services.AddApiVersioning();
//Eger varsayýlan version ile calismasini istersek
builder.Services.AddApiVersioning(options => {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Middleware

app.Map("/Mid1", () => "Middleware 1");
app.Map("/Mid2", () => "Middleware 2");
app.MapWhen(x => x.Request.QueryString.Value.Contains("abcd"),Git);

void Git(IApplicationBuilder builder)
{
    //builder.Run(async op => await op.Response.WriteAsync("abcd olamaz....."));
    builder.Run(async op =>  op.Response.Redirect("Session"));
}

//app.Use(async (ctx, next) => { ctx.Response.WriteAsync("bir...."); await next(); });
//app.Use(async (ctx, next) => { ctx.Response.WriteAsync("iki....");await next(); });
//app.Run(async ctx => ctx.Response.WriteAsync("son...."));


app.Run();
