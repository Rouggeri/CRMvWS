namespace crm
{
    partial class frm_estadistica_negocio_descripcion
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
            this.dgv_detalle_negocio = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbl_titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle_negocio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_detalle_negocio
            // 
            this.dgv_detalle_negocio.Location = new System.Drawing.Point(-16, 40);
            this.dgv_detalle_negocio.MainView = this.gridView1;
            this.dgv_detalle_negocio.Name = "dgv_detalle_negocio";
            this.dgv_detalle_negocio.Size = new System.Drawing.Size(706, 159);
            this.dgv_detalle_negocio.TabIndex = 0;
            this.dgv_detalle_negocio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgv_detalle_negocio;
            this.gridView1.Name = "gridView1";
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(282, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(66, 24);
            this.lbl_titulo.TabIndex = 1;
            this.lbl_titulo.Text = "label1";
            // 
            // frm_estadistica_negocio_descripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 199);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.dgv_detalle_negocio);
            this.Name = "frm_estadistica_negocio_descripcion";
            this.Text = "Descripcion de Negocio";
            this.Load += new System.EventHandler(this.frm_estadistica_negocio_descripcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle_negocio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.GridControl dgv_detalle_negocio;
        public System.Windows.Forms.Label lbl_titulo;
    }
}