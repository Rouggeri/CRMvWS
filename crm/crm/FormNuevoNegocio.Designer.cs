namespace crm
{
    partial class FormNuevoNegocio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoNegocio));
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel5 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel6 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel7 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel8 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dtp_fecha_cierre = new DevExpress.XtraEditors.DateEdit();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_detalles = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_valor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_nueva = new DevExpress.XtraEditors.SimpleButton();
            this.btn_refesh_cat = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_nuevo_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_actualizar_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nuevo_perem = new DevExpress.XtraEditors.SimpleButton();
            this.btn_refresh_perem = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_monedas = new System.Windows.Forms.ComboBox();
            this.btn_guardar = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_empleado = new System.Windows.Forms.ComboBox();
            this.cbo_cat = new System.Windows.Forms.ComboBox();
            this.btn_actualizar_mon = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nueva_mon = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_perem = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_etapa = new DevExpress.XtraEditors.TrackBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_etapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_etapa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.cbo_monedas);
            this.groupControl1.Controls.Add(this.btn_guardar);
            this.groupControl1.Controls.Add(this.cbo_empleado);
            this.groupControl1.Controls.Add(this.cbo_cat);
            this.groupControl1.Controls.Add(this.btn_actualizar_mon);
            this.groupControl1.Controls.Add(this.btn_nueva_mon);
            this.groupControl1.Controls.Add(this.cbo_perem);
            this.groupControl1.Controls.Add(this.comboBox1);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.tb_etapa);
            this.groupControl1.Controls.Add(this.btn_actualizar_emp);
            this.groupControl1.Controls.Add(this.btn_refresh_perem);
            this.groupControl1.Controls.Add(this.dtp_fecha_cierre);
            this.groupControl1.Controls.Add(this.btn_nuevo_perem);
            this.groupControl1.Controls.Add(this.lbl_titulo);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btn_nuevo_emp);
            this.groupControl1.Controls.Add(this.txt_titulo);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btn_refesh_cat);
            this.groupControl1.Controls.Add(this.txt_detalles);
            this.groupControl1.Controls.Add(this.btn_nueva);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txt_valor);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // dtp_fecha_cierre
            // 
            resources.ApplyResources(this.dtp_fecha_cierre, "dtp_fecha_cierre");
            this.dtp_fecha_cierre.Name = "dtp_fecha_cierre";
            this.dtp_fecha_cierre.Properties.AccessibleDescription = resources.GetString("dtp_fecha_cierre.Properties.AccessibleDescription");
            this.dtp_fecha_cierre.Properties.AccessibleName = resources.GetString("dtp_fecha_cierre.Properties.AccessibleName");
            this.dtp_fecha_cierre.Properties.AutoHeight = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.AutoHeight")));
            this.dtp_fecha_cierre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtp_fecha_cierre.Properties.Buttons"))))});
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.AccessibleDescription = resources.GetString("dtp_fecha_cierre.Properties.CalendarTimeProperties.AccessibleDescription");
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.AccessibleName = resources.GetString("dtp_fecha_cierre.Properties.CalendarTimeProperties.AccessibleName");
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.AutoHeight")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Buttons"))))});
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.AutoComplete")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.BeepOnError")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.EditMask = resources.GetString("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.EditMask");
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.MaskType")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.PlaceHolder")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.SaveLiteral")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.ShowPlaceHolders")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.NullValuePrompt = resources.GetString("dtp_fecha_cierre.Properties.CalendarTimeProperties.NullValuePrompt");
            this.dtp_fecha_cierre.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.CalendarTimeProperties.NullValuePromptShowForEmptyVal" +
        "ue")));
            this.dtp_fecha_cierre.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.AutoComplete")));
            this.dtp_fecha_cierre.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.BeepOnError")));
            this.dtp_fecha_cierre.Properties.Mask.EditMask = resources.GetString("dtp_fecha_cierre.Properties.Mask.EditMask");
            this.dtp_fecha_cierre.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.IgnoreMaskBlank")));
            this.dtp_fecha_cierre.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.MaskType")));
            this.dtp_fecha_cierre.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.PlaceHolder")));
            this.dtp_fecha_cierre.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.SaveLiteral")));
            this.dtp_fecha_cierre.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.ShowPlaceHolders")));
            this.dtp_fecha_cierre.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtp_fecha_cierre.Properties.NullValuePrompt = resources.GetString("dtp_fecha_cierre.Properties.NullValuePrompt");
            this.dtp_fecha_cierre.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtp_fecha_cierre.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lbl_titulo
            // 
            resources.ApplyResources(this.lbl_titulo, "lbl_titulo");
            this.lbl_titulo.Name = "lbl_titulo";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // txt_titulo
            // 
            resources.ApplyResources(this.txt_titulo, "txt_titulo");
            this.txt_titulo.Name = "txt_titulo";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txt_detalles
            // 
            resources.ApplyResources(this.txt_detalles, "txt_detalles");
            this.txt_detalles.Name = "txt_detalles";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txt_valor
            // 
            resources.ApplyResources(this.txt_valor, "txt_valor");
            this.txt_valor.Name = "txt_valor";
            this.txt_valor.TextChanged += new System.EventHandler(this.txt_valor_TextChanged);
            this.txt_valor.Leave += new System.EventHandler(this.txt_valor_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btn_nueva
            // 
            resources.ApplyResources(this.btn_nueva, "btn_nueva");
            this.btn_nueva.Image = ((System.Drawing.Image)(resources.GetObject("btn_nueva.Image")));
            this.btn_nueva.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nueva.Name = "btn_nueva";
            this.btn_nueva.Click += new System.EventHandler(this.btn_nueva_Click);
            // 
            // btn_refesh_cat
            // 
            resources.ApplyResources(this.btn_refesh_cat, "btn_refesh_cat");
            this.btn_refesh_cat.Image = ((System.Drawing.Image)(resources.GetObject("btn_refesh_cat.Image")));
            this.btn_refesh_cat.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_refesh_cat.Name = "btn_refesh_cat";
            this.btn_refesh_cat.Click += new System.EventHandler(this.btn_refesh_cat_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btn_nuevo_emp
            // 
            resources.ApplyResources(this.btn_nuevo_emp, "btn_nuevo_emp");
            this.btn_nuevo_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo_emp.Image")));
            this.btn_nuevo_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nuevo_emp.Name = "btn_nuevo_emp";
            this.btn_nuevo_emp.Click += new System.EventHandler(this.btn_nuevo_emp_Click);
            // 
            // btn_actualizar_emp
            // 
            resources.ApplyResources(this.btn_actualizar_emp, "btn_actualizar_emp");
            this.btn_actualizar_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_emp.Image")));
            this.btn_actualizar_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_emp.Name = "btn_actualizar_emp";
            this.btn_actualizar_emp.Click += new System.EventHandler(this.btn_actualizar_emp_Click);
            // 
            // btn_nuevo_perem
            // 
            resources.ApplyResources(this.btn_nuevo_perem, "btn_nuevo_perem");
            this.btn_nuevo_perem.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo_perem.Image")));
            this.btn_nuevo_perem.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nuevo_perem.Name = "btn_nuevo_perem";
            this.btn_nuevo_perem.Click += new System.EventHandler(this.btn_nuevo_perem_Click);
            // 
            // btn_refresh_perem
            // 
            resources.ApplyResources(this.btn_refresh_perem, "btn_refresh_perem");
            this.btn_refresh_perem.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh_perem.Image")));
            this.btn_refresh_perem.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_refresh_perem.Name = "btn_refresh_perem";
            this.btn_refresh_perem.Click += new System.EventHandler(this.btn_refresh_perem_Click);
            // 
            // cbo_monedas
            // 
            resources.ApplyResources(this.cbo_monedas, "cbo_monedas");
            this.cbo_monedas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_monedas.FormattingEnabled = true;
            this.cbo_monedas.Name = "cbo_monedas";
            // 
            // btn_guardar
            // 
            resources.ApplyResources(this.btn_guardar, "btn_guardar");
            this.btn_guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar.Image")));
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // cbo_empleado
            // 
            resources.ApplyResources(this.cbo_empleado, "cbo_empleado");
            this.cbo_empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_empleado.FormattingEnabled = true;
            this.cbo_empleado.Name = "cbo_empleado";
            // 
            // cbo_cat
            // 
            resources.ApplyResources(this.cbo_cat, "cbo_cat");
            this.cbo_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_cat.FormattingEnabled = true;
            this.cbo_cat.Name = "cbo_cat";
            // 
            // btn_actualizar_mon
            // 
            resources.ApplyResources(this.btn_actualizar_mon, "btn_actualizar_mon");
            this.btn_actualizar_mon.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_mon.Image")));
            this.btn_actualizar_mon.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_mon.Name = "btn_actualizar_mon";
            this.btn_actualizar_mon.Click += new System.EventHandler(this.btn_actualizar_mon_Click);
            // 
            // btn_nueva_mon
            // 
            resources.ApplyResources(this.btn_nueva_mon, "btn_nueva_mon");
            this.btn_nueva_mon.Image = ((System.Drawing.Image)(resources.GetObject("btn_nueva_mon.Image")));
            this.btn_nueva_mon.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nueva_mon.Name = "btn_nueva_mon";
            this.btn_nueva_mon.Click += new System.EventHandler(this.btn_nueva_mon_Click);
            // 
            // cbo_perem
            // 
            resources.ApplyResources(this.cbo_perem, "cbo_perem");
            this.cbo_perem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_perem.FormattingEnabled = true;
            this.cbo_perem.Name = "cbo_perem";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // tb_etapa
            // 
            resources.ApplyResources(this.tb_etapa, "tb_etapa");
            this.tb_etapa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tb_etapa.Name = "tb_etapa";
            this.tb_etapa.Properties.AccessibleDescription = resources.GetString("tb_etapa.Properties.AccessibleDescription");
            this.tb_etapa.Properties.AccessibleName = resources.GetString("tb_etapa.Properties.AccessibleName");
            this.tb_etapa.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("tb_etapa.Properties.Appearance.BackColor")));
            this.tb_etapa.Properties.Appearance.BackColor2 = ((System.Drawing.Color)(resources.GetObject("tb_etapa.Properties.Appearance.BackColor2")));
            this.tb_etapa.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("tb_etapa.Properties.Appearance.FontSizeDelta")));
            this.tb_etapa.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tb_etapa.Properties.Appearance.FontStyleDelta")));
            this.tb_etapa.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tb_etapa.Properties.Appearance.GradientMode")));
            this.tb_etapa.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("tb_etapa.Properties.Appearance.Image")));
            this.tb_etapa.Properties.Appearance.Options.UseBackColor = true;
            this.tb_etapa.Properties.LabelAppearance.FontSizeDelta = ((int)(resources.GetObject("tb_etapa.Properties.LabelAppearance.FontSizeDelta")));
            this.tb_etapa.Properties.LabelAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("tb_etapa.Properties.LabelAppearance.FontStyleDelta")));
            this.tb_etapa.Properties.LabelAppearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("tb_etapa.Properties.LabelAppearance.ForeColor")));
            this.tb_etapa.Properties.LabelAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("tb_etapa.Properties.LabelAppearance.GradientMode")));
            this.tb_etapa.Properties.LabelAppearance.Image = ((System.Drawing.Image)(resources.GetObject("tb_etapa.Properties.LabelAppearance.Image")));
            this.tb_etapa.Properties.LabelAppearance.Options.UseForeColor = true;
            this.tb_etapa.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tb_etapa.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(trackBarLabel5, "trackBarLabel5");
            resources.ApplyResources(trackBarLabel6, "trackBarLabel6");
            trackBarLabel6.Value = 1;
            resources.ApplyResources(trackBarLabel7, "trackBarLabel7");
            trackBarLabel7.Value = 2;
            resources.ApplyResources(trackBarLabel8, "trackBarLabel8");
            trackBarLabel8.Value = 3;
            this.tb_etapa.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel5,
            trackBarLabel6,
            trackBarLabel7,
            trackBarLabel8});
            this.tb_etapa.Properties.Maximum = 3;
            this.tb_etapa.Properties.Orientation = ((System.Windows.Forms.Orientation)(resources.GetObject("tb_etapa.Properties.Orientation")));
            this.tb_etapa.Properties.ShowLabels = true;
            // 
            // FormNuevoNegocio
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "FormNuevoNegocio";
            this.Load += new System.EventHandler(this.FormNuevoNegocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_etapa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_etapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtp_fecha_cierre;
        private System.Windows.Forms.Label lbl_titulo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txt_titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txt_detalles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_valor;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btn_nueva;
        private DevExpress.XtraEditors.SimpleButton btn_refesh_cat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo_emp;
        private DevExpress.XtraEditors.SimpleButton btn_actualizar_emp;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo_perem;
        private DevExpress.XtraEditors.SimpleButton btn_refresh_perem;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TrackBarControl tb_etapa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cbo_perem;
        private DevExpress.XtraEditors.SimpleButton btn_actualizar_mon;
        private DevExpress.XtraEditors.SimpleButton btn_nueva_mon;
        private System.Windows.Forms.ComboBox cbo_empleado;
        private System.Windows.Forms.ComboBox cbo_cat;
        private System.Windows.Forms.ComboBox cbo_monedas;
        public DevExpress.XtraEditors.SimpleButton btn_guardar;
    }
}