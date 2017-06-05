using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoUOne
{
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
            LLenarTabla();
            //Existencia();
        }
       
        private void txt_buscarP_TextChanged(object sender, EventArgs e)
        {
            /*try
            {*/

                if (!String.IsNullOrEmpty(txt_buscarP.Text))
                {
                    BuscarSelect();
                   
                }
                else
                {
                    LLenarTabla();
                    
                }
            /*}
            catch {
                MessageBox.Show("Error en TextCahnged");
            }*/
            
        }

        
        public void BuscarSelect(){
            /*try
            {*/
                int constan = Convert.ToInt32(txt_ratos.Text);
                string letra = Convert.ToString(txt_buscarP.Text);
                //DataTable carga = CapaDatos.CargarGridAutoIncrement("select p.id, p.nombre, p.existencia, pr.precio, pr.id_bien, pr.id_tipo FROM producto p inner JOIN precio pr ON p.id = pr.id_bien WHERE pr.id_tipo='"+constan+"' and p.id like '%"+txt_buscarP.Text+"%' or pr.id_tipo='"+constan+"' and p.nombre like '%"+txt_buscarP.Text+"%'");
                DataTable carga = CapaDatos.CargaProducto(constan, letra);
                dgv_productosVista.DataSource = carga;
    
            /*}
            catch {
                MessageBox.Show("Error al cargar busqueda");
            }*/
            }

        public string codigoP;
        public string decripcionP;
        public string precioUP;
        public string SubtotalP;

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo para llenar combobox Existencia
        public void Existencia()
        {
            /*try
            {*/
                string enviaIdProd = dgv_productosVista.CurrentRow.Cells[0].Value.ToString();
                string enviaIdMarca = dgv_productosVista.CurrentRow.Cells[5].Value.ToString();
                txt_codigo.Text = enviaIdProd;
                txt_marca.Text = enviaIdMarca;
                
                DataTable exis = new DataTable();
                exis = CapaDatos.Existencia(enviaIdProd, enviaIdMarca);
                cmb_existencia.DataSource = exis;
                cmb_existencia.ValueMember = "cantidad";
                cmb_existencia.DisplayMember = "cantidad";
            /*}
            catch
            {
                MessageBox.Show("No existe ningun existencia...");
            }*/
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            LLenarTabla();
              
        }

        public void LLenarTabla() {
            /*try
            {*/
                string constant = Convert.ToString(txt_ratos.Text);
                //DataTable carga = CapaDatos.CargarGridAutoIncrement("select p.id_producto, p.nombre, pr.precio, pr.id_bien, pr.id_tipo, pr.id_marca FROM producto p INNER JOIN precio pr ON p.id_producto = pr.id_bien  WHERE pr.id_tipo ='"+constan+"' ORDER BY p.nombre ASC");
                DataTable carga = CapaDatos.CargaProducto2(constant);
                dgv_productosVista.DataSource = carga;
            
            /*}
            catch {
                MessageBox.Show("Error al cargar el formularios");
            }*/
        }

        private void btn_prueba_Click(object sender, EventArgs e)
        {
            Existencia();
        }


        private void dgv_productosVista_CurrentCellChanged(object sender, EventArgs e)
        {
            //Existencia();
        }
    }
}
