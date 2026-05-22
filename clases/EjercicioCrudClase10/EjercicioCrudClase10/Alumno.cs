using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioCrudClase10;

public class Alumno
{
    [Column("id")]
    public int Id { get; set; }

    [Column("carnet")]
    public string Carnet { get; set; }

    [Column("nombres")]
    public string Nombres { get; set; }

    [Column("apellidos")]
    public string Apellidos { get; set; }

    [Column("telefono")]
    public long Telefono { get; set; }

    [Column("dpi")]
    public long DPI { get; set; }
}

