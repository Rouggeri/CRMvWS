using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    public partial class Form_Reporte_caso : Form
    {
        public Form_Reporte_caso()
        {
            InitializeComponent();
        }

        private void Form_Reporte_caso_Load(object sender, EventArgs e)
        {
            DataSet_Casos rep = new DataSet_Casos();
            int filas = dataGridView1.Rows.Count;

            foreach (DataGridViewRow dg_col in dataGridView1.Rows)
            {
                rep.Tables[0].Rows.Add(dg_col.Cells[0].Value, dg_col.Cells[1].Value, dg_col.Cells[2].Value, dg_col.Cells[3].Value, dg_col.Cells[4].Value, dg_col.Cells[5].Value);
            }

            rep.WriteXmlSchema("rep_casos.xml");
            ReporteCasos rp = new ReporteCasos();
            rp.SetDataSource(rep);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
