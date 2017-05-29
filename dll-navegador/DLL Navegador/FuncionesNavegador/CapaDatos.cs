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
    public class CapaDatos
    {
        #region insertar
        public static void insertar(string query)
        {
            Conexionmysql.ObtenerConexion();
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se inserto el registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }
        #endregion

        #region modificar
        public static void modificar(string query)
        {
            Conexionmysql.ObtenerConexion();
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se realizo la modificacion del registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }
        #endregion

        #region eliminar
        public static void eliminar(string query)
        {
            Conexionmysql.EjecutarMySql(query);
            MessageBox.Show("Se realizo la eliminacion del registro", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Conexionmysql.Desconectar();
        }
        #endregion

        #region Navegacion

        #region Navegacion Siguiente
        public static int Siguiente(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int indice = datagridview.CurrentCell.RowIndex;
                int limite = datagridview.Rows.Count - 2;
                indice = indice + 1;
                if (indice <= limite)
                {
                    datagridview.Rows[indice].Selected = true;
                    datagridview.CurrentCell = datagridview.Rows[indice].Cells[0];
                }
                else
                {
                    MessageBox.Show("Es el ultimo registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion

        #region Navegacion anterior
        public static int Anterior(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int indice = datagridview.CurrentCell.RowIndex;
                int limite = datagridview.Rows.Count - 2;
                indice = indice - 1;
                if (indice >= 0)
                {
                    datagridview.Rows[indice].Selected = true;
                    datagridview.CurrentCell = datagridview.Rows[indice].Cells[0];
                }
                else
                {
                    MessageBox.Show("Es el primer registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion

        #region Navegacion Ultimo
        public static int Ultimo(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                int limite = datagridview.Rows.Count - 2;
                datagridview.Rows[limite].Selected = true;
                datagridview.CurrentCell = datagridview.Rows[limite].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion

        #region Navegacion Primero
        public static int Primero(DataGridView datagridview)
        {
            if (datagridview.Rows.Count > 1)
            {
                datagridview.Rows[0].Selected = true;
                datagridview.CurrentCell = datagridview.Rows[0].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        #endregion

        #endregion


        //MANEJO DE CONTROLES
        #region Abilitar/Inhabilidat Controles


        public static int FunControlTextbox(TextBox textbox, Boolean valor)
        {
            textbox.Enabled = valor;
            return 0;
        }

        public static int FunControlButton(Button button, bool valor)
        {
            button.Enabled = valor;
            return 0;
        }

        public static int FunControlCheckBox(CheckBox checkbox, bool valor)
        {
            checkbox.Enabled = valor;
            return 0;
        }

        public static int FunControlCheckedListBox(CheckedListBox checkedlistBox, bool valor)
        {
            checkedlistBox.Enabled = valor;
            return 0;
        }

        public static int FunControlComboBox(ComboBox combobox, bool valor)
        {
            combobox.Enabled = valor;
            return 0;
        }

        public static int FunControlDateTimePicker(DateTimePicker datetimepicker, bool valor)
        {
            datetimepicker.Enabled = valor;
            return 0;
        }

        public static int FunControlListBox(ListBox listbox, bool valor)
        {
            listbox.Enabled = valor;
            return 0;
        }

        public static int FunControlListView(ListView listview, bool valor)
        {
            listview.Enabled = valor;
            return 0;
        }

        public static int FunControlNumericUpDown(NumericUpDown numericupdown, bool valor)
        {
            numericupdown.Enabled = valor;
            return 0;
        }

        public static int FunControlPictureBox(PictureBox picturebox, bool valor)
        {
            picturebox.Enabled = valor;
            return 0;
        }

        public static int FunControlRadioButton(RadioButton radiobutton, bool valor)
        {
            radiobutton.Enabled = valor;
            return 0;
        }

        public static int FunControlDataGridView(DataGridView datagridview, bool valor)
        {
            datagridview.Enabled = valor;
            return 0;
        }

        #endregion

    }
}
