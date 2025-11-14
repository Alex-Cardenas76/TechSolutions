using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CapaEntidad.Models;
using CapaDatos.Database;

namespace CapaDatos.Repositorio
{
    public class UsuarioDAL
    {
        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdUsuario, NombreUsuario, ContrasenaHash, IdRol, Estado FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            NombreUsuario = reader.GetString(1),
                            ContrasenaHash = (byte[])reader[2],
                            IdRol = reader.GetInt32(3),
                            Estado = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return lista;
        }

        public Usuario ObtenerPorId(int id)
        {
            Usuario usuario = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdUsuario, NombreUsuario, ContrasenaHash, IdRol, Estado FROM Usuario WHERE IdUsuario = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            NombreUsuario = reader.GetString(1),
                            ContrasenaHash = (byte[])reader[2],
                            IdRol = reader.GetInt32(3),
                            Estado = reader.GetBoolean(4)
                        };
                    }
                }
            }
            return usuario;
        }

        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "SELECT IdUsuario, NombreUsuario, ContrasenaHash, IdRol, Estado FROM Usuario WHERE NombreUsuario = @Nombre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", nombreUsuario);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            NombreUsuario = reader.GetString(1),
                            ContrasenaHash = (byte[])reader[2],
                            IdRol = reader.GetInt32(3),
                            Estado = reader.GetBoolean(4)
                        };
                    }
                }
            }
            return usuario;
        }

        public int Insertar(Usuario usuario)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "INSERT INTO Usuario (NombreUsuario, ContrasenaHash, IdRol, Estado) VALUES (@Nombre, @Contrasena, @IdRol, @Estado); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasena", usuario.ContrasenaHash);
                cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool Actualizar(Usuario usuario)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "UPDATE Usuario SET NombreUsuario = @Nombre, ContrasenaHash = @Contrasena, IdRol = @IdRol, Estado = @Estado WHERE IdUsuario = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasena", usuario.ContrasenaHash);
                cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int id)
        {
            using (SqlConnection conn = ConexionBD.Instancia.CrearConexion())
            {
                string query = "DELETE FROM Usuario WHERE IdUsuario = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
