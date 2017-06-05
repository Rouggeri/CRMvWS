namespace proyectoUOne
{
    partial class BuscarProducto
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
            this.dgv_productosVista = new System.Windows.Forms.DataGridView();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.txt_buscarP = new System.Windows.Forms.TextBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ratos = new System.Windows.Forms.TextBox();
            this.cmb_existencia = new System.Windows.Forms.ComboBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_marca = new System.Windows.Forms.TextBox();
            this.btn_prueba = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productosVista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_productosVista
            // 
            this.dgv_productosVista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_productosVista.Location = new System.Drawing.Point(25, 107);
            this.dgv_productosVista.Name = "dgv_productosVista";
            this.dgv_productosVista.Size = new System.Drawing.Size(326, 320);
            this.dgv_productosVista.TabIndex = 1;
            this.dgv_productosVista.CurrentCellChanged += new System.EventHandler(this.dgv_productosVista_CurrentCellChanged);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(127, 433);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 2;
            this.btn_agregar.Text = "Agrega";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // txt_buscarP
            // 
            this.txt_buscarP.Location = new System.Drawing.Point(38, 30);
            this.txt_buscarP.Name = "txt_buscarP";
            this.txt_buscarP.Size = new System.Drawing.Size(150, 20);
            this.txt_buscarP.TabIndex = 3;
            this.txt_buscarP.TextChanged += new System.EventHandler(this.txt_buscarP_TextChanged);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(236, 54);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(113, 20);
            this.txt_cantidad.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codigo o Descripcion Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cantidad de Producto";
            // 
            // txt_ratos
            // 
            this.txt_ratos.Location = new System.Drawing.Point(194, 30);
            this.txt_ratos.Name = "txt_ratos";
            this.txt_ratos.Size = new System.Drawing.Size(23, 20);
            this.txt_ratos.TabIndex = 7;
            this.txt_ratos.Visible = false;
            // 
            // cmb_existencia
            // 
            this.cmb_existencia.Enabled = false;
            this.cmb_existencia.FormattingEnabled = true;
            this.cmb_existencia.Location = new System.Drawing.Point(109, 54);
            this.cmb_existencia.Name = "cmb_existencia";
            this.cmb_existencia.Size = new System.Drawing.Size(121, 21);
            this.cmb_existencia.TabIndex = 8;
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(109, 81);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(27, 20);
            this.txt_codigo.TabIndex = 9;
            this.txt_codigo.Visible = false;
            // 
            // txt_marca
            // 
            this.txt_marca.Location = new System.Drawing.Point(142, 81);
            this.txt_marca.Name = "txt_marca";
            this.txt_marca.Size = new System.Drawing.Size(25, 20);
            this.txt_marca.TabIndex = 10;
            this.txt_marca.Visible = false;
            // 
            // btn_prueba
            // 
            this.btn_prueba.Location = new System.Drawing.Point(38, 54);
            this.btn_prueba.Name = "btn_prueba";
            this.btn_prueba.Size = new System.Drawing.Size(65, 23);
            this.btn_prueba.TabIndex = 11;
            this.btn_prueba.Text = "Existencia";
            this.btn_prueba.UseVisualStyleBackColor = true;
            this.btn_prueba.Click += new System.EventHandler(this.btn_prueba_Click);
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 478);
            this.Controls.Add(this.btn_prueba);
            this.Controls.Add(this.txt_marca);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.cmb_existencia);
            this.Controls.Add(this.txt_ratos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.txt_buscarP);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.dgv_productosVista);
            this.Name = "BuscarProducto";
            this.Text = "BuscarProducto";
            this.Load += new System.EventHandler(this.BuscarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_productosVista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.TextBox txt_buscarP;
        public System.Windows.Forms.TextBox txt_cantidad;
        public System.Windows.Forms.DataGridView dgv_productosVista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_ratos;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_marca;
        private System.Windows.Forms.Button btn_prueba;
        public System.Windows.Forms.ComboBox cmb_existencia;
    }
}