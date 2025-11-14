using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad.Models;
using CapaDatos.Repositorio;

namespace CapaNegocio.Servicios
{
    public class ReporteBLL
    {
        private readonly ReporteDAL _reporteDAL;
        private readonly VentaDAL _ventaDAL;
        private readonly ProductoDAL _productoDAL;

        public ReporteBLL()
        {
            _reporteDAL = new ReporteDAL();
            _ventaDAL = new VentaDAL();
            _productoDAL = new ProductoDAL();
        }

        public (bool exito, string mensaje, List<Venta> datos) ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                    return (false, "La fecha de inicio no puede ser mayor a la fecha fin", new List<Venta>());

                var ventas = _reporteDAL.ObtenerVentasPorFecha(fechaInicio, fechaFin);
                return (true, "Reporte de ventas generado correctamente", ventas);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar reporte de ventas: {ex.Message}", new List<Venta>());
            }
        }

        public (bool exito, string mensaje, decimal total) ObtenerTotalVentasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                    return (false, "La fecha de inicio no puede ser mayor a la fecha fin", 0);

                decimal total = _reporteDAL.ObtenerTotalVentasPorFecha(fechaInicio, fechaFin);
                return (true, "Total de ventas calculado correctamente", total);
            }
            catch (Exception ex)
            {
                return (false, $"Error al calcular total de ventas: {ex.Message}", 0);
            }
        }

        public (bool exito, string mensaje, List<Producto> datos) ObtenerProductosBajoStock(int stockMinimo = 10)
        {
            try
            {
                if (stockMinimo < 0)
                    return (false, "El stock mínimo no puede ser negativo", new List<Producto>());

                var productos = _reporteDAL.ObtenerProductosBajoStock(stockMinimo);
                return (true, "Reporte de productos con bajo stock generado correctamente", productos);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar reporte de stock: {ex.Message}", new List<Producto>());
            }
        }

        public (bool exito, string mensaje, List<dynamic> datos) ObtenerProductosMasVendidos(int top = 10)
        {
            try
            {
                if (top <= 0)
                    return (false, "El número de productos debe ser mayor a cero", new List<dynamic>());

                var productos = _reporteDAL.ObtenerProductosMasVendidos(top);
                return (true, "Reporte de productos más vendidos generado correctamente", productos);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar reporte de productos más vendidos: {ex.Message}", new List<dynamic>());
            }
        }

        public (bool exito, string mensaje, List<TransaccionStock> datos) ObtenerMovimientosStock(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (fechaInicio > fechaFin)
                    return (false, "La fecha de inicio no puede ser mayor a la fecha fin", new List<TransaccionStock>());

                var movimientos = _reporteDAL.ObtenerMovimientosStock(fechaInicio, fechaFin);
                return (true, "Reporte de movimientos de stock generado correctamente", movimientos);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar reporte de movimientos: {ex.Message}", new List<TransaccionStock>());
            }
        }

        public (bool exito, string mensaje, Dictionary<string, object> datos) ObtenerEstadisticasGenerales()
        {
            try
            {
                var estadisticas = new Dictionary<string, object>();

                // Total de productos
                var productos = _productoDAL.ObtenerTodos();
                estadisticas["TotalProductos"] = productos.Count;
                estadisticas["ProductosBajoStock"] = productos.Count(p => p.Stock <= 10);

                // Ventas del mes actual
                var inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var finMes = inicioMes.AddMonths(1).AddDays(-1);
                var ventasMes = _ventaDAL.ObtenerPorFecha(inicioMes, finMes);
                estadisticas["VentasMesActual"] = ventasMes.Count;
                estadisticas["TotalVentasMesActual"] = ventasMes.Sum(v => v.Total);

                // Ventas del día
                var hoy = DateTime.Today;
                var ventasHoy = _ventaDAL.ObtenerPorFecha(hoy, hoy.AddDays(1).AddSeconds(-1));
                estadisticas["VentasHoy"] = ventasHoy.Count;
                estadisticas["TotalVentasHoy"] = ventasHoy.Sum(v => v.Total);

                // Valor total del inventario
                decimal valorInventario = productos.Sum(p => p.Precio * p.Stock);
                estadisticas["ValorInventario"] = valorInventario;

                return (true, "Estadísticas generadas correctamente", estadisticas);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar estadísticas: {ex.Message}", new Dictionary<string, object>());
            }
        }

        public (bool exito, string mensaje, List<object> datos) ObtenerVentasPorMes(int año)
        {
            try
            {
                if (año < 2000 || año > DateTime.Now.Year + 1)
                    return (false, "Año inválido", new List<object>());

                var ventasAnuales = new List<object>();

                for (int mes = 1; mes <= 12; mes++)
                {
                    var inicioMes = new DateTime(año, mes, 1);
                    var finMes = inicioMes.AddMonths(1).AddDays(-1);
                    var ventas = _ventaDAL.ObtenerPorFecha(inicioMes, finMes);

                    ventasAnuales.Add(new
                    {
                        Mes = mes,
                        NombreMes = inicioMes.ToString("MMMM"),
                        CantidadVentas = ventas.Count,
                        TotalVentas = ventas.Sum(v => v.Total)
                    });
                }

                return (true, "Reporte de ventas por mes generado correctamente", ventasAnuales);
            }
            catch (Exception ex)
            {
                return (false, $"Error al generar reporte mensual: {ex.Message}", new List<object>());
            }
        }
    }
}
