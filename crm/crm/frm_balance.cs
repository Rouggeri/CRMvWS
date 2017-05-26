using MySql.Data.MySqlClient;
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
    public partial class BALANCE : Form
    {
        public BALANCE()
        {
            InitializeComponent();
        }
        public crm.entidades.factura FacturaActual { get; set; }
        private static OdbcCommand mySqlComando;
        private static OdbcDataAdapter mySqlDAdAdaptador;
        string id_form = "122";

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            crm.frm_buscarfct BuscarFactura = new crm.frm_buscarfct();
            BuscarFactura.ShowDialog();
            int result = 0;
            string abono = "";
            if (BuscarFactura.facturaselec != null)
            {
                FacturaActual = BuscarFactura.facturaselec;
                textBox2.Text = BuscarFactura.facturaselec.nombre_cliente;
                textBox3.Text = BuscarFactura.facturaselec.saldo_factura;
                textBox1.Text = Convert.ToString(BuscarFactura.facturaselec.id_factura);
                //textBox5.Text = Convert.ToString(BuscarFactura.facturaselec.id_cliente);
                //txt_telefono.Text = frm.ProveedorSeleccionado.
                //textBox4.Text = BuscarFactura.facturaselec.forma_pago;
                //txt_observaciones.Text = frm.ProveedorSeleccionado.observ_prov;
                // txt_nit.Text = frm.ProveedorSeleccionado.nit_prov;

                result++;
                if (result != 0)
                {
                    DataTable dtAbono = new DataTable();
                    try
                    {
                        mySqlComando = new OdbcCommand(
                             string.Format("SELECT SUM(abonos.abono) AS Suma FROM abonos WHERE abonos.id_factura ='"+textBox1.Text+"'"),
                             seguridad.Conexion.ObtenerConexionODBC()
                         );                                                  //se realiza el query para la consulta de todos los registros de la tabla persona           
                        mySqlDAdAdaptador = new OdbcDataAdapter();          //se crea un sqlDataAdaptor 
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;      //ejecutamos el query de consulta
                        mySqlDAdAdaptador.Fill(dtAbono);                 //poblamos el sqlDataAdaptor con el resultado del query
                        

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("No es posible obtener el cliente", "Error al Realizar la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    //abono = Convert.ToString(dtAbono.Rows[0].ToString());
                    DataRow dt1 = dtAbono.Rows[0];
                    abono = Convert.ToString(dt1[0]);
                    MessageBox.Show(abono);
                    dataGridView1.DataSource = dtAbono;
                    result++;
                    textBox4.Text = Convert.ToString(abono);
                    //return dtAbono; //retornamos el sqlDataAdaptor con los datos del query
                    if (result >= 2)
                    {
                        int diferencia = 0;
                        int total = 0;
                        int abonos = 0;
                        int.TryParse(textBox3.Text, out total);
                        int.TryParse(textBox4.Text, out abonos);
                        diferencia = total - abonos;
                        textBox5.Text = diferencia.ToString();
                        if (diferencia == 0)
                        {
                            textBox6.Text = "Cancelado";
                        }
                        else
                        {
                            textBox6.Text = "Credito";
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {        }

        private void frm_balance_Load(object sender, EventArgs e)
        {

        }
    }
}
