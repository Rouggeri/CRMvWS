namespace seguridad
{
    partial class FormAsignacionPerfil
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
            this.group_box_pp = new System.Windows.Forms.GroupBox();
            this.dgw_permisos = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chlb_permisos = new System.Windows.Forms.CheckedListBox();
            this.trv_aplicaciones = new System.Windows.Forms.TreeView();
            this.chlb_aplicaciones = new System.Windows.Forms.CheckedListBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_perfil = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.group_box_pp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_box_pp
            // 
            this.group_box_pp.Controls.Add(this.dgw_permisos);
            this.group_box_pp.Controls.Add(this.groupBox3);
            this.group_box_pp.Location = new System.Drawing.Point(24, 78);
            this.group_box_pp.Margin = new System.Windows.Forms.Padding(4);
            this.group_box_pp.Name = "group_box_pp";
            this.group_box_pp.Padding = new System.Windows.Forms.Padding(4);
            this.group_box_pp.Size = new System.Drawing.Size(747, 492);
            this.group_box_pp.TabIndex = 23;
            this.group_box_pp.TabStop = false;
            this.group_box_pp.Text = "Permisos y privilegios:";
            this.group_box_pp.Enter += new System.EventHandler(this.group_box_pp_Enter);
            // 
            // dgw_permisos
            // 
            this.dgw_permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_permisos.Location = new System.Drawing.Point(31, 261);
            this.dgw_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.dgw_permisos.Name = "dgw_permisos";
            this.dgw_permisos.Size = new System.Drawing.Size(677, 203);
            this.dgw_permisos.TabIndex = 22;
            this.dgw_permisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_permisos_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.chlb_permisos);
            this.groupBox3.Controls.Add(this.trv_aplicaciones);
            this.groupBox3.Location = new System.Drawing.Point(31, 21);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(677, 232);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar permisos:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 35);
            this.button1.TabIndex = 20;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chlb_permisos
            // 
            this.chlb_permisos.FormattingEnabled = true;
            this.chlb_permisos.Items.AddRange(new object[] {
            "Insertar",
            "Seleccionar",
            "Actualizar",
            "Eliminar"});
            this.chlb_permisos.Location = new System.Drawing.Point(359, 24);
            this.chlb_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_permisos.Name = "chlb_permisos";
            this.chlb_permisos.Size = new System.Drawing.Size(285, 154);
            this.chlb_permisos.TabIndex = 19;
            // 
            // trv_aplicaciones
            // 
            this.trv_aplicaciones.Location = new System.Drawing.Point(34, 24);
            this.trv_aplicaciones.Name = "trv_aplicaciones";
            this.trv_aplicaciones.Size = new System.Drawing.Size(273, 154);
            this.trv_aplicaciones.TabIndex = 30;
            this.trv_aplicaciones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trv_aplicaciones_AfterCheck);
            // 
            // chlb_aplicaciones
            // 
            this.chlb_aplicaciones.FormattingEnabled = true;
            this.chlb_aplicaciones.Location = new System.Drawing.Point(919, 100);
            this.chlb_aplicaciones.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_aplicaciones.Name = "chlb_aplicaciones";
            this.chlb_aplicaciones.Size = new System.Drawing.Size(133, 64);
            this.chlb_aplicaciones.TabIndex = 8;
            this.chlb_aplicaciones.Visible = false;
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(948, 165);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(104, 35);
            this.btn_agregar.TabIndex = 17;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Visible = false;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_perfil);
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(747, 57);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo perfil:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Perfil:";
            // 
            // txt_perfil
            // 
            this.txt_perfil.Location = new System.Drawing.Point(170, 21);
            this.txt_perfil.Margin = new System.Windows.Forms.Padding(4);
            this.txt_perfil.Name = "txt_perfil";
            this.txt_perfil.Size = new System.Drawing.Size(415, 20);
            this.txt_perfil.TabIndex = 8;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundImage = global::seguridad.Properties.Resources.guardar;
            this.btn_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aceptar.FlatAppearance.BorderSize = 0;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Location = new System.Drawing.Point(303, 588);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(72, 70);
            this.btn_aceptar.TabIndex = 24;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_reporte
            // 
            this.btn_reporte.BackgroundImage = global::seguridad.Properties.Resources.rpt_775;
            this.btn_reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reporte.FlatAppearance.BorderSize = 0;
            this.btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reporte.Location = new System.Drawing.Point(414, 583);
            this.btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(87, 80);
            this.btn_reporte.TabIndex = 25;
            this.btn_reporte.UseVisualStyleBackColor = true;
            this.btn_reporte.Click += new System.EventHandler(this.btn_reporte_Click);
            // 
            // FormAsignacionPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 685);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.chlb_aplicaciones);
            this.Controls.Add(this.btn_reporte);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.group_box_pp);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAsignacionPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear perfil";
            this.Load += new System.EventHandler(this.FormAsignacionPerfil_Load);
            this.group_box_pp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox group_box_pp;
        private System.Windows.Forms.DataGridView dgw_permisos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chlb_permisos;
        private System.Windows.Forms.CheckedListBox chlb_aplicaciones;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_perfil;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.TreeView trv_aplicaciones;
        private System.Windows.Forms.Button button1;
    }
}