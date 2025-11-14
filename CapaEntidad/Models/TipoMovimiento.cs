using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Models
{
    public class TipoMovimiento
    {
        public int IdTipoMovimiento { get; set; }
        public string NombreMovimiento { get; set; }

        // Relaciones
        public ICollection<TransaccionStock> TransaccionesStock { get; set; }
    }
}
