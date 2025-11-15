namespace Capa_Presentacion1.Forms
{
    partial class ClientesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;

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
            lblTitulo = new Label();
            panelBusqueda = new Panel();
            lblTotal = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            dgvClientes = new DataGridView();
            panelDatos = new Panel();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            panelBotones = new Panel();
            btnCancelar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            panelSuperior.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panelDatos.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1200, 60);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(233, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Clientes";
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.White;
            panelBusqueda.Controls.Add(lblTotal);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Location = new Point(20, 80);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(750, 60);
            panelBusqueda.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(550, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(58, 19);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(52, 152, 219);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(420, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 35);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 11F);
            txtBuscar.Location = new Point(20, 15);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre o apellido...";
            txtBuscar.Size = new Size(380, 27);
            txtBuscar.TabIndex = 0;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(20, 160);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(750, 400);
            dgvClientes.TabIndex = 2;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.White;
            panelDatos.Controls.Add(txtDireccion);
            panelDatos.Controls.Add(lblDireccion);
            panelDatos.Controls.Add(txtTelefono);
            panelDatos.Controls.Add(lblTelefono);
            panelDatos.Controls.Add(txtEmail);
            panelDatos.Controls.Add(lblEmail);
            panelDatos.Controls.Add(txtApellido);
            panelDatos.Controls.Add(lblApellido);
            panelDatos.Controls.Add(txtNombre);
            panelDatos.Controls.Add(lblNombre);
            panelDatos.Location = new Point(790, 80);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(390, 350);
            panelDatos.TabIndex = 3;
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Font = new Font("Segoe UI", 10F);
            txtDireccion.Location = new Point(20, 290);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(350, 40);
            txtDireccion.TabIndex = 9;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDireccion.Location = new Point(20, 265);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(76, 19);
            lblDireccion.TabIndex = 8;
            lblDireccion.Text = "Dirección:";
            // 
            // txtTelefono
            // 
            txtTelefono.Enabled = false;
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtTelefono.Location = new Point(20, 225);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(350, 25);
            txtTelefono.TabIndex = 7;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTelefono.Location = new Point(20, 200);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(71, 19);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(20, 160);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 25);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 135);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 19);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Font = new Font("Segoe UI", 10F);
            txtApellido.Location = new Point(20, 95);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(350, 25);
            txtApellido.TabIndex = 3;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblApellido.Location = new Point(20, 70);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(70, 19);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(20, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(350, 25);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNombre.Location = new Point(20, 5);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(69, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.White;
            panelBotones.Controls.Add(btnCancelar);
            panelBotones.Controls.Add(btnEliminar);
            panelBotones.Controls.Add(btnEditar);
            panelBotones.Controls.Add(btnGuardar);
            panelBotones.Controls.Add(btnNuevo);
            panelBotones.Location = new Point(790, 450);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(390, 110);
            panelBotones.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.Enabled = false;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(270, 60);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(270, 15);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 35);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(241, 196, 15);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(145, 15);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnGuardar.Enabled = false;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(145, 60);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(52, 152, 219);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(20, 15);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // ClientesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1200, 580);
            Controls.Add(panelBotones);
            Controls.Add(panelDatos);
            Controls.Add(dgvClientes);
            Controls.Add(panelBusqueda);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ClientesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            panelBotones.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
