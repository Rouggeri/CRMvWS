namespace seguridad
{
    partial class FormEliminarPerfil
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_deshabilitar = new System.Windows.Forms.Button();
            this.cbo_perfil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_deshabilitar);
            this.groupBox1.Controls.Add(this.cbo_perfil);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(48, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(391, 177);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Deshabilitar perfil:";
            // 
            // btn_deshabilitar
            // 
            this.btn_deshabilitar.BackgroundImage = global::seguridad.Properties.Resources.borrar_documento;
            this.btn_deshabilitar.FlatAppearance.BorderSize = 0;
            this.btn_deshabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deshabilitar.Location = new System.Drawing.Point(150, 89);
            this.btn_deshabilitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_deshabilitar.Name = "btn_deshabilitar";
            this.btn_deshabilitar.Size = new System.Drawing.Size(87, 80);
            this.btn_deshabilitar.TabIndex = 2;
            this.btn_deshabilitar.UseVisualStyleBackColor = true;
            this.btn_deshabilitar.Click += new System.EventHandler(this.btn_deshabilitar_Click);
            // 
            // cbo_perfil
            // 
            this.cbo_perfil.FormattingEnabled = true;
            this.cbo_perfil.Location = new System.Drawing.Point(124, 57);
            this.cbo_perfil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbo_perfil.Name = "cbo_perfil";
            this.cbo_perfil.Size = new System.Drawing.Size(160, 24);
            this.cbo_perfil.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Perfil:";
            // 
            // FormEliminarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 289);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormEliminarPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deshabilitar perfil";
            this.Load += new System.EventHandler(this.FormEliminarPerfil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_deshabilitar;
        private System.Windows.Forms.ComboBox cbo_perfil;
        private System.Windows.Forms.Label label1;
    }
}