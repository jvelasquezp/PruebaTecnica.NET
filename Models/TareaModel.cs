using System.ComponentModel.DataAnnotations;

namespace App2.Models
{
    public class TareaModel
    {
        public int IdTarea { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string NombreTarea { get; set; }

        public string EstadoTarea { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Vencimiento de la tarea es obligatorio")]
        public DateTime FechaVencimientoTarea { get; set; }

        public DateTime FechaCreacionTarea { get; set; }

        public int IdCategoria { get; set; }

        [Timestamp] public byte[] RowVersion { get; set; }
    }
}
