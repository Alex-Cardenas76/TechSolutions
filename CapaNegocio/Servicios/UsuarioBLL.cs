using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;
using CapaNegocio.Seguridad;

namespace CapaNegocio.Servicios
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _usuarioDAL;
        private readonly RolDAL _rolDAL;

        public UsuarioBLL()
        {
            _usuarioDAL = new UsuarioDAL();
            _rolDAL = new RolDAL();
        }

        public (bool exito, string mensaje, List<Usuario> datos) ObtenerTodos()
        {
            try
            {
                var usuarios = _usuarioDAL.ObtenerTodos();
                return (true, "Usuarios obtenidos correctamente", usuarios);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener usuarios: {ex.Message}", new List<Usuario>());
            }
        }

        public (bool exito, string mensaje, Usuario? usuario) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var usuario = _usuarioDAL.ObtenerPorId(id);
                if (usuario == null)
                    return (false, "Usuario no encontrado", null);

                return (true, "Usuario encontrado", usuario);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener usuario: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, Usuario? usuario) ValidarLogin(string nombreUsuario, string contrasena)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreUsuario))
                    return (false, "El nombre de usuario es obligatorio", null);

                if (string.IsNullOrWhiteSpace(contrasena))
                    return (false, "La contraseña es obligatoria", null);

                var usuario = _usuarioDAL.ObtenerPorNombre(nombreUsuario);
                if (usuario == null)
                    return (false, "Usuario o contraseña incorrectos", null);

                if (!usuario.Estado)
                    return (false, "Usuario inactivo. Contacte al administrador", null);

                if (!PasswordHasher.VerifyPassword(contrasena, usuario.ContrasenaHash))
                    return (false, "Usuario o contraseña incorrectos", null);

                return (true, "Login exitoso", usuario);
            }
            catch (Exception ex)
            {
                return (false, $"Error al validar login: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idUsuario) Insertar(Usuario usuario, string contrasena)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                    return (false, "El nombre de usuario es obligatorio", 0);

                if (string.IsNullOrWhiteSpace(contrasena))
                    return (false, "La contraseña es obligatoria", 0);

                if (contrasena.Length < 6)
                    return (false, "La contraseña debe tener al menos 6 caracteres", 0);

                if (usuario.IdRol <= 0)
                    return (false, "Debe seleccionar un rol válido", 0);

                var rolExiste = _rolDAL.ObtenerPorId(usuario.IdRol);
                if (rolExiste == null)
                    return (false, "El rol seleccionado no existe", 0);

                var usuarioExiste = _usuarioDAL.ObtenerPorNombre(usuario.NombreUsuario);
                if (usuarioExiste != null)
                    return (false, "El nombre de usuario ya existe", 0);

                usuario.ContrasenaHash = PasswordHasher.HashPassword(contrasena);
                int id = _usuarioDAL.Insertar(usuario);

                return (true, "Usuario creado correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear usuario: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Usuario usuario, string? nuevaContrasena = null)
        {
            try
            {
                if (usuario.IdUsuario <= 0)
                    return (false, "ID de usuario inválido");

                if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                    return (false, "El nombre de usuario es obligatorio");

                if (usuario.IdRol <= 0)
                    return (false, "Debe seleccionar un rol válido");

                var usuarioExiste = _usuarioDAL.ObtenerPorId(usuario.IdUsuario);
                if (usuarioExiste == null)
                    return (false, "Usuario no encontrado");

                if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                {
                    if (nuevaContrasena.Length < 6)
                        return (false, "La contraseña debe tener al menos 6 caracteres");
                    
                    usuario.ContrasenaHash = PasswordHasher.HashPassword(nuevaContrasena);
                }
                else
                {
                    usuario.ContrasenaHash = usuarioExiste.ContrasenaHash;
                }

                bool resultado = _usuarioDAL.Actualizar(usuario);
                return resultado 
                    ? (true, "Usuario actualizado correctamente") 
                    : (false, "No se pudo actualizar el usuario");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar usuario: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de usuario inválido");

                var usuario = _usuarioDAL.ObtenerPorId(id);
                if (usuario == null)
                    return (false, "Usuario no encontrado");

                bool resultado = _usuarioDAL.Eliminar(id);
                return resultado 
                    ? (true, "Usuario eliminado correctamente") 
                    : (false, "No se pudo eliminar el usuario");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar usuario: {ex.Message}");
            }
        }

        public List<Usuario> FiltrarPorRol(int idRol)
        {
            var usuarios = _usuarioDAL.ObtenerTodos();
            return usuarios.Where(u => u.IdRol == idRol).ToList();
        }

        public List<Usuario> FiltrarActivos()
        {
            var usuarios = _usuarioDAL.ObtenerTodos();
            return usuarios.Where(u => u.Estado).ToList();
        }
    }
}
