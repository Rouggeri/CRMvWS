namespace crm
{
    partial class FormTareasNegocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTareasNegocio));
            this.txt_descripcion = new System.Windows.Forms.RichTextBox();
            this.dn_fecha = new DevExpress.XtraScheduler.DateNavigator();
            this.te_hora = new DevExpress.XtraEditors.TimeEdit();
            this.cbo_empleado = new System.Windows.Forms.ComboBox();
            this.cbo_tareas = new System.Windows.Forms.ComboBox();
            this.btn_actualizar_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nuevo_emp = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_guardar = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_criticidad = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.te_hora_fin = new DevExpress.XtraEditors.TimeEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dn_fecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dn_fecha.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_hora.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_hora_fin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(30, 34);
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(428, 50);
            this.txt_descripcion.TabIndex = 0;
            this.txt_descripcion.Text = "";
            // 
            // dn_fecha
            // 
            this.dn_fecha.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dn_fecha.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dn_fecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dn_fecha.DateTime = new System.DateTime(2017, 4, 1, 0, 0, 0, 0);
            this.dn_fecha.EditValue = new System.DateTime(2017, 4, 1, 0, 0, 0, 0);
            this.dn_fecha.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dn_fecha.Location = new System.Drawing.Point(245, 119);
            this.dn_fecha.Name = "dn_fecha";
            this.dn_fecha.Size = new System.Drawing.Size(213, 237);
            this.dn_fecha.TabIndex = 1;
            // 
            // te_hora
            // 
            this.te_hora.EditValue = new System.DateTime(2017, 3, 26, 0, 0, 0, 0);
            this.te_hora.Location = new System.Drawing.Point(30, 192);
            this.te_hora.Name = "te_hora";
            this.te_hora.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.te_hora.Properties.Appearance.Options.UseFont = true;
            this.te_hora.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.te_hora.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_hora.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.te_hora.Size = new System.Drawing.Size(165, 26);
            this.te_hora.TabIndex = 2;
            // 
            // cbo_empleado
            // 
            this.cbo_empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_empleado.FormattingEnabled = true;
            this.cbo_empleado.Location = new System.Drawing.Point(30, 374);
            this.cbo_empleado.Name = "cbo_empleado";
            this.cbo_empleado.Size = new System.Drawing.Size(428, 21);
            this.cbo_empleado.TabIndex = 3;
            // 
            // cbo_tareas
            // 
            this.cbo_tareas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tareas.FormattingEnabled = true;
            this.cbo_tareas.Location = new System.Drawing.Point(30, 427);
            this.cbo_tareas.Name = "cbo_tareas";
            this.cbo_tareas.Size = new System.Drawing.Size(294, 21);
            this.cbo_tareas.TabIndex = 38;
            // 
            // btn_actualizar_emp
            // 
            this.btn_actualizar_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_emp.Image")));
            this.btn_actualizar_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_emp.Location = new System.Drawing.Point(397, 427);
            this.btn_actualizar_emp.Name = "btn_actualizar_emp";
            this.btn_actualizar_emp.Size = new System.Drawing.Size(61, 23);
            this.btn_actualizar_emp.TabIndex = 37;
            this.btn_actualizar_emp.ToolTip = "Actualizar";
            this.btn_actualizar_emp.Visible = false;
            // 
            // btn_nuevo_emp
            // 
            this.btn_nuevo_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo_emp.Image")));
            this.btn_nuevo_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nuevo_emp.Location = new System.Drawing.Point(330, 427);
            this.btn_nuevo_emp.Name = "btn_nuevo_emp";
            this.btn_nuevo_emp.Size = new System.Drawing.Size(61, 23);
            this.btn_nuevo_emp.TabIndex = 36;
            this.btn_nuevo_emp.ToolTip = "Nuevo empleado";
            this.btn_nuevo_emp.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Descripción de la tarea...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(27, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Hora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(242, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(27, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Encargado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(27, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Tipo de tarea";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_guardar.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_guardar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_guardar.Appearance.Options.UseBackColor = true;
            this.btn_guardar.Appearance.Options.UseFont = true;
            this.btn_guardar.Appearance.Options.UseForeColor = true;
            this.btn_guardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_guardar.Location = new System.Drawing.Point(30, 509);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(96, 31);
            this.btn_guardar.TabIndex = 44;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(63, 140);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.InitialImage = null;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(36, 29);
            this.pictureEdit1.TabIndex = 45;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(288, 87);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.InitialImage = null;
            this.pictureEdit2.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Size = new System.Drawing.Size(36, 29);
            this.pictureEdit2.TabIndex = 46;
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineAlignment = DevExpress.XtraEditors.Alignment.Center;
            this.separatorControl1.LineColor = System.Drawing.Color.DodgerBlue;
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.separatorControl1.Location = new System.Drawing.Point(209, 100);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(27, 256);
            this.separatorControl1.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(32, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "Criticidad";
            // 
            // cbo_criticidad
            // 
            this.cbo_criticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_criticidad.FormattingEnabled = true;
            this.cbo_criticidad.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja"});
            this.cbo_criticidad.Location = new System.Drawing.Point(30, 482);
            this.cbo_criticidad.Name = "cbo_criticidad";
            this.cbo_criticidad.Size = new System.Drawing.Size(294, 21);
            this.cbo_criticidad.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(32, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Hora de finalización";
            // 
            // te_hora_fin
            // 
            this.te_hora_fin.EditValue = new System.DateTime(2017, 3, 26, 0, 0, 0, 0);
            this.te_hora_fin.Location = new System.Drawing.Point(30, 237);
            this.te_hora_fin.Name = "te_hora_fin";
            this.te_hora_fin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.te_hora_fin.Properties.Appearance.Options.UseFont = true;
            this.te_hora_fin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.te_hora_fin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.te_hora_fin.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.te_hora_fin.Size = new System.Drawing.Size(165, 26);
            this.te_hora_fin.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(32, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "Hora de inicio";
            // 
            // FormTareasNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 561);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.te_hora_fin);
            this.Controls.Add(this.cbo_criticidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.pictureEdit2);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_tareas);
            this.Controls.Add(this.btn_actualizar_emp);
            this.Controls.Add(this.btn_nuevo_emp);
            this.Controls.Add(this.cbo_empleado);
            this.Controls.Add(this.te_hora);
            this.Controls.Add(this.dn_fecha);
            this.Controls.Add(this.txt_descripcion);
            this.Name = "FormTareasNegocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tareas";
            this.Load += new System.EventHandler(this.FormTareasNegocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dn_fecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dn_fecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_hora.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_hora_fin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox txt_descripcion;
        public DevExpress.XtraScheduler.DateNavigator dn_fecha;
        public DevExpress.XtraEditors.TimeEdit te_hora;
        public System.Windows.Forms.ComboBox cbo_empleado;
        public System.Windows.Forms.ComboBox cbo_tareas;
        public DevExpress.XtraEditors.SimpleButton btn_actualizar_emp;
        public DevExpress.XtraEditors.SimpleButton btn_nuevo_emp;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public DevExpress.XtraEditors.SimpleButton btn_guardar;
        public DevExpress.XtraEditors.PictureEdit pictureEdit1;
        public DevExpress.XtraEditors.PictureEdit pictureEdit2;
        public DevExpress.XtraEditors.SeparatorControl separatorControl1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbo_criticidad;
        private System.Windows.Forms.Label label8;
        public DevExpress.XtraEditors.TimeEdit te_hora_fin;
        private System.Windows.Forms.Label label7;
    }
}