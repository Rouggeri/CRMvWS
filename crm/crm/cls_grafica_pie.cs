using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using System.Drawing;


namespace crm
{
   public  class cls_grafica_pie
    {


        ChartControl pie = new ChartControl();
        Series serie1 = new Series("pie", ViewType.Doughnut3D);


        //ChartControl pie_retorno = new ChartControl();

        public DataTable dt_grafica_pie_caso(string nego_gana, string nego_perdido, string nego_ini)
        {
            DataTable casos = new DataTable();
            casos.Clear();
            casos.Columns.Add("estado", typeof(string));
            casos.Columns.Add("cantidad", typeof(string));

            casos.Rows.Add(new object[] { "Negocios Ganados", nego_gana });
            casos.Rows.Add(new object[] { "Negocios Perdidos", nego_perdido });
            casos.Rows.Add(new object[] { "Negocios Iniciados", nego_ini });

            return casos;
        }




        public ChartControl grafica_pie(string nego_gana, string nego_perdido, string nego_ini, string titulox)
        {

            // inicializacion de variables de chartcontrol
            pie.DataSource = null;
            pie.Series.Clear();
            pie.Titles.Clear();
            // Formato para retorno de grafica
            pie.Legend.BackColor = Color.Transparent; // fondo transparente
            pie.Legend.Border.Color = Color.Transparent;
            pie.BackColor = Color.Transparent;
            pie.BorderOptions.Color = Color.Transparent;


            Series serie1 = new Series("pie", ViewType.Doughnut3D);
            //Series serie1 = new Series("pie", ViewType.Pie3D);
            pie.RefreshData();



            DataTable dt_pie = dt_grafica_pie_caso(nego_gana, nego_perdido, nego_ini);
            dt_pie = dt_grafica_pie_caso(nego_gana, nego_perdido, nego_ini);

            foreach (DataRow row in dt_pie.Rows)
            {
                string estado = row["estado"].ToString();
                string cantidad = row["cantidad"].ToString();
                serie1.Points.Add(new SeriesPoint(estado, cantidad));
            }
            pie.Series.Add(serie1);



            serie1.PointOptions.ValueNumericOptions.Precision = 0;
            serie1.PointOptions.PointView = PointView.ArgumentAndValues;

            ((Pie3DSeriesView)serie1.View).Depth = 30;
            ((Pie3DSeriesView)serie1.View).ExplodedPoints.Add(serie1.Points[0]);
            ((Pie3DSeriesView)serie1.View).ExplodedDistancePercentage = 30;

            ((SimpleDiagram3D)pie.Diagram).RotationType = RotationType.UseAngles;
            ((SimpleDiagram3D)pie.Diagram).RotationAngleX = -35;
            ((SimpleDiagram3D)pie.Diagram).ZoomPercent = 200;

            ChartTitle titulo = new ChartTitle();
            titulo.Text = titulox;
            pie.Titles.Add(titulo);
            pie.Legend.Visible = true;



            pie.Dock = DockStyle.Fill;
            //pie_retorno.Controls.Add(pie);
            return pie;
        }

    }
}
