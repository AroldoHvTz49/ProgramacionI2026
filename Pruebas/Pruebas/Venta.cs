using Postgrest.Attributes;
using Postgrest.Models;

namespace Pruebas
{
    [Table("Gestion_Ventas")]
    public class Venta : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        // El ID del producto se guarda de forma única aquí
        [Column("codigo_producto")]
        public long CodigoProducto { get; set; }

        // El ID del cliente se guarda de forma única aquí
        [Column("codigo_cliente")]
        public long CodigoCliente { get; set; }

        [Column("total_venta")]
        public double TotalVenta { get; set; }

        [Column("cantidad_venta")]
        public long CantidadVenta { get; set; }
    }
}
