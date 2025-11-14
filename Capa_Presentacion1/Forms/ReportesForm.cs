using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class ReportesForm : Form
    {
        private readonly ReporteBLL _reporteBLL;

        public ReportesForm()
        {
            InitializeComponent();
            _reporteBLL = new ReporteBLL();
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
        }

        private async void btnVentasPorFecha_Click(object sender, EventArgs e)
        {
            try
            {
                btnVentasPorFecha.Enabled = false;
                var fechaInicio = dtpFechaInicio.Value.Date;
                var fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);

                var resultado = await Task.Run(() => _reporteBLL.ObtenerVentasPorFecha(fechaInicio, fechaFin));

                if (resultado.exito)
                {
                    dgvReporte.DataSource = resultado.datos;
                    ConfigurarDataGridViewVentas();

                    var total = await Task.Run(() => _reporteBLL.ObtenerTotalVentasPorFecha(fechaInicio, fechaFin));
                    if (total.exito)
                        lblResultado.Text = $"Total ventas: {total.total:C2} | Cantidad: {resultado.datos.Count}";
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnVentasPorFecha.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnVentasPorFecha.Enabled = true;
            }
        }

        private async void btnProductosMasVendidos_Click(object sender, EventArgs e)
        {
            try
            {
                btnProductosMasVendidos.Enabled = false;
                var resultado = await Task.Run(() => _reporteBLL.ObtenerProductosMasVendidos(10));

                if (resultado.exito)
                {
                    dgvReporte.DataSource = resultado.datos;
                    lblResultado.Text = $"Top 10 productos más vendidos";
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnProductosMasVendidos.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProductosMasVendidos.Enabled = true;
            }
        }

        private async void btnProductosBajoStock_Click(object sender, EventArgs e)
        {
            try
            {
                btnProductosBajoStock.Enabled = false;
                var resultado = await Task.Run(() => _reporteBLL.ObtenerProductosBajoStock(10));

                if (resultado.exito)
                {
                    dgvReporte.DataSource = resultado.datos;
                    ConfigurarDataGridViewProductos();
                    lblResultado.Text = $"Productos con stock bajo (≤10): {resultado.datos.Count}";
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnProductosBajoStock.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnProductosBajoStock.Enabled = true;
            }
        }

        private async void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                btnEstadisticas.Enabled = false;
                var resultado = await Task.Run(() => _reporteBLL.ObtenerEstadisticasGenerales());

                if (resultado.exito)
                {
                    var stats = resultado.datos;
                    string mensaje = $"=== ESTADÍSTICAS GENERALES ===\n\n";
                    mensaje += $"Total Productos: {stats["TotalProductos"]}\n";
                    mensaje += $"Productos Bajo Stock: {stats["ProductosBajoStock"]}\n";
                    mensaje += $"Valor Inventario: {stats["ValorInventario"]:C2}\n\n";
                    mensaje += $"Ventas Hoy: {stats["VentasHoy"]}\n";
                    mensaje += $"Total Ventas Hoy: {stats["TotalVentasHoy"]:C2}\n\n";
                    mensaje += $"Ventas Mes Actual: {stats["VentasMesActual"]}\n";
                    mensaje += $"Total Ventas Mes: {stats["TotalVentasMesActual"]:C2}";

                    MessageBox.Show(mensaje, "Estadísticas Generales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnEstadisticas.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEstadisticas.Enabled = true;
            }
        }

        private void ConfigurarDataGridViewVentas()
        {
            if (dgvReporte.Columns.Contains("IdVenta"))
            {
                dgvReporte.Columns["IdVenta"].HeaderText = "ID";
                dgvReporte.Columns["Fecha"].HeaderText = "Fecha";
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReporte.Columns["IdCliente"].HeaderText = "ID Cliente";
                dgvReporte.Columns["IdUsuario"].HeaderText = "ID Usuario";
                dgvReporte.Columns["Total"].HeaderText = "Total";
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

                if (dgvReporte.Columns.Contains("Cliente"))
                    dgvReporte.Columns["Cliente"].Visible = false;
                if (dgvReporte.Columns.Contains("Usuario"))
                    dgvReporte.Columns["Usuario"].Visible = false;
                if (dgvReporte.Columns.Contains("DetalleVentas"))
                    dgvReporte.Columns["DetalleVentas"].Visible = false;
            }

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarDataGridViewProductos()
        {
            if (dgvReporte.Columns.Contains("IdProducto"))
            {
                dgvReporte.Columns["IdProducto"].HeaderText = "ID";
                dgvReporte.Columns["Nombre"].HeaderText = "Nombre";
                dgvReporte.Columns["Precio"].HeaderText = "Precio";
                dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvReporte.Columns["Stock"].HeaderText = "Stock";

                if (dgvReporte.Columns.Contains("Descripcion"))
                    dgvReporte.Columns["Descripcion"].Visible = false;
                if (dgvReporte.Columns.Contains("IdCategoria"))
                    dgvReporte.Columns["IdCategoria"].Visible = false;
                if (dgvReporte.Columns.Contains("IdProveedor"))
                    dgvReporte.Columns["IdProveedor"].Visible = false;
                if (dgvReporte.Columns.Contains("Categoria"))
                    dgvReporte.Columns["Categoria"].Visible = false;
                if (dgvReporte.Columns.Contains("Proveedor"))
                    dgvReporte.Columns["Proveedor"].Visible = false;
                if (dgvReporte.Columns.Contains("DetalleVentas"))
                    dgvReporte.Columns["DetalleVentas"].Visible = false;
                if (dgvReporte.Columns.Contains("TransaccionesStock"))
                    dgvReporte.Columns["TransaccionesStock"].Visible = false;
            }

            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
