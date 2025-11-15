using System.Collections.Generic;

namespace CapaNegocio.Seguridad
{
    /// <summary>
    /// Define los permisos de cada rol en el sistema
    /// </summary>
    public static class PermisosPorRol
    {
        // IDs de roles
        public const int ROL_ADMINISTRADOR = 1;
        public const int ROL_SUPERVISOR = 2;
        public const int ROL_VENDEDOR = 3;

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar clientes
        /// </summary>
        public static bool PuedeGestionarClientes(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR || 
                   idRol == ROL_VENDEDOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar proveedores
        /// </summary>
        public static bool PuedeGestionarProveedores(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar categorías
        /// </summary>
        public static bool PuedeGestionarCategorias(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar productos
        /// </summary>
        public static bool PuedeGestionarProductos(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para registrar ventas
        /// </summary>
        public static bool PuedeRegistrarVentas(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR || 
                   idRol == ROL_VENDEDOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar movimientos de stock
        /// </summary>
        public static bool PuedeGestionarMovimientosStock(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para ver reportes
        /// </summary>
        public static bool PuedeVerReportes(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol tiene permiso para gestionar usuarios
        /// </summary>
        public static bool PuedeGestionarUsuarios(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR;
        }

        /// <summary>
        /// Verifica si un rol puede modificar precios
        /// </summary>
        public static bool PuedeModificarPrecios(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR || 
                   idRol == ROL_SUPERVISOR;
        }

        /// <summary>
        /// Verifica si un rol puede eliminar ventas
        /// </summary>
        public static bool PuedeEliminarVentas(int idRol)
        {
            return idRol == ROL_ADMINISTRADOR;
        }

        /// <summary>
        /// Obtiene el nombre descriptivo del rol
        /// </summary>
        public static string ObtenerNombreRol(int idRol)
        {
            return idRol switch
            {
                ROL_ADMINISTRADOR => "Administrador",
                ROL_SUPERVISOR => "Supervisor",
                ROL_VENDEDOR => "Vendedor",
                _ => "Desconocido"
            };
        }
    }
}
