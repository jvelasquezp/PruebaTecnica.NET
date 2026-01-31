using Microsoft.Extensions.Caching.Memory;
using App2.Models;

namespace App2.Services
{
    public class ServicioCategoria
    {
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "CategoriasTareas";

        public ServicioCategoria(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<string> ListarCategorias()
        {
            return _cache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
                return new List<string>
                {
                    "Infraestructura",
                    "Base de Datos",
                    "FrontEnd",
                    "BackEnd"
                };
            }) ?? new List<string>();
        }
    }
}
