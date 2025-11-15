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
            int espacioX = 250;  // Espacio entre botones
            int espacioY = 110;  // Espacio vertical entre filas
            int yInicial = 50;   // Margen superior

            // Obtener lista de botones funcionales visibles (sin incluir Salir)
            var botonesVisibles = new List<Button>();
            if (btnClientes.Visible) botonesVisibles.Add(btnClientes);
            if (btnProveedores.Visible) botonesVisibles.Add(btnProveedores);
            if (btnCategorias.Visible) botonesVisibles.Add(btnCategorias);
            if (btnProductos.Visible) botonesVisibles.Add(btnProductos);
            if (btnVentas.Visible) botonesVisibles.Add(btnVentas);
            if (btnMovimientos.Visible) botonesVisibles.Add(btnMovimientos);
            if (btnReportes.Visible) botonesVisibles.Add(btnReportes);
            if (btnUsuarios.Visible) botonesVisibles.Add(btnUsuarios);

            int totalBotones = botonesVisibles.Count + 1; // +1 por el botón Salir

            // Determinar número de columnas según cantidad de botones
            int columnas;
            if (totalBotones <= 3)
                columnas = totalBotones; // 1 fila
            else if (totalBotones <= 6)
                columnas = 3; // 2 filas
            else
                columnas = 3; // 3 filas

            // Calcular ancho total de la cuadrícula
            int anchoTotalCuadricula = (columnas - 1) * espacioX + anchoBoton;

            // Calcular posición X inicial para centrar
            int xInicial = (panelMenu.Width - anchoTotalCuadricula) / 2;

            // Reorganizar botones visibles en cuadrícula
            int indice = 0;
            for (int i = 0; i < botonesVisibles.Count; i++)
            {
                int fila = indice / columnas;
                int columna = indice % columnas;

                // Reservar la última posición de la primera fila para el botón Salir
                // Solo si hay más de 2 botones funcionales
                if (fila == 0 && columna == columnas - 1 && botonesVisibles.Count > 2)
                {
                    indice++; // Saltar esta posición
                    fila = indice / columnas;
                    columna = indice % columnas;
                }

                int x = xInicial + (columna * espacioX);
                int y = yInicial + (fila * espacioY);

                botonesVisibles[i].Location = new System.Drawing.Point(x, y);
                indice++;
            }

            // Posicionar botón Salir
            if (totalBotones <= 3)
            {
                // Si hay 3 o menos botones, Salir va al final de la primera fila
                int columnaSalir = botonesVisibles.Count;
                btnSalir.Location = new System.Drawing.Point(
                    xInicial + (columnaSalir * espacioX), 
                    yInicial
                );
            }
            else
            {
                // Si hay más de 3 botones, Salir va en la última posición de la primera fila
                btnSalir.Location = new System.Drawing.Point(
                    xInicial + ((columnas - 1) * espacioX), 
                    yInicial
                );
            }
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
