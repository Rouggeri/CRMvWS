using CrystalDecisions.CrystalReports.Engine;
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
    public partial class Form_Reporte_Negocios : Form
    {
        public Form_Reporte_Negocios()
        {
            InitializeComponent();
        }

        private void Form_Reporte_Negocios_Load(object sender, EventArgs e)
        {
            DataSetReporteNegocios rep = new DataSetReporteNegocios();
            int filas = dataGridView1.Rows.Count;

            foreach (DataGridViewRow dg_col in dataGridView1.Rows)
            {
                rep.Tables[0].Rows.Add(dg_col.Cells[0].Value, dg_col.Cells[1].Value, dg_col.Cells[2].Value, dg_col.Cells[3].Value, dg_col.Cells[4].Value, dg_col.Cells[5].Value, dg_col.Cells[6].Value, dg_col.Cells[7].Value);
            }

             rep.WriteXmlSchema("rep_negs.xml");
            ReporteNegocios rp = new ReporteNegocios();
            rp.SetDataSource(rep);
            crystalReportViewer1.ReportSource = rp;

            // ReportDocument doc = new ReportDocument();
            //doc.Load(@"C:\Users\Chrix\Documents\GitHub\CRMvWS\crm\crm\ReporteNegocios.rpt");
            //doc.SetDataSource(rep);
            //crystalReportViewer1.ReportSource = doc;
            //---------------------------------------------


        }
    }
}
