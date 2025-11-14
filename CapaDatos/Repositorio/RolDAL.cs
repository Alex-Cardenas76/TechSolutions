using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class RolDAL
    {
        public List<Rol> ObtenerTodos()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdRol, NombreRol, Descripcion FROM Rol";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Rol
                        {
                            IdRol = reader.GetInt32(0),
                            NombreRol = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public Rol ObtenerPorId(int id)
        {
            Rol rol = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdRol, NombreRol, Descripcion FROM Rol WHERE IdRol = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rol = new Rol
                        {
                            IdRol = reader.GetInt32(0),
                            NombreRol = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                        };
                    }
                }
            }
            return rol;
        }

        public int Insertar(Rol rol)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Rol (NombreRol, Descripcion) VALUES (@Nombre, @Descripcion); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", rol.NombreRol);
                cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Rol rol)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Rol SET NombreRol = @Nombre, Descripcion = @Descripcion WHERE IdRol = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", rol.IdRol);
                cmd.Parameters.AddWithValue("@Nombre", rol.NombreRol);
                cmd.Parameters.AddWithValue("@Descripcion", rol.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Rol WHERE IdRol = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
