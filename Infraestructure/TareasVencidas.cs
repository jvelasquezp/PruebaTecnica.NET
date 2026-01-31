using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using App2.Models;
//using Microsoft.OpenApi;

namespace App2.Infraestructure
{
    public class TareasVencidas:BackgroundService
    {
        private readonly ILogger<TareasVencidas> _logger;
        private readonly IServiceProvider _serviceProvider;

        public TareasVencidas(ILogger<TareasVencidas> logger, IServiceProvider proveedorServicios)
        {
            _logger = logger;
            _serviceProvider = proveedorServicios;
        }

        protected override async Task ExecuteAsync(CancellationToken tokenDetenido)
        {
            using PeriodicTimer temporizador = new(TimeSpan.FromMinutes(2));
            while(await temporizador.WaitForNextTickAsync(tokenDetenido))
            {
               _logger.LogInformation("Revisando tareas vencidas a las {time}: ...", DateTime.Now);
                using var alcance = _serviceProvider.CreateScope();
                var contexto = alcance.ServiceProvider.GetRequiredService<Api>();
                var tareasVencidas = contexto.Tareas.Where(t => t.EstadoTarea == "Pendiente" && t.FechaVencimientoTarea < DateTime.Now)
                    .ToList();
                foreach (var tarea in tareasVencidas)
                {
                    _logger.LogInformation("La tarea con Id {Id} está vencida. Enviando correo al equipo de soporte", tarea.IdTarea);
                }    
            }
        }

    }
}
