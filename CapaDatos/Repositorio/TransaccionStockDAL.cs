using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class TransaccionStockDAL
    {
        public List<TransaccionStock> ObtenerTodos()
        {
            List<TransaccionStock> lista = new List<TransaccionStock>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdTransaccion, IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, Observacion FROM TransaccionStock ORDER BY FechaMovimiento DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TransaccionStock
                        {
                            IdTransaccion = reader.GetInt32(0),
                            IdProducto = reader.GetInt32(1),
                            IdTipoMovimiento = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3),
                            FechaMovimiento = reader.GetDateTime(4),
                            Observacion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                        });
                    }
                }
            }
            return lista;
        }

        public List<TransaccionStock> ObtenerPorProducto(int idProducto)
        {
            List<TransaccionStock> lista = new List<TransaccionStock>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdTransaccion, IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, Observacion FROM TransaccionStock WHERE IdProducto = @IdProducto ORDER BY FechaMovimiento DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TransaccionStock
                        {
                            IdTransaccion = reader.GetInt32(0),
                            IdProducto = reader.GetInt32(1),
                            IdTipoMovimiento = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3),
                            FechaMovimiento = reader.GetDateTime(4),
                            Observacion = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                        });
                    }
                }
            }
            return lista;
        }

        public int Insertar(TransaccionStock transaccion, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO TransaccionStock (IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, Observacion) VALUES (@IdProducto, @IdTipoMovimiento, @Cantidad, @FechaMovimiento, @Observacion); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@IdProducto", transaccion.IdProducto);
            cmd.Parameters.AddWithValue("@IdTipoMovimiento", transaccion.IdTipoMovimiento);
            cmd.Parameters.AddWithValue("@Cantidad", transaccion.Cantidad);
            cmd.Parameters.AddWithValue("@FechaMovimiento", transaccion.FechaMovimiento);
            cmd.Parameters.AddWithValue("@Observacion", transaccion.Observacion ?? (object)DBNull.Value);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool ActualizarStock(int idProducto, int cantidad, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "UPDATE Producto SET Stock = Stock + @Cantidad WHERE IdProducto = @IdProducto";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
