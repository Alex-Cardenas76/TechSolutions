using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public int IdCategoria { get; set; }
        public int? IdProveedor { get; set; }

        // Relaciones
        public Categoria Categoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        public ICollection<TransaccionStock> TransaccionesStock { get; set; }
    }
}
