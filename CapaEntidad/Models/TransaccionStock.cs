using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Models
{
    public class TransaccionStock
    {
        public int IdTransaccion { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Observacion { get; set; }

        // Relaciones
        public Producto Producto { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
    }
}
