using System.ComponentModel.DataAnnotations;

namespace App2.Exceptions
{
    public class ExcepcionTarea : Exception
    {
        public ExcepcionTarea(string mensaje) : base(mensaje) { }

        public class ExcepcionTareaEditada : ExcepcionTarea
        {
            public ExcepcionTareaEditada(DateTime FechaEdicion, byte[] RowVersion)
        : base($"La tarea está siendo editada desde {FechaEdicion}. La versión actual es {Convert.ToBase64String(RowVersion)}. Por favor, refresque.")
            {
                this.RowVersion = RowVersion;
            }
            [Required]
            public byte[] RowVersion
            {
                get;
            }
        }
    }
}
