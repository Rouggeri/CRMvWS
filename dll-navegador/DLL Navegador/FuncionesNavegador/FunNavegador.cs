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


namespace FuncionesNavegador
{
    public class FunNavegador
    {
        public void activartextbox(TextBox textbox)
        {
            textbox.Enabled = true;
        }

        public void desactivartextbox(TextBox textbox)
        {
            textbox.Enabled = false;
        }

        public void insertar(DataTable datos, string tabla)
        {
            Conexionmysql.ObtenerConexion();
            string query1 = "insert into " + tabla + " (";
            string query2 = "values (";
            int cuentaFilas = datos.Rows.Count;
            DataRow contenido;
            for (int fila = 0; fila < cuentaFilas; fila++)
            {
                contenido = datos.Rows[fila];
                query1 = query1 + contenido["Columna"].ToString();
                query2 = query2 + "'" + contenido["Valor"].ToString() + "'";
                if (fila!=(cuentaFilas-1))
                {
                    query1 = query1 + ", ";
                    query2 = query2 + ", ";
                }
            }
            string query = query1 + ") " + query2 + ");";
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se inserto el registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }

        public DataTable construirDataTable(TextBox[] textbox)
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("Columna", typeof(string));
            datos.Columns.Add("Valor", typeof(string));
            DataRow fila;
            foreach (TextBox tb in textbox)
            {
                fila = datos.NewRow();
                fila["Columna"] = tb.Tag.ToString();
                fila["Valor"] = tb.Text;
                if (tb.Text == "")
                {
                    datos.Clear();
                    return datos;
                }
                datos.Rows.Add(fila);
            }
            return datos;
        }

        public void modificar(DataTable datos, string tabla,string atributo,string comparar)
        {
            Conexionmysql.ObtenerConexion();
            string query1 = "UPDATE  " + tabla + " SET ";
            string igual = "=";
            string comilla="";
           
            string query2 = " WHERE " +atributo+ "=" ;
            int cuentaFilas = datos.Rows.Count;
            DataRow contenido;
            for (int fila = 0; fila < cuentaFilas; fila++)
            {
                contenido = datos.Rows[fila];
                query1 = query1 + comilla + contenido["Columna"].ToString() + igual + comilla + "'" + contenido["Valor"].ToString() +"'";
                //query2 = query2 + "'" + contenido["Valor"].ToString() + "'";
                if (fila != (cuentaFilas - 1))
                {
                    query1 = query1 + ", ";
                   // query2 = query2 + ", ";
                }
            }
            string query = query1 + query2 + "'" + comparar+"'"+ ";";
            //MessageBox.Show(query);
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se realizo la modificacion del registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }

        public void eliminar(string tabla, string atributo, string codigo)
        {
            string estado = "INACTIVO";
            string igual = "=";
            string comillas = "";
            string query = "UPDATE " + tabla + " SET estado =" + "'" + estado +"'" + " WHERE " + comillas +atributo + igual +comillas+ "'"+codigo +"'"+";";
           // MessageBox.Show(query);
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se realizo la eliminacion del registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }
        public void ActualizarGrid(DataGridView dg, String Query, string tabla)
        {
            Conexionmysql.ObtenerConexion();
            //crear DataSet
            System.Data.DataSet MiDataSet = new System.Data.DataSet();
            //Crear Adaptador de datos
            OdbcDataAdapter MiDataAdapter = new OdbcDataAdapter(Query, Conexionmysql.ObtenerConexion());
            //LLenar el DataSet
            MiDataAdapter.Fill(MiDataSet, tabla);
            //Asignarle el valor adecuado a las propiedades del DataGrid
            dg.DataSource = MiDataSet;
            dg.DataMember = tabla;
            //nos desconectamos de la base de datos...
            Conexionmysql.Desconectar();
        }


        public int Siguiente(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int valor = datagridview.CurrentCell.RowIndex;
                int max = datagridview.Rows.Count - 2;
                valor = valor + 1;
                if (valor <= max)
                {
                    datagridview.Rows[valor].Selected = true;
                    datagridview.CurrentCell = datagridview.Rows[valor].Cells[0];
                }
                else { MessageBox.Show("ULTIMO REGISTRO"); }
                return 0;
            }
            else
            {
                MessageBox.Show("NO HAY DATOS");
                return 0;
            }
        }


        public int Anterior(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int valor = datagridview.CurrentCell.RowIndex;
                int max = datagridview.Rows.Count - 2;
                valor = valor - 1;
                if (valor >= 0)
                {
                    datagridview.Rows[valor].Selected = true;
                    datagridview.CurrentCell = datagridview.Rows[valor].Cells[0];
                }
                else { MessageBox.Show("PRIMER REGISTRO"); }
                return 0;
            }
            else
            {
                MessageBox.Show("NO HAY DATOS");
                return 0;
            }
        }


        public int Ultimo(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int max = datagridview.Rows.Count - 2;
                datagridview.Rows[max].Selected = true;
                datagridview.CurrentCell = datagridview.Rows[max].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("NO HAY REGISTROS");
                return 0;
            }
        }

        public int Primero(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                datagridview.Rows[0].Selected = true;
                datagridview.CurrentCell = datagridview.Rows[0].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("NO HAY REGISTROS");
                return 0;
            }
        }

        public void LimpiarTextbox(TextBox textbox)
        {
            textbox.Text = "";
        }

        public void LimpiarCombobox(ComboBox combobox)
        {
            combobox.Text = "";
        }

        public ComboBox llenarCbo(string Query, string tabla, ComboBox cbo, string valor, string mostrar)
        {
            //se realiza la conexión a la base de datos
            Conexionmysql.ObtenerConexion();
            //se inicia un DataSet
            DataSet ds = new DataSet();
            //se indica la consulta en sql
            String Query1 = Query;
            OdbcDataAdapter dad = new OdbcDataAdapter(Query1, Conexionmysql.ObtenerConexion());
            //se indica con quu tabla se llena
            dad.Fill(ds, tabla);
            cbo.DataSource = ds.Tables[0].DefaultView;
            //indicamos el valor de los miembros
            cbo.ValueMember = (valor);
            //se indica el valor a desplegar en el combobox
            cbo.DisplayMember = (mostrar);
            return cbo;
        }

        public void llenartextbox(TextBox[] textbox, DataGridView datagridview)
        {
            int cantidadcolumnas = datagridview.Columns.Count;
            DataGridViewColumn contenido;
            foreach (TextBox tb in textbox)
            {
                for(int i = 0; i < cantidadcolumnas; i++)
                {
                    contenido = datagridview.Columns[i];
                    if (tb.Tag.ToString() == contenido.HeaderText.ToString())
                    {
                        tb.Text = datagridview.CurrentRow.Cells[i].Value.ToString();
                    }
                }
            }
        }
    }
}
