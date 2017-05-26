namespace crm
{
    partial class frm_pronostico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_pronostico));
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lkl_pronostico = new System.Windows.Forms.LinkLabel();
            this.lbl_fecha_hoy = new System.Windows.Forms.Label();
            this.btn_meta_acceso = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgv_hijo = new System.Windows.Forms.DataGridView();
            this.lbl_total_proceso = new System.Windows.Forms.Label();
            this.dgv_nego_importantes = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_total_ganado = new System.Windows.Forms.Label();
            this.lbl_ganados = new System.Windows.Forms.Label();
            this.lbl_total_perdidas = new System.Windows.Forms.Label();
            this.lbl_perdidos = new System.Windows.Forms.Label();
            this.lbl_meta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpc_actis_recents = new DevExpress.XtraEditors.GroupControl();
            this.gpc_nego_hoy = new DevExpress.XtraEditors.GroupControl();
            this.gpc_tareas_importantes = new DevExpress.XtraEditors.GroupControl();
            this.ctc_metas_negocios = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hijo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nego_importantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_actis_recents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_nego_hoy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_tareas_importantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctc_metas_negocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.lkl_pronostico);
            this.groupControl1.Controls.Add(this.lbl_fecha_hoy);
            this.groupControl1.Controls.Add(this.btn_meta_acceso);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.dataGridView3);
            this.groupControl1.Controls.Add(this.dataGridView2);
            this.groupControl1.Controls.Add(this.dataGridView1);
            this.groupControl1.Controls.Add(this.dgv_hijo);
            this.groupControl1.Controls.Add(this.lbl_total_proceso);
            this.groupControl1.Controls.Add(this.dgv_nego_importantes);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.lbl_total_ganado);
            this.groupControl1.Controls.Add(this.lbl_ganados);
            this.groupControl1.Controls.Add(this.lbl_total_perdidas);
            this.groupControl1.Controls.Add(this.lbl_perdidos);
            this.groupControl1.Controls.Add(this.lbl_meta);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.gpc_actis_recents);
            this.groupControl1.Controls.Add(this.gpc_nego_hoy);
            this.groupControl1.Controls.Add(this.gpc_tareas_importantes);
            this.groupControl1.Controls.Add(this.ctc_metas_negocios);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1362, 693);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Meta mensual";
            // 
            // lkl_pronostico
            // 
            this.lkl_pronostico.AutoSize = true;
            this.lkl_pronostico.Location = new System.Drawing.Point(593, 78);
            this.lkl_pronostico.Name = "lkl_pronostico";
            this.lkl_pronostico.Size = new System.Drawing.Size(57, 13);
            this.lkl_pronostico.TabIndex = 175;
            this.lkl_pronostico.TabStop = true;
            this.lkl_pronostico.Text = "Pronostico";
            this.lkl_pronostico.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkl_pronostico_LinkClicked);
            // 
            // lbl_fecha_hoy
            // 
            this.lbl_fecha_hoy.AutoSize = true;
            this.lbl_fecha_hoy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_hoy.Location = new System.Drawing.Point(1015, 61);
            this.lbl_fecha_hoy.Name = "lbl_fecha_hoy";
            this.lbl_fecha_hoy.Size = new System.Drawing.Size(98, 16);
            this.lbl_fecha_hoy.TabIndex = 174;
            this.lbl_fecha_hoy.Text = "A fecha de hoy:";
            // 
            // btn_meta_acceso
            // 
            this.btn_meta_acceso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_meta_acceso.BackgroundImage")));
            this.btn_meta_acceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_meta_acceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_meta_acceso.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_meta_acceso.FlatAppearance.BorderSize = 0;
            this.btn_meta_acceso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_meta_acceso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_meta_acceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_meta_acceso.Location = new System.Drawing.Point(776, 56);
            this.btn_meta_acceso.Margin = new System.Windows.Forms.Padding(4);
            this.btn_meta_acceso.Name = "btn_meta_acceso";
            this.btn_meta_acceso.Size = new System.Drawing.Size(23, 21);
            this.btn_meta_acceso.TabIndex = 173;
            this.btn_meta_acceso.UseVisualStyleBackColor = true;
            this.btn_meta_acceso.Click += new System.EventHandler(this.btn_meta_acceso_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(898, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "A fecha de hoy:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1290, 124);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(10, 10);
            this.dataGridView3.TabIndex = 14;
            this.dataGridView3.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1290, 302);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(10, 10);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1290, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(10, 10);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.Visible = false;
            // 
            // dgv_hijo
            // 
            this.dgv_hijo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hijo.Location = new System.Drawing.Point(1329, 464);
            this.dgv_hijo.Name = "dgv_hijo";
            this.dgv_hijo.Size = new System.Drawing.Size(28, 10);
            this.dgv_hijo.TabIndex = 1;
            this.dgv_hijo.Visible = false;
            // 
            // lbl_total_proceso
            // 
            this.lbl_total_proceso.AutoSize = true;
            this.lbl_total_proceso.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_proceso.Location = new System.Drawing.Point(498, 61);
            this.lbl_total_proceso.Name = "lbl_total_proceso";
            this.lbl_total_proceso.Size = new System.Drawing.Size(98, 16);
            this.lbl_total_proceso.TabIndex = 11;
            this.lbl_total_proceso.Text = "A fecha de hoy:";
            // 
            // dgv_nego_importantes
            // 
            this.dgv_nego_importantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nego_importantes.Location = new System.Drawing.Point(1290, 511);
            this.dgv_nego_importantes.Name = "dgv_nego_importantes";
            this.dgv_nego_importantes.Size = new System.Drawing.Size(10, 10);
            this.dgv_nego_importantes.TabIndex = 0;
            this.dgv_nego_importantes.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(416, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "PROCESO  Q.";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbl_total_ganado
            // 
            this.lbl_total_ganado.AutoSize = true;
            this.lbl_total_ganado.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_ganado.Location = new System.Drawing.Point(299, 61);
            this.lbl_total_ganado.Name = "lbl_total_ganado";
            this.lbl_total_ganado.Size = new System.Drawing.Size(98, 16);
            this.lbl_total_ganado.TabIndex = 9;
            this.lbl_total_ganado.Text = "A fecha de hoy:";
            // 
            // lbl_ganados
            // 
            this.lbl_ganados.AutoSize = true;
            this.lbl_ganados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ganados.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ganados.Location = new System.Drawing.Point(221, 61);
            this.lbl_ganados.Name = "lbl_ganados";
            this.lbl_ganados.Size = new System.Drawing.Size(83, 16);
            this.lbl_ganados.TabIndex = 8;
            this.lbl_ganados.Text = "GANADO  Q.";
            this.lbl_ganados.Click += new System.EventHandler(this.lbl_ganados_Click);
            // 
            // lbl_total_perdidas
            // 
            this.lbl_total_perdidas.AutoSize = true;
            this.lbl_total_perdidas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total_perdidas.Location = new System.Drawing.Point(95, 61);
            this.lbl_total_perdidas.Name = "lbl_total_perdidas";
            this.lbl_total_perdidas.Size = new System.Drawing.Size(98, 16);
            this.lbl_total_perdidas.TabIndex = 7;
            this.lbl_total_perdidas.Text = "A fecha de hoy:";
            // 
            // lbl_perdidos
            // 
            this.lbl_perdidos.AutoSize = true;
            this.lbl_perdidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_perdidos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_perdidos.Location = new System.Drawing.Point(14, 61);
            this.lbl_perdidos.Name = "lbl_perdidos";
            this.lbl_perdidos.Size = new System.Drawing.Size(85, 16);
            this.lbl_perdidos.TabIndex = 6;
            this.lbl_perdidos.Text = "PERDIDO  Q.";
            this.lbl_perdidos.Click += new System.EventHandler(this.lbl_perdidos_Click);
            // 
            // lbl_meta
            // 
            this.lbl_meta.AutoSize = true;
            this.lbl_meta.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_meta.Location = new System.Drawing.Point(705, 61);
            this.lbl_meta.Name = "lbl_meta";
            this.lbl_meta.Size = new System.Drawing.Size(98, 16);
            this.lbl_meta.TabIndex = 5;
            this.lbl_meta.Text = "A fecha de hoy:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(646, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "META  Q.";
            // 
            // gpc_actis_recents
            // 
            this.gpc_actis_recents.Location = new System.Drawing.Point(880, 97);
            this.gpc_actis_recents.Name = "gpc_actis_recents";
            this.gpc_actis_recents.Size = new System.Drawing.Size(375, 508);
            this.gpc_actis_recents.TabIndex = 3;
            this.gpc_actis_recents.Text = "Actividades recientes";
            // 
            // gpc_nego_hoy
            // 
            this.gpc_nego_hoy.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gpc_nego_hoy.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.gpc_nego_hoy.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gpc_nego_hoy.Appearance.Options.UseBackColor = true;
            this.gpc_nego_hoy.Appearance.Options.UseBorderColor = true;
            this.gpc_nego_hoy.Location = new System.Drawing.Point(458, 423);
            this.gpc_nego_hoy.Name = "gpc_nego_hoy";
            this.gpc_nego_hoy.Size = new System.Drawing.Size(416, 182);
            this.gpc_nego_hoy.TabIndex = 2;
            this.gpc_nego_hoy.Text = "Negociaciones de hoy";
            // 
            // gpc_tareas_importantes
            // 
            this.gpc_tareas_importantes.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gpc_tareas_importantes.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.gpc_tareas_importantes.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gpc_tareas_importantes.Appearance.Options.UseBackColor = true;
            this.gpc_tareas_importantes.Appearance.Options.UseBorderColor = true;
            this.gpc_tareas_importantes.Location = new System.Drawing.Point(17, 423);
            this.gpc_tareas_importantes.Name = "gpc_tareas_importantes";
            this.gpc_tareas_importantes.Size = new System.Drawing.Size(407, 98);
            this.gpc_tareas_importantes.TabIndex = 1;
            this.gpc_tareas_importantes.Text = "Tareas más importantes";
            // 
            // ctc_metas_negocios
            // 
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.ctc_metas_negocios.Diagram = swiftPlotDiagram1;
            this.ctc_metas_negocios.Location = new System.Drawing.Point(17, 97);
            this.ctc_metas_negocios.Name = "ctc_metas_negocios";
            series1.Name = "Series 1";
            series1.View = swiftPlotSeriesView1;
            this.ctc_metas_negocios.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.ctc_metas_negocios.Size = new System.Drawing.Size(857, 301);
            this.ctc_metas_negocios.TabIndex = 0;
            // 
            // frm_pronostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 693);
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_pronostico";
            this.Text = "Metas";
            this.Load += new System.EventHandler(this.frm_pronostico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hijo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nego_importantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_actis_recents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_nego_hoy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpc_tareas_importantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctc_metas_negocios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl gpc_nego_hoy;
        private DevExpress.XtraEditors.GroupControl gpc_tareas_importantes;
        private DevExpress.XtraCharts.ChartControl ctc_metas_negocios;
        private DevExpress.XtraEditors.GroupControl gpc_actis_recents;
        private System.Windows.Forms.Label lbl_total_proceso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_total_ganado;
        private System.Windows.Forms.Label lbl_ganados;
        private System.Windows.Forms.Label lbl_total_perdidas;
        private System.Windows.Forms.Label lbl_perdidos;
        private System.Windows.Forms.Label lbl_meta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_nego_importantes;
        public System.Windows.Forms.DataGridView dgv_hijo;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_meta_acceso;
        private System.Windows.Forms.Label lbl_fecha_hoy;
        private System.Windows.Forms.LinkLabel lkl_pronostico;
    }
}