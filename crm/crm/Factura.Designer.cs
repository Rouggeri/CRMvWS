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
            this.label4 = new System.Windows.Forms.Label();
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
            this.btn_buscarCliente = new System.Windows.Forms.Button();
            this.txt_temporal = new System.Windows.Forms.TextBox();
            this.cmb_prueba = new System.Windows.Forms.ComboBox();
            this.cmb_cotizaciones = new System.Windows.Forms.ComboBox();
            this.chb_habilita = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_agregarProducto = new System.Windows.Forms.Button();
            this.txt_tipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_empleado = new System.Windows.Forms.ComboBox();
            this.ClienteData = new DevExpress.XtraEditors.GroupControl();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturaDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteData)).BeginInit();
            this.ClienteData.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(100, 107);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(131, 21);
            this.txt_total.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Total:";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(404, 107);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(188, 21);
            this.dtp_fecha.TabIndex = 29;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(404, 54);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.ReadOnly = true;
            this.txt_apellido.Size = new System.Drawing.Size(188, 21);
            this.txt_apellido.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Apellidos";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(391, 29);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ReadOnly = true;
            this.txt_nombre.Size = new System.Drawing.Size(181, 21);
            this.txt_nombre.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 35);
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
            this.dgv_facturaDetalle.Location = new System.Drawing.Point(29, 256);
            this.dgv_facturaDetalle.Name = "dgv_facturaDetalle";
            this.dgv_facturaDetalle.Size = new System.Drawing.Size(630, 243);
            this.dgv_facturaDetalle.TabIndex = 21;
            this.dgv_facturaDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_facturaDetalle_CellContentClick);
            this.dgv_facturaDetalle.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_facturaDetalle_CellMouseDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(331, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "NIT";
            // 
            // txt_nit
            // 
            this.txt_nit.Location = new System.Drawing.Point(391, 80);
            this.txt_nit.Name = "txt_nit";
            this.txt_nit.ReadOnly = true;
            this.txt_nit.Size = new System.Drawing.Size(183, 21);
            this.txt_nit.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Buscar Cotizacion";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Pago:";
            // 
            // cmb_pago
            // 
            this.cmb_pago.DisplayMember = "Seleccione:::";
            this.cmb_pago.FormattingEnabled = true;
            this.cmb_pago.Location = new System.Drawing.Point(397, 132);
            this.cmb_pago.Name = "cmb_pago";
            this.cmb_pago.Size = new System.Drawing.Size(154, 21);
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
            this.panel2.Location = new System.Drawing.Point(29, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 77);
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
            // btn_buscarCliente
            // 
            this.btn_buscarCliente.Location = new System.Drawing.Point(100, 54);
            this.btn_buscarCliente.Name = "btn_buscarCliente";
            this.btn_buscarCliente.Size = new System.Drawing.Size(100, 23);
            this.btn_buscarCliente.TabIndex = 191;
            this.btn_buscarCliente.Text = "buscar::";
            this.btn_buscarCliente.UseVisualStyleBackColor = true;
            this.btn_buscarCliente.Click += new System.EventHandler(this.btn_buscarCliente_Click);
            // 
            // txt_temporal
            // 
            this.txt_temporal.Location = new System.Drawing.Point(557, 132);
            this.txt_temporal.Name = "txt_temporal";
            this.txt_temporal.Size = new System.Drawing.Size(10, 21);
            this.txt_temporal.TabIndex = 192;
            this.txt_temporal.Visible = false;
            // 
            // cmb_prueba
            // 
            this.cmb_prueba.FormattingEnabled = true;
            this.cmb_prueba.Location = new System.Drawing.Point(573, 131);
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
            this.cmb_cotizaciones.Location = new System.Drawing.Point(100, 27);
            this.cmb_cotizaciones.Name = "cmb_cotizaciones";
            this.cmb_cotizaciones.Size = new System.Drawing.Size(137, 21);
            this.cmb_cotizaciones.TabIndex = 194;
            this.cmb_cotizaciones.ValueMember = "ninguno";
            this.cmb_cotizaciones.SelectedIndexChanged += new System.EventHandler(this.cmb_cotizaciones_SelectedIndexChanged);
            this.cmb_cotizaciones.DataSourceChanged += new System.EventHandler(this.cmb_cotizaciones_DataSourceChanged);
            // 
            // chb_habilita
            // 
            this.chb_habilita.AutoSize = true;
            this.chb_habilita.Location = new System.Drawing.Point(244, 32);
            this.chb_habilita.Name = "chb_habilita";
            this.chb_habilita.Size = new System.Drawing.Size(15, 14);
            this.chb_habilita.TabIndex = 197;
            this.chb_habilita.UseVisualStyleBackColor = true;
            this.chb_habilita.CheckedChanged += new System.EventHandler(this.chb_habilita_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 204;
            this.label2.Text = "Agregar Producto:";
            // 
            // btn_agregarProducto
            // 
            this.btn_agregarProducto.Location = new System.Drawing.Point(125, 130);
            this.btn_agregarProducto.Name = "btn_agregarProducto";
            this.btn_agregarProducto.Size = new System.Drawing.Size(75, 23);
            this.btn_agregarProducto.TabIndex = 205;
            this.btn_agregarProducto.Text = "Add Prod";
            this.btn_agregarProducto.UseVisualStyleBackColor = true;
            this.btn_agregarProducto.Click += new System.EventHandler(this.btn_agregarProducto_Click);
            // 
            // txt_tipo
            // 
            this.txt_tipo.Location = new System.Drawing.Point(580, 81);
            this.txt_tipo.Name = "txt_tipo";
            this.txt_tipo.Size = new System.Drawing.Size(12, 21);
            this.txt_tipo.TabIndex = 206;
            this.txt_tipo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Empleado Vendedor";
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.DisplayMember = "Seleccione:::";
            this.cmb_empleado.FormattingEnabled = true;
            this.cmb_empleado.Location = new System.Drawing.Point(113, 81);
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.Size = new System.Drawing.Size(154, 21);
            this.cmb_empleado.TabIndex = 208;
            this.cmb_empleado.ValueMember = "Seleccione:::";
            // 
            // ClienteData
            // 
            this.ClienteData.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClienteData.Appearance.Options.UseBackColor = true;
            this.ClienteData.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClienteData.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.ClienteData.AppearanceCaption.Options.UseFont = true;
            this.ClienteData.AppearanceCaption.Options.UseForeColor = true;
            this.ClienteData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ClienteData.CaptionImageUri.Uri = "ListBullets";
            this.ClienteData.Controls.Add(this.label6);
            this.ClienteData.Controls.Add(this.btn_agregarProducto);
            this.ClienteData.Controls.Add(this.label5);
            this.ClienteData.Controls.Add(this.label2);
            this.ClienteData.Controls.Add(this.cmb_empleado);
            this.ClienteData.Controls.Add(this.txt_total);
            this.ClienteData.Controls.Add(this.cmb_prueba);
            this.ClienteData.Controls.Add(this.label8);
            this.ClienteData.Controls.Add(this.txt_temporal);
            this.ClienteData.Controls.Add(this.label12);
            this.ClienteData.Controls.Add(this.cmb_cotizaciones);
            this.ClienteData.Controls.Add(this.txt_tipo);
            this.ClienteData.Controls.Add(this.cmb_pago);
            this.ClienteData.Controls.Add(this.chb_habilita);
            this.ClienteData.Controls.Add(this.label14);
            this.ClienteData.Controls.Add(this.btn_buscarCliente);
            this.ClienteData.Controls.Add(this.label1);
            this.ClienteData.Controls.Add(this.txt_nombre);
            this.ClienteData.Controls.Add(this.label4);
            this.ClienteData.Controls.Add(this.txt_apellido);
            this.ClienteData.Controls.Add(this.label11);
            this.ClienteData.Controls.Add(this.txt_nit);
            this.ClienteData.Controls.Add(this.dtp_fecha);
            this.ClienteData.Controls.Add(this.label3);
            this.ClienteData.Location = new System.Drawing.Point(29, 87);
            this.ClienteData.Name = "ClienteData";
            this.ClienteData.Size = new System.Drawing.Size(630, 163);
            this.ClienteData.TabIndex = 209;
            this.ClienteData.Text = "Client Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 198;
            this.label6.Text = "Buscar Cliente";
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(694, 512);
            this.Controls.Add(this.ClienteData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_facturaDetalle);
            this.Name = "Factura";
            this.Text = "Factura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturaDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClienteData)).EndInit();
            this.ClienteData.ResumeLayout(false);
            this.ClienteData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.Button btn_buscarCliente;
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
        private DevExpress.XtraEditors.GroupControl ClienteData;
        private System.Windows.Forms.Label label6;
    }
}