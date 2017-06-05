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
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Grid;
using FuncionesNavegador;

namespace crm
{
    public partial class frm_NuevoEmpleado : Form
    {
        public frm_NuevoEmpleado()
        {
            InitializeComponent();
        }

        // variable globales:
        String direccionima ;
        String codigoemp = "";
        CapaDatosPersonas empleados = new CapaDatosPersonas();
        string id_form = "111";

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        // Boton para examinar la imagen de empleado
        private void btn_examinar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opcion = new OpenFileDialog();
                opcion.InitialDirectory = "C:\\ProyectoCRM\\Usuarios";
                DialogResult mensaje = opcion.ShowDialog();

                //opcion.FileName = "";

                if (mensaje == DialogResult.OK)
                {
                    pcb_empleado.Image = Image.FromFile(opcion.FileName);
                    direccionima = opcion.FileName;

                    //txt_direccion.Text = opcion.FileName;


                }

                // ---------------------
                //OpenFileDialog BuscarImagen = new OpenFileDialog();
                //BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
                ////Aquí incluiremos los filtros que queramos.
                //BuscarImagen.FileName = "";
                ////BuscarImagen.Title = "Titulo del Dialogo";
                ////BuscarImagen.InitialDirectory = "C:\\";
                //BuscarImagen.FileName = this.txt_direccion.Text;
                //if (BuscarImagen.ShowDialog() == DialogResult.OK)
                //{
                //    /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                //    this.txt_direccion.Text = BuscarImagen.FileName;
                //    String Direccion = BuscarImagen.FileName;
                //    this.pcb_empleado.ImageLocation = Direccion;
                //    //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
                //    //this.pictureBox1.ImageLocation = textBox1.Text;
                //    //pcb_empleado.SizeMode = PictureBoxSizeMode.StretchImage;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        // Boton guardar informacion
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txt_apellidos.Text == "" || txt_correo.Text == "" || txt_direccion.Text == "" || txt_movil.Text == "" || txt_nombres.Text == "" || txt_puesto.Text == "" || txt_telefono.Text == "")
                {

                    MessageBox.Show("Usuario no ingresado, Uno o más campos estan vacíos","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else {
                    // agregar mas "\" para que los acepte mysql 
                    direccionima = direccionima.Replace("\\", "\\\\");

                    empleados.InsertarEmpleado(txt_nombres.Text.Trim(), txt_apellidos.Text.Trim(), txt_puesto.Text.Trim(),
                    txt_telefono.Text.Trim(), txt_movil.Text.Trim(), txt_direccion.Text.Trim(), txt_correo.Text, direccionima);

                    // actualizar datos despues de insertar

                    MessageBox.Show("Empleado Ingresado existosamente","Ingreso correcto",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

                    DataTable almacen = new DataTable();
                    almacen = empleados.ConsultarEmpleados();
                    dgv_empleado.DataSource = almacen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        // cargar formulario de empleados
        private void frm_NuevoEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                CapaNegocio fn = new CapaNegocio();
                DataTable seg = seguridad.ObtenerPermisos.Permisos(seguridad.Conexion.User, id_form);
                if (seg.Rows.Count > 0)
                {
                    fn.desactivarPermiso(seg, btn_guardar, btn_eliminar, btn_editar, btn_nuevo, btn_cancelar, btn_actualizar, btn_buscar, btn_anterior, btn_siguiente, btn_primero, btn_ultimo);
                }
                else
                {
                    btn_guardar.Enabled = false; btn_eliminar.Enabled = false; btn_editar.Enabled = false; btn_nuevo.Enabled = false; btn_actualizar.Enabled = false; btn_cancelar.Enabled = false; btn_buscar.Enabled = false;
                }


                DataTable almacen = new DataTable();
                almacen = empleados.ConsultarEmpleados();
                dgv_empleado.DataSource = almacen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // boton nuevo registro
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                pcb_empleado.Image = null;
                txt_nombres.Text = "";
                txt_apellidos.Text = "";
                txt_direccion.Text = "";
                txt_correo.Text = "";
                txt_movil.Text = "";
                txt_puesto.Text = "";
                txt_telefono.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // boton modificar registro
        private void btn_editar_Click(object sender, EventArgs e)
        {

            try
            {
                var opcion = MessageBox.Show("¿Esta seguro de modificar el registro?", "Modificar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    // envio de parametros a ser modificados
                    direccionima = direccionima.Replace("\\", "\\\\");
                    empleados.ModificarEmpleado(txt_nombres.Text.Trim(), txt_apellidos.Text.Trim(), txt_puesto.Text.Trim(), txt_telefono.Text.Trim(),
                        txt_movil.Text.Trim(), txt_direccion.Text.Trim(), txt_correo.Text.Trim(), direccionima, codigoemp);

                    // carga de datagrid
                    DataTable contenedor = empleados.ConsultarEmpleados();
                    dgv_empleado.DataSource = contenedor;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // gridchart de empleados activos
        private void dgv_empleado_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear vector:
                int[] vector = ((GridView)dgv_empleado.MainView).GetSelectedRows();
                // Seleccionar las areas que tomará el vector del grid
                DataRowView nombres = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView apellidos = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView direccion = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView puesto = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView movil = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView telefono = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView correo = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView id_empleado = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));
                DataRowView foto = (DataRowView)(((GridView)dgv_empleado.MainView).GetRow(vector[0]));

                // asignacion de partes de vectores en cajas de texto
                txt_nombres.Text = nombres["nombres"].ToString();
                txt_apellidos.Text = apellidos["apellidos"].ToString();
                txt_direccion.Text = nombres["direccion"].ToString();
                txt_puesto.Text = apellidos["puesto"].ToString();
                txt_movil.Text = nombres["movil"].ToString();
                txt_telefono.Text = apellidos["telefono1"].ToString();
                txt_correo.Text = correo["correo"].ToString();
                codigoemp = id_empleado["id_empleado"].ToString();
                direccionima = foto["foto"].ToString();

                pcb_empleado.ImageLocation = direccionima;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var opcion = MessageBox.Show("¿Esta seguro de eliminar el registro?", "Eliminar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    empleados.EliminarEmpleado(codigoemp);

                    // carga de datos actualizados
                    DataTable contenedor = empleados.ConsultarEmpleados();
                    dgv_empleado.DataSource = contenedor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            frm_moneda moneda = new frm_moneda();
            moneda.Show();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_estadistica_personal personal = new frm_estadistica_personal();
            personal.Show();
        }
    }
}
