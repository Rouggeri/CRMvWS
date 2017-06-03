namespace crm
{
    partial class frmbuscexisbod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbuscexisbod));
            this.dgv_exis = new System.Windows.Forms.DataGridView();
            this.txt_exis = new System.Windows.Forms.TextBox();
            this.lbl_exis = new System.Windows.Forms.Label();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_buscexis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_exis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_exis
            // 
            this.dgv_exis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_exis.Location = new System.Drawing.Point(72, 114);
            this.dgv_exis.Name = "dgv_exis";
            this.dgv_exis.Size = new System.Drawing.Size(484, 150);
            this.dgv_exis.TabIndex = 179;
            this.dgv_exis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_exis_CellContentClick);
            // 
            // txt_exis
            // 
            this.txt_exis.Location = new System.Drawing.Point(151, 67);
            this.txt_exis.Name = "txt_exis";
            this.txt_exis.Size = new System.Drawing.Size(199, 20);
            this.txt_exis.TabIndex = 177;
            // 
            // lbl_exis
            // 
            this.lbl_exis.AutoSize = true;
            this.lbl_exis.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exis.Location = new System.Drawing.Point(68, 64);
            this.lbl_exis.Name = "lbl_exis";
            this.lbl_exis.Size = new System.Drawing.Size(77, 21);
            this.lbl_exis.TabIndex = 176;
            this.lbl_exis.Text = "Nombre:";
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
            this.btn_agregar.Location = new System.Drawing.Point(498, 48);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(58, 59);
            this.btn_agregar.TabIndex = 180;
            this.btn_agregar.UseVisualStyleBackColor = true;
            // 
            // btn_buscexis
            // 
            this.btn_buscexis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buscexis.BackgroundImage")));
            this.btn_buscexis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscexis.Location = new System.Drawing.Point(365, 67);
            this.btn_buscexis.Name = "btn_buscexis";
            this.btn_buscexis.Size = new System.Drawing.Size(29, 23);
            this.btn_buscexis.TabIndex = 178;
            this.btn_buscexis.UseVisualStyleBackColor = true;
            this.btn_buscexis.Click += new System.EventHandler(this.btn_buscexis_Click);
            // 
            // frmbuscexisbod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 292);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.dgv_exis);
            this.Controls.Add(this.btn_buscexis);
            this.Controls.Add(this.txt_exis);
            this.Controls.Add(this.lbl_exis);
            this.Name = "frmbuscexisbod";
            this.Text = "Buscar Existencia";
            this.Load += new System.EventHandler(this.frmbuscexisbod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_exis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.DataGridView dgv_exis;
        private System.Windows.Forms.Button btn_buscexis;
        private System.Windows.Forms.TextBox txt_exis;
        private System.Windows.Forms.Label lbl_exis;
    }
}