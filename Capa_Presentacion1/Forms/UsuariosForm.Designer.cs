namespace Capa_Presentacion1.Forms
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFormulario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblTotal;

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
            panelFormulario = new Panel();
            chkActivo = new CheckBox();
            cboRol = new ComboBox();
            lblRol = new Label();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            panelBotones = new Panel();
            btnEliminar = new Button();
            btnEditar = new Button();
            dgvUsuarios = new DataGridView();
            lblTotal = new Label();
            panelSuperior.SuspendLayout();
            panelFormulario.SuspendLayout();
            panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(52, 73, 94);
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1000, 60);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(285, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Usuarios";
            // 
            // panelFormulario
            // 
            panelFormulario.BackColor = Color.White;
            panelFormulario.BorderStyle = BorderStyle.FixedSingle;
            panelFormulario.Controls.Add(chkActivo);
            panelFormulario.Controls.Add(cboRol);
            panelFormulario.Controls.Add(lblRol);
            panelFormulario.Controls.Add(txtContrasena);
            panelFormulario.Controls.Add(lblContrasena);
            panelFormulario.Controls.Add(txtNombreUsuario);
            panelFormulario.Controls.Add(lblNombreUsuario);
            panelFormulario.Controls.Add(btnCancelar);
            panelFormulario.Controls.Add(btnGuardar);
            panelFormulario.Controls.Add(btnNuevo);
            panelFormulario.Location = new Point(20, 80);
            panelFormulario.Name = "panelFormulario";
            panelFormulario.Size = new Size(960, 180);
            panelFormulario.TabIndex = 1;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Enabled = false;
            chkActivo.Font = new Font("Segoe UI", 10F);
            chkActivo.Location = new Point(520, 90);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(67, 23);
            chkActivo.TabIndex = 9;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.Enabled = false;
            cboRol.Font = new Font("Segoe UI", 10F);
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(520, 50);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(200, 25);
            cboRol.TabIndex = 8;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F);
            lblRol.Location = new Point(520, 25);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(37, 19);
            lblRol.TabIndex = 7;
            lblRol.Text = "Rol:*";
            // 
            // txtContrasena
            // 
            txtContrasena.Enabled = false;
            txtContrasena.Font = new Font("Segoe UI", 10F);
            txtContrasena.Location = new Point(270, 90);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '●';
            txtContrasena.Size = new Size(200, 25);
            txtContrasena.TabIndex = 6;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F);
            lblContrasena.Location = new Point(270, 65);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(87, 19);
            lblContrasena.TabIndex = 5;
            lblContrasena.Text = "Contraseña:*";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Enabled = false;
            txtNombreUsuario.Font = new Font("Segoe UI", 10F);
            txtNombreUsuario.Location = new Point(270, 50);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(200, 25);
            txtNombreUsuario.TabIndex = 4;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 10F);
            lblNombreUsuario.Location = new Point(270, 25);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(66, 19);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Usuario:*";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelar.Enabled = false;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(20, 130);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 35);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 204, 113);
            btnGuardar.Enabled = false;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(20, 85);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
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
            btnNuevo.Location = new Point(20, 40);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 35);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.White;
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(btnEliminar);
            panelBotones.Controls.Add(btnEditar);
            panelBotones.Location = new Point(20, 270);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(960, 60);
            panelBotones.TabIndex = 2;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(150, 12);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 35);
            btnEliminar.TabIndex = 1;
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
            btnEditar.Location = new Point(20, 12);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(120, 35);
            btnEditar.TabIndex = 0;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(20, 340);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(960, 220);
            dgvUsuarios.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 570);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(60, 19);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: 0";
            // 
            // UsuariosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1000, 600);
            Controls.Add(lblTotal);
            Controls.Add(dgvUsuarios);
            Controls.Add(panelBotones);
            Controls.Add(panelFormulario);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "UsuariosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Usuarios - TechSolutions";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelFormulario.ResumeLayout(false);
            panelFormulario.PerformLayout();
            panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
