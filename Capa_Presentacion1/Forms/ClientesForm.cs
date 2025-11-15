using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class ClientesForm : Form
    {
        private readonly ClienteBLL _clienteBLL;
        private List<Cliente> _clientes;
        private Cliente? _clienteSeleccionado;

        public ClientesForm()
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            _clientes = new List<Cliente>();
            CargarClientes();
        }

        private async void CargarClientes()
        {
            try
            {
                btnNuevo.Enabled = false;
                dgvClientes.DataSource = null;

                var resultado = await Task.Run(() => _clienteBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _clientes = resultado.datos;
                    dgvClientes.DataSource = _clientes;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_clientes.Count}";
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            dgvClientes.Columns["IdCliente"].HeaderText = "ID";
            dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
            dgvClientes.Columns["Apellido"].HeaderText = "Apellido";
            dgvClientes.Columns["Email"].HeaderText = "Email";
            dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
            dgvClientes.Columns["Direccion"].HeaderText = "Dirección";

            if (dgvClientes.Columns.Contains("Ventas"))
                dgvClientes.Columns["Ventas"].Visible = false;

            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            _clienteSeleccionado = null;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            if (_clienteSeleccionado == null)
                InsertarCliente(cliente);
            else
            {
                cliente.IdCliente = _clienteSeleccionado.IdCliente;
                ActualizarCliente(cliente);
            }
        }

        private async void InsertarCliente(Cliente cliente)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _clienteBLL.Insertar(cliente));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarClientes();
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

        private async void ActualizarCliente(Cliente cliente)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _clienteBLL.Actualizar(cliente));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarClientes();
                    _clienteSeleccionado = null;
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
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _clienteSeleccionado = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
            txtNombre.Text = _clienteSeleccionado.Nombre;
            txtApellido.Text = _clienteSeleccionado.Apellido;
            txtEmail.Text = _clienteSeleccionado.Email;
            txtTelefono.Text = _clienteSeleccionado.Telefono;
            txtDireccion.Text = _clienteSeleccionado.Direccion;
            HabilitarCampos(true);
            txtNombre.Focus();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar a {cliente.Nombre} {cliente.Apellido}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    var resultado = await Task.Run(() => _clienteBLL.Eliminar(cliente.IdCliente));

                    if (resultado.exito)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes();
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
            _clienteSeleccionado = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                dgvClientes.DataSource = _clientes;
            else
            {
                var filtrados = _clienteBLL.BuscarPorNombre(txtBuscar.Text.Trim());
                dgvClientes.DataSource = filtrados;
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

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
