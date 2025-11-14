using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class ProductoBLL
    {
        private readonly ProductoDAL _productoDAL;
        private readonly CategoriaDAL _categoriaDAL;
        private readonly ProveedorDAL _proveedorDAL;

        public ProductoBLL()
        {
            _productoDAL = new ProductoDAL();
            _categoriaDAL = new CategoriaDAL();
            _proveedorDAL = new ProveedorDAL();
        }

        public (bool exito, string mensaje, List<Producto> datos) ObtenerTodos()
        {
            try
            {
                var productos = _productoDAL.ObtenerTodos();
                return (true, "Productos obtenidos correctamente", productos);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener productos: {ex.Message}", new List<Producto>());
            }
        }

        public (bool exito, string mensaje, Producto? producto) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var producto = _productoDAL.ObtenerPorId(id);
                if (producto == null)
                    return (false, "Producto no encontrado", null);

                return (true, "Producto encontrado", producto);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener producto: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje, int idProducto) Insertar(Producto producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    return (false, "El nombre del producto es obligatorio", 0);

                if (producto.Precio <= 0)
                    return (false, "El precio debe ser mayor a cero", 0);

                if (producto.Stock < 0)
                    return (false, "El stock no puede ser negativo", 0);

                if (producto.IdCategoria <= 0)
                    return (false, "Debe seleccionar una categoría válida", 0);

                var categoriaExiste = _categoriaDAL.ObtenerPorId(producto.IdCategoria);
                if (categoriaExiste == null)
                    return (false, "La categoría seleccionada no existe", 0);

                if (producto.IdProveedor.HasValue && producto.IdProveedor.Value > 0)
                {
                    var proveedorExiste = _proveedorDAL.ObtenerPorId(producto.IdProveedor.Value);
                    if (proveedorExiste == null)
                        return (false, "El proveedor seleccionado no existe", 0);
                }

                int id = _productoDAL.Insertar(producto);
                return (true, "Producto creado correctamente", id);
            }
            catch (Exception ex)
            {
                return (false, $"Error al crear producto: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje) Actualizar(Producto producto)
        {
            try
            {
                if (producto.IdProducto <= 0)
                    return (false, "ID de producto inválido");

                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    return (false, "El nombre del producto es obligatorio");

                if (producto.Precio <= 0)
                    return (false, "El precio debe ser mayor a cero");

                if (producto.Stock < 0)
                    return (false, "El stock no puede ser negativo");

                if (producto.IdCategoria <= 0)
                    return (false, "Debe seleccionar una categoría válida");

                var productoExiste = _productoDAL.ObtenerPorId(producto.IdProducto);
                if (productoExiste == null)
                    return (false, "Producto no encontrado");

                var categoriaExiste = _categoriaDAL.ObtenerPorId(producto.IdCategoria);
                if (categoriaExiste == null)
                    return (false, "La categoría seleccionada no existe");

                if (producto.IdProveedor.HasValue && producto.IdProveedor.Value > 0)
                {
                    var proveedorExiste = _proveedorDAL.ObtenerPorId(producto.IdProveedor.Value);
                    if (proveedorExiste == null)
                        return (false, "El proveedor seleccionado no existe");
                }

                bool resultado = _productoDAL.Actualizar(producto);
                return resultado 
                    ? (true, "Producto actualizado correctamente") 
                    : (false, "No se pudo actualizar el producto");
            }
            catch (Exception ex)
            {
                return (false, $"Error al actualizar producto: {ex.Message}");
            }
        }

        public (bool exito, string mensaje) Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "ID de producto inválido");

                var producto = _productoDAL.ObtenerPorId(id);
                if (producto == null)
                    return (false, "Producto no encontrado");

                bool resultado = _productoDAL.Eliminar(id);
                return resultado 
                    ? (true, "Producto eliminado correctamente") 
                    : (false, "No se pudo eliminar el producto");
            }
            catch (Exception ex)
            {
                return (false, $"Error al eliminar producto: {ex.Message}");
            }
        }

        public (bool exito, string mensaje, int stock) VerificarStock(int idProducto)
        {
            try
            {
                if (idProducto <= 0)
                    return (false, "ID de producto inválido", 0);

                int stock = _productoDAL.ObtenerStock(idProducto);
                return (true, "Stock obtenido", stock);
            }
            catch (Exception ex)
            {
                return (false, $"Error al verificar stock: {ex.Message}", 0);
            }
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            var productos = _productoDAL.ObtenerTodos();
            return productos.Where(p => 
                p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        public List<Producto> FiltrarPorCategoria(int idCategoria)
        {
            var productos = _productoDAL.ObtenerTodos();
            return productos.Where(p => p.IdCategoria == idCategoria).ToList();
        }

        public List<Producto> FiltrarPorProveedor(int idProveedor)
        {
            var productos = _productoDAL.ObtenerTodos();
            return productos.Where(p => p.IdProveedor == idProveedor).ToList();
        }

        public List<Producto> ObtenerProductosBajoStock(int stockMinimo)
        {
            var productos = _productoDAL.ObtenerTodos();
            return productos.Where(p => p.Stock <= stockMinimo).OrderBy(p => p.Stock).ToList();
        }
    }
}
