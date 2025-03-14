using Microsoft.Extensions.DependencyInjection;
using PedimentoFormulario.BLL.Servicios;
using PedimentoFormulario.BLL.Servicios.Interfaces;

namespace PedimentoFormulario.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // Registrar servicios
            services.AddScoped<IPedimentoService, PedimentoService>();

            return services;
        }
    }
}