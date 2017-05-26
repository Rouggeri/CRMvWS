namespace seguridad
{
    partial class FormAsignarPermisosUsuario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbo_roles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contraseña = new System.Windows.Forms.TextBox();
            this.txt_rep_contraseña = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_admin = new System.Windows.Forms.CheckBox();
            this.lbl_colab = new System.Windows.Forms.Label();
            this.cmb_colab = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgw_central = new System.Windows.Forms.DataGridView();
            this.cmb_emp = new System.Windows.Forms.ComboBox();
            this.group_box_pp = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.trv_aplicaciones = new System.Windows.Forms.TreeView();
            this.chlb_permisos = new System.Windows.Forms.CheckedListBox();
            this.dgw_permisos = new System.Windows.Forms.DataGridView();
            this.chlb_aplicaciones = new System.Windows.Forms.CheckedListBox();
            this.btn_mover = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_agregar_perfil = new System.Windows.Forms.Button();
            this.dgw_perfil = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.chb_usuario = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_central)).BeginInit();
            this.group_box_pp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_perfil)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_roles
            // 
            this.cbo_roles.FormattingEnabled = true;
            this.cbo_roles.Location = new System.Drawing.Point(339, 17);
            this.cbo_roles.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_roles.Name = "cbo_roles";
            this.cbo_roles.Size = new System.Drawing.Size(160, 23);
            this.cbo_roles.TabIndex = 0;
            this.cbo_roles.SelectedIndexChanged += new System.EventHandler(this.cbo_roles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Perfil:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(123, 12);
            this.txt_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(155, 20);
            this.txt_usuario.TabIndex = 8;
            this.txt_usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_usuario_KeyPress);
            // 
            // txt_contraseña
            // 
            this.txt_contraseña.Location = new System.Drawing.Point(568, 16);
            this.txt_contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txt_contraseña.Name = "txt_contraseña";
            this.txt_contraseña.PasswordChar = '*';
            this.txt_contraseña.Size = new System.Drawing.Size(192, 20);
            this.txt_contraseña.TabIndex = 9;
            this.txt_contraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_contraseña_KeyPress);
            // 
            // txt_rep_contraseña
            // 
            this.txt_rep_contraseña.Location = new System.Drawing.Point(568, 44);
            this.txt_rep_contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.txt_rep_contraseña.Name = "txt_rep_contraseña";
            this.txt_rep_contraseña.PasswordChar = '*';
            this.txt_rep_contraseña.Size = new System.Drawing.Size(192, 20);
            this.txt_rep_contraseña.TabIndex = 10;
            this.txt_rep_contraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rep_contraseña_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Repetir contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Usuario:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_usuario);
            this.groupBox1.Controls.Add(this.check_admin);
            this.groupBox1.Controls.Add(this.lbl_colab);
            this.groupBox1.Controls.Add(this.cmb_colab);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txt_rep_contraseña);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_usuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_contraseña);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(780, 268);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo usuario:";
            // 
            // check_admin
            // 
            this.check_admin.AutoSize = true;
            this.check_admin.Location = new System.Drawing.Point(324, 20);
            this.check_admin.Name = "check_admin";
            this.check_admin.Size = new System.Drawing.Size(100, 20);
            this.check_admin.TabIndex = 24;
            this.check_admin.Text = "Administrador";
            this.check_admin.UseVisualStyleBackColor = true;
            // 
            // lbl_colab
            // 
            this.lbl_colab.AutoSize = true;
            this.lbl_colab.Location = new System.Drawing.Point(11, 44);
            this.lbl_colab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_colab.Name = "lbl_colab";
            this.lbl_colab.Size = new System.Drawing.Size(67, 16);
            this.lbl_colab.TabIndex = 18;
            this.lbl_colab.Text = "Empleado:";
            // 
            // cmb_colab
            // 
            this.cmb_colab.FormattingEnabled = true;
            this.cmb_colab.Location = new System.Drawing.Point(123, 41);
            this.cmb_colab.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_colab.Name = "cmb_colab";
            this.cmb_colab.Size = new System.Drawing.Size(96, 23);
            this.cmb_colab.TabIndex = 16;
            this.cmb_colab.SelectedIndexChanged += new System.EventHandler(this.cmb_colab_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgw_central);
            this.groupBox3.Location = new System.Drawing.Point(14, 70);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(758, 192);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos del usuario:";
            // 
            // dgw_central
            // 
            this.dgw_central.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_central.Location = new System.Drawing.Point(8, 24);
            this.dgw_central.Margin = new System.Windows.Forms.Padding(4);
            this.dgw_central.Name = "dgw_central";
            this.dgw_central.Size = new System.Drawing.Size(746, 153);
            this.dgw_central.TabIndex = 22;
            this.dgw_central.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_central_CellContentClick);
            // 
            // cmb_emp
            // 
            this.cmb_emp.FormattingEnabled = true;
            this.cmb_emp.Location = new System.Drawing.Point(1053, 41);
            this.cmb_emp.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_emp.Name = "cmb_emp";
            this.cmb_emp.Size = new System.Drawing.Size(10, 23);
            this.cmb_emp.TabIndex = 15;
            this.cmb_emp.Visible = false;
            this.cmb_emp.SelectedIndexChanged += new System.EventHandler(this.cmb_emp_SelectedIndexChanged);
            // 
            // group_box_pp
            // 
            this.group_box_pp.Controls.Add(this.button2);
            this.group_box_pp.Controls.Add(this.btn_agregar);
            this.group_box_pp.Controls.Add(this.trv_aplicaciones);
            this.group_box_pp.Controls.Add(this.chlb_permisos);
            this.group_box_pp.Controls.Add(this.dgw_permisos);
            this.group_box_pp.Location = new System.Drawing.Point(24, 8);
            this.group_box_pp.Margin = new System.Windows.Forms.Padding(4);
            this.group_box_pp.Name = "group_box_pp";
            this.group_box_pp.Padding = new System.Windows.Forms.Padding(4);
            this.group_box_pp.Size = new System.Drawing.Size(740, 357);
            this.group_box_pp.TabIndex = 16;
            this.group_box_pp.TabStop = false;
            this.group_box_pp.Text = "Permisos y privilegios:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 140);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 27);
            this.button2.TabIndex = 23;
            this.button2.Text = "Mover";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(296, 321);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(141, 27);
            this.btn_agregar.TabIndex = 17;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // trv_aplicaciones
            // 
            this.trv_aplicaciones.Location = new System.Drawing.Point(25, 24);
            this.trv_aplicaciones.Name = "trv_aplicaciones";
            this.trv_aplicaciones.Size = new System.Drawing.Size(285, 109);
            this.trv_aplicaciones.TabIndex = 29;
            this.trv_aplicaciones.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.trv_aplicaciones_BeforeCheck);
            this.trv_aplicaciones.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trv_aplicaciones_AfterCheck);
            this.trv_aplicaciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_aplicaciones_AfterSelect);
            // 
            // chlb_permisos
            // 
            this.chlb_permisos.FormattingEnabled = true;
            this.chlb_permisos.Items.AddRange(new object[] {
            "Insertar",
            "Seleccionar",
            "Actualizar",
            "Eliminar"});
            this.chlb_permisos.Location = new System.Drawing.Point(367, 24);
            this.chlb_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_permisos.Name = "chlb_permisos";
            this.chlb_permisos.Size = new System.Drawing.Size(285, 109);
            this.chlb_permisos.TabIndex = 19;
            // 
            // dgw_permisos
            // 
            this.dgw_permisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_permisos.Location = new System.Drawing.Point(6, 176);
            this.dgw_permisos.Margin = new System.Windows.Forms.Padding(4);
            this.dgw_permisos.Name = "dgw_permisos";
            this.dgw_permisos.Size = new System.Drawing.Size(724, 137);
            this.dgw_permisos.TabIndex = 22;
            this.dgw_permisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_permisos_CellContentClick);
            // 
            // chlb_aplicaciones
            // 
            this.chlb_aplicaciones.FormattingEnabled = true;
            this.chlb_aplicaciones.Location = new System.Drawing.Point(1064, 374);
            this.chlb_aplicaciones.Margin = new System.Windows.Forms.Padding(4);
            this.chlb_aplicaciones.Name = "chlb_aplicaciones";
            this.chlb_aplicaciones.Size = new System.Drawing.Size(48, 34);
            this.chlb_aplicaciones.TabIndex = 8;
            this.chlb_aplicaciones.Visible = false;
            this.chlb_aplicaciones.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chlb_aplicaciones_ItemCheck);
            this.chlb_aplicaciones.Click += new System.EventHandler(this.chlb_aplicaciones_Click);
            this.chlb_aplicaciones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chlb_aplicaciones_MouseClick);
            this.chlb_aplicaciones.SelectedIndexChanged += new System.EventHandler(this.chlb_aplicaciones_SelectedIndexChanged);
            this.chlb_aplicaciones.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chlb_aplicaciones_MouseDoubleClick);
            // 
            // btn_mover
            // 
            this.btn_mover.Location = new System.Drawing.Point(1083, 538);
            this.btn_mover.Margin = new System.Windows.Forms.Padding(4);
            this.btn_mover.Name = "btn_mover";
            this.btn_mover.Size = new System.Drawing.Size(29, 27);
            this.btn_mover.TabIndex = 17;
            this.btn_mover.Text = "Mover";
            this.btn_mover.UseVisualStyleBackColor = true;
            this.btn_mover.Visible = false;
            this.btn_mover.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_agregar_perfil);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dgw_perfil);
            this.groupBox2.Controls.Add(this.cbo_roles);
            this.groupBox2.Location = new System.Drawing.Point(23, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(741, 383);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Asignar perfil:";
            // 
            // btn_agregar_perfil
            // 
            this.btn_agregar_perfil.Location = new System.Drawing.Point(290, 300);
            this.btn_agregar_perfil.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar_perfil.Name = "btn_agregar_perfil";
            this.btn_agregar_perfil.Size = new System.Drawing.Size(141, 34);
            this.btn_agregar_perfil.TabIndex = 19;
            this.btn_agregar_perfil.Text = "Agregar";
            this.btn_agregar_perfil.UseVisualStyleBackColor = true;
            this.btn_agregar_perfil.Click += new System.EventHandler(this.btn_aceptar_perfil_Click);
            // 
            // dgw_perfil
            // 
            this.dgw_perfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_perfil.Location = new System.Drawing.Point(8, 48);
            this.dgw_perfil.Margin = new System.Windows.Forms.Padding(4);
            this.dgw_perfil.Name = "dgw_perfil";
            this.dgw_perfil.Size = new System.Drawing.Size(725, 244);
            this.dgw_perfil.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 274);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 408);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.group_box_pp);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(772, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asignar permisos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(772, 380);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asignar perfil";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(997, 849);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackgroundImage = global::seguridad.Properties.Resources.guardar;
            this.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Location = new System.Drawing.Point(822, 319);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(58, 57);
            this.btn_guardar.TabIndex = 27;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_reporte
            // 
            this.btn_reporte.BackgroundImage = global::seguridad.Properties.Resources.crystal;
            this.btn_reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reporte.Location = new System.Drawing.Point(945, 516);
            this.btn_reporte.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(41, 34);
            this.btn_reporte.TabIndex = 28;
            this.btn_reporte.UseVisualStyleBackColor = true;
            this.btn_reporte.Visible = false;
            this.btn_reporte.Click += new System.EventHandler(this.btn_reporte_Click);
            // 
            // chb_usuario
            // 
            this.chb_usuario.AutoSize = true;
            this.chb_usuario.Location = new System.Drawing.Point(273, 49);
            this.chb_usuario.Name = "chb_usuario";
            this.chb_usuario.Size = new System.Drawing.Size(155, 20);
            this.chb_usuario.TabIndex = 25;
            this.chb_usuario.Text = "Crear usuario a nivel BD";
            this.chb_usuario.UseVisualStyleBackColor = true;
            // 
            // FormAsignarPermisosUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 706);
            this.Controls.Add(this.btn_mover);
            this.Controls.Add(this.chlb_aplicaciones);
            this.Controls.Add(this.btn_reporte);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_emp);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAsignarPermisosUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear usuario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_central)).EndInit();
            this.group_box_pp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_permisos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_perfil)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contraseña;
        private System.Windows.Forms.TextBox txt_rep_contraseña;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox group_box_pp;
        public System.Windows.Forms.ComboBox cbo_roles;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgw_permisos;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox chlb_permisos;
        private System.Windows.Forms.CheckedListBox chlb_aplicaciones;
        private System.Windows.Forms.Button btn_mover;
        private System.Windows.Forms.DataGridView dgw_perfil;
        private System.Windows.Forms.Button btn_agregar_perfil;
        private System.Windows.Forms.DataGridView dgw_central;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label lbl_colab;
        private System.Windows.Forms.ComboBox cmb_colab;
        private System.Windows.Forms.ComboBox cmb_emp;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.CheckBox check_admin;
        private System.Windows.Forms.TreeView trv_aplicaciones;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chb_usuario;
    }
}

