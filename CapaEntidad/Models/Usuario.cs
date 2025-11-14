using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public byte[] ContrasenaHash { get; set; }
        public int IdRol { get; set; }
        public bool Estado { get; set; }

        // Relaciones
        public Rol Rol { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}