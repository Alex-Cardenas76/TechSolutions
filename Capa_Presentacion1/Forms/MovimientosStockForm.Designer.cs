namespace Capa_Presentacion1.Forms
{
    partial class MovimientosStockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvTransacciones;

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
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dgvTransacciones = new System.Windows.Forms.DataGridView();
            this.panelSuperior.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1100, 60);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(310, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Movimientos de Inventario";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.lblTotal);
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.cmbTipoMovimiento);
            this.panelFiltros.Controls.Add(this.lblTipoMovimiento);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.lblFechaFin);
            this.panelFiltros.Controls.Add(this.dtpFechaInicio);
            this.panelFiltros.Controls.Add(this.lblFechaInicio);
            this.panelFiltros.Location = new System.Drawing.Point(20, 80);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1060, 100);
            this.panelFiltros.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(900, 65);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 20);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total: 0";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(780, 55);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 35);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(660, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 35);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(440, 60);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(200, 25);
            this.cmbTipoMovimiento.TabIndex = 5;
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTipoMovimiento.Location = new System.Drawing.Point(440, 35);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(138, 19);
            this.lblTipoMovimiento.TabIndex = 4;
            this.lblTipoMovimiento.Text = "Tipo de Movimiento:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(230, 60);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(190, 25);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(230, 35);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(77, 19);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(20, 60);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(190, 25);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 35);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(95, 19);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dgvTransacciones
            // 
            this.dgvTransacciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransacciones.Location = new System.Drawing.Point(20, 200);
            this.dgvTransacciones.Name = "dgvTransacciones";
            this.dgvTransacciones.Size = new System.Drawing.Size(1060, 360);
            this.dgvTransacciones.TabIndex = 2;
            // 
            // MovimientosStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1100, 580);
            this.Controls.Add(this.dgvTransacciones);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MovimientosStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Inventario";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransacciones)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
