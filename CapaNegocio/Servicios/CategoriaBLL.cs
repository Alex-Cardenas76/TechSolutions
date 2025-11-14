using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBLL()
        {
            _categoriaDAL = new CategoriaDAL();
        }

        public (bool exito, string mensaje, List<Categoria> datos) ObtenerTodos()
        {
            try
            {
                var categorias = _categoriaDAL.ObtenerTodos();
                return (true, "Categorías obtenidas correctamente", categorias);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener categorías: {ex.Message}", new List<Categoria>());
            }
        }

        public (bool exito, string mensaje, Categoria? categoria) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var categoria = _categoriaDAL.ObtenerPorId(id);
                if (categoria == null)
                    return (false, "Categoría no encontrada", null);

                return (true, "Categoría encontrada", categoria);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener categoría: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idCategoria) Insertar(Categoria categoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
                    return (false, "El nombre de la categoría es obligatorio", 0);

                int id = _categoriaDAL.Insertar(categoria);
                return (true, "Categoría creada correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear categoría: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Categoria categoria)
        {
            try
            {
                if (categoria.IdCategoria <= 0)
                    return (false, "ID de categoría inválido");

                if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
                    return (false, "El nombre de la categoría es obligatorio");

                var categoriaExiste = _categoriaDAL.ObtenerPorId(categoria.IdCategoria);
                if (categoriaExiste == null)
                    return (false, "Categoría no encontrada");

                bool resultado = _categoriaDAL.Actualizar(categoria);
                return resultado 
                    ? (true, "Categoría actualizada correctamente") 
                    : (false, "No se pudo actualizar la categoría");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar categoría: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de categoría inválido");

                var categoria = _categoriaDAL.ObtenerPorId(id);
                if (categoria == null)
                    return (false, "Categoría no encontrada");

                bool resultado = _categoriaDAL.Eliminar(id);
                return resultado 
                    ? (true, "Categoría eliminada correctamente") 
                    : (false, "No se pudo eliminar la categoría");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar categoría: {ex.Message}");
            }
        }

        public List<Categoria> BuscarPorNombre(string nombre)
        {
            var categorias = _categoriaDAL.ObtenerTodos();
            return categorias.Where(c => 
                c.NombreCategoria.Contains(nombre, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
