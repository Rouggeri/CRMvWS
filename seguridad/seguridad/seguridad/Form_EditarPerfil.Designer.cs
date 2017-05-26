namespace seguridad
{
    partial class Form_EditarPerfil
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chlb_permisos = new System.Windows.Forms.CheckedListBox();
            this.chlb_aplicaciones = new System.Windows.Forms.CheckedListBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.dgw_permisos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_perfil = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonaceptar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Permisos:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chlb_permisos);
            this.groupBox3.Controls.Add(this.chlb_aplicaciones);
            this.groupBox3.Controls.Add(this.btn_agregar);
            this.groupBox3.Location = new System.Drawing.Point(27, 88);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(753, 218);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar permisos nuevos:";
            // 
            // chlb_permisos
            // 
            this.chlb_permisos.FormattingEnabled = true;
            this.chlb_permisos.Items.AddRange(new object[] {
            "Insertar",
            "Seleccionar",
            "Actualizar",
            "Eliminar"});
            this.chlb_permisos.Location = new System.Drawing.Point(399, 24);
            this.chlb_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_permisos.Name = "chlb_permisos";
            this.chlb_permisos.Size = new System.Drawing.Size(336, 124);
            this.chlb_permisos.TabIndex = 19;
            // 
            // chlb_aplicaciones
            // 
            this.chlb_aplicaciones.FormattingEnabled = true;
            this.chlb_aplicaciones.Location = new System.Drawing.Point(25, 24);
            this.chlb_aplicaciones.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_aplicaciones.Name = "chlb_aplicaciones";
            this.chlb_aplicaciones.Size = new System.Drawing.Size(356, 124);
            this.chlb_aplicaciones.TabIndex = 8;
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(342, 166);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(104, 29);
            this.btn_agregar.TabIndex = 17;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundImage = global::seguridad.Properties.Resources.guardar;
            this.btn_aceptar.FlatAppearance.BorderSize = 0;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Location = new System.Drawing.Point(266, 764);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(87, 80);
            this.btn_aceptar.TabIndex = 26;
            this.toolTip1.SetToolTip(this.btn_aceptar, "Botón Guardar");
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // dgw_permisos
            // 
            this.dgw_permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_permisos.Location = new System.Drawing.Point(27, 330);
            this.dgw_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.dgw_permisos.Name = "dgw_permisos";
            this.dgw_permisos.Size = new System.Drawing.Size(747, 189);
            this.dgw_permisos.TabIndex = 22;
            this.dgw_permisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_permisos_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_perfil);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(753, 67);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar perfil:";
            // 
            // cbo_perfil
            // 
            this.cbo_perfil.FormattingEnabled = true;
            this.cbo_perfil.Location = new System.Drawing.Point(269, 24);
            this.cbo_perfil.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_perfil.Name = "cbo_perfil";
            this.cbo_perfil.Size = new System.Drawing.Size(160, 23);
            this.cbo_perfil.TabIndex = 15;
            this.cbo_perfil.SelectedIndexChanged += new System.EventHandler(this.cbo_usuario_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Perfil:";
            // 
            // btn_reporte
            // 
            this.btn_reporte.BackgroundImage = global::seguridad.Properties.Resources.rpt_775;
            this.btn_reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reporte.FlatAppearance.BorderSize = 0;
            this.btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reporte.Location = new System.Drawing.Point(439, 764);
            this.btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(87, 80);
            this.btn_reporte.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btn_reporte, "Botón Visualizar Reporte");
            this.btn_reporte.UseVisualStyleBackColor = true;
            this.btn_reporte.Click += new System.EventHandler(this.btn_reporte_Click);
            // 
            // buttonaceptar
            // 
            this.buttonaceptar.BackgroundImage = global::seguridad.Properties.Resources.guardar;
            this.buttonaceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonaceptar.FlatAppearance.BorderSize = 0;
            this.buttonaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonaceptar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonaceptar.Location = new System.Drawing.Point(355, 540);
            this.buttonaceptar.Name = "buttonaceptar";
            this.buttonaceptar.Size = new System.Drawing.Size(76, 68);
            this.buttonaceptar.TabIndex = 31;
            this.buttonaceptar.Text = "\r\n";
            this.buttonaceptar.UseVisualStyleBackColor = true;
            this.buttonaceptar.Click += new System.EventHandler(this.buttonaceptar_Click);
            // 
            // Form_EditarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 633);
            this.Controls.Add(this.buttonaceptar);
            this.Controls.Add(this.btn_reporte);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgw_permisos);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_EditarPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar perfiles";
            this.Load += new System.EventHandler(this.Form_EditarPerfil_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.DataGridView dgw_permisos;
        private System.Windows.Forms.CheckedListBox chlb_permisos;
        private System.Windows.Forms.CheckedListBox chlb_aplicaciones;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_perfil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonaceptar;
    }
}