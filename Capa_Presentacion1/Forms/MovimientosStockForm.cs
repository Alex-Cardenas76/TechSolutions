using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class MovimientosStockForm : Form
    {
        private readonly TransaccionStockBLL _transaccionBLL;
        private readonly TipoMovimientoBLL _tipoMovimientoBLL;
        private List<TransaccionStock> _transacciones;

        public MovimientosStockForm()
        {
            InitializeComponent();
            _transaccionBLL = new TransaccionStockBLL();
            _tipoMovimientoBLL = new TipoMovimientoBLL();
            _transacciones = new List<TransaccionStock>();
            CargarTiposMovimiento();
            CargarTransacciones();
        }

        private async void CargarTiposMovimiento()
        {
            try
            {
                var resultado = await Task.Run(() => _tipoMovimientoBLL.ObtenerTodos());
                if (resultado.exito)
                {
                    var tipos = resultado.datos.ToList();
                    tipos.Insert(0, new TipoMovimiento { IdTipoMovimiento = 0, NombreMovimiento = "Todos" });
                    cmbTipoMovimiento.DataSource = tipos;
                    cmbTipoMovimiento.DisplayMember = "NombreMovimiento";
                    cmbTipoMovimiento.ValueMember = "IdTipoMovimiento";
                    cmbTipoMovimiento.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarTransacciones()
        {
            try
            {
                btnBuscar.Enabled = false;
                var resultado = await Task.Run(() => _transaccionBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _transacciones = resultado.datos;
                    dgvTransacciones.DataSource = _transacciones;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_transacciones.Count}";
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBuscar.Enabled = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvTransacciones.Columns["IdTransaccion"].HeaderText = "ID";
            dgvTransacciones.Columns["IdProducto"].HeaderText = "ID Producto";
            dgvTransacciones.Columns["IdTipoMovimiento"].HeaderText = "ID Tipo";
            dgvTransacciones.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvTransacciones.Columns["FechaMovimiento"].HeaderText = "Fecha";
            dgvTransacciones.Columns["FechaMovimiento"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvTransacciones.Columns["Observacion"].HeaderText = "Observación";

            if (dgvTransacciones.Columns.Contains("Producto"))
                dgvTransacciones.Columns["Producto"].Visible = false;
            if (dgvTransacciones.Columns.Contains("TipoMovimiento"))
                dgvTransacciones.Columns["TipoMovimiento"].Visible = false;

            dgvTransacciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransacciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransacciones.MultiSelect = false;
            dgvTransacciones.ReadOnly = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var fechaInicio = dtpFechaInicio.Value.Date;
            var fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1);
            var idTipo = (int)cmbTipoMovimiento.SelectedValue;

            var filtrados = _transaccionBLL.FiltrarPorFecha(fechaInicio, fechaFin);

            if (idTipo > 0)
                filtrados = _transaccionBLL.FiltrarPorTipo(idTipo);

            dgvTransacciones.DataSource = filtrados;
            lblTotal.Text = $"Resultados: {filtrados.Count}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;
            cmbTipoMovimiento.SelectedIndex = 0;
            dgvTransacciones.DataSource = _transacciones;
            lblTotal.Text = $"Total: {_transacciones.Count}";
        }
    }
}
