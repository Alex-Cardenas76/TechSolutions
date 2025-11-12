using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CapaDatos.Database
{
    // Usamos 'sealed' para evitar herencia y mantener el patrón Singleton.
    public sealed class ConexionBD
    {
        // 1. Variable privada estática para contener la única instancia (Lazy Initialization).
        private static ConexionBD? _instancia;

        // 2. Cadena de conexión adaptada al nombre de tu BD (TechSolutionsDB).
        // NOTA: Asegúrate de reemplazar 'DESKTOP-FFT69FN' con el nombre de tu servidor SQL.
        private readonly string _cadenaConexion =
            "Server=DESKTOP-FFT69FN;Database=TechSolutionsDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // 3. Constructor privado para prevenir la instanciación externa.
        private ConexionBD() { }

        // 4. Propiedad pública estática para obtener la única instancia.
        // Utiliza el operador ??= para crear la instancia solo si es null.
        public static ConexionBD Instancia => _instancia ??= new ConexionBD();

        // 5. Método para crear y retornar una nueva conexión (SqlConnection).
        public SqlConnection CrearConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}