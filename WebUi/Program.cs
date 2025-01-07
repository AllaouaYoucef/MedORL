


using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();



builder.Host.UseSerilog(); // Utiliser Serilog comme fournisseur de logs


// Configuration du logging
builder.Logging.ClearProviders(); // Supprime les fournisseurs de logs par défaut
builder.Logging.AddConsole(); // Ajoute la sortie des logs dans la console
builder.Logging.AddDebug(); // Ajoute la sortie des logs dans le débogueur
builder.Logging.AddEventLog(); // Ajoute la sortie des logs dans le journal des événements Windows (optionnel)



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();



builder.Services.AddAutoMapper(typeof(AutoMapperProfileBLL));
builder.Services.AddAutoMapper(typeof(AutoMapperProfileWebUi));

//Dependecy injection 
builder.Services.AddScoped<IDrugManager, DrugManager>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
Log.CloseAndFlush();