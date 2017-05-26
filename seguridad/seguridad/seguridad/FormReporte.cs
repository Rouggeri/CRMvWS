using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seguridad
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        public DataTable dtamo = new DataTable();
        public string usuario;

        private void FormReporte_Load(object sender, EventArgs e)
        {
            DataColumn col;
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "Aplicación";
            dtamo.Columns.Add(col);

            //2 columna
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "Insertar";
            dtamo.Columns.Add(col);
            //3 columna
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "Seleccionar";
            dtamo.Columns.Add(col);
            //4 columna
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "Modificar";
            dtamo.Columns.Add(col);
            //5 columna
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.String");
            col.ColumnName = "Eliminar";
            dtamo.Columns.Add(col);

            DataSet ds = new DataSet();

            foreach (DataGridViewRow dg_col in dgw_cen.Rows)
            {
                dtamo.Rows.Add(dg_col.Cells[0].Value, dg_col.Cells[1].Value, dg_col.Cells[2].Value, dg_col.Cells[3].Value, dg_col.Cells[4].Value);
            }

            ds.Tables.Add(dtamo);
            ds.WriteXmlSchema("permi.xml");

            Reporte rp = new Reporte();

            rp.SetDataSource(ds);
            rp.SetParameterValue("usuarinho",  usuario);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
