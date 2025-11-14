using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class TransaccionStockBLL
    {
        private readonly TransaccionStockDAL _transaccionDAL;
        private readonly ProductoDAL _productoDAL;
        private readonly TipoMovimientoDAL _tipoMovimientoDAL;

        public TransaccionStockBLL()
        {
            _transaccionDAL = new TransaccionStockDAL();
            _productoDAL = new ProductoDAL();
            _tipoMovimientoDAL = new TipoMovimientoDAL();
        }

        public (bool exito, string mensaje, List<TransaccionStock> datos) ObtenerTodos()
        {
            try
            {
                var transacciones = _transaccionDAL.ObtenerTodos();
                return (true, "Transacciones obtenidas correctamente", transacciones);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener transacciones: {ex.Message}", new List<TransaccionStock>());
            }
        }

        public (bool exito, string mensaje, List<TransaccionStock> datos) ObtenerPorProducto(int idProducto)
        {
            try
            {
                if (idProducto <= 0)
                    return (false, "El ID de producto debe ser mayor a cero", new List<TransaccionStock>());

                var transacciones = _transaccionDAL.ObtenerPorProducto(idProducto);
                return (true, "Transacciones obtenidas correctamente", transacciones);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener transacciones del producto: {ex.Message}", new List<TransaccionStock>());
            }
        }

        public List<TransaccionStock> FiltrarPorTipo(int idTipoMovimiento)
        {
            var transacciones = _transaccionDAL.ObtenerTodos();
            return transacciones.Where(t => t.IdTipoMovimiento == idTipoMovimiento).ToList();
        }

        public List<TransaccionStock> FiltrarPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            var transacciones = _transaccionDAL.ObtenerTodos();
            return transacciones.Where(t => 
                t.FechaMovimiento >= fechaInicio && t.FechaMovimiento <= fechaFin
            ).ToList();
        }
    }
}
