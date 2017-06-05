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
    public partial class inventario : Form
    {
        string id_form= "116";
        public inventario()
        {
            InitializeComponent();
           
        }

       

        private void limpiar()
        {
            txt_nombre.Clear();
            txt_descripcion.Clear();
            //txt_marca.Clear();
            txt_precio.Clear();
            //txt_categoria.Clear();
            txt_comision.Clear();

        }

        private void habilitar()
        {
            txt_nombre.Enabled = true;
            cbo_marca.Enabled = true;
            txt_descripcion.Enabled = true;
            txt_precio.Enabled = true;
            txt_comision.Enabled = true;
            cbo_cat.Enabled = true;
            //txt_categoria.Enabled = true;
        }

        private void deshabilitar()
        {
            txt_nombre.Enabled = false;
            cbo_marca.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_precio.Enabled = false;
            txt_comision.Enabled = false;
            cbo_cat.Enabled = false;
            //txt_categoria.Enabled = false;
        }


        private void llenarcbo()
        {
            negocio cnegocio = new negocio();
            cbo_cat.ValueMember = "id";
            cbo_cat.DisplayMember = "nombre";
            cbo_cat.DataSource = cnegocio.consultacat(); 
        }

        private void llenarmarca()
        {
            negocio cnegocio = new negocio();
            cbo_marca.ValueMember = "id_marca";
            cbo_marca.DisplayMember = "nombre_marca";
            cbo_marca.DataSource = cnegocio.consultamarca();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
        }

        public Int32 codbodega;
        public Int32 codproducto;
        public Int32 codmarca;

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                entidades.Producto producto = new entidades.Producto();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
                negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
                producto.nombre = txt_nombre.Text; //Llenamos el objeto persona con la informacion de los cuadros de texto/
                producto.descripcion = txt_descripcion.Text;
                producto.marca = Convert.ToInt32(cbo_marca.SelectedIndex + 1);
                codmarca = Convert.ToInt32(cbo_marca.SelectedIndex + 1);
                producto.precio = Convert.ToDouble(txt_precio.Text);
                producto.categoria = Convert.ToInt32(cbo_cat.SelectedIndex + 1);
                producto.porcentaje = Convert.ToInt32(txt_comision.Text);
                cnegocio.InsertarProducto(producto);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona

                string scad1 = "SELECT max(id_producto) from producto";
                OdbcCommand mcd1 = new OdbcCommand(scad1, Conexion.ObtenerConexion());
                OdbcDataReader mdr1 = mcd1.ExecuteReader();
                while (mdr1.Read())
                {
                    codproducto = mdr1.GetInt32(0);
                }

                string scad3 = "SELECT id_bodega from bodega";
                OdbcCommand mcd3 = new OdbcCommand(scad3, Conexion.ObtenerConexion());
                OdbcDataReader mdr3 = mcd3.ExecuteReader();

                while (mdr3.Read())
                {
                    codbodega = mdr3.GetInt32(0);

                    try
                    {
                        OdbcCommand mySqlComando = new OdbcCommand(
                        string.Format("INSERT INTO existencia_bodega (id_producto, id_marca, id_bodega, cantidad) values ('{0}','{1}','{2}','0')", codproducto, codmarca, codbodega),
                        seguridad.Conexion.ObtenerConexionODBC()
                        );
                        mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                        MessageBox.Show("Insertado existencia");
                    }
                    catch
                    {
                        MessageBox.Show("Error de insercion");          //si el try-catch encontro algun error indica mensaje de fracaso
                    }

                }

            } catch { MessageBox.Show("Debe llenar todos los campos"); }
                limpiar();
            deshabilitar();

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            entidades.Producto producto = new entidades.Producto();
            Int32 selectedRowCount =
            dgv_producto.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                producto.codigo = Convert.ToString(dgv_producto.CurrentRow.Cells[0].Value);
                negocio neg = new negocio();
                neg.EliminarProducto(producto);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dgv_producto);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dgv_producto);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dgv_producto);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dgv_producto);
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            llenarmarca();
            llenarcbo();
            limpiar();
            deshabilitar();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_producto.DataSource = cnegocio.consultaprod();
            cbo_cat.DataSource = null;
            cbo_marca.DataSource = null;
            llenarcbo();
            llenarmarca();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            deshabilitar();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
