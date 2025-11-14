using System;
using System.Collections.Generic;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class DetalleVentaBLL
    {
        private readonly DetalleVentaDAL _detalleVentaDAL;

        public DetalleVentaBLL()
        {
            _detalleVentaDAL = new DetalleVentaDAL();
        }

        public (bool exito, string mensaje, List<DetalleVenta> datos) ObtenerPorVenta(int idVenta)
        {
            try
            {
                if (idVenta <= 0)
                    return (false, "El ID de venta debe ser mayor a cero", new List<DetalleVenta>());

                var detalles = _detalleVentaDAL.ObtenerPorVenta(idVenta);
                return (true, "Detalles obtenidos correctamente", detalles);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener detalles de venta: {ex.Message}", new List<DetalleVenta>());
            }
        }
    }
}
