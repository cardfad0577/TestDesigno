using System;
using System.Collections.Generic;

namespace TestDesigno.Data.Entities;

public partial class Usuario
{
    public Guid UsuarioId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public int Sueldo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaModificacion { get; set; }
}
