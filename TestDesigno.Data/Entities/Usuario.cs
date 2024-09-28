using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesigno.Data.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; } = Guid.NewGuid();
        public required string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public required string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
    }
}
