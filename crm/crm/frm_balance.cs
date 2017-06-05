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

namespace Cobros
{
    public partial class frm_balance : Form
    {
        public frm_balance()
        {
            InitializeComponent();
        }
        public crm.entidades.factura FacturaActual { get; set; }
        private static OdbcCommand mySqlComando;
        private static OdbcDataAdapter mySqlDAdAdaptador;
        public int conti = 0;
        public int saldof = 0;
        public int cliente = 0;
        public int totales = 0;


        private void button2_Click(object sender, EventArgs e)
        {
            /*frm_buscarfct BuscarFactura = new frm_buscarfct();
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
                             string.Format("SELECT SUM(abonos.abono) AS Suma FROM abonos WHERE abonos.id_factura ='" + textBox1.Text + "'"),
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
            }*/


            if (textBox2.Text != null)
            {
                if (conti == 0)
                {
                    string cte = "";
                    cte = textBox2.Text;
                    int identificador = 0;
                    DataTable id = new DataTable();
                    try
                    {
                        OdbcCommand mySqlComando = new OdbcCommand(
                                    string.Format("SELECT id_cliente FROM tbl_cliente WHERE nombres = '" + cte + "'")
                                    , crm.Conexion.ObtenerConexion()
                            );

                        mySqlDAdAdaptador = new OdbcDataAdapter();
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;
                        mySqlDAdAdaptador.Fill(id);
                        //dataGridView1.DataSource = id;
                        DataRow dt1 = id.Rows[0];
                        identificador = Convert.ToInt32(dt1[0]);
                        cliente = identificador;
                        conti++;

                    }
                    catch (OdbcException exception)
                    {
                        MessageBox.Show(Convert.ToString(exception));
                    }
                    if (conti != 0)
                    {
                        int cta = 0;
                        DataTable cuenta = new DataTable();
                        try
                        {
                            OdbcCommand mySqlComando = new OdbcCommand(
                                        string.Format("SELECT SUM(factura_encabezado.total) AS Suma FROM factura_encabezado WHERE id_cliente ='" + identificador + "'")
                                        , crm.Conexion.ObtenerConexion()
                                );

                            mySqlDAdAdaptador = new OdbcDataAdapter();
                            mySqlDAdAdaptador.SelectCommand = mySqlComando;
                            mySqlDAdAdaptador.Fill(cuenta);
                            //dataGridView1.DataSource = cuenta;
                            DataRow dt2 = cuenta.Rows[0];
                            cta = Convert.ToInt32(dt2[0]);
                            saldof = cta;
                            textBox3.Text = Convert.ToString(cta);
                            conti++;
                        }
                        catch (OdbcException exception)
                        {
                            MessageBox.Show(Convert.ToString(exception));
                        }
                    }
                    if (conti > 1)
                    {
                        int abonos = 0;
                        DataTable abono = new DataTable();
                        try
                        {
                            OdbcCommand mySqlComando = new OdbcCommand(
                                        string.Format("SELECT SUM(abonos.abono) AS Suma FROM abonos WHERE id_cliente = '" + identificador + "'")
                                        , crm.Conexion.ObtenerConexion()
                                );

                            mySqlDAdAdaptador = new OdbcDataAdapter();
                            mySqlDAdAdaptador.SelectCommand = mySqlComando;
                            mySqlDAdAdaptador.Fill(abono);
                            //dataGridView1.DataSource = cuenta;
                            DataRow dt2 = abono.Rows[0];
                            abonos = Convert.ToInt32(dt2[0]);
                            textBox4.Text = Convert.ToString(abonos);
                            conti++;
                            
                            totales = saldof - abonos;
                            textBox5.Text = Convert.ToString(totales);

                            //textBox4.Text = Convert.ToString(saldof);
                        }
                        catch (OdbcException exception)
                        {
                            MessageBox.Show(Convert.ToString(exception));
                        }
                    }if (totales == 0)
                    {
                        textBox6.Text = "Cancelada";
                    }
                    else
                    {
                        if (totales != 0)
                        {
                            textBox6.Text = "Pendiente";
                        }
                    }
                }
            }
        }
        private void frm_balance_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
