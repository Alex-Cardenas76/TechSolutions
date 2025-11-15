namespace Capa_Presentacion1.Forms
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnIngresar;
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
            panelPrincipal = new Panel();
            btnSalir = new Button();
            btnIngresar = new Button();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            lblTitulo = new Label();
            panelPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.BorderStyle = BorderStyle.FixedSingle;
            panelPrincipal.Controls.Add(btnSalir);
            panelPrincipal.Controls.Add(btnIngresar);
            panelPrincipal.Controls.Add(txtContrasena);
            panelPrincipal.Controls.Add(lblContrasena);
            panelPrincipal.Controls.Add(txtUsuario);
            panelPrincipal.Controls.Add(lblUsuario);
            panelPrincipal.Controls.Add(lblTitulo);
            panelPrincipal.Location = new Point(150, 80);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(400, 300);
            panelPrincipal.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(231, 76, 60);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(220, 230);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 40);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(46, 204, 113);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(60, 230);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(120, 40);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 11F);
            txtContrasena.Location = new Point(60, 170);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '●';
            txtContrasena.Size = new Size(280, 27);
            txtContrasena.TabIndex = 2;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContrasena.Location = new Point(60, 145);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(88, 19);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(60, 105);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(280, 27);
            txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.Location = new Point(60, 80);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(64, 19);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.Location = new Point(100, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(155, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "TechSolutions";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(700, 450);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - TechSolutions";
            Load += Login_Load;
            panelPrincipal.ResumeLayout(false);
            panelPrincipal.PerformLayout();
            ResumeLayout(false);
        }
    }
}
