using AgendaOnline.Data;
using AgendaOnline.Interfaces;
using AgendaOnline.Repository;
using AgendaOnline.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnPadrao")));

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddScoped<IContatoService, ContatoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contato}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
