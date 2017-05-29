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
using FuncionesNavegador;

namespace FuncionesNavegador
{
     public class FuncionDeControles
    {
        //private static OdbcCommand mySqlComando;
        //private static OdbcDataAdapter mySqlDAdAdaptador;
        public int cc;


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
            ManejoDeControles.FunControlTextbox(txtboxnuevo, estado);
        }

        public void ControlButton(Button buttonnueo, Boolean estado)
        {
            ManejoDeControles.FunControlButton(buttonnueo, estado);
        }

        public void ControlCheckBox(CheckBox checkbox, Boolean estado)
        {
            ManejoDeControles.FunControlCheckBox(checkbox, estado);
        }

        public void ControlCheckedListBox(CheckedListBox checkedlistbox, Boolean estado)
        {
            ManejoDeControles.FunControlCheckedListBox(checkedlistbox, estado);
        }

        public void ControlComboBox(ComboBox combobox, Boolean estado)
        {
            ManejoDeControles.FunControlComboBox(combobox, estado);
        }

        public void ControlDateTimePicker(DateTimePicker datetimepicker, Boolean estado)
        {
            ManejoDeControles.FunControlDateTimePicker(datetimepicker, estado);
        }

        public void ControlListBox(ListBox listbox, Boolean estado)
        {
            ManejoDeControles.FunControlListBox(listbox, estado);
        }

        public void ControlListView(ListView listview, Boolean estado)
        {
            ManejoDeControles.FunControlListView(listview, estado);
        }

        public void ControlNumericUpDown(NumericUpDown numericupdown, Boolean estado)
        {
            ManejoDeControles.FunControlNumericUpDown(numericupdown, estado);
        }

        public void ControlPictureBox(PictureBox picturebox, Boolean estado)
        {
            ManejoDeControles.FunControlPictureBox(picturebox, estado);
        }

        public void ControlRadioButton(RadioButton radiobutton, Boolean estado)
        {
            ManejoDeControles.FunControlRadioButton(radiobutton, estado);

        }

        public void ControlDataGridView(DataGridView datagridview, Boolean estado)
        {
            ManejoDeControles.FunControlDataGridView(datagridview, estado);

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
