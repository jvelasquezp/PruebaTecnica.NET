using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace App2.Models
{
    public class Api:DbContext
    {
        public Api(DbContextOptions<Api> options) : base(options) { }
        public DbSet<TareaModel> Tareas => Set<TareaModel>();
        public DbSet<CategoriaModel> Categorias => Set<CategoriaModel>();

    }
}
