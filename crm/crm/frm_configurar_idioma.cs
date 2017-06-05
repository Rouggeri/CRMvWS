using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class frm_configurar_idioma : Form
    {
        public frm_configurar_idioma()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)//boton aceptar
        {
            if (cbo_idioma.SelectedItem.ToString() == "Ingles" || cbo_idioma.SelectedItem.ToString() == "English")
            {
                // Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                //  this.Controls.Clear();
                //InitializeComponent();
                OpBD.Idioma = "ingles";
                OpBD.CambioIdioma = true;
            }
            else if (cbo_idioma.SelectedItem.ToString() == "Español" || cbo_idioma.SelectedItem.ToString() == "Spanish")
            {
                //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
                //this.Controls.Clear();
                //InitializeComponent();
                OpBD.Idioma = "español";
                OpBD.CambioIdioma = true;

            }

            
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_configurar_idioma_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form1.ActiveForm.Controls.Clear();
            //Form1.ActiveForm.Refresh();


            //Form1.ActiveForm.Close();
            //Form1 f = new Form1();
            //f.Show();
        }

        private void frm_configurar_idioma_Load(object sender, EventArgs e)
        {
            if (OpBD.Idioma=="ingles")
            {
                cbo_idioma.Items.Add("Spanish");
                cbo_idioma.Items.Add("English");
            }
            else
            {
                cbo_idioma.Items.Add("Español");
                cbo_idioma.Items.Add("Ingles");
            }
        }
    }
}
