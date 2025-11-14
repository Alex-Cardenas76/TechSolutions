using System;
using System.Collections.Generic;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class TipoMovimientoBLL
    {
        private readonly TipoMovimientoDAL _tipoMovimientoDAL;

        public TipoMovimientoBLL()
        {
            _tipoMovimientoDAL = new TipoMovimientoDAL();
        }

        public (bool exito, string mensaje, List<TipoMovimiento> datos) ObtenerTodos()
        {
            try
            {
                var tipos = _tipoMovimientoDAL.ObtenerTodos();
                return (true, "Tipos de movimiento obtenidos correctamente", tipos);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener tipos de movimiento: {ex.Message}", new List<TipoMovimiento>());
            }
        }

        public (bool exito, string mensaje, TipoMovimiento? tipo) ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return (false, "El ID debe ser mayor a cero", null);

                var tipo = _tipoMovimientoDAL.ObtenerPorId(id);
                if (tipo == null)
                    return (false, "Tipo de movimiento no encontrado", null);

                return (true, "Tipo de movimiento encontrado", tipo);
            }
            catch (Exception ex)
            {
                return (false, $"Error al obtener tipo de movimiento: {ex.Message}", null);
            }
        }
    }
}
