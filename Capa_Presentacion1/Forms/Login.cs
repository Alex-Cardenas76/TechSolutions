using System;
using System.Windows.Forms;
using CapaNegocio.Servicios;
using CapaEntidad.Models;

namespace Capa_Presentacion1.Forms
{
    public partial class Login : Form
    {
        private readonly UsuarioBLL _usuarioBLL;

        public Login()
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();
            this.KeyPreview = true;
            this.KeyDown += Login_KeyDown;
        }

        private void Login_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIngresar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnSalir_Click(sender, e);
            }
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Por favor ingrese el nombre de usuario", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContrasena.Text))
                {
                    MessageBox.Show("Por favor ingrese la contraseña", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }

                btnIngresar.Enabled = false;
                btnIngresar.Text = "Validando...";
                Cursor = Cursors.WaitCursor;

                var resultado = await Task.Run(() =>
                    _usuarioBLL.ValidarLogin(txtUsuario.Text.Trim(), txtContrasena.Text));

                Cursor = Cursors.Default;
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Ingresar";

                if (resultado.exito)
                {
                    MenuPrincipal menu = new MenuPrincipal(resultado.usuario!);
                    this.Hide();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje, "Error de Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Ingresar";
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
