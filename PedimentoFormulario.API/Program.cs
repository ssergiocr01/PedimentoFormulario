using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PedimentoFormulario.API.Middlewares;
using PedimentoFormulario.BLL.Extensions;
using PedimentoFormulario.Data;
using PedimentoFormulario.Data.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
    config.AddDebug();
    config.SetMinimumLevel(LogLevel.Information);
}).CreateLogger("Program");

try
{
    logger.LogInformation("Iniciando la aplicación");

    // Agregar servicios al contenedor
    builder.Services.AddControllers();

    // Obtener la cadena de conexión
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        logger.LogError("La cadena de conexión 'DefaultConnection' no está configurada");
        throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada");
    }
    logger.LogInformation("Cadena de conexión obtenida correctamente");

    // Configurar DbContext
    logger.LogInformation("Configurando DbContext con SQL Server");
    builder.Services.AddDbContext<PedimentoContext>(options =>
    {
        options.UseSqlServer(connectionString, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            sqlOptions.CommandTimeout(30);
        });
        options.EnableSensitiveDataLogging(); // Solo para desarrollo
        options.EnableDetailedErrors(); // Solo para desarrollo
    });
    logger.LogInformation("DbContext configurado correctamente");

    // Configurar AutoMapper
    logger.LogInformation("Configurando AutoMapper");
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    logger.LogInformation("AutoMapper configurado correctamente");

    // Registrar servicios de la capa de datos
    logger.LogInformation("Registrando servicios de la capa de datos");
    builder.Services.AddDataServices();
    logger.LogInformation("Servicios de la capa de datos registrados correctamente");

    // Registrar servicios de la capa de negocio
    logger.LogInformation("Registrando servicios de la capa de negocio");
    builder.Services.AddBusinessServices();
    logger.LogInformation("Servicios de la capa de negocio registrados correctamente");

    // Configurar Swagger/OpenAPI
    logger.LogInformation("Configurando Swagger");
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API de Pedimentos de Personal",
            Version = "v1",
            Description = "API para la gestión de pedimentos de personal",
            Contact = new OpenApiContact
            {
                Name = "Equipo de Desarrollo",
                Email = "desarrollo@ejemplo.com"
            }
        });

        // Configurar la generación de documentación XML para Swagger
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
        {
            c.IncludeXmlComments(xmlPath);
        }
    });
    logger.LogInformation("Swagger configurado correctamente");

    // Configurar CORS
    logger.LogInformation("Configurando CORS");
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
    logger.LogInformation("CORS configurado correctamente");

    var app = builder.Build();

    // Middleware para capturar excepciones no controladas
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Configurar el pipeline de solicitudes HTTP
    if (app.Environment.IsDevelopment())
    {
        logger.LogInformation("Configurando middleware para entorno de desarrollo");
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Pedimentos v1"));
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    // Habilitar CORS
    app.UseCors("AllowAll");

    app.UseAuthorization();

    app.MapControllers();

    logger.LogInformation("Aplicación configurada correctamente, iniciando...");
    app.Run();
}
catch (Exception ex)
{
    logger.LogError(ex, "Error al iniciar la aplicación");
    throw;
}

