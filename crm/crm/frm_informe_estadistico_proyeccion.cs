using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace crm
{
    public partial class frm_informe_estadistico_proyeccion : Form
    {
        public frm_informe_estadistico_proyeccion()
        {
            InitializeComponent();
        }

        public DataTable dt_contenedor = new DataTable();
        public string fecha_inicio = "";
        public string fecha_fin = "";
        public int deci = 0;

        private void frm_informe_estadistico_proyeccion_Load(object sender, EventArgs e)
        {
            //frm_pronostico_ventas_secundario frm_pronostico = new frm_pronostico_ventas_secundario();
            //dgv_contenedor = frm_pronostico.dgv_detalle_informe;
            if (deci == 1)
            {
                ds_estadistica ds = new ds_estadistica();
                int filas = dgv_contenedor.Rows.Count;

                for (int i = 0; i <= filas - 2; i++)
                {
                    ds.Tables[0].Rows.Add
                        (

                        new object[]
                        {

                        dgv_contenedor[0,i].Value.ToString(),
                        dgv_contenedor[1,i].Value.ToString(),
                        dgv_contenedor[2,i].Value.ToString(),
                        dgv_contenedor[3,i].Value.ToString(),
                        dgv_contenedor[4,i].Value.ToString(),
                        dgv_contenedor[5,i].Value.ToString(),


                        }

                        );

                }
                ReportDocument rd = new ReportDocument();
                rd.Load(@"C:\CRMvWS\crm\crm\cr_estadistica.rpt");
                rd.SetDataSource(ds);
                rd.SetParameterValue("fecha_inicio", fecha_inicio);
                rd.SetParameterValue("fecha_fin", fecha_fin);
                crv_proyeccion.ReportSource = rd;
                
            }

            // en caso de que mande los datos de ventas haremos:
            else if (deci == 2)
            {
                dt_estadistica_ventas ds = new dt_estadistica_ventas();
                int filas = dgv_contenedor.Rows.Count;

                for (int i = 0; i <= filas - 2; i++)
                {
                    ds.Tables[0].Rows.Add
                        (

                        new object[]
                        {

                        dgv_contenedor[0,i].Value.ToString(),
                        dgv_contenedor[1,i].Value.ToString(),
                        dgv_contenedor[2,i].Value.ToString(),
                        


                        }

                        );

                }
                ReportDocument rd = new ReportDocument();
                rd.Load(@"C:\CRMvWS\crm\crm\cr_esta_ventas.rpt");
                rd.SetDataSource(ds);
                rd.SetParameterValue("fecha_inicio", fecha_inicio);
                rd.SetParameterValue("fecha_fin", fecha_fin);
                crv_proyeccion.ReportSource = rd;

                

            }
        }
    }
}
