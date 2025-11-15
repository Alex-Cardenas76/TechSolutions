namespace Capa_Presentacion1.Forms
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSuperior = new Panel();
            lblFechaHora = new Label();
            lblUsuario = new Label();
            lblTitulo = new Label();
            panelMenu = new Panel();
            btnSalir = new Button();
            btnReportes = new Button();
            btnMovimientos = new Button();
            btnVentas = new Button();
            btnProductos = new Button();
            btnCategorias = new Button();
            btnProveedores = new Button();
            btnClientes = new Button();
            panelSuperior.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblFechaHora);
            panelSuperior.Controls.Add(lblUsuario);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1000, 80);
            panelSuperior.TabIndex = 0;
            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.Font = new Font("Segoe UI", 11F);
            lblFechaHora.ForeColor = Color.White;
            lblFechaHora.Location = new Point(750, 45);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(143, 20);
            lblFechaHora.TabIndex = 2;
            lblFechaHora.Text = "00/00/0000 00:00:00";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 11F);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(750, 15);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(110, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario: Admin";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(413, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TechSolutions - Menú Principal";
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.White;
            panelMenu.Controls.Add(btnSalir);
            panelMenu.Controls.Add(btnReportes);
            panelMenu.Controls.Add(btnMovimientos);
            panelMenu.Controls.Add(btnVentas);
            panelMenu.Controls.Add(btnProductos);
            panelMenu.Controls.Add(btnCategorias);
            panelMenu.Controls.Add(btnProveedores);
            panelMenu.Controls.Add(btnClientes);
            panelMenu.Location = new Point(100, 120);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(800, 450);
            panelMenu.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(231, 76, 60);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(550, 350);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(200, 60);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.FromArgb(155, 89, 182);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(300, 350);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(200, 60);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnMovimientos
            // 
            btnMovimientos.BackColor = Color.FromArgb(52, 152, 219);
            btnMovimientos.FlatStyle = FlatStyle.Flat;
            btnMovimientos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMovimientos.ForeColor = Color.White;
            btnMovimientos.Location = new Point(50, 350);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Size = new Size(200, 60);
            btnMovimientos.TabIndex = 5;
            btnMovimientos.Text = "Movimientos Stock";
            btnMovimientos.UseVisualStyleBackColor = false;
            btnMovimientos.Click += btnMovimientos_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(46, 204, 113);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVentas.ForeColor = Color.White;
            btnVentas.Location = new Point(550, 240);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(200, 60);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(241, 196, 15);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(300, 240);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(200, 60);
            btnProductos.TabIndex = 3;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.FromArgb(230, 126, 34);
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(50, 240);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(200, 60);
            btnCategorias.TabIndex = 2;
            btnCategorias.Text = "Categorías";
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(52, 152, 219);
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(300, 130);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(200, 60);
            btnProveedores.TabIndex = 1;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(52, 152, 219);
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(50, 130);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(200, 60);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMenu);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal - TechSolutions";
            Load += MenuPrincipal_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
