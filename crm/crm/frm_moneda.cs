using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;


namespace crm
{
    public partial class frm_moneda : Form
    {
        public frm_moneda()
        {
            InitializeComponent();
        }
        string id_form = "109";
        CapaDatosPersonas moneda = new CapaDatosPersonas();
        string simbolo = "";
        string id_mone = "";

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_nueva_moneda nueva_moneda = new frm_nueva_moneda();
            nueva_moneda.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }


        // form load carga monedas
        private void frm_moneda_Load(object sender, EventArgs e)
        {
            pcb_balanza.Image = Image.FromFile("balanza.jpg");

            DataTable carga = new DataTable();
            carga = moneda.carga_combox_monedas();
            cmb_moneda.DataSource = carga;
            cmb_moneda.ValueMember = "id_moneda";
            cmb_moneda.DisplayMember = "nombre";
           
            
        }



        private void cmb_moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (cmb_moneda.SelectedValue.ToString() == "System.Data.DataRowView" ||cmb_moneda.SelectedValue.ToString()=="")
            {
                //MessageBox.Show("error");
            }
            else
            {
                
                DataTable caja = new DataTable();
                moneda.seleccion_moneda_simbolo(cmb_moneda.SelectedValue.ToString());
                caja = moneda.seleccion_moneda_simbolo(cmb_moneda.SelectedValue.ToString());
                DataRow casilla = caja.Rows[0];
                simbolo = casilla["simbolo"].ToString();
                txt_simbolo.Text = simbolo;


            }



        }
        //boton guardar

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_moneda.SelectedValue.ToString() == "" || txt_vactual.Text == "")
                {
                    MessageBox.Show("Valor de moneda no ingresado, uno o mas campos estan vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    moneda.Insertar_valor_moneda(txt_vactual.Text.Trim(), cmb_moneda.SelectedValue.ToString());
                    MessageBox.Show("Valor de moneda ingresado con exito", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }


            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        // boton actualizar
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DataTable carga = new DataTable();
            carga = moneda.carga_combox_monedas();
            cmb_moneda.DataSource = carga;
            cmb_moneda.ValueMember = "id_moneda";
            cmb_moneda.DisplayMember = "nombre";
        }
    }
}
