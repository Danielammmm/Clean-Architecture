using FP.Application.Interfaces;
using FP.Infrastructure.Persistence;
using FP.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Agregar configuración desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 🔹 Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// 🔹 Configurar Entity Framework Core con la cadena de conexión de `appsettings.json`
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Registrar servicios (en el orden correcto)
builder.Services.AddScoped<IFileService, FileService>(); // Solo una vez
builder.Services.AddSingleton<IConfigurationService, ConfigurationService>();

// 🔹 Agregar servicios de API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


var app = builder.Build();

// 🔹 Ejecutar migraciones automáticamente al iniciar la aplicación
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// 🔹 Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();
app.Run();
