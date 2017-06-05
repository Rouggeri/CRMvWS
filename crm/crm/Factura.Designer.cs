namespace proyectoUOne
{
    partial class Factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_facturaDetalle = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_nit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmb_pago = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.txt_temporal = new System.Windows.Forms.TextBox();
            this.cmb_prueba = new System.Windows.Forms.ComboBox();
            this.cmb_cotizaciones = new System.Windows.Forms.ComboBox();
            this.chb_habilita = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_agregarProducto = new System.Windows.Forms.Button();
            this.txt_tipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_empleado = new System.Windows.Forms.ComboBox();
            this.ClienteControl = new DevExpress.XtraEditors.GroupControl();
            this.txt_motrarID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_producto = new System.Windows.Forms.ComboBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.ProductoControl = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_marca = new System.Windows.Forms.ComboBox();
            this.txt_precioUnidad = new System.Windows.Forms.TextBox();
            this.txt_existencia = new System.Windows.Forms.TextBox();
            this.cmb_bodega = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.controlCotizacion = new DevExpress.XtraEditors.GroupControl();
            this.btn_verifica = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturaDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteControl)).BeginInit();
            this.ClienteControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoControl)).BeginInit();
            this.ProductoControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlCotizacion)).BeginInit();
            this.controlCotizacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(365, 64);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(101, 21);
            this.txt_total.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Total:";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(259, 49);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(160, 21);
            this.dtp_fecha.TabIndex = 29;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(362, 27);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.ReadOnly = true;
            this.txt_apellido.Size = new System.Drawing.Size(91, 21);
            this.txt_apellido.TabIndex = 27;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(259, 27);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ReadOnly = true;
            this.txt_nombre.Size = new System.Drawing.Size(101, 21);
            this.txt_nombre.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nombres";
            // 
            // dgv_facturaDetalle
            // 
            this.dgv_facturaDetalle.AllowUserToAddRows = false;
            this.dgv_facturaDetalle.AllowUserToOrderColumns = true;
            this.dgv_facturaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_facturaDetalle.Location = new System.Drawing.Point(12, 285);
            this.dgv_facturaDetalle.Name = "dgv_facturaDetalle";
            this.dgv_facturaDetalle.Size = new System.Drawing.Size(610, 207);
            this.dgv_facturaDetalle.TabIndex = 21;
            this.dgv_facturaDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_facturaDetalle_CellContentClick);
            this.dgv_facturaDetalle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_facturaDetalle_CellMouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(459, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "NIT";
            // 
            // txt_nit
            // 
            this.txt_nit.Location = new System.Drawing.Point(489, 27);
            this.txt_nit.Name = "txt_nit";
            this.txt_nit.ReadOnly = true;
            this.txt_nit.Size = new System.Drawing.Size(107, 21);
            this.txt_nit.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Buscar Cotizacion";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(424, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Pago:";
            // 
            // cmb_pago
            // 
            this.cmb_pago.DisplayMember = "Seleccione:::";
            this.cmb_pago.FormattingEnabled = true;
            this.cmb_pago.Location = new System.Drawing.Point(462, 49);
            this.cmb_pago.Name = "cmb_pago";
            this.cmb_pago.Size = new System.Drawing.Size(87, 21);
            this.cmb_pago.TabIndex = 50;
            this.cmb_pago.ValueMember = "Seleccione:::";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_nuevo);
            this.panel2.Controls.Add(this.btn_cancelar);
            this.panel2.Controls.Add(this.btn_ultimo);
            this.panel2.Controls.Add(this.btn_actualizar);
            this.panel2.Controls.Add(this.btn_guardar);
            this.panel2.Controls.Add(this.btn_buscar);
            this.panel2.Controls.Add(this.btn_primero);
            this.panel2.Controls.Add(this.btn_anterior);
            this.panel2.Controls.Add(this.btn_editar);
            this.panel2.Controls.Add(this.btn_eliminar);
            this.panel2.Controls.Add(this.btn_siguiente);
            this.panel2.Location = new System.Drawing.Point(13, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 77);
            this.panel2.TabIndex = 190;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_nuevo.BackgroundImage")));
            this.btn_nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nuevo.FlatAppearance.BorderSize = 0;
            this.btn_nuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_nuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevo.Location = new System.Drawing.Point(29, 4);
            this.btn_nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(58, 59);
            this.btn_nuevo.TabIndex = 4;
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.BackgroundImage")));
            this.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancelar.FlatAppearance.BorderSize = 0;
            this.btn_cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Location = new System.Drawing.Point(334, 4);
            this.btn_cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(56, 59);
            this.btn_cancelar.TabIndex = 176;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_ultimo
            // 
            this.btn_ultimo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ultimo.BackgroundImage")));
            this.btn_ultimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ultimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ultimo.FlatAppearance.BorderSize = 0;
            this.btn_ultimo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_ultimo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_ultimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ultimo.Location = new System.Drawing.Point(503, 37);
            this.btn_ultimo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ultimo.Name = "btn_ultimo";
            this.btn_ultimo.Size = new System.Drawing.Size(30, 26);
            this.btn_ultimo.TabIndex = 181;
            this.btn_ultimo.UseVisualStyleBackColor = true;
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_actualizar.BackgroundImage")));
            this.btn_actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_actualizar.FlatAppearance.BorderSize = 0;
            this.btn_actualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_actualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_actualizar.Location = new System.Drawing.Point(391, 4);
            this.btn_actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(56, 59);
            this.btn_actualizar.TabIndex = 177;
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_guardar.BackgroundImage")));
            this.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardar.FlatAppearance.BorderSize = 0;
            this.btn_guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_guardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar.Location = new System.Drawing.Point(95, 3);
            this.btn_guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(58, 59);
            this.btn_guardar.TabIndex = 3;
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buscar.BackgroundImage")));
            this.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Location = new System.Drawing.Point(275, 4);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(58, 59);
            this.btn_buscar.TabIndex = 175;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_primero
            // 
            this.btn_primero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_primero.BackgroundImage")));
            this.btn_primero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_primero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_primero.FlatAppearance.BorderSize = 0;
            this.btn_primero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_primero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_primero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_primero.Location = new System.Drawing.Point(465, 37);
            this.btn_primero.Margin = new System.Windows.Forms.Padding(4);
            this.btn_primero.Name = "btn_primero";
            this.btn_primero.Size = new System.Drawing.Size(30, 26);
            this.btn_primero.TabIndex = 180;
            this.btn_primero.UseVisualStyleBackColor = true;
            // 
            // btn_anterior
            // 
            this.btn_anterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_anterior.BackgroundImage")));
            this.btn_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_anterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_anterior.FlatAppearance.BorderSize = 0;
            this.btn_anterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_anterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_anterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_anterior.Location = new System.Drawing.Point(465, 4);
            this.btn_anterior.Margin = new System.Windows.Forms.Padding(4);
            this.btn_anterior.Name = "btn_anterior";
            this.btn_anterior.Size = new System.Drawing.Size(30, 26);
            this.btn_anterior.TabIndex = 178;
            this.btn_anterior.UseVisualStyleBackColor = true;
            // 
            // btn_editar
            // 
            this.btn_editar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_editar.BackgroundImage")));
            this.btn_editar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_editar.FlatAppearance.BorderSize = 0;
            this.btn_editar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_editar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Location = new System.Drawing.Point(157, 4);
            this.btn_editar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(58, 59);
            this.btn_editar.TabIndex = 5;
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.BackgroundImage")));
            this.btn_eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.FlatAppearance.BorderSize = 0;
            this.btn_eliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_eliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Location = new System.Drawing.Point(216, 4);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(58, 59);
            this.btn_eliminar.TabIndex = 6;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_siguiente
            // 
            this.btn_siguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_siguiente.BackgroundImage")));
            this.btn_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_siguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_siguiente.FlatAppearance.BorderSize = 0;
            this.btn_siguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_siguiente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_siguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_siguiente.Location = new System.Drawing.Point(503, 3);
            this.btn_siguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_siguiente.Name = "btn_siguiente";
            this.btn_siguiente.Size = new System.Drawing.Size(30, 26);
            this.btn_siguiente.TabIndex = 179;
            this.btn_siguiente.UseVisualStyleBackColor = true;
            // 
            // txt_temporal
            // 
            this.txt_temporal.Location = new System.Drawing.Point(551, 49);
            this.txt_temporal.Name = "txt_temporal";
            this.txt_temporal.Size = new System.Drawing.Size(10, 21);
            this.txt_temporal.TabIndex = 192;
            this.txt_temporal.Visible = false;
            // 
            // cmb_prueba
            // 
            this.cmb_prueba.FormattingEnabled = true;
            this.cmb_prueba.Location = new System.Drawing.Point(562, 49);
            this.cmb_prueba.Name = "cmb_prueba";
            this.cmb_prueba.Size = new System.Drawing.Size(19, 21);
            this.cmb_prueba.TabIndex = 193;
            this.cmb_prueba.Visible = false;
            // 
            // cmb_cotizaciones
            // 
            this.cmb_cotizaciones.DisplayMember = "ninguno";
            this.cmb_cotizaciones.FormattingEnabled = true;
            this.cmb_cotizaciones.Items.AddRange(new object[] {
            "Ninguno..."});
            this.cmb_cotizaciones.Location = new System.Drawing.Point(13, 42);
            this.cmb_cotizaciones.Name = "cmb_cotizaciones";
            this.cmb_cotizaciones.Size = new System.Drawing.Size(100, 21);
            this.cmb_cotizaciones.TabIndex = 194;
            this.cmb_cotizaciones.ValueMember = "ninguno";
            this.cmb_cotizaciones.SelectedIndexChanged += new System.EventHandler(this.cmb_cotizaciones_SelectedIndexChanged);
            this.cmb_cotizaciones.DataSourceChanged += new System.EventHandler(this.cmb_cotizaciones_DataSourceChanged);
            // 
            // chb_habilita
            // 
            this.chb_habilita.AutoSize = true;
            this.chb_habilita.Location = new System.Drawing.Point(184, 30);
            this.chb_habilita.Name = "chb_habilita";
            this.chb_habilita.Size = new System.Drawing.Size(15, 14);
            this.chb_habilita.TabIndex = 197;
            this.chb_habilita.UseVisualStyleBackColor = true;
            this.chb_habilita.CheckedChanged += new System.EventHandler(this.chb_habilita_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 204;
            this.label2.Text = "Codigo";
            // 
            // btn_agregarProducto
            // 
            this.btn_agregarProducto.Location = new System.Drawing.Point(297, 64);
            this.btn_agregarProducto.Name = "btn_agregarProducto";
            this.btn_agregarProducto.Size = new System.Drawing.Size(36, 23);
            this.btn_agregarProducto.TabIndex = 205;
            this.btn_agregarProducto.Text = "Add Prod";
            this.btn_agregarProducto.UseVisualStyleBackColor = true;
            this.btn_agregarProducto.Click += new System.EventHandler(this.btn_agregarProducto_Click);
            // 
            // txt_tipo
            // 
            this.txt_tipo.Location = new System.Drawing.Point(583, 49);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(12, 21);
            this.txt_tipo.TabIndex = 206;
            this.txt_tipo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Empleado";
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.DisplayMember = "Seleccione:::";
            this.cmb_empleado.FormattingEnabled = true;
            this.cmb_empleado.Location = new System.Drawing.Point(62, 26);
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.Size = new System.Drawing.Size(116, 21);
            this.cmb_empleado.TabIndex = 208;
            this.cmb_empleado.ValueMember = "Seleccione:::";
            // 
            // ClienteControl
            // 
            this.ClienteControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClienteControl.Appearance.Options.UseBackColor = true;
            this.ClienteControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteControl.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.ClienteControl.AppearanceCaption.Options.UseFont = true;
            this.ClienteControl.AppearanceCaption.Options.UseForeColor = true;
            this.ClienteControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ClienteControl.CaptionImageUri.Uri = "ListBullets";
            this.ClienteControl.Controls.Add(this.chb_habilita);
            this.ClienteControl.Controls.Add(this.label5);
            this.ClienteControl.Controls.Add(this.cmb_empleado);
            this.ClienteControl.Controls.Add(this.cmb_prueba);
            this.ClienteControl.Controls.Add(this.txt_temporal);
            this.ClienteControl.Controls.Add(this.cmb_bodega);
            this.ClienteControl.Controls.Add(this.txt_tipo);
            this.ClienteControl.Controls.Add(this.label4);
            this.ClienteControl.Controls.Add(this.cmb_pago);
            this.ClienteControl.Controls.Add(this.label14);
            this.ClienteControl.Controls.Add(this.label1);
            this.ClienteControl.Controls.Add(this.txt_nombre);
            this.ClienteControl.Controls.Add(this.txt_apellido);
            this.ClienteControl.Controls.Add(this.label11);
            this.ClienteControl.Controls.Add(this.txt_nit);
            this.ClienteControl.Controls.Add(this.dtp_fecha);
            this.ClienteControl.Controls.Add(this.label3);
            this.ClienteControl.Location = new System.Drawing.Point(12, 87);
            this.ClienteControl.Name = "ClienteControl";
            this.ClienteControl.Size = new System.Drawing.Size(610, 84);
            this.ClienteControl.TabIndex = 209;
            this.ClienteControl.Text = "Client Data";
            this.ClienteControl.Paint += new System.Windows.Forms.PaintEventHandler(this.ClienteData_Paint);
            // 
            // txt_motrarID
            // 
            this.txt_motrarID.AutoSize = true;
            this.txt_motrarID.Location = new System.Drawing.Point(435, 26);
            this.txt_motrarID.Name = "txt_motrarID";
            this.txt_motrarID.Size = new System.Drawing.Size(31, 13);
            this.txt_motrarID.TabIndex = 209;
            this.txt_motrarID.Text = ":::...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 212;
            this.label7.Text = "Producto";
            // 
            // cmb_producto
            // 
            this.cmb_producto.FormattingEnabled = true;
            this.cmb_producto.Location = new System.Drawing.Point(53, 66);
            this.cmb_producto.Name = "cmb_producto";
            this.cmb_producto.Size = new System.Drawing.Size(121, 21);
            this.cmb_producto.TabIndex = 211;
            this.cmb_producto.SelectedIndexChanged += new System.EventHandler(this.cmb_producto_SelectedIndexChanged);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(5, 66);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.ReadOnly = true;
            this.txt_codigo.Size = new System.Drawing.Size(43, 21);
            this.txt_codigo.TabIndex = 210;
            // 
            // ProductoControl
            // 
            this.ProductoControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ProductoControl.Appearance.Options.UseBackColor = true;
            this.ProductoControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductoControl.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.ProductoControl.AppearanceCaption.Options.UseFont = true;
            this.ProductoControl.AppearanceCaption.Options.UseForeColor = true;
            this.ProductoControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ProductoControl.CaptionImageUri.Uri = "ListBullets";
            this.ProductoControl.Controls.Add(this.label15);
            this.ProductoControl.Controls.Add(this.label13);
            this.ProductoControl.Controls.Add(this.label10);
            this.ProductoControl.Controls.Add(this.label9);
            this.ProductoControl.Controls.Add(this.label6);
            this.ProductoControl.Controls.Add(this.txt_motrarID);
            this.ProductoControl.Controls.Add(this.cmb_marca);
            this.ProductoControl.Controls.Add(this.txt_precioUnidad);
            this.ProductoControl.Controls.Add(this.txt_existencia);
            this.ProductoControl.Controls.Add(this.txt_cantidad);
            this.ProductoControl.Controls.Add(this.label7);
            this.ProductoControl.Controls.Add(this.cmb_producto);
            this.ProductoControl.Controls.Add(this.label2);
            this.ProductoControl.Controls.Add(this.txt_codigo);
            this.ProductoControl.Controls.Add(this.txt_total);
            this.ProductoControl.Controls.Add(this.btn_agregarProducto);
            this.ProductoControl.Controls.Add(this.label8);
            this.ProductoControl.Location = new System.Drawing.Point(142, 177);
            this.ProductoControl.Name = "ProductoControl";
            this.ProductoControl.Size = new System.Drawing.Size(480, 96);
            this.ProductoControl.TabIndex = 213;
            this.ProductoControl.Text = "Producto Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 219;
            this.label6.Text = "Factura NO:";
            // 
            // cmb_marca
            // 
            this.cmb_marca.FormattingEnabled = true;
            this.cmb_marca.Location = new System.Drawing.Point(177, 66);
            this.cmb_marca.Name = "cmb_marca";
            this.cmb_marca.Size = new System.Drawing.Size(65, 21);
            this.cmb_marca.TabIndex = 218;
            // 
            // txt_precioUnidad
            // 
            this.txt_precioUnidad.Location = new System.Drawing.Point(182, 23);
            this.txt_precioUnidad.Name = "txt_precioUnidad";
            this.txt_precioUnidad.ReadOnly = true;
            this.txt_precioUnidad.Size = new System.Drawing.Size(54, 21);
            this.txt_precioUnidad.TabIndex = 217;
            // 
            // txt_existencia
            // 
            this.txt_existencia.Location = new System.Drawing.Point(69, 23);
            this.txt_existencia.Name = "txt_existencia";
            this.txt_existencia.ReadOnly = true;
            this.txt_existencia.Size = new System.Drawing.Size(44, 21);
            this.txt_existencia.TabIndex = 216;
            // 
            // cmb_bodega
            // 
            this.cmb_bodega.FormattingEnabled = true;
            this.cmb_bodega.Location = new System.Drawing.Point(62, 52);
            this.cmb_bodega.Name = "cmb_bodega";
            this.cmb_bodega.Size = new System.Drawing.Size(121, 21);
            this.cmb_bodega.TabIndex = 215;
            this.cmb_bodega.SelectedIndexChanged += new System.EventHandler(this.cmb_bodega_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 214;
            this.label4.Text = "Bodega";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(248, 66);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(41, 21);
            this.txt_cantidad.TabIndex = 213;
            // 
            // controlCotizacion
            // 
            this.controlCotizacion.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.controlCotizacion.Appearance.Options.UseBackColor = true;
            this.controlCotizacion.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlCotizacion.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.controlCotizacion.AppearanceCaption.Options.UseFont = true;
            this.controlCotizacion.AppearanceCaption.Options.UseForeColor = true;
            this.controlCotizacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.controlCotizacion.CaptionImageUri.Uri = "ListBullets";
            this.controlCotizacion.Controls.Add(this.btn_verifica);
            this.controlCotizacion.Controls.Add(this.cmb_cotizaciones);
            this.controlCotizacion.Controls.Add(this.label12);
            this.controlCotizacion.Location = new System.Drawing.Point(12, 177);
            this.controlCotizacion.Name = "controlCotizacion";
            this.controlCotizacion.Size = new System.Drawing.Size(124, 96);
            this.controlCotizacion.TabIndex = 214;
            this.controlCotizacion.Text = "Cotizacion";
            // 
            // btn_verifica
            // 
            this.btn_verifica.Location = new System.Drawing.Point(22, 67);
            this.btn_verifica.Name = "btn_verifica";
            this.btn_verifica.Size = new System.Drawing.Size(75, 23);
            this.btn_verifica.TabIndex = 215;
            this.btn_verifica.Text = "Verificar";
            this.btn_verifica.UseVisualStyleBackColor = true;
            this.btn_verifica.Click += new System.EventHandler(this.btn_verifica_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 220;
            this.label9.Text = "Existencia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 221;
            this.label10.Text = "precio C/U";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(186, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 222;
            this.label13.Text = "Marca";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(241, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 223;
            this.label15.Text = "Cantidad";
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(647, 512);
            this.Controls.Add(this.controlCotizacion);
            this.Controls.Add(this.ProductoControl);
            this.Controls.Add(this.ClienteControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_facturaDetalle);
            this.Name = "Factura";
            this.Text = "Factura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturaDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClienteControl)).EndInit();
            this.ClienteControl.ResumeLayout(false);
            this.ClienteControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoControl)).EndInit();
            this.ProductoControl.ResumeLayout(false);
            this.ProductoControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlCotizacion)).EndInit();
            this.controlCotizacion.ResumeLayout(false);
            this.controlCotizacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmb_pago;
        private System.Windows.Forms.Panel panel2;
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
        public System.Windows.Forms.TextBox txt_apellido;
        public System.Windows.Forms.TextBox txt_nombre;
        public System.Windows.Forms.TextBox txt_nit;
        public System.Windows.Forms.TextBox txt_temporal;
        private System.Windows.Forms.ComboBox cmb_prueba;
        public System.Windows.Forms.ComboBox cmb_cotizaciones;
        private System.Windows.Forms.CheckBox chb_habilita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_agregarProducto;
        public System.Windows.Forms.DataGridView dgv_facturaDetalle;
        public System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_empleado;
        public System.Windows.Forms.TextBox txt_tipo;
        private DevExpress.XtraEditors.GroupControl ClienteControl;
        private System.Windows.Forms.Label txt_motrarID;
        private System.Windows.Forms.ComboBox cmb_producto;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.GroupControl ProductoControl;
        private DevExpress.XtraEditors.GroupControl controlCotizacion;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.TextBox txt_existencia;
        private System.Windows.Forms.ComboBox cmb_bodega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_precioUnidad;
        private System.Windows.Forms.ComboBox cmb_marca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_verifica;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}