using Postgrest.Attributes;
using Postgrest.Models;

namespace Pruebas
{
    // Vincula esta clase con el nombre exacto de la tabla en Supabase
    [Table("productos")]
    public class Producto : BaseModel
    {
        // El segundo parámetro 'false' indica que el ID es auto-incremental en la BD
        [PrimaryKey("id_prod", false)]
        public int IdProd { get; set; }

        [Column("nombre_prod")]
        public string NombreProd { get; set; }

        [Column("precio_prod")]
        public double PrecioProd { get; set; }

        [Column("stock_prod")]
        public int StockProd { get; set; }
    }
}
