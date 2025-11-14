using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class CategoriasForm : Form
    {
        private readonly CategoriaBLL _categoriaBLL;
        private List<Categoria> _categorias;
        private Categoria? _categoriaSeleccionada;

        public CategoriasForm()
        {
            InitializeComponent();
            _categoriaBLL = new CategoriaBLL();
            _categorias = new List<Categoria>();
            CargarCategorias();
        }

        private async void CargarCategorias()
        {
            try
            {
                btnNuevo.Enabled = false;
                var resultado = await Task.Run(() => _categoriaBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _categorias = resultado.datos;
                    dgvCategorias.DataSource = _categorias;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_categorias.Count}";
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
            dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
            dgvCategorias.Columns["NombreCategoria"].HeaderText = "Nombre";
            dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";

            if (dgvCategorias.Columns.Contains("Productos"))
                dgvCategorias.Columns["Productos"].Visible = false;

            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            _categoriaSeleccionada = null;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var categoria = new Categoria
            {
                NombreCategoria = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (_categoriaSeleccionada == null)
                InsertarCategoria(categoria);
            else
            {
                categoria.IdCategoria = _categoriaSeleccionada.IdCategoria;
                ActualizarCategoria(categoria);
            }
        }

        private async void InsertarCategoria(Categoria categoria)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _categoriaBLL.Insertar(categoria));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarCategorias();
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

        private async void ActualizarCategoria(Categoria categoria)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _categoriaBLL.Actualizar(categoria));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarCategorias();
                    _categoriaSeleccionada = null;
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
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _categoriaSeleccionada = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
            txtNombre.Text = _categoriaSeleccionada.NombreCategoria;
            txtDescripcion.Text = _categoriaSeleccionada.Descripcion;
            HabilitarCampos(true);
            txtNombre.Focus();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoria = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar {categoria.NombreCategoria}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    var resultado = await Task.Run(() => _categoriaBLL.Eliminar(categoria.IdCategoria));

                    if (resultado.exito)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
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
            _categoriaSeleccionada = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                dgvCategorias.DataSource = _categorias;
            else
            {
                var filtrados = _categoriaBLL.BuscarPorNombre(txtBuscar.Text.Trim());
                dgvCategorias.DataSource = filtrados;
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
            txtDescripcion.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }
    }
}
