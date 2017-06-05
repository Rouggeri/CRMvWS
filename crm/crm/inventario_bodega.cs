using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuncionesNavegador;
using System.Data.Odbc;

namespace crm
{
    public partial class inventario_bodega : Form
    {
        public inventario_bodega()
        {
            InitializeComponent();
        }

        private void inventario_bodega_Load(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
        }
        string id_form = "117";

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_bodega.DataSource = cnegocio.consultarbod();
            
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            String codi;
            Int32 selectedRowCount =
            dgv_bodega.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                codi = Convert.ToString(dgv_bodega.CurrentRow.Cells[0].Value);
                negocio neg = new negocio();
                neg.EliminarBodega(Convert.ToInt32(codi));
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }
        public Int32 codbodega;

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Bodega bodega = new entidades.Bodega();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            bodega.nombre = txt_nombre.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            bodega.direccion = txt_ubicacion.Text;
            cnegocio.InsertarBodega(bodega);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();

            Int32 codproducto;
            Int32 codmarca;
            //Int32 codbodega;

            string scad1 = "SELECT max(id_bodega) from bodega";
            OdbcCommand mcd1 = new OdbcCommand(scad1, Conexion.ObtenerConexion());
            OdbcDataReader mdr1 = mcd1.ExecuteReader();
            while (mdr1.Read())
            {
                codbodega = mdr1.GetInt32(0);
            }

            string scad3 = "SELECT id_producto, id_marca from producto";
            OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
            OdbcDataReader mdr3 = mcd3.ExecuteReader();

            while (mdr3.Read())
            {
                codproducto = mdr3.GetInt32(0);
                codmarca = mdr3.GetInt32(1);

                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                    string.Format("INSERT INTO existencia_bodega (id_producto, id_marca, id_bodega, cantidad) values ('{0}','{1}','{2}','0')", codproducto, codmarca, codbodega),
                    seguridad.Conexion.ObtenerConexionODBC()
                    );
                    mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                   
                }
                catch 
                {
                    MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
                }
            }

        }

        void limpiar()
        {
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }
        void deshabilitar()
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_bodega);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_bodega);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_bodega);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_bodega);
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = false;
            txt_ubicacion.Enabled = false;
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = true;
            txt_ubicacion.Enabled = true;
            txt_nombre.Clear();
            txt_ubicacion.Clear();
        }
    }
}
