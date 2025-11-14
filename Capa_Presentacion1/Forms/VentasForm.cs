using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class VentasForm : Form
    {
        private readonly VentaBLL _ventaBLL;
        private readonly ClienteBLL _clienteBLL;
        private readonly ProductoBLL _productoBLL;
        private readonly Usuario _usuarioActual;
        private List<DetalleVenta> _detallesVenta;

        public VentasForm(Usuario usuario)
        {
            InitializeComponent();
            _ventaBLL = new VentaBLL();
            _clienteBLL = new ClienteBLL();
            _productoBLL = new ProductoBLL();
            _usuarioActual = usuario;
            _detallesVenta = new List<DetalleVenta>();
            CargarCombos();
            ConfigurarDataGridView();
        }

        private async void CargarCombos()
        {
            try
            {
                var clientes = await Task.Run(() => _clienteBLL.ObtenerTodos());
                if (clientes.exito)
                {
                    cmbCliente.DataSource = clientes.datos;
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "IdCliente";
                    cmbCliente.SelectedIndex = -1;
                }

                var productos = await Task.Run(() => _productoBLL.ObtenerTodos());
                if (productos.exito)
                {
                    cmbProducto.DataSource = productos.datos;
                    cmbProducto.DisplayMember = "Nombre";
                    cmbProducto.ValueMember = "IdProducto";
                    cmbProducto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdProducto", HeaderText = "ID Producto", Width = 80 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cantidad", Width = 80 });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PrecioUnitario", HeaderText = "Precio Unit.", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Subtotal", HeaderText = "Subtotal", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            
            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Text = "Quitar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvDetalles.Columns.Add(btnEliminar);

            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.MultiSelect = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.CellClick += DgvDetalles_CellClick;
        }

        private void DgvDetalles_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvDetalles.Columns.Count - 1)
            {
                _detallesVenta.RemoveAt(e.RowIndex);
                ActualizarGrilla();
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != -1)
            {
                var producto = (Producto)cmbProducto.SelectedItem;
                txtPrecio.Text = producto.Precio.ToString("F2");
                txtStockDisponible.Text = producto.Stock.ToString();
                nudCantidad.Maximum = producto.Stock;
                nudCantidad.Value = 1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = (Producto)cmbProducto.SelectedItem;

            var detalleExistente = _detallesVenta.FirstOrDefault(d => d.IdProducto == producto.IdProducto);
            if (detalleExistente != null)
            {
                detalleExistente.Cantidad += (int)nudCantidad.Value;
                detalleExistente.Subtotal = detalleExistente.Cantidad * detalleExistente.PrecioUnitario;
            }
            else
            {
                var detalle = new DetalleVenta
                {
                    IdProducto = producto.IdProducto,
                    Cantidad = (int)nudCantidad.Value,
                    PrecioUnitario = producto.Precio,
                    Subtotal = (int)nudCantidad.Value * producto.Precio
                };
                _detallesVenta.Add(detalle);
            }

            ActualizarGrilla();
            cmbProducto.SelectedIndex = -1;
            nudCantidad.Value = 1;
        }

        private void ActualizarGrilla()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesVenta.ToList();
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = _detallesVenta.Sum(d => d.Subtotal);
            lblTotal.Text = $"Total: {total:C2}";
        }

        private async void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detallesVenta.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = new Venta
            {
                IdCliente = (int)cmbCliente.SelectedValue,
                IdUsuario = _usuarioActual.IdUsuario,
                Fecha = DateTime.Now,
                Total = _detallesVenta.Sum(d => d.Subtotal)
            };

            try
            {
                btnRegistrarVenta.Enabled = false;
                var resultado = await Task.Run(() => _ventaBLL.RegistrarVenta(venta, _detallesVenta));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRegistrarVenta.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRegistrarVenta.Enabled = true;
            }
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            cmbCliente.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            _detallesVenta.Clear();
            ActualizarGrilla();
            txtPrecio.Clear();
            txtStockDisponible.Clear();
            nudCantidad.Value = 1;
        }
    }
}
