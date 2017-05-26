namespace crm
{
    partial class frm_NuevoCaso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NuevoCaso));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbo_perem = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_reporte = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_ultimo = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_primero = new System.Windows.Forms.Button();
            this.btn_anterior = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_siguiente = new System.Windows.Forms.Button();
            this.cmb_responsable = new System.Windows.Forms.ComboBox();
            this.cmb_categoria = new System.Windows.Forms.ComboBox();
            this.cmb_ente = new System.Windows.Forms.ComboBox();
            this.btn_actualizar_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_actualizar_ente = new DevExpress.XtraEditors.SimpleButton();
            this.dtp_fecha_cierre = new DevExpress.XtraEditors.DateEdit();
            this.btn_nuevo_ente = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_nuevo_emp = new DevExpress.XtraEditors.SimpleButton();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_actualizar_cat = new DevExpress.XtraEditors.SimpleButton();
            this.txt_descripcion = new System.Windows.Forms.RichTextBox();
            this.btn_nueva_categoria = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.cbo_perem);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Controls.Add(this.cmb_responsable);
            this.groupControl1.Controls.Add(this.cmb_categoria);
            this.groupControl1.Controls.Add(this.cmb_ente);
            this.groupControl1.Controls.Add(this.btn_actualizar_emp);
            this.groupControl1.Controls.Add(this.btn_actualizar_ente);
            this.groupControl1.Controls.Add(this.dtp_fecha_cierre);
            this.groupControl1.Controls.Add(this.btn_nuevo_ente);
            this.groupControl1.Controls.Add(this.lbl_titulo);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btn_nuevo_emp);
            this.groupControl1.Controls.Add(this.txt_titulo);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btn_actualizar_cat);
            this.groupControl1.Controls.Add(this.txt_descripcion);
            this.groupControl1.Controls.Add(this.btn_nueva_categoria);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // cbo_perem
            // 
            resources.ApplyResources(this.cbo_perem, "cbo_perem");
            this.cbo_perem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_perem.FormattingEnabled = true;
            this.cbo_perem.Name = "cbo_perem";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btn_reporte);
            this.panel1.Controls.Add(this.btn_nuevo);
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.btn_ultimo);
            this.panel1.Controls.Add(this.btn_actualizar);
            this.panel1.Controls.Add(this.btn_guardar);
            this.panel1.Controls.Add(this.btn_buscar);
            this.panel1.Controls.Add(this.btn_primero);
            this.panel1.Controls.Add(this.btn_anterior);
            this.panel1.Controls.Add(this.btn_editar);
            this.panel1.Controls.Add(this.btn_eliminar);
            this.panel1.Controls.Add(this.btn_siguiente);
            this.panel1.Name = "panel1";
            // 
            // btn_reporte
            // 
            resources.ApplyResources(this.btn_reporte, "btn_reporte");
            this.btn_reporte.BackgroundImage = global::crm.Properties.Resources.imprimir1;
            this.btn_reporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reporte.FlatAppearance.BorderSize = 0;
            this.btn_reporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_reporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            resources.ApplyResources(this.btn_nuevo, "btn_nuevo");
            this.btn_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_cancelar
            // 
            resources.ApplyResources(this.btn_cancelar, "btn_cancelar");
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_ultimo
            // 
            resources.ApplyResources(this.btn_ultimo, "btn_ultimo");
            this.btn_ultimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ultimo.FlatAppearance.BorderSize = 0;
            this.btn_ultimo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ultimo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ultimo.Name = "btn_ultimo";
            this.btn_ultimo.UseVisualStyleBackColor = true;
            this.btn_ultimo.Click += new System.EventHandler(this.btn_ultimo_Click);
            // 
            // btn_actualizar
            // 
            resources.ApplyResources(this.btn_actualizar, "btn_actualizar");
            this.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_actualizar.FlatAppearance.BorderSize = 0;
            this.btn_actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_guardar
            // 
            resources.ApplyResources(this.btn_guardar, "btn_guardar");
            this.btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_buscar
            // 
            resources.ApplyResources(this.btn_buscar, "btn_buscar");
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            // 
            // btn_primero
            // 
            resources.ApplyResources(this.btn_primero, "btn_primero");
            this.btn_primero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_primero.FlatAppearance.BorderSize = 0;
            this.btn_primero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_primero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_primero.Name = "btn_primero";
            this.btn_primero.UseVisualStyleBackColor = true;
            // 
            // btn_anterior
            // 
            resources.ApplyResources(this.btn_anterior, "btn_anterior");
            this.btn_anterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_anterior.FlatAppearance.BorderSize = 0;
            this.btn_anterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_anterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.UseVisualStyleBackColor = true;
            this.btn_anterior.Click += new System.EventHandler(this.btn_anterior_Click);
            // 
            // btn_editar
            // 
            resources.ApplyResources(this.btn_editar, "btn_editar");
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.FlatAppearance.BorderSize = 0;
            this.btn_editar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_editar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            resources.ApplyResources(this.btn_eliminar, "btn_eliminar");
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.FlatAppearance.BorderSize = 0;
            this.btn_eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_eliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_siguiente
            // 
            resources.ApplyResources(this.btn_siguiente, "btn_siguiente");
            this.btn_siguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_siguiente.FlatAppearance.BorderSize = 0;
            this.btn_siguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_siguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.UseVisualStyleBackColor = true;
            this.btn_siguiente.Click += new System.EventHandler(this.btn_siguiente_Click);
            // 
            // cmb_responsable
            // 
            resources.ApplyResources(this.cmb_responsable, "cmb_responsable");
            this.cmb_responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_responsable.FormattingEnabled = true;
            this.cmb_responsable.Name = "cmb_responsable";
            // 
            // cmb_categoria
            // 
            resources.ApplyResources(this.cmb_categoria, "cmb_categoria");
            this.cmb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_categoria.FormattingEnabled = true;
            this.cmb_categoria.Name = "cmb_categoria";
            // 
            // cmb_ente
            // 
            resources.ApplyResources(this.cmb_ente, "cmb_ente");
            this.cmb_ente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ente.FormattingEnabled = true;
            this.cmb_ente.Items.AddRange(new object[] {
            resources.GetString("cmb_ente.Items"),
            resources.GetString("cmb_ente.Items1")});
            this.cmb_ente.Name = "cmb_ente";
            this.cmb_ente.SelectedIndexChanged += new System.EventHandler(this.cmb_ente_SelectedIndexChanged);
            // 
            // btn_actualizar_emp
            // 
            resources.ApplyResources(this.btn_actualizar_emp, "btn_actualizar_emp");
            this.btn_actualizar_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_emp.Image")));
            this.btn_actualizar_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_emp.Name = "btn_actualizar_emp";
            this.btn_actualizar_emp.Click += new System.EventHandler(this.btn_actualizar_emp_Click);
            // 
            // btn_actualizar_ente
            // 
            resources.ApplyResources(this.btn_actualizar_ente, "btn_actualizar_ente");
            this.btn_actualizar_ente.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_ente.Image")));
            this.btn_actualizar_ente.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_ente.Name = "btn_actualizar_ente";
            this.btn_actualizar_ente.Click += new System.EventHandler(this.btn_actualizar_ente_Click);
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
            // btn_nuevo_ente
            // 
            resources.ApplyResources(this.btn_nuevo_ente, "btn_nuevo_ente");
            this.btn_nuevo_ente.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo_ente.Image")));
            this.btn_nuevo_ente.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nuevo_ente.Name = "btn_nuevo_ente";
            this.btn_nuevo_ente.Click += new System.EventHandler(this.btn_nuevo_ente_Click);
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
            // btn_nuevo_emp
            // 
            resources.ApplyResources(this.btn_nuevo_emp, "btn_nuevo_emp");
            this.btn_nuevo_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_nuevo_emp.Image")));
            this.btn_nuevo_emp.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nuevo_emp.Name = "btn_nuevo_emp";
            this.btn_nuevo_emp.Click += new System.EventHandler(this.btn_nuevo_emp_Click);
            // 
            // txt_titulo
            // 
            resources.ApplyResources(this.txt_titulo, "txt_titulo");
            this.txt_titulo.ForeColor = System.Drawing.Color.Gray;
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_titulo_MouseClick);
            this.txt_titulo.TextChanged += new System.EventHandler(this.txt_titulo_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_actualizar_cat
            // 
            resources.ApplyResources(this.btn_actualizar_cat, "btn_actualizar_cat");
            this.btn_actualizar_cat.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar_cat.Image")));
            this.btn_actualizar_cat.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_actualizar_cat.Name = "btn_actualizar_cat";
            this.btn_actualizar_cat.Click += new System.EventHandler(this.btn_actualizar_cat_Click);
            // 
            // txt_descripcion
            // 
            resources.ApplyResources(this.txt_descripcion, "txt_descripcion");
            this.txt_descripcion.ForeColor = System.Drawing.Color.Gray;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_descripcion_MouseClick);
            this.txt_descripcion.TextChanged += new System.EventHandler(this.txt_descripcion_TextChanged);
            // 
            // btn_nueva_categoria
            // 
            resources.ApplyResources(this.btn_nueva_categoria, "btn_nueva_categoria");
            this.btn_nueva_categoria.Image = ((System.Drawing.Image)(resources.GetObject("btn_nueva_categoria.Image")));
            this.btn_nueva_categoria.ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
            this.btn_nueva_categoria.Name = "btn_nueva_categoria";
            this.btn_nueva_categoria.Click += new System.EventHandler(this.btn_nueva_categoria_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // frm_NuevoCaso
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_NuevoCaso";
            this.Load += new System.EventHandler(this.frm_NuevoCaso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha_cierre.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_responsable;
        private System.Windows.Forms.ComboBox cmb_categoria;
        private System.Windows.Forms.ComboBox cmb_ente;
        private DevExpress.XtraEditors.SimpleButton btn_actualizar_emp;
        private DevExpress.XtraEditors.SimpleButton btn_actualizar_ente;
        private DevExpress.XtraEditors.DateEdit dtp_fecha_cierre;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo_ente;
        private System.Windows.Forms.Label lbl_titulo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo_emp;
        private System.Windows.Forms.TextBox txt_titulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_actualizar_cat;
        private System.Windows.Forms.RichTextBox txt_descripcion;
        private DevExpress.XtraEditors.SimpleButton btn_nueva_categoria;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_reporte;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_ultimo;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_primero;
        private System.Windows.Forms.Button btn_anterior;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_siguiente;
        private System.Windows.Forms.ComboBox cbo_perem;
    }
}