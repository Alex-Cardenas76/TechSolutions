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
            btnUsuarios.Visible = PermisosPorRol.PuedeGestionarUsuarios(idRol);

            // NO reorganizar aquí, se hará en el evento Load
        }

        private void ReorganizarBotones()
        {
            // Configuración de la cuadrícula
            int anchoBoton = 200;
            int espacioX = 250;  // Espacio entre botones (incluye el ancho del botón + margen)
            int espacioY = 110;  // Espacio vertical entre filas
            int columnas = 3;
            int y = 50;  // Margen superior

            // Calcular el ancho total de la cuadrícula (3 columnas)
            // Ancho total = (columnas * espacioX) - (espacioX - anchoBoton)
            // Esto es: 2 espacios completos + 1 botón final
            int anchoTotalCuadricula = (columnas - 1) * espacioX + anchoBoton;

            // Calcular la posición X inicial para centrar la cuadrícula en el panel
            int xInicial = (panelMenu.Width - anchoTotalCuadricula) / 2;

            // Posiciones fijas para cada botón centradas en el panel
            // Fila 1: [Clientes] [Proveedores] [Salir]
            // Fila 2: [Categorías] [Productos] [Ventas]
            // Fila 3: [Movimientos] [Reportes] [Usuarios]

            // Fila 1
            if (btnClientes.Visible)
                btnClientes.Location = new System.Drawing.Point(xInicial, y);

            if (btnProveedores.Visible)
                btnProveedores.Location = new System.Drawing.Point(xInicial + espacioX, y);

            // Botón Salir SIEMPRE visible (primera fila, tercera columna)
            btnSalir.Location = new System.Drawing.Point(xInicial + (2 * espacioX), y);

            // Fila 2
            if (btnCategorias.Visible)
                btnCategorias.Location = new System.Drawing.Point(xInicial, y + espacioY);

            if (btnProductos.Visible)
                btnProductos.Location = new System.Drawing.Point(xInicial + espacioX, y + espacioY);

            if (btnVentas.Visible)
                btnVentas.Location = new System.Drawing.Point(xInicial + (2 * espacioX), y + espacioY);

            // Fila 3
            if (btnMovimientos.Visible)
                btnMovimientos.Location = new System.Drawing.Point(xInicial, y + (2 * espacioY));

            if (btnReportes.Visible)
                btnReportes.Location = new System.Drawing.Point(xInicial + espacioX, y + (2 * espacioY));

            if (btnUsuarios.Visible)
                btnUsuarios.Location = new System.Drawing.Point(xInicial + (2 * espacioX), y + (2 * espacioY));
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (PermisosPorRol.PuedeGestionarUsuarios(_usuarioActual.IdRol))
            {
                AbrirFormulario(new UsuariosForm(_usuarioActual.IdUsuario));
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
            // Reorganizar botones cuando el formulario ya esté completamente cargado
            ReorganizarBotones();
        }
    }
}
