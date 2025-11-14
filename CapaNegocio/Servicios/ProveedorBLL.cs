using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class ProveedorBLL
    {
        private readonly ProveedorDAL _proveedorDAL;

        public ProveedorBLL()
        {
            _proveedorDAL = new ProveedorDAL();
        }

        public (bool exito, string mensaje, List<Proveedor> datos) ObtenerTodos()
        {
            try
            {
                var proveedores = _proveedorDAL.ObtenerTodos();
                return (true, "Proveedores obtenidos correctamente", proveedores);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener proveedores: {ex.Message}", new List<Proveedor>());
            }
        }

        public (bool exito, string mensaje, Proveedor? proveedor) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var proveedor = _proveedorDAL.ObtenerPorId(id);
                if (proveedor == null)
                    return (false, "Proveedor no encontrado", null);

                return (true, "Proveedor encontrado", proveedor);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener proveedor: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idProveedor) Insertar(Proveedor proveedor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(proveedor.NombreProveedor))
                    return (false, "El nombre del proveedor es obligatorio", 0);

                if (!string.IsNullOrWhiteSpace(proveedor.Email) && !EsEmailValido(proveedor.Email))
                    return (false, "El formato del email no es válido", 0);

                int id = _proveedorDAL.Insertar(proveedor);
                return (true, "Proveedor creado correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear proveedor: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Proveedor proveedor)
        {
            try
            {
                if (proveedor.IdProveedor <= 0)
                    return (false, "ID de proveedor inválido");

                if (string.IsNullOrWhiteSpace(proveedor.NombreProveedor))
                    return (false, "El nombre del proveedor es obligatorio");

                if (!string.IsNullOrWhiteSpace(proveedor.Email) && !EsEmailValido(proveedor.Email))
                    return (false, "El formato del email no es válido");

                var proveedorExiste = _proveedorDAL.ObtenerPorId(proveedor.IdProveedor);
                if (proveedorExiste == null)
                    return (false, "Proveedor no encontrado");

                bool resultado = _proveedorDAL.Actualizar(proveedor);
                return resultado 
                    ? (true, "Proveedor actualizado correctamente") 
                    : (false, "No se pudo actualizar el proveedor");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar proveedor: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de proveedor inválido");

                var proveedor = _proveedorDAL.ObtenerPorId(id);
                if (proveedor == null)
                    return (false, "Proveedor no encontrado");

                bool resultado = _proveedorDAL.Eliminar(id);
                return resultado 
                    ? (true, "Proveedor eliminado correctamente") 
                    : (false, "No se pudo eliminar el proveedor");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar proveedor: {ex.Message}");
            }
        }

        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            var proveedores = _proveedorDAL.ObtenerTodos();
            return proveedores.Where(p => 
                p.NombreProveedor.Contains(nombre, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
