using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad.Models;
using CapaNegocio.Seguridad;

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

            lblUsuario.Text = $"Usuario: {_usuarioActual.NombreUsuario} ({PermisosPorRol.ObtenerNombreRol(_usuarioActual.IdRol)})";
            ActualizarFechaHora();
            ConfigurarPermisosPorRol();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ConfigurarPermisosPorRol()
        {
            int idRol = _usuarioActual.IdRol;

            // Configurar visibilidad de botones según permisos
            btnClientes.Visible = PermisosPorRol.PuedeGestionarClientes(idRol);
            btnProveedores.Visible = PermisosPorRol.PuedeGestionarProveedores(idRol);
            btnCategorias.Visible = PermisosPorRol.PuedeGestionarCategorias(idRol);
            btnProductos.Visible = PermisosPorRol.PuedeGestionarProductos(idRol);
            btnVentas.Visible = PermisosPorRol.PuedeRegistrarVentas(idRol);
            btnMovimientos.Visible = PermisosPorRol.PuedeGestionarMovimientosStock(idRol);
            btnReportes.Visible = PermisosPorRol.PuedeVerReportes(idRol);

            // Reorganizar botones visibles
            ReorganizarBotones();
        }

        private void ReorganizarBotones()
        {
            // Lista de todos los botones del menú (excepto Salir)
            var botones = new List<Button> 
            { 
                btnClientes, btnProveedores, btnCategorias, 
                btnProductos, btnVentas, btnMovimientos, btnReportes 
            };

            // Filtrar solo los visibles
            var botonesVisibles = botones.Where(b => b.Visible).ToList();

            // Posiciones iniciales
            int x = 50;
            int y = 50;
            int espacioX = 250;
            int espacioY = 110;
            int columnas = 3;

            // Reorganizar botones visibles en una cuadrícula
            for (int i = 0; i < botonesVisibles.Count; i++)
            {
                int fila = i / columnas;
                int columna = i % columnas;

                botonesVisibles[i].Location = new System.Drawing.Point(
                    x + (columna * espacioX),
                    y + (fila * espacioY)
                );
            }

            // Mantener el botón Salir en su posición
            btnSalir.Location = new System.Drawing.Point(550, 400);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarClientes(_usuarioActual.IdRol))
            {
                AbrirFormulario(new ClientesForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarProveedores(_usuarioActual.IdRol))
            {
                AbrirFormulario(new ProveedoresForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarCategorias(_usuarioActual.IdRol))
            {
                AbrirFormulario(new CategoriasForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarProductos(_usuarioActual.IdRol))
            {
                AbrirFormulario(new ProductosForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeRegistrarVentas(_usuarioActual.IdRol))
            {
                AbrirFormulario(new VentasForm(_usuarioActual));
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarMovimientosStock(_usuarioActual.IdRol))
            {
                AbrirFormulario(new MovimientosStockForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeVerReportes(_usuarioActual.IdRol))
            {
                AbrirFormulario(new ReportesForm());
            }
            else
            {
                MostrarAccesoDenegado();
            }
        }

        private void MostrarAccesoDenegado()
        {
            MessageBox.Show("No tiene permisos para acceder a esta funcionalidad.", 
                "Acceso Denegado", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
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

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
