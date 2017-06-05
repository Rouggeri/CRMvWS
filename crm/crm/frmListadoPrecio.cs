using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.Odbc;
using seguridad;
using System.Diagnostics;

namespace crm
{
    public partial class frmListadoPrecio : Form
    {
        public frmListadoPrecio()
        {
            InitializeComponent();
            
        }
        string id_form = "118";

        public void llenar_encabezado()
        {
            DataGridViewTextBoxColumn c1 = new DataGridViewTextBoxColumn();
            c1.HeaderText = "Bien";
            c1.Width = 100;
            c1.ReadOnly = true;

            dgv_bien.Columns.Add(c1);

            DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
            c2.HeaderText = "Costo";
            c2.Width = 50;
            c2.ReadOnly = true;

            dgv_bien.Columns.Add(c2);

            DataGridViewTextBoxColumn c3 = new DataGridViewTextBoxColumn();
            c3.HeaderText = "Precio";
            c3.Width = 50;
            c3.ReadOnly = true;

            dgv_bien.Columns.Add(c3);

            
        }

        private void llenarcbo()
        {
            negocio cnegocio = new negocio();
            cbo_catalogo.ValueMember = "id_tprecio_pk";
            cbo_catalogo.DisplayMember = "tipo";
            cbo_catalogo.DataSource = cnegocio.consultaprecio();
        }

        private void llenarcategoria()
        {
            negocio cnegocio = new negocio();
            cbo_categoria.ValueMember = "id";
            cbo_categoria.DisplayMember = "nombre";
            cbo_categoria.DataSource = cnegocio.consultacat();
        }

        private void llenarmarca()
        {
            negocio cnegocio = new negocio();
            cbo_marca.ValueMember = "id_marca";
            cbo_marca.DisplayMember = "nombre_marca";
            cbo_marca.DataSource = cnegocio.consultamarca();
        }

        public Int32 codtipo;

        public void obtenerid()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS

            
            string scad2 = "SELECT id_tprecio_pk from tipo_precio where tipo='" + cbo_catalogo.Text + "'";
            OdbcCommand mcd2 = new OdbcCommand(scad2, Conexion.ObtenerConexion());
            OdbcDataReader mdr2 = mcd2.ExecuteReader();

            while (mdr2.Read())
            {
                codtipo = mdr2.GetInt16(0);
            }
        }

        public Int32 codmarca;
        public void obteneridmarca()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS


            string scad3 = "SELECT id_marca from marca where nombre_marca='" + cbo_marca.Text + "'";
            OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
            OdbcDataReader mdr3 = mcd3.ExecuteReader();

            while (mdr3.Read())
            {
                codmarca = mdr3.GetInt16(0);
            }
        }

        public Int32 codcategoria;
        public void obteneridcat()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS


            string scad4 = "SELECT id from categoria where nombre='" + cbo_categoria.Text + "'";
            OdbcCommand mcd4 = new OdbcCommand(scad4, Conexion.ObtenerConexion());
            OdbcDataReader mdr4 = mcd4.ExecuteReader();

            while (mdr4.Read())
            {
                codcategoria = mdr4.GetInt16(0);
            }
        }

        public void llenar_bien()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS
            dgv_bien.Rows.Clear();


            //LLENANDO DATAGRID CON BIENES Y SU PRECIO
            string scad = "SELECT producto.nombre, producto.precio_unidad, precio.precio FROM producto INNER JOIN precio ON producto.id_producto = precio.id_bien and precio.id_tipo = " + codtipo;
            OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();

            while (mdr.Read())
            {

                dgv_bien.Rows.Add(mdr.GetString(0), mdr.GetDecimal(1), mdr.GetDecimal(2));

            }
        }

        public void llenar_bienc()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS
            dgv_bien.Rows.Clear();

            
            //LLENANDO DATAGRID CON BIENES Y SU PRECIO
            string scad = "SELECT producto.nombre, producto.precio_unidad, precio.precio FROM producto INNER JOIN precio ON producto.id_producto = precio.id_bien and producto.id_categoria = "+ codcategoria + " and precio.id_tipo = " + codtipo;
            OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();
            //MessageBox.Show(Convert.ToString(codcategoria));

            while (mdr.Read())
            {

                dgv_bien.Rows.Add(mdr.GetString(0), mdr.GetDecimal(1), mdr.GetDecimal(2));

            }
        }

        public void llenar_bienm()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS
            dgv_bien.Rows.Clear();


            //LLENANDO DATAGRID CON BIENES Y SU PRECIO
            string scad = "SELECT producto.nombre, producto.precio_unidad, precio.precio FROM producto INNER JOIN precio ON producto.id_producto = precio.id_bien and producto.id_marca = " + codmarca + " and precio.id_tipo = " + codtipo;
            OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();
            //MessageBox.Show(Convert.ToString(codcategoria));

            while (mdr.Read())
            {

                dgv_bien.Rows.Add(mdr.GetString(0), mdr.GetDecimal(1), mdr.GetDecimal(2));

            }
        }

        public void llenar_biena()
        {
            //OBTENIENDO ID DE CATALOGO DE PRECIOS
            dgv_bien.Rows.Clear();


            //LLENANDO DATAGRID CON BIENES Y SU PRECIO
            string scad = "SELECT producto.nombre, producto.precio_unidad, precio.precio FROM producto INNER JOIN precio ON producto.id_producto = precio.id_bien and producto.id_categoria = "+ codcategoria +" and producto.id_marca = " + codmarca + " and precio.id_tipo = " + codtipo;
            OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();
            //MessageBox.Show(Convert.ToString(codcategoria));

            while (mdr.Read())
            {

                dgv_bien.Rows.Add(mdr.GetString(0), mdr.GetDecimal(1), mdr.GetDecimal(2));

            }
        }


        private void btn_Buscte_Click(object sender, EventArgs e)
        {

        }

        public string condicion;
        public void condiciones()
        {
           
            
            cbo_categoria.Enabled = check_categoria.Checked;

            cbo_marca.Enabled = check_marca.Checked;
            
        }

       
        private void frmListadoPrecio_Load(object sender, EventArgs e)
        {
            cbo_catalogo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_categoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_marca.DropDownStyle = ComboBoxStyle.DropDownList;
            
            llenar_encabezado();
            llenarcbo();
            cbo_categoria.Enabled = false;
            cbo_marca.Enabled = false;

        }

        public Int32 codm;
        public Int32 codc;
        public Int32 codp;

        private void ninguno()
        {
            if (string.IsNullOrWhiteSpace(txt_precio1.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                MessageBox.Show("Cambiando precio...");
                string scad = "select * from producto";
                OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
                OdbcDataReader mdr = mcd.ExecuteReader();
                int j = 1;

                string scad4 = "DELETE FROM precio where id_tipo = "+codtipo;
                OdbcCommand mcd4 = new OdbcCommand(scad4, Conexion.ObtenerConexion());
                OdbcDataReader mdr4 = mcd4.ExecuteReader();

                while (mdr.Read())
                {

                    float costo = Convert.ToInt32(mdr.GetDouble(4));
                    float costo2 = Convert.ToInt32(txt_precio1.Text);
                    float mult = costo * (costo2 / 100);
                    float total = mult + (Convert.ToInt32(costo));

                    string scad3 = "SELECT id_marca, id_categoria from producto where id_producto='" + j + "'";
                    OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
                    OdbcDataReader mdr3 = mcd3.ExecuteReader();

                    if (mdr3.Read())
                    {
                        codm = mdr3.GetInt16(0);
                        codc = mdr3.GetInt16(1);
                    }
                    
                    OdbcCommand mcd2 = new OdbcCommand(
                    string.Format("insert into precio (precio, id_bien, id_tipo, id_marca, id_categoria) values ('{0}','{1}','{2}','{3}','{4}')", total, j, codtipo, codm, codc), 
                    Conexion.ObtenerConexion());
                    OdbcDataReader mdr2 = mcd2.ExecuteReader();

                    j++;
                    costo = 0;
                    costo2 = 0;
                    mult = 0;
                    total = 0;
                    codm = 0;
                    codc = 0;
                    
                }
                MessageBox.Show("Precios modificados... presione Actualizar");
                codtipo = 0;
            }
        }

        private void categoria()
        {
            if (string.IsNullOrWhiteSpace(txt_precio1.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                MessageBox.Show("Cambiando precio...");
                string scad = "select * from producto where id_categoria=" +codcategoria;
                OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
                OdbcDataReader mdr = mcd.ExecuteReader();
                int j = 1;

                string scad4 = "DELETE FROM precio where id_categoria=" +codcategoria+" and id_tipo ="+codtipo;
                OdbcCommand mcd4 = new OdbcCommand(scad4, Conexion.ObtenerConexion());
                OdbcDataReader mdr4 = mcd4.ExecuteReader();

                while (mdr.Read())
                {

                    codp = mdr.GetInt16(0);
                    float costo = Convert.ToInt32(mdr.GetDouble(4));
                    float costo2 = Convert.ToInt32(txt_precio1.Text);
                    float mult = costo * (costo2 / 100);
                    float total = mult + (Convert.ToInt32(costo));

                    string scad3 = "SELECT id_marca from producto where id_producto='" + codp + "'";
                    OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
                    OdbcDataReader mdr3 = mcd3.ExecuteReader();

                    if (mdr3.Read())
                    {
                        codm = mdr3.GetInt16(0);
                    }

                    OdbcCommand mcd2 = new OdbcCommand(
                    string.Format("insert into precio (precio, id_bien, id_tipo, id_marca, id_categoria) values ('{0}','{1}','{2}','{3}','{4}')", total, codp, codtipo, codm, codcategoria),
                    Conexion.ObtenerConexion());
                    OdbcDataReader mdr2 = mcd2.ExecuteReader();

                    j++;
                    costo = 0;
                    costo2 = 0;
                    mult = 0;
                    total = 0;
                    codm = 0;
                    codc = 0;
                    codp = 0;
                   
                }
                MessageBox.Show("Precios modificados... presione Actualizar");
                codtipo = 0;
            }
        }

        private void marca()
        {
            if (string.IsNullOrWhiteSpace(txt_precio1.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                MessageBox.Show("Cambiando precio...");
                string scad = "select * from producto where id_marca = " + codmarca;
                OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
                OdbcDataReader mdr = mcd.ExecuteReader();
                int j = 1;

                string scad4 = "DELETE FROM precio where id_marca=" + codmarca+" and id_tipo = "+codtipo;
                OdbcCommand mcd4 = new OdbcCommand(scad4, Conexion.ObtenerConexion());
                OdbcDataReader mdr4 = mcd4.ExecuteReader();

                while (mdr.Read())
                {

                    codp = mdr.GetInt16(0);
                    float costo = Convert.ToInt32(mdr.GetDouble(4));
                    float costo2 = Convert.ToInt32(txt_precio1.Text);
                    float mult = costo * (costo2 / 100);
                    float total = mult + (Convert.ToInt32(costo));

                    string scad3 = "SELECT id_categoria from producto where id_producto = '" + codp + "'";
                    OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
                    OdbcDataReader mdr3 = mcd3.ExecuteReader();

                    if (mdr3.Read())
                    {
                        codc = mdr3.GetInt16(0);
                    }

                    OdbcCommand mcd2 = new OdbcCommand(
                    string.Format("insert into precio (precio, id_bien, id_tipo, id_marca, id_categoria) values ('{0}','{1}','{2}','{3}','{4}')", total, codp, codtipo, codmarca, codc),
                    Conexion.ObtenerConexion());
                    OdbcDataReader mdr2 = mcd2.ExecuteReader();

                    j++;
                    costo = 0;
                    costo2 = 0;
                    mult = 0;
                    total = 0;
                    codm = 0;
                    codc = 0;
                    codp = 0;
                    
                }
                MessageBox.Show("Precios modificados... presione Actualizar");
                codtipo = 0;
            }
        }

        private void ambos()
        {
            if (string.IsNullOrWhiteSpace(txt_precio1.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                MessageBox.Show("Cambiando precio...");
                string scad = "select * from producto where id_marca=" + codmarca +" and id_categoria=" + codcategoria;
                OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
                OdbcDataReader mdr = mcd.ExecuteReader();
                int j = 1;

                string scad4 = "DELETE FROM precio where id_marca=" + codmarca + " and id_categoria=" + codcategoria+ "and id_tipo = "+codtipo;
                OdbcCommand mcd4 = new OdbcCommand(scad4, Conexion.ObtenerConexion());
                OdbcDataReader mdr4 = mcd4.ExecuteReader();

                while (mdr.Read())
                {

                    codp = mdr.GetInt16(0);
                    float costo = Convert.ToInt32(mdr.GetDouble(4));
                    float costo2 = Convert.ToInt32(txt_precio1.Text);
                    float mult = costo * (costo2 / 100);
                    float total = mult + (Convert.ToInt32(costo));

                    OdbcCommand mcd2 = new OdbcCommand(
                    string.Format("insert into precio (precio, id_bien, id_tipo, id_marca, id_categoria) values ('{0}','{1}','{2}','{3}','{4}')", total, codp, codtipo, codmarca, codcategoria),
                    Conexion.ObtenerConexion());
                    OdbcDataReader mdr2 = mcd2.ExecuteReader();

                    j++;
                    costo = 0;
                    costo2 = 0;
                    mult = 0;
                    total = 0;
                    codm = 0;
                    codc = 0;
                    codp = 0;
                }
                MessageBox.Show("Precios modificados... presione Actualizar");
                codtipo = 0;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            obtenerid();

            if ((check_categoria.Checked) && (check_marca.Checked))
            {
                 obteneridmarca(); obteneridcat(); ambos() ;
            }
            else
                if (check_marca.Checked) { obteneridmarca(); marca(); }
            else
                        if (check_categoria.Checked) { obteneridcat(); categoria(); }
            else
                 ninguno();

        }

       

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            obtenerid();
            cbo_catalogo.DataSource = null;
            cbo_categoria.DataSource = null;
            cbo_marca.DataSource = null;
            //llenarmarca();
            llenarcbo();
            //llenarcategoria();
           
            //condiciones();
            if((check_categoria.Checked)&&(check_marca.Checked)) {
                obteneridcat(); obteneridmarca(); llenar_biena();


            }
            else
                if (check_marca.Checked) { obteneridmarca(); llenar_bienm(); }    
                    else
                        if (check_categoria.Checked) { obteneridcat(); llenar_bienc();  } 
                            else
                                llenar_bien(); 

        }

        

        private void cbo_catalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void check_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void check_marca_CheckedChanged(object sender, EventArgs e)
        {
            switch(check_marca.CheckState.ToString())
                {
                case "Checked": cbo_marca.Enabled = true;
                    llenarmarca();
                    
                    break;
                case "Uncheked": cbo_marca.Enabled = false;
                    break;
                default:
                    cbo_marca.Enabled = false;

                    break;
                }
        }

        private void check_categoria_CheckedChanged(object sender, EventArgs e)
        {
            switch (check_categoria.CheckState.ToString())
            {
                case "Checked":
                    cbo_categoria.Enabled = true;
                    llenarcategoria();
                    break;
                case "Indeterminated":
                    cbo_categoria.Enabled = false;
                    break;
                default:
                    cbo_categoria.Enabled = false;

                    break;
            }
        }
    }
}
