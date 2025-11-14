using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class VentaDAL
    {
        public List<Venta> ObtenerTodos()
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdVenta, Fecha, IdCliente, IdUsuario, Total FROM Venta ORDER BY Fecha DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Venta
                        {
                            IdVenta = reader.GetInt32(0),
                            Fecha = reader.GetDateTime(1),
                            IdCliente = reader.GetInt32(2),
                            IdUsuario = reader.GetInt32(3),
                            Total = reader.GetDecimal(4)
                        });
                    }
                }
            }
            return lista;
        }

        public Venta ObtenerPorId(int id)
        {
            Venta venta = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdVenta, Fecha, IdCliente, IdUsuario, Total FROM Venta WHERE IdVenta = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        venta = new Venta
                        {
                            IdVenta = reader.GetInt32(0),
                            Fecha = reader.GetDateTime(1),
                            IdCliente = reader.GetInt32(2),
                            IdUsuario = reader.GetInt32(3),
                            Total = reader.GetDecimal(4)
                        };
                    }
                }
            }
            return venta;
        }

        public int Insertar(Venta venta, SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO Venta (Fecha, IdCliente, IdUsuario, Total) VALUES (@Fecha, @IdCliente, @IdUsuario, @Total); SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
            cmd.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
            cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
            cmd.Parameters.AddWithValue("@Total", venta.Total);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool RegistrarVentaCompleta(Venta venta, List<DetalleVenta> detalles)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // 1. Insertar venta
                    int idVenta = Insertar(venta, conn, transaction);

                    // 2. Insertar detalles y actualizar stock
                    DetalleVentaDAL detalleDAL = new DetalleVentaDAL();
                    TransaccionStockDAL stockDAL = new TransaccionStockDAL();

                    foreach (var detalle in detalles)
                    {
                        detalle.IdVenta = idVenta;
                        detalleDAL.Insertar(detalle, conn, transaction);

                        // Descontar stock
                        stockDAL.ActualizarStock(detalle.IdProducto, -detalle.Cantidad, conn, transaction);

                        // Registrar transacción de stock (IdTipoMovimiento = 2 para Salida/Venta)
                        TransaccionStock transaccion = new TransaccionStock
                        {
                            IdProducto = detalle.IdProducto,
                            IdTipoMovimiento = 2,
                            Cantidad = -detalle.Cantidad,
                            FechaMovimiento = DateTime.Now,
                            Observacion = $"Venta #{idVenta}"
                        };
                        stockDAL.Insertar(transaccion, conn, transaction);
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Venta WHERE IdVenta = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Venta> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdVenta, Fecha, IdCliente, IdUsuario, Total FROM Venta WHERE Fecha BETWEEN @FechaInicio AND @FechaFin ORDER BY Fecha DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Venta
                        {
                            IdVenta = reader.GetInt32(0),
                            Fecha = reader.GetDateTime(1),
                            IdCliente = reader.GetInt32(2),
                            IdUsuario = reader.GetInt32(3),
                            Total = reader.GetDecimal(4)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
