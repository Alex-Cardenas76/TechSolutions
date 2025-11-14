using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class RolBLL
    {
        private readonly RolDAL _rolDAL;

        public RolBLL()
        {
            _rolDAL = new RolDAL();
        }

        public (bool exito, string mensaje, List<Rol> datos) ObtenerTodos()
        {
            try
            {
                var roles = _rolDAL.ObtenerTodos();
                return (true, "Roles obtenidos correctamente", roles);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener roles: {ex.Message}", new List<Rol>());
            }
        }

        public (bool exito, string mensaje, Rol? rol) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var rol = _rolDAL.ObtenerPorId(id);
                if (rol == null)
                    return (false, "Rol no encontrado", null);

                return (true, "Rol encontrado", rol);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener rol: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idRol) Insertar(Rol rol)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rol.NombreRol))
                    return (false, "El nombre del rol es obligatorio", 0);

                int id = _rolDAL.Insertar(rol);
                return (true, "Rol creado correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear rol: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Rol rol)
        {
            try
            {
                if (rol.IdRol <= 0)
                    return (false, "ID de rol inválido");

                if (string.IsNullOrWhiteSpace(rol.NombreRol))
                    return (false, "El nombre del rol es obligatorio");

                var rolExiste = _rolDAL.ObtenerPorId(rol.IdRol);
                if (rolExiste == null)
                    return (false, "Rol no encontrado");

                bool resultado = _rolDAL.Actualizar(rol);
                return resultado 
                    ? (true, "Rol actualizado correctamente") 
                    : (false, "No se pudo actualizar el rol");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar rol: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de rol inválido");

                var rol = _rolDAL.ObtenerPorId(id);
                if (rol == null)
                    return (false, "Rol no encontrado");

                bool resultado = _rolDAL.Eliminar(id);
                return resultado 
                    ? (true, "Rol eliminado correctamente") 
                    : (false, "No se pudo eliminar el rol");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar rol: {ex.Message}");
            }
        }
    }
}
