using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class DetalleVentaDAL
    {
        public List<DetalleVenta> ObtenerPorVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdDetalleVenta, IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal FROM DetalleVenta WHERE IdVenta = @IdVenta";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DetalleVenta
                        {
                            IdDetalleVenta = reader.GetInt32(0),
                            IdVenta = reader.GetInt32(1),
                            IdProducto = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3),
                            PrecioUnitario = reader.GetDecimal(4),
                            Subtotal = reader.GetDecimal(5)
                        });
                    }
                }
            }
            return lista;
        }

        public int Insertar(DetalleVenta detalle, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@IdVenta", detalle.IdVenta);
            cmd.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
            cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
            cmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
            cmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM DetalleVenta WHERE IdDetalleVenta = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
