using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class TipoMovimientoDAL
    {
        public List<TipoMovimiento> ObtenerTodos()
        {
            List<TipoMovimiento> lista = new List<TipoMovimiento>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdTipoMovimiento, NombreMovimiento FROM TipoMovimiento";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TipoMovimiento
                        {
                            IdTipoMovimiento = reader.GetInt32(0),
                            NombreMovimiento = reader.GetString(1)
                        });
                    }
                }
            }
            return lista;
        }

        public TipoMovimiento ObtenerPorId(int id)
        {
            TipoMovimiento tipo = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdTipoMovimiento, NombreMovimiento FROM TipoMovimiento WHERE IdTipoMovimiento = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tipo = new TipoMovimiento
                        {
                            IdTipoMovimiento = reader.GetInt32(0),
                            NombreMovimiento = reader.GetString(1)
                        };
                    }
                }
            }
            return tipo;
        }

        public int Insertar(TipoMovimiento tipo)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO TipoMovimiento (NombreMovimiento) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", tipo.NombreMovimiento);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(TipoMovimiento tipo)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE TipoMovimiento SET NombreMovimiento = @Nombre WHERE IdTipoMovimiento = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", tipo.IdTipoMovimiento);
                cmd.Parameters.AddWithValue("@Nombre", tipo.NombreMovimiento);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM TipoMovimiento WHERE IdTipoMovimiento = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
