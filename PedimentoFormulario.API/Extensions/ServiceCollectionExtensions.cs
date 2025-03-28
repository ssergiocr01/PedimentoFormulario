using Microsoft.EntityFrameworkCore;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.BLL.Services;
using PedimentoFormulario.BLL.Servicios;
using PedimentoFormulario.Data;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Data.Repositories;
using PedimentoFormulario.Data.UnitOfWork;
using PedimentoFormulario.Utilities.Mappings;

namespace PedimentoFormulario.API.Extensions
{
    /// <summary>
    /// Extensiones para configurar los servicios de la aplicación
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configura los servicios de acceso a datos
        /// </summary>
        /// <param name="services">Colección de servicios</param>
        /// <param name="configuration">Configuración de la aplicación</param>
        /// <returns>Colección de servicios actualizada</returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar el contexto de base de datos
            services.AddDbContext<PedimentoContext>(options =>
                options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("PedimentoFormulario.Data"))
                    // Habilitar el registro de datos sensibles para ver los valores de los parámetros
                    .EnableSensitiveDataLogging()
                    // Configurar el logging para mostrar las consultas SQL - versión simplificada
                    .LogTo(Console.WriteLine, LogLevel.Information)
            );

            // Registrar repositorios
            services.AddScoped<ICombosRepository, CombosRepository>();
            services.AddScoped<IPedimentoRepository, PedimentoRepository>();
            services.AddScoped<IRubrosSalarialesRepository, RubrosSalarialesRepository>();

            // Registrar UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        /// <summary>
        /// Configura los servicios de negocio
        /// </summary>
        /// <param name="services">Colección de servicios</param>
        /// <returns>Colección de servicios actualizada</returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // Registrar servicios
            services.AddScoped<ICombosService, CombosService>();
            services.AddScoped<IPedimentoService, PedimentoService>();
            services.AddScoped<IRubrosSalarialesService, RubrosSalarialesService>();

            // Configurar AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}