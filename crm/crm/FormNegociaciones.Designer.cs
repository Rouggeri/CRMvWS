namespace crm
{
    partial class FormNegociaciones
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNegociaciones));
            this.dgv_negocios = new DevExpress.XtraGrid.GridControl();
            this.dgv_neg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.navigationPane1 = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.pag_lista = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.btn_empresa = new DevExpress.XtraEditors.SimpleButton();
            this.btn_clie = new DevExpress.XtraEditors.SimpleButton();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ddb_clientes = new DevExpress.XtraEditors.DropDownButton();
            this.btn_normal = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cat = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pag_estado = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.tileBar3 = new DevExpress.XtraBars.Navigation.TileBar();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.tileBar2 = new DevExpress.XtraBars.Navigation.TileBar();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.grupo_preparacion = new DevExpress.XtraEditors.GroupControl();
            this.tileBar0 = new DevExpress.XtraBars.Navigation.TileBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_negocios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_neg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).BeginInit();
            this.navigationPane1.SuspendLayout();
            this.pag_lista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            this.popupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.pag_estado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupo_preparacion)).BeginInit();
            this.grupo_preparacion.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_negocios
            // 
            resources.ApplyResources(this.dgv_negocios, "dgv_negocios");
            this.dgv_negocios.MainView = this.dgv_neg;
            this.dgv_negocios.Name = "dgv_negocios";
            this.dgv_negocios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_neg});
            this.dgv_negocios.Click += new System.EventHandler(this.dgv_negocios_Click);
            this.dgv_negocios.DoubleClick += new System.EventHandler(this.dgv_negocios_DoubleClick);
            // 
            // dgv_neg
            // 
            this.dgv_neg.GridControl = this.dgv_negocios;
            this.dgv_neg.Name = "dgv_neg";
            this.dgv_neg.OptionsView.ShowFooter = true;
            this.dgv_neg.OptionsView.ShowGroupPanel = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // navigationPane1
            // 
            this.navigationPane1.Controls.Add(this.pag_lista);
            this.navigationPane1.Controls.Add(this.pag_estado);
            resources.ApplyResources(this.navigationPane1, "navigationPane1");
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this.navigationPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.pag_lista,
            this.pag_estado});
            this.navigationPane1.RegularSize = new System.Drawing.Size(1013, 526);
            this.navigationPane1.SelectedPage = this.pag_estado;
            this.navigationPane1.SelectedPageIndex = 1;
            // 
            // pag_lista
            // 
            this.pag_lista.Caption = "Lista";
            this.pag_lista.Controls.Add(this.popupControlContainer1);
            this.pag_lista.Controls.Add(this.ddb_clientes);
            this.pag_lista.Controls.Add(this.btn_normal);
            this.pag_lista.Controls.Add(this.btn_cat);
            this.pag_lista.Controls.Add(this.label1);
            this.pag_lista.Controls.Add(this.dgv_negocios);
            this.pag_lista.Image = ((System.Drawing.Image)(resources.GetObject("pag_lista.Image")));
            this.pag_lista.Name = "pag_lista";
            this.pag_lista.PageText = "";
            resources.ApplyResources(this.pag_lista, "pag_lista");
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Controls.Add(this.btn_empresa);
            this.popupControlContainer1.Controls.Add(this.btn_clie);
            resources.ApplyResources(this.popupControlContainer1, "popupControlContainer1");
            this.popupControlContainer1.Manager = this.barManager1;
            this.popupControlContainer1.Name = "popupControlContainer1";
            // 
            // btn_empresa
            // 
            this.btn_empresa.Image = ((System.Drawing.Image)(resources.GetObject("btn_empresa.Image")));
            resources.ApplyResources(this.btn_empresa, "btn_empresa");
            this.btn_empresa.Name = "btn_empresa";
            this.btn_empresa.Click += new System.EventHandler(this.btn_empresa_Click);
            // 
            // btn_clie
            // 
            this.btn_clie.Image = ((System.Drawing.Image)(resources.GetObject("btn_clie.Image")));
            resources.ApplyResources(this.btn_clie, "btn_clie");
            this.btn_clie.Name = "btn_clie";
            this.btn_clie.Click += new System.EventHandler(this.btn_clie_Click);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // ddb_clientes
            // 
            this.ddb_clientes.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.ddb_clientes.DropDownControl = this.popupControlContainer1;
            this.ddb_clientes.Image = ((System.Drawing.Image)(resources.GetObject("ddb_clientes.Image")));
            resources.ApplyResources(this.ddb_clientes, "ddb_clientes");
            this.ddb_clientes.MenuManager = this.barManager1;
            this.ddb_clientes.Name = "ddb_clientes";
            // 
            // btn_normal
            // 
            this.btn_normal.Image = ((System.Drawing.Image)(resources.GetObject("btn_normal.Image")));
            resources.ApplyResources(this.btn_normal, "btn_normal");
            this.btn_normal.Name = "btn_normal";
            this.btn_normal.Click += new System.EventHandler(this.btn_normal_Click);
            // 
            // btn_cat
            // 
            this.btn_cat.Image = ((System.Drawing.Image)(resources.GetObject("btn_cat.Image")));
            resources.ApplyResources(this.btn_cat, "btn_cat");
            this.btn_cat.Name = "btn_cat";
            this.btn_cat.Click += new System.EventHandler(this.btn_cat_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pag_estado
            // 
            this.pag_estado.Caption = "Etapa";
            this.pag_estado.Controls.Add(this.groupControl5);
            this.pag_estado.Controls.Add(this.groupControl3);
            this.pag_estado.Controls.Add(this.groupControl2);
            this.pag_estado.Controls.Add(this.grupo_preparacion);
            this.pag_estado.Image = ((System.Drawing.Image)(resources.GetObject("pag_estado.Image")));
            this.pag_estado.Name = "pag_estado";
            resources.ApplyResources(this.pag_estado, "pag_estado");
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl5.AppearanceCaption.Font")));
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl5.CaptionImage")));
            this.groupControl5.Controls.Add(this.tileBar3);
            this.groupControl5.Controls.Add(this.groupControl6);
            resources.ApplyResources(this.groupControl5, "groupControl5");
            this.groupControl5.Name = "groupControl5";
            // 
            // tileBar3
            // 
            this.tileBar3.AllowDrag = false;
            this.tileBar3.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("tileBar3.AppearanceItem.Normal.Font")));
            this.tileBar3.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBar3.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar3.ItemSize = 80;
            resources.ApplyResources(this.tileBar3, "tileBar3");
            this.tileBar3.Name = "tileBar3";
            this.tileBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileBar3.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            // 
            // groupControl6
            // 
            resources.ApplyResources(this.groupControl6, "groupControl6");
            this.groupControl6.Name = "groupControl6";
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl3.AppearanceCaption.Font")));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImage")));
            this.groupControl3.Controls.Add(this.tileBar2);
            this.groupControl3.Controls.Add(this.groupControl4);
            resources.ApplyResources(this.groupControl3, "groupControl3");
            this.groupControl3.Name = "groupControl3";
            // 
            // tileBar2
            // 
            this.tileBar2.AllowDrag = false;
            this.tileBar2.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("tileBar2.AppearanceItem.Normal.Font")));
            this.tileBar2.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBar2.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar2.ItemSize = 80;
            resources.ApplyResources(this.tileBar2, "tileBar2");
            this.tileBar2.Name = "tileBar2";
            this.tileBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileBar2.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            // 
            // groupControl4
            // 
            resources.ApplyResources(this.groupControl4, "groupControl4");
            this.groupControl4.Name = "groupControl4";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("groupControl2.AppearanceCaption.Font")));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionImage = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImage")));
            this.groupControl2.Controls.Add(this.tileBar1);
            resources.ApplyResources(this.groupControl2, "groupControl2");
            this.groupControl2.Name = "groupControl2";
            // 
            // tileBar1
            // 
            this.tileBar1.AllowDrag = false;
            this.tileBar1.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("tileBar1.AppearanceItem.Normal.Font")));
            this.tileBar1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.ItemSize = 80;
            resources.ApplyResources(this.tileBar1, "tileBar1");
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            // 
            // grupo_preparacion
            // 
            this.grupo_preparacion.AppearanceCaption.Font = ((System.Drawing.Font)(resources.GetObject("grupo_preparacion.AppearanceCaption.Font")));
            this.grupo_preparacion.AppearanceCaption.Options.UseFont = true;
            this.grupo_preparacion.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grupo_preparacion.CaptionImage")));
            this.grupo_preparacion.Controls.Add(this.tileBar0);
            resources.ApplyResources(this.grupo_preparacion, "grupo_preparacion");
            this.grupo_preparacion.Name = "grupo_preparacion";
            // 
            // tileBar0
            // 
            this.tileBar0.AllowDrag = false;
            this.tileBar0.AppearanceItem.Normal.Font = ((System.Drawing.Font)(resources.GetObject("tileBar0.AppearanceItem.Normal.Font")));
            this.tileBar0.AppearanceItem.Normal.Options.UseFont = true;
            this.tileBar0.AppearanceText.Font = ((System.Drawing.Font)(resources.GetObject("tileBar0.AppearanceText.Font")));
            this.tileBar0.AppearanceText.Options.UseFont = true;
            this.tileBar0.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar0.ItemSize = 80;
            resources.ApplyResources(this.tileBar0, "tileBar0");
            this.tileBar0.MaxId = 3;
            this.tileBar0.Name = "tileBar0";
            this.tileBar0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileBar0.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tileGroup1
            // 
            this.tileGroup1.Name = "tileGroup1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileGroup3
            // 
            this.tileGroup3.Name = "tileGroup3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::crm.Properties.Resources.imprimir1;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click_1);
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
            this.btn_primero.Click += new System.EventHandler(this.btn_primero_Click);
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
            // FormNegociaciones
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.navigationPane1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormNegociaciones";
            this.Load += new System.EventHandler(this.FormNegociaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_negocios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_neg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPane1)).EndInit();
            this.navigationPane1.ResumeLayout(false);
            this.pag_lista.ResumeLayout(false);
            this.pag_lista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            this.popupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.pag_estado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grupo_preparacion)).EndInit();
            this.grupo_preparacion.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgv_negocios;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_neg;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraBars.Navigation.NavigationPane navigationPane1;
        private DevExpress.XtraBars.Navigation.NavigationPage pag_lista;
        private DevExpress.XtraBars.Navigation.NavigationPage pag_estado;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
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
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl grupo_preparacion;
        private DevExpress.XtraBars.Navigation.TileBar tileBar0;
        private DevExpress.XtraBars.Navigation.TileBar tileBar3;
        private DevExpress.XtraBars.Navigation.TileBar tileBar2;
        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_normal;
        private DevExpress.XtraEditors.SimpleButton btn_cat;
        private DevExpress.XtraEditors.SimpleButton btn_clie;
        private DevExpress.XtraEditors.DropDownButton ddb_clientes;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraEditors.SimpleButton btn_empresa;
    }
}