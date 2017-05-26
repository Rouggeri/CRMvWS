namespace crm
{
    partial class FormDetallesCaso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetallesCaso));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.Notas_page = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.btn_eliminar_nota = new DevExpress.XtraEditors.SimpleButton();
            this.tileBar_notas = new DevExpress.XtraBars.Navigation.TileBar();
            this.btn_guardar_nota = new DevExpress.XtraEditors.SimpleButton();
            this.rtxt_notas = new System.Windows.Forms.RichTextBox();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.btn_refrescar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_eliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_modificar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nueva_tarea = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_tareas = new DevExpress.XtraGrid.GridControl();
            this.dgv_tareas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbl_encargado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_categoria = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_fecha_ini = new System.Windows.Forms.Label();
            this.lbl_fecha_cierre = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cliente = new System.Windows.Forms.Label();
            this.switch_caso = new DevExpress.XtraEditors.ToggleSwitch();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.Notas_page.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tareas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch_caso.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImage")));
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.switch_caso);
            this.groupControl1.Controls.Add(this.tabPane1);
            this.groupControl1.Controls.Add(this.lbl_encargado);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lbl_categoria);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.lbl_fecha_ini);
            this.groupControl1.Controls.Add(this.lbl_fecha_cierre);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.lbl_cliente);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1010, 619);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "groupControl1";
            // 
            // tabPane1
            // 
            this.tabPane1.AppearanceButton.Normal.Image = ((System.Drawing.Image)(resources.GetObject("tabPane1.AppearanceButton.Normal.Image")));
            this.tabPane1.AppearanceButton.Normal.Options.UseImage = true;
            this.tabPane1.Controls.Add(this.Notas_page);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Location = new System.Drawing.Point(487, 127);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.Notas_page,
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(511, 392);
            this.tabPane1.SelectedPage = this.Notas_page;
            this.tabPane1.SelectedPageIndex = 1;
            this.tabPane1.Size = new System.Drawing.Size(511, 392);
            this.tabPane1.TabIndex = 18;
            this.tabPane1.Text = "tabPane1";
            // 
            // Notas_page
            // 
            this.Notas_page.Caption = "Notas";
            this.Notas_page.Controls.Add(this.btn_eliminar_nota);
            this.Notas_page.Controls.Add(this.tileBar_notas);
            this.Notas_page.Controls.Add(this.btn_guardar_nota);
            this.Notas_page.Controls.Add(this.rtxt_notas);
            this.Notas_page.Name = "Notas_page";
            this.Notas_page.Size = new System.Drawing.Size(493, 347);
            // 
            // btn_eliminar_nota
            // 
            this.btn_eliminar_nota.Appearance.BackColor = System.Drawing.Color.Crimson;
            this.btn_eliminar_nota.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.btn_eliminar_nota.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_eliminar_nota.Appearance.Options.UseBackColor = true;
            this.btn_eliminar_nota.Appearance.Options.UseBorderColor = true;
            this.btn_eliminar_nota.Appearance.Options.UseForeColor = true;
            this.btn_eliminar_nota.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar_nota.Image")));
            this.btn_eliminar_nota.Location = new System.Drawing.Point(121, 103);
            this.btn_eliminar_nota.Name = "btn_eliminar_nota";
            this.btn_eliminar_nota.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar_nota.TabIndex = 3;
            this.btn_eliminar_nota.Text = "Eliminar";
            this.btn_eliminar_nota.Click += new System.EventHandler(this.btn_eliminar_nota_Click);
            // 
            // tileBar_notas
            // 
            this.tileBar_notas.AllowDrag = false;
            this.tileBar_notas.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar_notas.ItemSize = 130;
            this.tileBar_notas.Location = new System.Drawing.Point(38, 132);
            this.tileBar_notas.MaxId = 10;
            this.tileBar_notas.Name = "tileBar_notas";
            this.tileBar_notas.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar_notas.Size = new System.Drawing.Size(421, 205);
            this.tileBar_notas.TabIndex = 2;
            this.tileBar_notas.Text = "tileBar1";
            // 
            // btn_guardar_nota
            // 
            this.btn_guardar_nota.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_guardar_nota.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btn_guardar_nota.Appearance.Options.UseBackColor = true;
            this.btn_guardar_nota.Appearance.Options.UseForeColor = true;
            this.btn_guardar_nota.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar_nota.Image")));
            this.btn_guardar_nota.Location = new System.Drawing.Point(38, 103);
            this.btn_guardar_nota.Name = "btn_guardar_nota";
            this.btn_guardar_nota.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar_nota.TabIndex = 1;
            this.btn_guardar_nota.Text = "Guardar";
            this.btn_guardar_nota.Click += new System.EventHandler(this.btn_guardar_nota_Click);
            // 
            // rtxt_notas
            // 
            this.rtxt_notas.Location = new System.Drawing.Point(38, 26);
            this.rtxt_notas.Name = "rtxt_notas";
            this.rtxt_notas.Size = new System.Drawing.Size(421, 71);
            this.rtxt_notas.TabIndex = 0;
            this.rtxt_notas.Text = "";
            this.rtxt_notas.Click += new System.EventHandler(this.rtxt_notas_Click);
            this.rtxt_notas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtxt_notas_MouseClick);
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Tareas";
            this.tabNavigationPage2.Controls.Add(this.btn_refrescar);
            this.tabNavigationPage2.Controls.Add(this.btn_eliminar);
            this.tabNavigationPage2.Controls.Add(this.btn_modificar);
            this.tabNavigationPage2.Controls.Add(this.btn_nueva_tarea);
            this.tabNavigationPage2.Controls.Add(this.gridControl_tareas);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(493, 347);
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.Image = ((System.Drawing.Image)(resources.GetObject("btn_refrescar.Image")));
            this.btn_refrescar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_refrescar.Location = new System.Drawing.Point(346, 223);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(30, 28);
            this.btn_refrescar.TabIndex = 4;
            this.btn_refrescar.ToolTip = "Actualizar registros";
            this.btn_refrescar.Click += new System.EventHandler(this.btn_refrescar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.Location = new System.Drawing.Point(134, 223);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(100, 28);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.ToolTip = "Eliminar tarea seleccionada";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Image = ((System.Drawing.Image)(resources.GetObject("btn_modificar.Image")));
            this.btn_modificar.Location = new System.Drawing.Point(240, 223);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(100, 28);
            this.btn_modificar.TabIndex = 2;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.ToolTip = "Modificar tarea seleccionada";
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_nueva_tarea
            // 
            this.btn_nueva_tarea.Image = ((System.Drawing.Image)(resources.GetObject("btn_nueva_tarea.Image")));
            this.btn_nueva_tarea.Location = new System.Drawing.Point(23, 223);
            this.btn_nueva_tarea.Name = "btn_nueva_tarea";
            this.btn_nueva_tarea.Size = new System.Drawing.Size(105, 28);
            this.btn_nueva_tarea.TabIndex = 1;
            this.btn_nueva_tarea.Text = "Nueva tarea";
            this.btn_nueva_tarea.ToolTip = "Agregar nueva tarea";
            this.btn_nueva_tarea.Click += new System.EventHandler(this.btn_nueva_tarea_Click);
            // 
            // gridControl_tareas
            // 
            this.gridControl_tareas.Location = new System.Drawing.Point(13, 16);
            this.gridControl_tareas.MainView = this.dgv_tareas;
            this.gridControl_tareas.Name = "gridControl_tareas";
            this.gridControl_tareas.Size = new System.Drawing.Size(477, 201);
            this.gridControl_tareas.TabIndex = 0;
            this.gridControl_tareas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_tareas});
            // 
            // dgv_tareas
            // 
            this.dgv_tareas.GridControl = this.gridControl_tareas;
            this.dgv_tareas.Name = "dgv_tareas";
            this.dgv_tareas.OptionsView.ShowFooter = true;
            this.dgv_tareas.OptionsView.ShowGroupPanel = false;
            // 
            // lbl_encargado
            // 
            this.lbl_encargado.AutoSize = true;
            this.lbl_encargado.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_encargado.Location = new System.Drawing.Point(62, 421);
            this.lbl_encargado.Name = "lbl_encargado";
            this.lbl_encargado.Size = new System.Drawing.Size(44, 18);
            this.lbl_encargado.TabIndex = 17;
            this.lbl_encargado.Text = "label5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(62, 408);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Encargado";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(380, 175);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(62, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Detalles";
            // 
            // lbl_categoria
            // 
            this.lbl_categoria.AutoSize = true;
            this.lbl_categoria.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_categoria.Location = new System.Drawing.Point(59, 190);
            this.lbl_categoria.Name = "lbl_categoria";
            this.lbl_categoria.Size = new System.Drawing.Size(44, 18);
            this.lbl_categoria.TabIndex = 11;
            this.lbl_categoria.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(59, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Categoría";
            // 
            // lbl_fecha_ini
            // 
            this.lbl_fecha_ini.AutoSize = true;
            this.lbl_fecha_ini.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_ini.Location = new System.Drawing.Point(59, 114);
            this.lbl_fecha_ini.Name = "lbl_fecha_ini";
            this.lbl_fecha_ini.Size = new System.Drawing.Size(44, 18);
            this.lbl_fecha_ini.TabIndex = 6;
            this.lbl_fecha_ini.Text = "label6";
            // 
            // lbl_fecha_cierre
            // 
            this.lbl_fecha_cierre.AutoSize = true;
            this.lbl_fecha_cierre.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha_cierre.Location = new System.Drawing.Point(241, 114);
            this.lbl_fecha_cierre.Name = "lbl_fecha_cierre";
            this.lbl_fecha_cierre.Size = new System.Drawing.Size(44, 18);
            this.lbl_fecha_cierre.TabIndex = 5;
            this.lbl_fecha_cierre.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(59, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Creado el";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(241, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cierre estimado";
            // 
            // lbl_cliente
            // 
            this.lbl_cliente.AutoSize = true;
            this.lbl_cliente.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cliente.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_cliente.Location = new System.Drawing.Point(23, 39);
            this.lbl_cliente.Name = "lbl_cliente";
            this.lbl_cliente.Size = new System.Drawing.Size(51, 19);
            this.lbl_cliente.TabIndex = 0;
            this.lbl_cliente.Text = "label1";
            // 
            // switch_caso
            // 
            this.switch_caso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switch_caso.EditValue = null;
            this.switch_caso.Location = new System.Drawing.Point(59, 474);
            this.switch_caso.Name = "switch_caso";
            this.switch_caso.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.switch_caso.Properties.Appearance.BackColor2 = System.Drawing.SystemColors.Control;
            this.switch_caso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switch_caso.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.switch_caso.Properties.Appearance.Options.UseBackColor = true;
            this.switch_caso.Properties.Appearance.Options.UseFont = true;
            this.switch_caso.Properties.Appearance.Options.UseForeColor = true;
            this.switch_caso.Properties.AutoHeight = false;
            this.switch_caso.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.switch_caso.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.switch_caso.Properties.OffText = "Cerrado";
            this.switch_caso.Properties.OnText = "Abierto";
            this.switch_caso.Size = new System.Drawing.Size(132, 45);
            this.switch_caso.TabIndex = 23;
            this.switch_caso.Toggled += new System.EventHandler(this.switch_caso_Toggled);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(59, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Estado";
            // 
            // FormDetallesCaso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 619);
            this.Controls.Add(this.groupControl1);
            this.Name = "FormDetallesCaso";
            this.Load += new System.EventHandler(this.FormDetallesCaso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.Notas_page.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_tareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tareas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.switch_caso.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage Notas_page;
        private DevExpress.XtraEditors.SimpleButton btn_eliminar_nota;
        private DevExpress.XtraBars.Navigation.TileBar tileBar_notas;
        private DevExpress.XtraEditors.SimpleButton btn_guardar_nota;
        private System.Windows.Forms.RichTextBox rtxt_notas;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraEditors.SimpleButton btn_refrescar;
        private DevExpress.XtraEditors.SimpleButton btn_eliminar;
        private DevExpress.XtraEditors.SimpleButton btn_modificar;
        private DevExpress.XtraEditors.SimpleButton btn_nueva_tarea;
        private DevExpress.XtraGrid.GridControl gridControl_tareas;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_tareas;
        private System.Windows.Forms.Label lbl_encargado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_fecha_ini;
        private System.Windows.Forms.Label lbl_fecha_cierre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cliente;
        private DevExpress.XtraEditors.ToggleSwitch switch_caso;
        private System.Windows.Forms.Label label6;
    }
}