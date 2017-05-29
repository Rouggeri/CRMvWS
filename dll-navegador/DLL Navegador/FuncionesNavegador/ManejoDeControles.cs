using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
using System.Windows.Forms;
//using MySql.Data;
using System.Data;
using System.Data.Odbc;
//using ConexionODBC;

namespace FuncionesNavegador
{
    public class ManejoDeControles
    {
        //private  OdbcCommand mySqlComando;
        //private  OdbcDataAdapter mySqlDAdAdaptador;



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
