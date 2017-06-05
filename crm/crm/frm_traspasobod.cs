using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace crm
{
    public partial class frm_traspasobod : Form
    {
        public frm_traspasobod()
        {
            InitializeComponent();
        }

        public Int32 idprod;
        public Int32 idmarc;
        public Int32 idbod;
        public Int32 idbod2;
        public Int32 cant1;
        public Int32 cant2;

        public entidades.Producto clsprod { get; set; }
        private void btn_bproducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmbuscproducto buscl = new frmbuscproducto();
                buscl.ShowDialog();


                if (buscl.busq != null)
                {
                    clsprod = buscl.busq;

                    txt_prod.Text = Convert.ToString(buscl.busq.nombre);
                    idprod = Convert.ToInt16(buscl.busq.codigo);
                    idmarc = Convert.ToInt16(buscl.busq.marca);
                    llenarbod1();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            txt_cantidad.Enabled = false;
        }

        private void llenarbod1()
        {
            negocio cnegocio = new negocio();
            cbo_bod1.ValueMember = "id_bodega";
            cbo_bod1.DisplayMember = "nombre_bodega";
            cbo_bod1.DataSource = cnegocio.consultabod1(idprod,idmarc);
        }

        private void llenarbod()
        {
            negocio cnegocio = new negocio();
            cbo_bod2.DataSource = cnegocio.consultarbod();
            cbo_bod2.ValueMember = "id_bodega";
            cbo_bod2.DisplayMember = "nombre_bodega";
        }

        private void llenarcant1(Int32 idb)
        {
            OdbcCommand mcd = new OdbcCommand(string.Format("select cantidad from existencia_bodega where id_producto='{0}' and id_marca='{1}' and id_bodega='{2}'",idprod,idmarc,idb), Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();

            while (mdr.Read())
            {
                cant1 = mdr.GetInt32(0);
            }

        }

        private void llenarcant2(Int32 idb)
        {
            OdbcCommand mcd = new OdbcCommand(string.Format("select cantidad from existencia_bodega where id_producto='{0}' and id_marca='{1}' and id_bodega='{2}'", idprod, idmarc, idb), Conexion.ObtenerConexion());
            OdbcDataReader mdr = mcd.ExecuteReader();

            while (mdr.Read())
            {
                cant2 = mdr.GetInt32(0);
            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            /*cbo_bod1.DataSource = null;
            llenarbod1();
            cbo_bod2.DataSource = null;
            llenarbod();*/
            llenarcant1(cbo_bod1.SelectedIndex + 1);
            txt_c1.Text = Convert.ToString(cant1);
            llenarcant2(cbo_bod2.SelectedIndex + 1);
            txt_c2.Text = Convert.ToString(cant2);

        }

        private void frm_traspasobod_Load(object sender, EventArgs e)
        {
            txt_cantidad.Enabled = false;

        }

        
        private void cbo_bod1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cbo_bod2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_bod1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            llenarcant1(cbo_bod1.SelectedIndex + 1);
            txt_c1.Text = Convert.ToString(cant1);
            llenarbod();
        }

        private void txt_c1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbo_bod2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            llenarcant2(cbo_bod2.SelectedIndex + 1);
            txt_c2.Text = Convert.ToString(cant2);
            txt_cantidad.Enabled = true;
        }

        private void txt_prod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txt_cantidad.Text)>cant1)
            {
                MessageBox.Show("La cantidad ingresada no existe en bodega");
            }
            else
            {
                MessageBox.Show("cantidad validada");
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Int32 cantidad = Convert.ToInt32(txt_cantidad.Text);
            MessageBox.Show(Convert.ToString(cant2));
            Int32 total1 = cantidad + cant2;
            Int32 total2 = cant1 - cantidad;
            idbod2 = cbo_bod2.SelectedIndex + 1;
            idbod = cbo_bod1.SelectedIndex + 1;

            try
            {
                OdbcCommand mySqlComando = new OdbcCommand(
                string.Format("Update existencia_bodega set cantidad='{0}' where id_producto='{1}' and id_marca='{2}' and id_bodega='{3}'",total1,idprod,idmarc,idbod2),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se actualizo con exito bodega 2");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
        
            }
            catch
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }

            try
            {
                OdbcCommand mySqlComando = new OdbcCommand(
                string.Format("Update existencia_bodega set cantidad='{0}' where id_producto='{1}' and id_marca='{2}' and id_bodega='{3}'",total2, idprod, idmarc, idbod),
                Conexion.ObtenerConexion()
                );
                mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                MessageBox.Show("Se actualizo con exito bodega 1");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
            }
            catch 
            {
                MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
            }



        } //insertar categoria

        private void txt_c2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            frmbuscexisbod fb = new frmbuscexisbod();
            fb.Show();
        }
    }
}
