using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestDesigno.Core.Dtos
{
    public class UsuarioDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Debe ser mayor que 0")]
        public int Sueldo { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
        [JsonIgnore]
        public DateTime FechaModificacion { get; set; }

    }
}
