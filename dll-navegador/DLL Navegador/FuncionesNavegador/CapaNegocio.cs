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
    public class CapaNegocio
    {
        public int cc;

        #region insertar
        public void insertar(DataTable datos, string tabla)
        {
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
            CapaDatos.insertar(query);
        }
        #endregion

        #region Crear DataTable para procesos
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
        #endregion

        #region Modificar
        public void modificar(DataTable datos, string tabla,string atributo,string comparar)
        {
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
            CapaDatos.modificar(query);
        }
        #endregion

        #region eliminar
        public void eliminar(string tabla, string atributo, string codigo)
        {
            string estado = "INACTIVO";
            string igual = "=";
            string comillas = "";
            string query = "UPDATE " + tabla + " SET estado =" + "'" + estado +"'" + " WHERE " + comillas +atributo + igual +comillas+ "'"+codigo +"'"+";";
            CapaDatos.eliminar(query);
        }
        #endregion

        #region Botones de navegacion

        #region Boton Siguiente
        public void Siguiente(DataGridView datagridview)
        {
            CapaDatos.Siguiente(datagridview);
        }
        #endregion

        #region Boton Anterior
        public void Anterior(DataGridView datagridview)
        {
            CapaDatos.Anterior(datagridview);
        }
        #endregion

        #region Boton Ultimo
        public void Ultimo(DataGridView datagridview)
        {
            CapaDatos.Ultimo(datagridview);
        }
        #endregion

        #region Boton Primero
        public void Primero(DataGridView datagridview)
        {
            CapaDatos.Primero(datagridview);
        }
        #endregion

        #region llenarTextbox
        public void llenartextbox(TextBox[] textbox, DataGridView datagridview)
        {
            int cantidadcolumnas = datagridview.Columns.Count;
            DataGridViewColumn contenido;
            foreach (TextBox tb in textbox)
            {
                for (int i = 0; i < cantidadcolumnas; i++)
                {
                    contenido = datagridview.Columns[i];
                    if (tb.Tag.ToString() == contenido.HeaderText.ToString())
                    {
                        tb.Text = datagridview.CurrentRow.Cells[i].Value.ToString();
                    }
                }
            }
        }
        #endregion

        #endregion

        #region limpiar 
        public void LimpiarTextbox(TextBox textbox)
        {
            textbox.Text = "";
        }

        public void LimpiarCombobox(ComboBox combobox)
        {
            combobox.Text = "";
        }
        #endregion

        #region LlenarCombobox
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
        #endregion

        #region Llenar Datagrid
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
        #endregion


        //MANEJO DE CONTROLES
        #region Abilitar/Inhabilidat Controles

        public void desactivarPermiso(DataTable datos, Button guardar, Button eliminar, Button modificar, Button nuevo, Button cancelar, Button refrescar, Button buscar, Button anterior, Button siguiente, Button primero, Button ultimo)
        {
            DataRow permisos = datos.Rows[0];
            int insertar = Convert.ToInt32(permisos[0]);
            int seleccionar = Convert.ToInt32(permisos[1]);
            int actualizar = Convert.ToInt32(permisos[2]);
            int eliminar1 = Convert.ToInt32(permisos[3]);

            if (insertar == 0)
            {
                ControlButton(nuevo, false);
                ControlButton(guardar, false);
            }
            else
            {
                ControlButton(nuevo, true);
                ControlButton(guardar, true);
            }

            if (seleccionar == 0)
            {
                ControlButton(buscar, false);
                ControlButton(refrescar, false);
            }
            else
            {
                ControlButton(buscar, true);
                ControlButton(refrescar, true);
            }

            if (actualizar == 0)
            {
                ControlButton(modificar, false);
            }
            else
            {
                ControlButton(modificar, true);
            }

            if (eliminar1 == 0)
            {
                ControlButton(eliminar, false);
            }
            else
            {
                ControlButton(eliminar, true);
            }
        }

        public void ControlTextbox(TextBox txtboxnuevo, Boolean estado)
        {
            CapaDatos.FunControlTextbox(txtboxnuevo, estado);
        }

        public void ControlButton(Button buttonnueo, Boolean estado)
        {
            CapaDatos.FunControlButton(buttonnueo, estado);
        }

        public void ControlCheckBox(CheckBox checkbox, Boolean estado)
        {
            CapaDatos.FunControlCheckBox(checkbox, estado);
        }

        public void ControlCheckedListBox(CheckedListBox checkedlistbox, Boolean estado)
        {
            CapaDatos.FunControlCheckedListBox(checkedlistbox, estado);
        }

        public void ControlComboBox(ComboBox combobox, Boolean estado)
        {
            CapaDatos.FunControlComboBox(combobox, estado);
        }

        public void ControlDateTimePicker(DateTimePicker datetimepicker, Boolean estado)
        {
            CapaDatos.FunControlDateTimePicker(datetimepicker, estado);
        }

        public void ControlListBox(ListBox listbox, Boolean estado)
        {
            CapaDatos.FunControlListBox(listbox, estado);
        }

        public void ControlListView(ListView listview, Boolean estado)
        {
            CapaDatos.FunControlListView(listview, estado);
        }

        public void ControlNumericUpDown(NumericUpDown numericupdown, Boolean estado)
        {
            CapaDatos.FunControlNumericUpDown(numericupdown, estado);
        }

        public void ControlPictureBox(PictureBox picturebox, Boolean estado)
        {
            CapaDatos.FunControlPictureBox(picturebox, estado);
        }

        public void ControlRadioButton(RadioButton radiobutton, Boolean estado)
        {
            CapaDatos.FunControlRadioButton(radiobutton, estado);

        }

        public void ControlDataGridView(DataGridView datagridview, Boolean estado)
        {
            CapaDatos.FunControlDataGridView(datagridview, estado);

        }

        public void ActivarControles(Control actv)
        {
            foreach (Control c in actv.Controls)
            {
                if (c is Button)
                    ((Button)c).Enabled = true;

                if (c is CheckBox)
                    ((CheckBox)c).Enabled = true;

                if (c is CheckedListBox)
                    ((CheckedListBox)c).Enabled = true;

                if (c is ComboBox)
                    ((ComboBox)c).Enabled = true;

                if (c is DateTimePicker)
                    ((DateTimePicker)c).Enabled = true;

                if (c is ListBox)
                    ((ListBox)c).Enabled = true;

                if (c is ListView)
                    ((ListView)c).Enabled = true;

                if (c is NumericUpDown)
                    ((NumericUpDown)c).Enabled = true;

                if (c is PictureBox)
                    ((PictureBox)c).Enabled = true;

                if (c is RadioButton)
                    ((RadioButton)c).Enabled = true;

                if (c is TextBox)
                    ((TextBox)c).Enabled = true;

                if (c is DataGridView)
                    ((DataGridView)c).Enabled = true;
            }
        }




        #endregion

        //CANCELAR Y LIMPIAR CONTROLES
        #region Limpiar e inhabilitar Controles

        public void LimpiarComponentes(Control control)
        {
            foreach (Control c in control.Controls)
            {

                if (c is CheckBox)
                    ((CheckBox)c).Checked = false;

                if (c is TextBox)
                    ((TextBox)c).Clear();

                if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = 0;

                if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Today;

                if (c is CheckedListBox)
                    ((CheckedListBox)c).SetItemCheckState(cc, CheckState.Unchecked);

            }
        }

        public void InhabilitarComponentes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Button)
                    ((Button)c).Enabled = false;

                if (c is CheckBox)
                    ((CheckBox)c).Enabled = false;

                if (c is CheckedListBox)
                    ((CheckedListBox)c).Enabled = false;

                if (c is ComboBox)
                    ((ComboBox)c).Enabled = false;

                if (c is DateTimePicker)
                    ((DateTimePicker)c).Enabled = false;

                if (c is ListBox)
                    ((ListBox)c).Enabled = false;

                if (c is ListView)
                    ((ListView)c).Enabled = false;

                if (c is NumericUpDown)
                    ((NumericUpDown)c).Enabled = false;

                if (c is PictureBox)
                    ((PictureBox)c).Enabled = false;

                if (c is RadioButton)
                    ((RadioButton)c).Enabled = false;

                if (c is TextBox)
                    ((TextBox)c).Enabled = false;



            }
        }



        #endregion


    }
}
