namespace Capa_Presentacion1.Forms
{
    partial class VentasForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblStockDisponible;
        private System.Windows.Forms.TextBox txtStockDisponible;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnNuevaVenta;

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
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtStockDisponible = new System.Windows.Forms.TextBox();
            this.lblStockDisponible = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.panelCliente.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1000, 60);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(220, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Ventas";
            // 
            // panelCliente
            // 
            this.panelCliente.BackColor = System.Drawing.Color.White;
            this.panelCliente.Controls.Add(this.cmbCliente);
            this.panelCliente.Controls.Add(this.lblCliente);
            this.panelCliente.Location = new System.Drawing.Point(20, 80);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(960, 60);
            this.panelCliente.TabIndex = 1;
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(120, 15);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(820, 28);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(20, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(65, 20);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.White;
            this.panelProducto.Controls.Add(this.btnAgregar);
            this.panelProducto.Controls.Add(this.txtStockDisponible);
            this.panelProducto.Controls.Add(this.lblStockDisponible);
            this.panelProducto.Controls.Add(this.txtPrecio);
            this.panelProducto.Controls.Add(this.lblPrecio);
            this.panelProducto.Controls.Add(this.nudCantidad);
            this.panelProducto.Controls.Add(this.lblCantidad);
            this.panelProducto.Controls.Add(this.cmbProducto);
            this.panelProducto.Controls.Add(this.lblProducto);
            this.panelProducto.Location = new System.Drawing.Point(20, 160);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(960, 100);
            this.panelProducto.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(800, 50);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(140, 35);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtStockDisponible
            // 
            this.txtStockDisponible.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStockDisponible.Location = new System.Drawing.Point(640, 55);
            this.txtStockDisponible.Name = "txtStockDisponible";
            this.txtStockDisponible.ReadOnly = true;
            this.txtStockDisponible.Size = new System.Drawing.Size(140, 25);
            this.txtStockDisponible.TabIndex = 7;
            // 
            // lblStockDisponible
            // 
            this.lblStockDisponible.AutoSize = true;
            this.lblStockDisponible.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockDisponible.Location = new System.Drawing.Point(640, 30);
            this.lblStockDisponible.Name = "lblStockDisponible";
            this.lblStockDisponible.Size = new System.Drawing.Size(127, 19);
            this.lblStockDisponible.TabIndex = 6;
            this.lblStockDisponible.Text = "Stock Disponible:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(480, 55);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(140, 25);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(480, 30);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(55, 19);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudCantidad.Location = new System.Drawing.Point(320, 55);
            this.nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(140, 25);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(320, 30);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(73, 19);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(20, 55);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(280, 25);
            this.cmbProducto.TabIndex = 1;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProducto.Location = new System.Drawing.Point(20, 30);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(75, 19);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(20, 280);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(960, 200);
            this.dgvDetalles.TabIndex = 3;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.White;
            this.panelTotal.Controls.Add(this.btnNuevaVenta);
            this.panelTotal.Controls.Add(this.btnRegistrarVenta);
            this.panelTotal.Controls.Add(this.lblTotal);
            this.panelTotal.Location = new System.Drawing.Point(20, 500);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(960, 70);
            this.panelTotal.TabIndex = 4;
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Location = new System.Drawing.Point(640, 15);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(140, 40);
            this.btnNuevaVenta.TabIndex = 2;
            this.btnNuevaVenta.Text = "Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(800, 15);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(140, 40);
            this.btnRegistrarVenta.TabIndex = 1;
            this.btnRegistrarVenta.Text = "Registrar";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(160, 32);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // VentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1000, 590);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.panelProducto);
            this.Controls.Add(this.panelCliente);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VentasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Ventas";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
