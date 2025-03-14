using Microsoft.EntityFrameworkCore;
using PedimentoFormulario.BLL.Extensions;
using PedimentoFormulario.Data;
using PedimentoFormulario.Data.UnidadDeTrabajo;
using PedimentoFormulario.Data.UnidadDeTrabajo.Interfaces;
using PedimentoFormulario.Utilities.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });

    options.AddPolicy("AllowNextJs", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",  // Next.js desarrollo
                "https://localhost:3000",
                "http://localhost:3001",  // Alternativa para Next.js
                "https://localhost:3001",
                "http://127.0.0.1:3000",  // También permitir acceso desde IP local
                "https://127.0.0.1:3000"
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el contexto de EF Core
builder.Services.AddDbContext<PedimentoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Registrar la unidad de trabajo
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registrar servicios de negocio
builder.Services.AddBusinessServices();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // En desarrollo, podemos usar una política más permisiva
    app.UseCors("AllowAll");
}
else
{
    // En producción, usar una política más restrictiva
    app.UseCors("AllowNextJs");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();