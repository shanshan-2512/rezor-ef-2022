using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("GameStoreContext"), new MariaDbServerVersion(new Version(10, 4, 22))));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/test", () => "Hello World");
app.MapGet("/manual", (ctx) =>
{
    return ctx.Response.WriteAsync("Hello World!");
});

app.MapRazorPages();

app.Run();
