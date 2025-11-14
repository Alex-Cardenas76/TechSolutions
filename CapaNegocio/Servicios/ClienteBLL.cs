using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class ClienteBLL
    {
        private readonly ClienteDAL _clienteDAL;

        public ClienteBLL()
        {
            _clienteDAL = new ClienteDAL();
        }

        public (bool exito, string mensaje, List<Cliente> datos) ObtenerTodos()
        {
            try
            {
                var clientes = _clienteDAL.ObtenerTodos();
                return (true, "Clientes obtenidos correctamente", clientes);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener clientes: {ex.Message}", new List<Cliente>());
            }
        }

        public (bool exito, string mensaje, Cliente? cliente) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var cliente = _clienteDAL.ObtenerPorId(id);
                if (cliente == null)
                    return (false, "Cliente no encontrado", null);

                return (true, "Cliente encontrado", cliente);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener cliente: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idCliente) Insertar(Cliente cliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                    return (false, "El nombre es obligatorio", 0);

                if (string.IsNullOrWhiteSpace(cliente.Apellido))
                    return (false, "El apellido es obligatorio", 0);

                if (!string.IsNullOrWhiteSpace(cliente.Email) && !EsEmailValido(cliente.Email))
                    return (false, "El formato del email no es válido", 0);

                int id = _clienteDAL.Insertar(cliente);
                return (true, "Cliente creado correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear cliente: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Cliente cliente)
        {
            try
            {
                if (cliente.IdCliente <= 0)
                    return (false, "ID de cliente inválido");

                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                    return (false, "El nombre es obligatorio");

                if (string.IsNullOrWhiteSpace(cliente.Apellido))
                    return (false, "El apellido es obligatorio");

                if (!string.IsNullOrWhiteSpace(cliente.Email) && !EsEmailValido(cliente.Email))
                    return (false, "El formato del email no es válido");

                var clienteExiste = _clienteDAL.ObtenerPorId(cliente.IdCliente);
                if (clienteExiste == null)
                    return (false, "Cliente no encontrado");

                bool resultado = _clienteDAL.Actualizar(cliente);
                return resultado 
                    ? (true, "Cliente actualizado correctamente") 
                    : (false, "No se pudo actualizar el cliente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar cliente: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de cliente inválido");

                var cliente = _clienteDAL.ObtenerPorId(id);
                if (cliente == null)
                    return (false, "Cliente no encontrado");

                bool resultado = _clienteDAL.Eliminar(id);
                return resultado 
                    ? (true, "Cliente eliminado correctamente") 
                    : (false, "No se pudo eliminar el cliente");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar cliente: {ex.Message}");
            }
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            var clientes = _clienteDAL.ObtenerTodos();
            return clientes.Where(c => 
                c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) ||
                c.Apellido.Contains(nombre, StringComparison.OrdinalIgnoreCase)
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
