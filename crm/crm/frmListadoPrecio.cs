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
            llenar_encabezado();
            llenarcbo();
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



        private void btn_Buscte_Click(object sender, EventArgs e)
        {

        }

        private void frmListadoPrecio_Load(object sender, EventArgs e)
        {
            cbo_catalogo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            obtenerid();
            if (string.IsNullOrWhiteSpace(txt_precio1.Text))
                MessageBox.Show("Campo obligatorio vacío", "Campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else
            {

                MessageBox.Show("Cambiando precio...");
                string scad = "select * from producto";
                OdbcCommand mcd = new OdbcCommand(scad, Conexion.ObtenerConexion());
                OdbcDataReader mdr = mcd.ExecuteReader();
                int j = 1;

                OdbcCommand mcd2 = new OdbcCommand("delete from precio where id_tipo=(" + codtipo + ")", Conexion.ObtenerConexion());
                OdbcDataReader mdr2 = mcd2.ExecuteReader();

                while (mdr.Read())
                {

                    float costo = Convert.ToInt32(mdr.GetString(4));
                    float costo2 = Convert.ToInt32(txt_precio1.Text);
                    float mult = costo * (costo2 / 100);
                    float total = mult + (Convert.ToInt32(costo));


                    OdbcCommand mcd1 = new OdbcCommand("insert into precio (precio, id_bien, id_tipo) values(" + total + "," + j + "," + codtipo + ")", Conexion.ObtenerConexion());
                    OdbcDataReader mdr1 = mcd1.ExecuteReader();
                    j++;
                    costo = 0;
                    costo2 = 0;
                    mult = 0;
                    total = 0;
                }
                MessageBox.Show("Precios modificados... presione Actualizar");
                //}else { MessageBox.Show("Debe ingresar un valor de ganancia"); }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            obtenerid();
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
    }
}
