using Postgrest.Attributes;
using Postgrest.Models;

namespace Pruebas
{
    [Table("clientes")]
    public class Cliente : BaseModel
    {
        [PrimaryKey("id_cl", false)]
        public int IdCl { get; set; }

        [Column("nombre_cl")]
        public string NombreCl { get; set; }

        [Column("edad_cl")]
        public int EdadCl { get; set; }

        [Column("telefono_cl")]
        public string TelefonoCl { get; set; }
    }
}
