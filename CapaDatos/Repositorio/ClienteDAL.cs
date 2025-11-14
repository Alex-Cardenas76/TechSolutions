using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class ClienteDAL
    {
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdCliente, Nombre, Apellido, Email, Telefono, Direccion FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Telefono = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Direccion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                        });
                    }
                }
            }
            return lista;
        }

        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdCliente, Nombre, Apellido, Email, Telefono, Direccion FROM Cliente WHERE IdCliente = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Telefono = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Direccion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                        };
                    }
                }
            }
            return cliente;
        }

        public int Insertar(Cliente cliente)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Cliente (Nombre, Apellido, Email, Telefono, Direccion) VALUES (@Nombre, @Apellido, @Email, @Telefono, @Direccion); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Cliente cliente)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, Direccion = @Direccion WHERE IdCliente = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Cliente WHERE IdCliente = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
