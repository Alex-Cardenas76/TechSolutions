namespace Capa_Presentacion1.Forms
{
    partial class ReportesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnVentasPorFecha;
        private System.Windows.Forms.Button btnProductosMasVendidos;
        private System.Windows.Forms.Button btnProductosBajoStock;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResultado;

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
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnProductosBajoStock = new System.Windows.Forms.Button();
            this.btnProductosMasVendidos = new System.Windows.Forms.Button();
            this.btnVentasPorFecha = new System.Windows.Forms.Button();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(120, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.btnEstadisticas);
            this.panelFiltros.Controls.Add(this.btnProductosBajoStock);
            this.panelFiltros.Controls.Add(this.btnProductosMasVendidos);
            this.panelFiltros.Controls.Add(this.btnVentasPorFecha);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.lblFechaFin);
            this.panelFiltros.Controls.Add(this.dtpFechaInicio);
            this.panelFiltros.Controls.Add(this.lblFechaInicio);
            this.panelFiltros.Location = new System.Drawing.Point(20, 80);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1060, 120);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEstadisticas.ForeColor = System.Drawing.Color.White;
            this.btnEstadisticas.Location = new System.Drawing.Point(800, 60);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(240, 40);
            this.btnEstadisticas.TabIndex = 7;
            this.btnEstadisticas.Text = "Estadísticas Generales";
            this.btnEstadisticas.UseVisualStyleBackColor = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnProductosBajoStock
            // 
            this.btnProductosBajoStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnProductosBajoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosBajoStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProductosBajoStock.ForeColor = System.Drawing.Color.White;
            this.btnProductosBajoStock.Location = new System.Drawing.Point(540, 60);
            this.btnProductosBajoStock.Name = "btnProductosBajoStock";
            this.btnProductosBajoStock.Size = new System.Drawing.Size(240, 40);
            this.btnProductosBajoStock.TabIndex = 6;
            this.btnProductosBajoStock.Text = "Productos Bajo Stock";
            this.btnProductosBajoStock.UseVisualStyleBackColor = false;
            this.btnProductosBajoStock.Click += new System.EventHandler(this.btnProductosBajoStock_Click);
            // 
            // btnProductosMasVendidos
            // 
            this.btnProductosMasVendidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnProductosMasVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosMasVendidos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProductosMasVendidos.ForeColor = System.Drawing.Color.White;
            this.btnProductosMasVendidos.Location = new System.Drawing.Point(280, 60);
            this.btnProductosMasVendidos.Name = "btnProductosMasVendidos";
            this.btnProductosMasVendidos.Size = new System.Drawing.Size(240, 40);
            this.btnProductosMasVendidos.TabIndex = 5;
            this.btnProductosMasVendidos.Text = "Productos Más Vendidos";
            this.btnProductosMasVendidos.UseVisualStyleBackColor = false;
            this.btnProductosMasVendidos.Click += new System.EventHandler(this.btnProductosMasVendidos_Click);
            // 
            // btnVentasPorFecha
            // 
            this.btnVentasPorFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnVentasPorFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasPorFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVentasPorFecha.ForeColor = System.Drawing.Color.White;
            this.btnVentasPorFecha.Location = new System.Drawing.Point(20, 60);
            this.btnVentasPorFecha.Name = "btnVentasPorFecha";
            this.btnVentasPorFecha.Size = new System.Drawing.Size(240, 40);
            this.btnVentasPorFecha.TabIndex = 4;
            this.btnVentasPorFecha.Text = "Ventas por Fecha";
            this.btnVentasPorFecha.UseVisualStyleBackColor = false;
            this.btnVentasPorFecha.Click += new System.EventHandler(this.btnVentasPorFecha_Click);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(280, 20);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(240, 25);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFechaFin.Location = new System.Drawing.Point(280, -2);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(77, 19);
            this.lblFechaFin.TabIndex = 2;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(20, 20);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(240, 25);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFechaInicio.Location = new System.Drawing.Point(20, -2);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(95, 19);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dgvReporte
            // 
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(20, 250);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(1060, 280);
            this.dgvReporte.TabIndex = 2;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.BackColor = System.Drawing.Color.White;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(40, 220);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(200, 20);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Seleccione un reporte...";
            // 
            // ReportesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1100, 550);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ReportesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
