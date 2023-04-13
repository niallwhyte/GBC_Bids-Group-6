using GBC_Bids_Group_6.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options =>
{
    options.AppendTrailingSlash = true;
    options.LowercaseUrls = true;
});

builder.Services.AddDbContext<ItemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ItemContext")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Asset}/{id?}");

app.Run();
