using System;
using System.Windows.Forms;
using CapaEntidad.Models;

namespace Capa_Presentacion1.Forms
{
    public partial class MenuPrincipal : Form
    {
        private Usuario _usuarioActual;
        private System.Windows.Forms.Timer _timer;

        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            
            lblUsuario.Text = $"Usuario: {_usuarioActual.NombreUsuario}";
            ActualizarFechaHora();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ClientesForm());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ProveedoresForm());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CategoriasForm());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ProductosForm());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VentasForm(_usuarioActual));
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new MovimientosStockForm());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ReportesForm());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _timer.Stop();
                this.Close();
            }
        }

        private void AbrirFormulario(Form formulario)
        {
            formulario.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer?.Stop();
            base.OnFormClosing(e);
        }
    }
}
