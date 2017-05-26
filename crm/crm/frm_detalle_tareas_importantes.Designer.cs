namespace crm
{
    partial class frm_detalle_tareas_importantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_detalle_tareas_importantes));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgv_hijo_secundario = new System.Windows.Forms.DataGridView();
            this.lbl_rep_nom1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_fecha_cierre = new System.Windows.Forms.Label();
            this.lbl_clt_nom1 = new System.Windows.Forms.Label();
            this.lbl_empresa = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_monto_real = new System.Windows.Forms.Label();
            this.lbl_monto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hijo_secundario)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.dgv_hijo_secundario);
            this.groupControl1.Controls.Add(this.lbl_rep_nom1);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.lbl_fecha_cierre);
            this.groupControl1.Controls.Add(this.lbl_clt_nom1);
            this.groupControl1.Controls.Add(this.lbl_empresa);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.lbl_titulo);
            this.groupControl1.Controls.Add(this.lbl_monto_real);
            this.groupControl1.Controls.Add(this.lbl_monto);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(480, 169);
            this.groupControl1.TabIndex = 29;
            this.groupControl1.Text = "Tarea";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // dgv_hijo_secundario
            // 
            this.dgv_hijo_secundario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hijo_secundario.Location = new System.Drawing.Point(40, 283);
            this.dgv_hijo_secundario.Name = "dgv_hijo_secundario";
            this.dgv_hijo_secundario.Size = new System.Drawing.Size(10, 10);
            this.dgv_hijo_secundario.TabIndex = 17;
            // 
            // lbl_rep_nom1
            // 
            this.lbl_rep_nom1.AutoSize = true;
            this.lbl_rep_nom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rep_nom1.Location = new System.Drawing.Point(156, 138);
            this.lbl_rep_nom1.Name = "lbl_rep_nom1";
            this.lbl_rep_nom1.Size = new System.Drawing.Size(41, 16);
            this.lbl_rep_nom1.TabIndex = 14;
            this.lbl_rep_nom1.Text = "nom1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(156, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Encargado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(307, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Fecha de cierre";
            // 
            // lbl_fecha_cierre
            // 
            this.lbl_fecha_cierre.AutoSize = true;
            this.lbl_fecha_cierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_cierre.Location = new System.Drawing.Point(307, 94);
            this.lbl_fecha_cierre.Name = "lbl_fecha_cierre";
            this.lbl_fecha_cierre.Size = new System.Drawing.Size(100, 16);
            this.lbl_fecha_cierre.TabIndex = 11;
            this.lbl_fecha_cierre.Text = "A fecha de hoy:";
            // 
            // lbl_clt_nom1
            // 
            this.lbl_clt_nom1.AutoSize = true;
            this.lbl_clt_nom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clt_nom1.Location = new System.Drawing.Point(156, 94);
            this.lbl_clt_nom1.Name = "lbl_clt_nom1";
            this.lbl_clt_nom1.Size = new System.Drawing.Size(41, 16);
            this.lbl_clt_nom1.TabIndex = 10;
            this.lbl_clt_nom1.Text = "nom1";
            // 
            // lbl_empresa
            // 
            this.lbl_empresa.AutoSize = true;
            this.lbl_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empresa.Location = new System.Drawing.Point(10, 94);
            this.lbl_empresa.Name = "lbl_empresa";
            this.lbl_empresa.Size = new System.Drawing.Size(100, 16);
            this.lbl_empresa.TabIndex = 9;
            this.lbl_empresa.Text = "A fecha de hoy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empresa";
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lbl_titulo.Location = new System.Drawing.Point(105, 39);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(92, 25);
            this.lbl_titulo.TabIndex = 6;
            this.lbl_titulo.Text = "TITULO";
            // 
            // lbl_monto_real
            // 
            this.lbl_monto_real.AutoSize = true;
            this.lbl_monto_real.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_monto_real.Location = new System.Drawing.Point(10, 138);
            this.lbl_monto_real.Name = "lbl_monto_real";
            this.lbl_monto_real.Size = new System.Drawing.Size(100, 16);
            this.lbl_monto_real.TabIndex = 5;
            this.lbl_monto_real.Text = "A fecha de hoy:";
            // 
            // lbl_monto
            // 
            this.lbl_monto.AutoSize = true;
            this.lbl_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_monto.Location = new System.Drawing.Point(10, 122);
            this.lbl_monto.Name = "lbl_monto";
            this.lbl_monto.Size = new System.Drawing.Size(50, 16);
            this.lbl_monto.TabIndex = 4;
            this.lbl_monto.Text = "Monto";
            // 
            // frm_detalle_tareas_importantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 169);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_detalle_tareas_importantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Tarea";
            this.Load += new System.EventHandler(this.frm_detalle_tareas_importantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hijo_secundario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lbl_fecha_cierre;
        private System.Windows.Forms.Label lbl_clt_nom1;
        private System.Windows.Forms.Label lbl_empresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Label lbl_monto_real;
        private System.Windows.Forms.Label lbl_monto;
        private System.Windows.Forms.Label lbl_rep_nom1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_hijo_secundario;
    }
}