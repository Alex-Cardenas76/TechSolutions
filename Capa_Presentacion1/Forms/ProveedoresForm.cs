using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class ProveedoresForm : Form
    {
        private readonly ProveedorBLL _proveedorBLL;
        private List<Proveedor> _proveedores;
        private Proveedor? _proveedorSeleccionado;

        public ProveedoresForm()
        {
            InitializeComponent();
            _proveedorBLL = new ProveedorBLL();
            _proveedores = new List<Proveedor>();
            CargarProveedores();
        }

        private async void CargarProveedores()
        {
            try
            {
                btnNuevo.Enabled = false;
                var resultado = await Task.Run(() => _proveedorBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _proveedores = resultado.datos;
                    dgvProveedores.DataSource = _proveedores;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_proveedores.Count}";
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnNuevo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNuevo.Enabled = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProveedores.Columns["IdProveedor"].HeaderText = "ID";
            dgvProveedores.Columns["NombreProveedor"].HeaderText = "Nombre";
            dgvProveedores.Columns["Telefono"].HeaderText = "Teléfono";
            dgvProveedores.Columns["Email"].HeaderText = "Email";
            dgvProveedores.Columns["Direccion"].HeaderText = "Dirección";

            if (dgvProveedores.Columns.Contains("Productos"))
                dgvProveedores.Columns["Productos"].Visible = false;

            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            _proveedorSeleccionado = null;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var proveedor = new Proveedor
            {
                NombreProveedor = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            if (_proveedorSeleccionado == null)
                InsertarProveedor(proveedor);
            else
            {
                proveedor.IdProveedor = _proveedorSeleccionado.IdProveedor;
                ActualizarProveedor(proveedor);
            }
        }

        private async void InsertarProveedor(Proveedor proveedor)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _proveedorBLL.Insertar(proveedor));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarProveedores();
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
            }
        }

        private async void ActualizarProveedor(Proveedor proveedor)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _proveedorBLL.Actualizar(proveedor));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarProveedores();
                    _proveedorSeleccionado = null;
                }
                else
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardar.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _proveedorSeleccionado = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;
            txtNombre.Text = _proveedorSeleccionado.NombreProveedor;
            txtTelefono.Text = _proveedorSeleccionado.Telefono;
            txtEmail.Text = _proveedorSeleccionado.Email;
            txtDireccion.Text = _proveedorSeleccionado.Direccion;
            HabilitarCampos(true);
            txtNombre.Focus();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedor = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar a {proveedor.NombreProveedor}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    var resultado = await Task.Run(() => _proveedorBLL.Eliminar(proveedor.IdProveedor));

                    if (resultado.exito)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProveedores();
                    }
                    else
                        MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnEliminar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
            _proveedorSeleccionado = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                dgvProveedores.DataSource = _proveedores;
            else
            {
                var filtrados = _proveedorBLL.BuscarPorNombre(txtBuscar.Text.Trim());
                dgvProveedores.DataSource = filtrados;
                lblTotal.Text = $"Resultados: {filtrados.Count}";
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }
    }
}
