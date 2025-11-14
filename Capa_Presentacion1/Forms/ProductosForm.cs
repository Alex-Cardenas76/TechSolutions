using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;

namespace Capa_Presentacion1.Forms
{
    public partial class ProductosForm : Form
    {
        private readonly ProductoBLL _productoBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly ProveedorBLL _proveedorBLL;
        private List<Producto> _productos;
        private Producto? _productoSeleccionado;

        public ProductosForm()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _proveedorBLL = new ProveedorBLL();
            _productos = new List<Producto>();
            CargarCombos();
            CargarProductos();
        }

        private async void CargarCombos()
        {
            try
            {
                var categorias = await Task.Run(() => _categoriaBLL.ObtenerTodos());
                if (categorias.exito)
                {
                    cmbCategoria.DataSource = categorias.datos;
                    cmbCategoria.DisplayMember = "NombreCategoria";
                    cmbCategoria.ValueMember = "IdCategoria";
                    cmbCategoria.SelectedIndex = -1;
                }

                var proveedores = await Task.Run(() => _proveedorBLL.ObtenerTodos());
                if (proveedores.exito)
                {
                    var listaProveedores = proveedores.datos.ToList();
                    listaProveedores.Insert(0, new Proveedor { IdProveedor = 0, NombreProveedor = "Sin proveedor" });
                    cmbProveedor.DataSource = listaProveedores;
                    cmbProveedor.DisplayMember = "NombreProveedor";
                    cmbProveedor.ValueMember = "IdProveedor";
                    cmbProveedor.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarProductos()
        {
            try
            {
                btnNuevo.Enabled = false;
                var resultado = await Task.Run(() => _productoBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _productos = resultado.datos;
                    dgvProductos.DataSource = _productos;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_productos.Count}";
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
            dgvProductos.Columns["IdProducto"].HeaderText = "ID";
            dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
            dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvProductos.Columns["Precio"].HeaderText = "Precio";
            dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["Stock"].HeaderText = "Stock";
            dgvProductos.Columns["IdCategoria"].HeaderText = "ID Cat";
            dgvProductos.Columns["IdProveedor"].HeaderText = "ID Prov";

            if (dgvProductos.Columns.Contains("Categoria"))
                dgvProductos.Columns["Categoria"].Visible = false;
            if (dgvProductos.Columns.Contains("Proveedor"))
                dgvProductos.Columns["Proveedor"].Visible = false;
            if (dgvProductos.Columns.Contains("DetalleVentas"))
                dgvProductos.Columns["DetalleVentas"].Visible = false;
            if (dgvProductos.Columns.Contains("TransaccionesStock"))
                dgvProductos.Columns["TransaccionesStock"].Visible = false;

            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            _productoSeleccionado = null;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var producto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                IdCategoria = (int)cmbCategoria.SelectedValue,
                IdProveedor = (int)cmbProveedor.SelectedValue == 0 ? null : (int)cmbProveedor.SelectedValue
            };

            if (_productoSeleccionado == null)
                InsertarProducto(producto);
            else
            {
                producto.IdProducto = _productoSeleccionado.IdProducto;
                ActualizarProducto(producto);
            }
        }

        private async void InsertarProducto(Producto producto)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _productoBLL.Insertar(producto));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarProductos();
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

        private async void ActualizarProducto(Producto producto)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _productoBLL.Actualizar(producto));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarProductos();
                    _productoSeleccionado = null;
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
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _productoSeleccionado = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;
            txtNombre.Text = _productoSeleccionado.Nombre;
            txtDescripcion.Text = _productoSeleccionado.Descripcion;
            txtPrecio.Text = _productoSeleccionado.Precio.ToString();
            txtStock.Text = _productoSeleccionado.Stock.ToString();
            cmbCategoria.SelectedValue = _productoSeleccionado.IdCategoria;
            cmbProveedor.SelectedValue = _productoSeleccionado.IdProveedor ?? 0;
            HabilitarCampos(true);
            txtNombre.Focus();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar {producto.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    var resultado = await Task.Run(() => _productoBLL.Eliminar(producto.IdProducto));

                    if (resultado.exito)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
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
            _productoSeleccionado = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                dgvProductos.DataSource = _productos;
            else
            {
                var filtrados = _productoBLL.BuscarPorNombre(txtBuscar.Text.Trim());
                dgvProductos.DataSource = filtrados;
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

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a cero", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Ingrese un stock válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = 0;
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtStock.Enabled = habilitar;
            cmbCategoria.Enabled = habilitar;
            cmbProveedor.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }
    }
}
