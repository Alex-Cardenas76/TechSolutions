using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class ProveedorDAL
    {
        public List<Proveedor> ObtenerTodos()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdProveedor, NombreProveedor, Telefono, Email, Direccion FROM Proveedor";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            IdProveedor = reader.GetInt32(0),
                            NombreProveedor = reader.GetString(1),
                            Telefono = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Direccion = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                        });
                    }
                }
            }
            return lista;
        }

        public Proveedor ObtenerPorId(int id)
        {
            Proveedor proveedor = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdProveedor, NombreProveedor, Telefono, Email, Direccion FROM Proveedor WHERE IdProveedor = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        proveedor = new Proveedor
                        {
                            IdProveedor = reader.GetInt32(0),
                            NombreProveedor = reader.GetString(1),
                            Telefono = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Direccion = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                        };
                    }
                }
            }
            return proveedor;
        }

        public int Insertar(Proveedor proveedor)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Proveedor (NombreProveedor, Telefono, Email, Direccion) VALUES (@Nombre, @Telefono, @Email, @Direccion); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion ?? (object)DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Proveedor proveedor)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Proveedor SET NombreProveedor = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion WHERE IdProveedor = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.NombreProveedor);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Proveedor WHERE IdProveedor = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
