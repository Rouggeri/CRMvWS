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
    public partial class frm_abonos : Form
    {
        public frm_abonos()
        {
            InitializeComponent();
        }

        string id_form = "121";
        public crm.entidades.factura FacturaActual { get; set; }
        public int conti = 0;
        private static OdbcCommand mySqlComando;
        private static OdbcDataAdapter mySqlDAdAdaptador;
        public int saldof = 0;
        public int cliente = 0;
        private void frm_abonos_Load(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            //textBox1.Clear();
            //textBox7.Clear();
            textBox2.Clear();
            textBox4.Clear();
            //textBox3.Clear();
            comboBox1.ResetText();
            textBox6.Clear();
            //textBox8.Clear();
            dtp1.ResetText();
        }

        private void habilitar()
        {
            //textBox1.Enabled = true;
            //textBox7.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            //textBox3.Enabled = true;
            comboBox1.Enabled = true;
            textBox6.Enabled = true;
            //textBox8.Enabled = true;
            dtp1.Enabled = true;
        }

        private void deshabilitar()
        {
            //textBox1.Enabled = false;
            //textBox7.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            //textBox3.Enabled = false;
            comboBox1.Enabled = false;
            textBox6.Enabled = false;
            //textBox8.Enabled = false;
            dtp1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            /*crm.negocio cnegocio = new crm.negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dataGridView1.DataSource = cnegocio.consultar();*/
            /*if (textBox8.Text != null)
            {
                int valida = 0;
                if (valida == 0)
                {
                    string nombre = "";
                    nombre = textBox8.Text;
                    int identi = 0;
                    DataTable id = new DataTable();
                    try
                    {
                        OdbcCommand mySqlComando = new OdbcCommand(
                                    string.Format("SELECT id_cliente FROM tbl_cliente WHERE nombres = '" + nombre + "'")
                                    , crm.Conexion.ObtenerConexion()
                            );

                        mySqlDAdAdaptador = new OdbcDataAdapter();
                        mySqlDAdAdaptador.SelectCommand = mySqlComando;
                        mySqlDAdAdaptador.Fill(id);
                        //dataGridView1.DataSource = id;
                        DataRow dt1 = id.Rows[0];
                        identi = Convert.ToInt32(dt1[0]);
                        //cliente = identi;
                        valida++;
                    }
                    catch (OdbcException exception)
                    {
                        MessageBox.Show(Convert.ToString(exception));
                    }
                    if (valida != 0)
                    {
                        int ct = 0;
                        DataTable cuenta = new DataTable();
                        try
                        {
                            OdbcCommand mySqlComando = new OdbcCommand(
                                        string.Format("SELECT SUM(factura_encabezado.total) AS Suma FROM factura_encabezado WHERE id_cliente ='" + identi + "'")
                                        , crm.Conexion.ObtenerConexion()
                                );

                            mySqlDAdAdaptador = new OdbcDataAdapter();
                            mySqlDAdAdaptador.SelectCommand = mySqlComando;
                            mySqlDAdAdaptador.Fill(cuenta);
                            //dataGridView1.DataSource = cuenta;
                            DataRow dt2 = cuenta.Rows[0];
                            ct = Convert.ToInt32(dt2[0]);
                            textBox4.Text = Convert.ToString(ct);
                            valida++;
                        }
                        catch (OdbcException exception)
                        {
                            MessageBox.Show(Convert.ToString(exception));
                        }
                    }
                }

            }*/
            int nueva = 0;
            if (comboBox2.Text != null)
            {
                int idcta = 0;

                int cta = 0;
                idcta = Convert.ToInt32(comboBox2.Text);
                DataTable cuenta = new DataTable();
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                                //string.Format("SELECT SUM(factura_encabezado.total) AS Suma FROM factura_encabezado WHERE id_cliente ='" + identificador + "'")
                                string.Format("SELECT total from factura_encabezado where id_factura ='" + idcta + "'")
                                , crm.Conexion.ObtenerConexion()
                        );

                    mySqlDAdAdaptador = new OdbcDataAdapter();
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;
                    mySqlDAdAdaptador.Fill(cuenta);
                    //dataGridView1.DataSource = cuenta;
                    DataRow dt2 = cuenta.Rows[0];
                    cta = Convert.ToInt32(dt2[0]);
                    saldof = cta;
                    nueva++;
                }
                catch (OdbcException exception)
                {
                    MessageBox.Show(Convert.ToString(exception));
                }
            }
            if (nueva != 0)
            {
                int idcta;
                idcta = Convert.ToInt32(comboBox2.Text);
                int abonos = 0;
                DataTable abono = new DataTable();
                try
                {
                    OdbcCommand mySqlComando = new OdbcCommand(
                                string.Format("SELECT SUM(abonos.abono) AS Suma FROM abonos WHERE id_factura = '" + idcta + "'")
                                , crm.Conexion.ObtenerConexion()
                        );

                    mySqlDAdAdaptador = new OdbcDataAdapter();
                    mySqlDAdAdaptador.SelectCommand = mySqlComando;
                    mySqlDAdAdaptador.Fill(abono);
                    //dataGridView1.DataSource = cuenta;
                    DataRow dt2 = abono.Rows[0];

                    if (dt2 != null)
                    {
                        abonos = Convert.ToInt32(dt2[0]);
                        conti++;
                        int totales = 0;
                        totales = saldof - abonos;
                        textBox4.Text = Convert.ToString(totales);
                    }
                    else
                    {
                        textBox4.Text = Convert.ToString(saldof);
                    }
                }
                catch (OdbcException exception)
                {
                    MessageBox.Show(Convert.ToString(exception));
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            crm.entidades.Abono abono = new crm.entidades.Abono();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            crm.negocio cnegocio = new crm.negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            abono.id_factura = textBox3.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            //abono.serie = textBox7.Text;
            abono.id_cliente = textBox5.Text;
            //abono.saldo_factura = Convert.ToDouble(textBox6.Text);
            //abono.forma_pago = textBox3.Text;
            abono.forma_pago = comboBox1.Text;
            abono.abono = Convert.ToDouble(textBox6.Text);
            abono.fecha = Convert.ToString(dtp1);
            cnegocio.InsertarAbono(abono);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            Cobros.frm_buscarfct BuscarFactura = new Cobros.frm_buscarfct();
            BuscarFactura.ShowDialog();
            if (BuscarFactura.facturaselec != null)
            {
                FacturaActual = BuscarFactura.facturaselec;
                textBox2.Text = BuscarFactura.facturaselec.nombre_cliente;
                textBox4.Text = BuscarFactura.facturaselec.saldo_factura;
                textBox3.Text = Convert.ToString(BuscarFactura.facturaselec.id_factura);
                textBox5.Text = Convert.ToString(BuscarFactura.facturaselec.id_cliente);
                //txt_telefono.Text = frm.ProveedorSeleccionado.
                comboBox1.Text = BuscarFactura.facturaselec.forma_pago;
                //txt_observaciones.Text = frm.ProveedorSeleccionado.observ_prov;
               // txt_nit.Text = frm.ProveedorSeleccionado.nit_prov;


            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            crm.negocio cnegocio = new crm.negocio();           //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            dataGridView1.DataSource = cnegocio.consultar();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            /*crm.entidades.Abono abono = new crm.entidades.Abono();  //Creamos un objeto de la capa de Entidades para poder acceder a sus objetos
            crm.negocio cnegocio = new crm.negocio();                       //Creamos un objeto de la capa de negocio para poder acceder a sus funciones
            abono.id_factura = textBox3.Text;                                //Llenamos el objeto persona con la informacion de los cuadros de texto/
            //abono.serie = textBox7.Text;
            abono.id_cliente = textBox5.Text;
            //abono.saldo_factura = Convert.ToDouble(textBox6.Text);
            //abono.forma_pago = textBox3.Text;
            abono.forma_pago = comboBox1.Text;
            abono.abono = Convert.ToDouble(textBox6.Text);
            abono.fecha = Convert.ToString(dtp1.Text);
            cnegocio.InsertarAbono(abono);                                    //Llamamos a la funcion Ninsertar a traves del objeto de la capa de negocio y le enviamos como parametro nuestro objeto persona
            limpiar();
            deshabilitar();*/
            int recibo = 0;
            string concepto = "";
            string recibode = "";
            string formap = "";
            int abonar = 0;
            string fecha = "";
            int inser = 0;
            int idfactura = 0;

            recibo = Convert.ToInt32(textBox1.Text);
            concepto = textBox7.Text;
            recibode = textBox2.Text;
            formap = comboBox1.Text;
            abonar = Convert.ToInt32(textBox6.Text);
            fecha = dtp1.Text;
            idfactura = Convert.ToInt32(comboBox2.Text);
            if (textBox8.Text == null)
            {
                string cte = "";
                cte = textBox8.Text;
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
                    MessageBox.Show(Convert.ToString(identificador));
                    inser++;
                    if (inser != 0)
                    {
                        try
                        {
                            mySqlComando = new OdbcCommand(
                            string.Format("Insert into abonos (id_cliente, no_recibo, forma_pago, abono, fecha, concepto, recibo_de, id_factura) values ('{0}','{1}','{2}','{3}','{4}', '{5}','{6}','{7}')", cliente, recibo, formap, abonar, fecha, concepto, recibode, idfactura),
                             crm.Conexion.ObtenerConexion()
                            );                                              //se realiza el query con los datos que ser recibieron del objeto persona
                            mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                            MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
                            textBox8.Clear();
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox4.Clear();
                            textBox3.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox7.Clear();
                            comboBox1.ResetText();
                            comboBox2.ResetText();
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));          //si el try-catch encontro algun error indica mensaje de fracaso
                        }
                    }
                }
                catch (OdbcException exception)
                {
                    MessageBox.Show(Convert.ToString(exception));
                }


            }
            else
            {
                if(textBox8.Text != null)
                {
                    string cte = "";
                    cte = textBox8.Text;
                    int identificador = 0;
                    int nulo = 0;
                    int idfact = 0;
                    idfact = Convert.ToInt32(comboBox2.Text);
                    if(nulo == 0)
                    { 
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
                            MessageBox.Show(Convert.ToString(identificador));
                            nulo++;
                        }
                        catch (OdbcException ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                   }
                    if (nulo != 0)
                    {
                    
                        try
                    {
                        mySqlComando = new OdbcCommand(
                        string.Format("Insert into abonos (id_cliente, no_recibo, forma_pago, abono, fecha, concepto, recibo_de, id_factura) values ('{0}','{1}','{2}','{3}','{4}', '{5}','{6}', '{7}')", cliente, recibo, formap, abonar, fecha, concepto, recibode, idfact),
                         crm.Conexion.ObtenerConexion()
                        );                                              //se realiza el query con los datos que ser recibieron del objeto persona
                        mySqlComando.ExecuteNonQuery();                 //se ejecuta el query
                        MessageBox.Show("Se inserto con exito");        //si el try-catch no encontro algun error se muestra el mensaje de transaccion exitosa
                        textBox8.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox4.Clear();
                        textBox3.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        comboBox1.ResetText();
                        comboBox2.ResetText();
                        

                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));          //si el try-catch encontro algun error indica mensaje de fracaso
                    }
                    }
                }
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Cobros.frm_buscarfct BuscarFactura = new Cobros.frm_buscarfct();
            BuscarFactura.ShowDialog();
            if (BuscarFactura.facturaselec != null)
            {
                FacturaActual = BuscarFactura.facturaselec;
                textBox2.Text = BuscarFactura.facturaselec.nombre_cliente;
                textBox4.Text = BuscarFactura.facturaselec.saldo_factura;
                textBox3.Text = Convert.ToString(BuscarFactura.facturaselec.id_factura);
                textBox5.Text = Convert.ToString(BuscarFactura.facturaselec.id_cliente);
                //txt_telefono.Text = frm.ProveedorSeleccionado.
                comboBox1.Text = BuscarFactura.facturaselec.forma_pago;
                //txt_observaciones.Text = frm.ProveedorSeleccionado.observ_prov;
                // txt_nit.Text = frm.ProveedorSeleccionado.nit_prov;*/
            if(textBox8.Text != null)
            {
                if (conti == 0)
                {
                    string cte = "";
                    cte = textBox8.Text;
                    int identificador = 0;
                    int documento = 0;
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
                        documento++;

                        if(documento != 0)
                        {
                            DataTable idocumento = new DataTable();
                            try
                            {
                                 
                            OdbcCommand mySqlComando22 = new OdbcCommand(
                                    string.Format("SELECT id_factura FROM factura_encabezado WHERE id_cliente = '" + cliente + "'")
                                    , crm.Conexion.ObtenerConexion()
                            );

                            mySqlDAdAdaptador = new OdbcDataAdapter();
                            mySqlDAdAdaptador.SelectCommand = mySqlComando22;
                            mySqlDAdAdaptador.Fill(idocumento);
                            
                            comboBox2.DataSource =idocumento;
                                comboBox2.DisplayMember = "id_factura";
                                comboBox2.ValueMember = "id_factura";
                            } catch (OdbcException ex)
                            {
                                MessageBox.Show(Convert.ToString(ex));
                            }
                            //dataGridView1.DataSource = id;
                            //DataRow dt5 = idocumento.Rows[0];
                            //documento = Convert.ToInt32(dt5[0]);
                            //cliente = identificador;
                            //conti++;
                        }
                    }
                    catch (OdbcException exception)
                    {
                        MessageBox.Show(Convert.ToString(exception));
                    }
                   
                    }                   
                }
            }

        }

        

        /*private void btn_anterior_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Anterior(dataGridView1);
        }

        private void btn_siguiente_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Siguiente(dataGridView1);
        }

        private void btn_primero_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Primero(dataGridView1);
        }

        private void btn_ultimo_Click(object sender, EventArgs e)
        {
            CapaNegocio fn = new CapaNegocio();
            fn.Ultimo(dataGridView1);
        }*/
    }

