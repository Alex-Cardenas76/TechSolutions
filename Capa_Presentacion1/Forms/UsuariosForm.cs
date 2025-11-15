using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Servicios;
using CapaNegocio.Seguridad;

namespace Capa_Presentacion1.Forms
{
    public partial class UsuariosForm : Form
    {
        private readonly UsuarioBLL _usuarioBLL;
        private readonly RolBLL _rolBLL;
        private List<Usuario> _usuarios;
        private Usuario? _usuarioSeleccionado;
        private readonly int _idUsuarioActual;

        public UsuariosForm(int idUsuarioActual)
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();
            _rolBLL = new RolBLL();
            _usuarios = new List<Usuario>();
            _idUsuarioActual = idUsuarioActual;
            CargarRoles();
            CargarUsuarios();
        }

        private async void CargarRoles()
        {
            try
            {
                var resultado = await Task.Run(() => _rolBLL.ObtenerTodos());
                if (resultado.exito)
                {
                    cboRol.DataSource = resultado.datos;
                    cboRol.DisplayMember = "NombreRol";
                    cboRol.ValueMember = "IdRol";
                    cboRol.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CargarUsuarios()
        {
            try
            {
                btnNuevo.Enabled = false;
                dgvUsuarios.DataSource = null;

                var resultado = await Task.Run(() => _usuarioBLL.ObtenerTodos());

                if (resultado.exito)
                {
                    _usuarios = resultado.datos;
                    
                    // Crear lista para mostrar con nombre de rol
                    var usuariosConRol = _usuarios.Select(u => new
                    {
                        u.IdUsuario,
                        u.NombreUsuario,
                        Rol = PermisosPorRol.ObtenerNombreRol(u.IdRol),
                        u.IdRol,
                        Estado = u.Estado ? "Activo" : "Inactivo"
                    }).ToList();

                    dgvUsuarios.DataSource = usuariosConRol;
                    ConfigurarDataGridView();
                    lblTotal.Text = $"Total: {_usuarios.Count}";
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
            dgvUsuarios.Columns["IdUsuario"].HeaderText = "ID";
            dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgvUsuarios.Columns["Rol"].HeaderText = "Rol";
            dgvUsuarios.Columns["Estado"].HeaderText = "Estado";
            
            if (dgvUsuarios.Columns.Contains("IdRol"))
                dgvUsuarios.Columns["IdRol"].Visible = false;

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            _usuarioSeleccionado = null;
            txtContrasena.Enabled = true;
            lblContrasena.Text = "Contraseña:*";
            chkActivo.Checked = true;
            txtNombreUsuario.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var usuario = new Usuario
            {
                NombreUsuario = txtNombreUsuario.Text.Trim(),
                IdRol = (int)cboRol.SelectedValue,
                Estado = chkActivo.Checked
            };

            if (_usuarioSeleccionado == null)
            {
                // Nuevo usuario - contraseña obligatoria
                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("La contraseña es obligatoria", "Validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }
                InsertarUsuario(usuario, txtContrasena.Text);
            }
            else
            {
                // Editar usuario
                usuario.IdUsuario = _usuarioSeleccionado.IdUsuario;
                string? nuevaContrasena = string.IsNullOrWhiteSpace(txtContrasena.Text) 
                    ? null 
                    : txtContrasena.Text;
                ActualizarUsuario(usuario, nuevaContrasena);
            }
        }

        private async void InsertarUsuario(Usuario usuario, string contrasena)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _usuarioBLL.Insertar(usuario, contrasena));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarUsuarios();
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

        private async void ActualizarUsuario(Usuario usuario, string? nuevaContrasena)
        {
            try
            {
                btnGuardar.Enabled = false;
                var resultado = await Task.Run(() => _usuarioBLL.Actualizar(usuario, nuevaContrasena));

                if (resultado.exito)
                {
                    MessageBox.Show(resultado.mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    HabilitarCampos(false);
                    CargarUsuarios();
                    _usuarioSeleccionado = null;
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
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
            _usuarioSeleccionado = _usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (_usuarioSeleccionado != null)
            {
                txtNombreUsuario.Text = _usuarioSeleccionado.NombreUsuario;
                cboRol.SelectedValue = _usuarioSeleccionado.IdRol;
                chkActivo.Checked = _usuarioSeleccionado.Estado;
                txtContrasena.Clear();
                txtContrasena.Enabled = true;
                lblContrasena.Text = "Nueva Contraseña: (dejar vacío para no cambiar)";
                HabilitarCampos(true);
                txtNombreUsuario.Focus();
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = (int)dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
            
            // No permitir eliminar el usuario actual
            if (idUsuario == _idUsuarioActual)
            {
                MessageBox.Show("No puede eliminar su propio usuario", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = _usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if (usuario == null) return;

            if (MessageBox.Show($"¿Eliminar al usuario '{usuario.NombreUsuario}'?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnEliminar.Enabled = false;
                    var resultado = await Task.Run(() => _usuarioBLL.Eliminar(idUsuario));

                    if (resultado.exito)
                    {
                        MessageBox.Show(resultado.mensaje, "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                    }
                    else
                        MessageBox.Show(resultado.mensaje, "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnEliminar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
            _usuarioSeleccionado = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (txtNombreUsuario.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return false;
            }

            if (cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRol.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtContrasena.Text) && txtContrasena.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            cboRol.SelectedIndex = -1;
            chkActivo.Checked = true;
            lblContrasena.Text = "Contraseña:*";
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombreUsuario.Enabled = habilitar;
            txtContrasena.Enabled = habilitar;
            cboRol.Enabled = habilitar;
            chkActivo.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }
    }
}
