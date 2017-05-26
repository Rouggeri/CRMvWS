using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm
{
    class CapaNegociod
    {

        public  int Anterior(DevExpress.XtraGrid.Views.Grid.GridView datagridview)
        {
            if (datagridview.DataRowCount > 1)
            {
                int indice = datagridview.FocusedRowHandle;
                int limite = datagridview.DataRowCount - 2;
                indice = indice - 1;
                if (indice >= 0)
                {
                    datagridview.FocusedRowHandle = indice;
                    //datagridview.CurrentCell = datagridview.Rows[indice].Cells[0];
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



        public  int Siguiente(DevExpress.XtraGrid.Views.Grid.GridView datagridview)
        {
            if (datagridview.DataRowCount > 1)
            {
                int indice = datagridview.FocusedRowHandle;
                int limite = datagridview.DataRowCount - 1;
                indice = indice + 1;
                if (indice <= limite)
                {
                    datagridview.FocusedRowHandle = indice;
                   // datagridview.CurrentCell = datagridview.Rows[indice].Cells[0];
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


        public int Ultimo(DevExpress.XtraGrid.Views.Grid.GridView datagridview)
        {
            if (datagridview.DataRowCount > 1)
            {
                int limite = datagridview.DataRowCount - 1;
                datagridview.FocusedRowHandle = limite;
                //datagridview.CurrentCell = datagridview.Rows[limite].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        public  int Primero(DevExpress.XtraGrid.Views.Grid.GridView datagridview)
        {
            if (datagridview.DataRowCount > 1)
            {
                int principio = 0;
                datagridview.FocusedRowHandle = principio;
                //datagridview.CurrentCell = datagridview.Rows[0].Cells[0];
                return 0;
            }
            else
            {
                MessageBox.Show("No hay datos en el datagrid", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }



    }
}
