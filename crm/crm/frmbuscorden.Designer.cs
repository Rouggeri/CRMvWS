namespace crm
{
    partial class frmbuscorden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbuscorden));
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bien = new System.Windows.Forms.TextBox();
            this.btn_buscbien = new System.Windows.Forms.Button();
            this.dgv_bien = new System.Windows.Forms.DataGridView();
            this.btn_agregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bien)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nombre:";
            // 
            // txt_bien
            // 
            this.txt_bien.Location = new System.Drawing.Point(198, 97);
            this.txt_bien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_bien.Name = "txt_bien";
            this.txt_bien.Size = new System.Drawing.Size(296, 26);
            this.txt_bien.TabIndex = 23;
            // 
            // btn_buscbien
            // 
            this.btn_buscbien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buscbien.BackgroundImage")));
            this.btn_buscbien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscbien.Location = new System.Drawing.Point(506, 97);
            this.btn_buscbien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_buscbien.Name = "btn_buscbien";
            this.btn_buscbien.Size = new System.Drawing.Size(44, 35);
            this.btn_buscbien.TabIndex = 24;
            this.btn_buscbien.UseVisualStyleBackColor = true;
            this.btn_buscbien.Click += new System.EventHandler(this.btn_buscbien_Click);
            // 
            // dgv_bien
            // 
            this.dgv_bien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bien.Location = new System.Drawing.Point(80, 203);
            this.dgv_bien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv_bien.Name = "dgv_bien";
            this.dgv_bien.Size = new System.Drawing.Size(726, 231);
            this.dgv_bien.TabIndex = 27;
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_agregar.BackgroundImage")));
            this.btn_agregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_agregar.FlatAppearance.BorderSize = 0;
            this.btn_agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Location = new System.Drawing.Point(718, 102);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(87, 91);
            this.btn_agregar.TabIndex = 174;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // frmbuscorden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 466);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.dgv_bien);
            this.Controls.Add(this.btn_buscbien);
            this.Controls.Add(this.txt_bien);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmbuscorden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Orden de Compra";
            this.Load += new System.EventHandler(this.frmbuscorden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bien;
        private System.Windows.Forms.Button btn_buscbien;
        private System.Windows.Forms.DataGridView dgv_bien;
        private System.Windows.Forms.Button btn_agregar;
    }
}