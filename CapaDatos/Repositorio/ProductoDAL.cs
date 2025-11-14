using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class ProductoDAL
    {
        public List<Producto> ObtenerTodos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdProducto, Nombre, Descripcion, Precio, Stock, IdCategoria, IdProveedor FROM Producto";
                SqlCommand cmd = new SqlCommand(query, conn);
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

        public Producto ObtenerPorId(int id)
        {
            Producto producto = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdProducto, Nombre, Descripcion, Precio, Stock, IdCategoria, IdProveedor FROM Producto WHERE IdProducto = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new Producto
                        {
                            IdProducto = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Descripcion = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Precio = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            IdCategoria = reader.GetInt32(5),
                            IdProveedor = reader.IsDBNull(6) ? null : reader.GetInt32(6)
                        };
                    }
                }
            }
            return producto;
        }

        public int Insertar(Producto producto)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Producto (Nombre, Descripcion, Precio, Stock, IdCategoria, IdProveedor) VALUES (@Nombre, @Descripcion, @Precio, @Stock, @IdCategoria, @IdProveedor); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdProveedor", producto.IdProveedor ?? (object)DBNull.Value);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Producto producto)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Producto SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock, IdCategoria = @IdCategoria, IdProveedor = @IdProveedor WHERE IdProducto = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", producto.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                cmd.Parameters.AddWithValue("@IdProveedor", producto.IdProveedor ?? (object)DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Producto WHERE IdProducto = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int ObtenerStock(int idProducto)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT Stock FROM Producto WHERE IdProducto = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", idProducto);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
