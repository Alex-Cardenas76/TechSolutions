using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class ReporteDAL
    {
        public List<Venta> ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> lista = new List<Venta>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = @"SELECT v.IdVenta, v.Fecha, v.IdCliente, v.IdUsuario, v.Total 
                                FROM Venta v 
                                WHERE v.Fecha BETWEEN @FechaInicio AND @FechaFin 
                                ORDER BY v.Fecha DESC";
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

        public decimal ObtenerTotalVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT ISNULL(SUM(Total), 0) FROM Venta WHERE Fecha BETWEEN @FechaInicio AND @FechaFin";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                conn.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public List<Producto> ObtenerProductosBajoStock(int stockMinimo)
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdProducto, Nombre, Descripcion, Precio, Stock, IdCategoria, IdProveedor FROM Producto WHERE Stock <= @StockMinimo ORDER BY Stock ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StockMinimo", stockMinimo);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            IdProducto = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            IdCategoria = reader.GetInt32(5),
                            IdProveedor = reader.IsDBNull(6) ? null : reader.GetInt32(6)
                        });
                    }
                }
            }
            return lista;
        }

        public List<dynamic> ObtenerProductosMasVendidos(int top)
        {
            List<dynamic> lista = new List<dynamic>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = @"SELECT TOP (@Top) p.IdProducto, p.Nombre, SUM(dv.Cantidad) AS TotalVendido 
                                FROM DetalleVenta dv 
                                INNER JOIN Producto p ON dv.IdProducto = p.IdProducto 
                                GROUP BY p.IdProducto, p.Nombre 
                                ORDER BY TotalVendido DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Top", top);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new
                        {
                            IdProducto = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            TotalVendido = reader.GetInt32(2)
                        });
                    }
                }
            }
            return lista;
        }

        public List<TransaccionStock> ObtenerMovimientosStock(DateTime fechaInicio, DateTime fechaFin)
        {
            List<TransaccionStock> lista = new List<TransaccionStock>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = @"SELECT IdTransaccion, IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, Observacion 
                                FROM TransaccionStock 
                                WHERE FechaMovimiento BETWEEN @FechaInicio AND @FechaFin 
                                ORDER BY FechaMovimiento DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
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
    }
}
