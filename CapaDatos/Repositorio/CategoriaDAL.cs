using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class CategoriaDAL
    {
        public List<Categoria> ObtenerTodos()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdCategoria, NombreCategoria, Descripcion FROM Categoria";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Categoria
                        {
                            IdCategoria = reader.GetInt32(0),
                            NombreCategoria = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public Categoria ObtenerPorId(int id)
        {
            Categoria categoria = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdCategoria, NombreCategoria, Descripcion FROM Categoria WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        categoria = new Categoria
                        {
                            IdCategoria = reader.GetInt32(0),
                            NombreCategoria = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                        };
                    }
                }
            }
            return categoria;
        }

        public int Insertar(Categoria categoria)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Categoria (NombreCategoria, Descripcion) VALUES (@Nombre, @Descripcion); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Categoria categoria)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Categoria SET NombreCategoria = @Nombre, Descripcion = @Descripcion WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", categoria.IdCategoria);
                cmd.Parameters.AddWithValue("@Nombre", categoria.NombreCategoria);
                cmd.Parameters.AddWithValue("@Descripcion", categoria.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Categoria WHERE IdCategoria = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
