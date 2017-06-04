namespace crm
{
    partial class frm_informe_estadistico_proyeccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crv_proyeccion = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dgv_contenedor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // crv_proyeccion
            // 
            this.crv_proyeccion.ActiveViewIndex = -1;
            this.crv_proyeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv_proyeccion.Cursor = System.Windows.Forms.Cursors.Default;
            this.crv_proyeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv_proyeccion.Location = new System.Drawing.Point(0, 0);
            this.crv_proyeccion.Name = "crv_proyeccion";
            this.crv_proyeccion.Size = new System.Drawing.Size(923, 464);
            this.crv_proyeccion.TabIndex = 0;
            // 
            // dgv_contenedor
            // 
            this.dgv_contenedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_contenedor.Location = new System.Drawing.Point(638, 0);
            this.dgv_contenedor.Name = "dgv_contenedor";
            this.dgv_contenedor.Size = new System.Drawing.Size(10, 10);
            this.dgv_contenedor.TabIndex = 1;
            this.dgv_contenedor.Visible = false;
            // 
            // frm_informe_estadistico_proyeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 464);
            this.Controls.Add(this.dgv_contenedor);
            this.Controls.Add(this.crv_proyeccion);
            this.Name = "frm_informe_estadistico_proyeccion";
            this.Text = "Reporte de Proyección";
            this.Load += new System.EventHandler(this.frm_informe_estadistico_proyeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_contenedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv_proyeccion;
        public System.Windows.Forms.DataGridView dgv_contenedor;
    }
}