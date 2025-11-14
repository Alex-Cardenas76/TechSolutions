using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL;
        private readonly ProductoDAL _productoDAL;
        private readonly ClienteDAL _clienteDAL;
        private readonly UsuarioDAL _usuarioDAL;

        public VentaBLL()
        {
            _ventaDAL = new VentaDAL();
            _productoDAL = new ProductoDAL();
            _clienteDAL = new ClienteDAL();
            _usuarioDAL = new UsuarioDAL();
        }

        public (bool exito, string mensaje, List<Venta> datos) ObtenerTodos()
        {
            try
            {
                var ventas = _ventaDAL.ObtenerTodos();
                return (true, "Ventas obtenidas correctamente", ventas);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener ventas: {ex.Message}", new List<Venta>());
            }
        }

        public (bool exito, string mensaje, Venta? venta) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var venta = _ventaDAL.ObtenerPorId(id);
                if (venta == null)
                    return (false, "Venta no encontrada", null);

                return (true, "Venta encontrada", venta);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener venta: {ex.Message}", null);
            }
        }

        public (bool exito, string mensaje) RegistrarVenta(Venta venta, List<DetalleVenta> detalles)
        {
            try
            {
                // Validaciones básicas
                if (venta.IdCliente <= 0)
                    return (false, "Debe seleccionar un cliente válido");

                if (venta.IdUsuario <= 0)
                    return (false, "Debe seleccionar un usuario válido");

                if (detalles == null || detalles.Count == 0)
                    return (false, "Debe agregar al menos un producto a la venta");

                // Verificar que cliente existe
                var clienteExiste = _clienteDAL.ObtenerPorId(venta.IdCliente);
                if (clienteExiste == null)
                    return (false, "El cliente seleccionado no existe");

                // Verificar que usuario existe
                var usuarioExiste = _usuarioDAL.ObtenerPorId(venta.IdUsuario);
                if (usuarioExiste == null)
                    return (false, "El usuario seleccionado no existe");

                // Validar cada detalle y verificar stock
                decimal totalVenta = 0;
                foreach (var detalle in detalles)
                {
                    if (detalle.IdProducto <= 0)
                        return (false, "ID de producto inválido en los detalles");

                    if (detalle.Cantidad <= 0)
                        return (false, "La cantidad debe ser mayor a cero");

                    var producto = _productoDAL.ObtenerPorId(detalle.IdProducto);
                    if (producto == null)
                        return (false, $"El producto con ID {detalle.IdProducto} no existe");

                    if (producto.Stock < detalle.Cantidad)
                        return (false, $"Stock insuficiente para el producto '{producto.Nombre}'. Stock disponible: {producto.Stock}");

                    // Calcular subtotal
                    detalle.PrecioUnitario = producto.Precio;
                    detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                    totalVenta += detalle.Subtotal;
                }

                // Asignar total calculado
                venta.Total = totalVenta;
                venta.Fecha = DateTime.Now;

                // Registrar venta completa (con transacción)
                bool resultado = _ventaDAL.RegistrarVentaCompleta(venta, detalles);

                return resultado 
                    ? (true, $"Venta registrada correctamente. Total: {totalVenta:C}") 
                    : (false, "No se pudo registrar la venta");
            }
            catch (Exception ex)
            {
                return (false, $"Error al registrar venta: {ex.Message}");
            }
        }

        public (bool exito, string mensaje, List<Venta> datos) ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                    return (false, "La fecha de inicio no puede ser mayor a la fecha fin", new List<Venta>());

                var ventas = _ventaDAL.ObtenerPorFecha(fechaInicio, fechaFin);
                return (true, "Ventas obtenidas correctamente", ventas);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener ventas por fecha: {ex.Message}", new List<Venta>());
            }
        }

        public (bool exito, string mensaje, decimal total) CalcularTotalVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                    return (false, "La fecha de inicio no puede ser mayor a la fecha fin", 0);

                var ventas = _ventaDAL.ObtenerPorFecha(fechaInicio, fechaFin);
                decimal total = ventas.Sum(v => v.Total);

                return (true, "Total calculado correctamente", total);
            }
            catch (Exception ex)
            {
                return (false, $"Error al calcular total de ventas: {ex.Message}", 0);
            }
        }

        public List<Venta> FiltrarPorCliente(int idCliente)
        {
            var ventas = _ventaDAL.ObtenerTodos();
            return ventas.Where(v => v.IdCliente == idCliente).ToList();
        }

        public List<Venta> FiltrarPorUsuario(int idUsuario)
        {
            var ventas = _ventaDAL.ObtenerTodos();
            return ventas.Where(v => v.IdUsuario == idUsuario).ToList();
        }
    }
}
