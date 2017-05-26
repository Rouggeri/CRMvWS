using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class frm_categoria : Form
    {
        public frm_categoria()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            entidades.Categoria categoria = new entidades.Categoria();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            negocio cnegocio = new negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            categoria.nombre = txt_nombre.Text; //Llenamos el objeto persona con la informacion de los cuadros de texto/
            cnegocio.InsertarCategoria(categoria);
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            negocio cnegocio = new negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dgv_categoria.DataSource = cnegocio.consultacat();
        }

        private void frm_categoria_Load(object sender, EventArgs e)
        {

        }
    }
}
