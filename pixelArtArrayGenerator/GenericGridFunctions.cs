using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixelArtArrayGenerator
{
    class GenericGridFunctions
    {
        public static void InitPixelGrid(DataGridView dgv, int sizeX,int sizeY)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Refresh();

            for (int a = 0; a < sizeX; a++)
            {
                dgv.Columns.Add("" + a, "" + a);
                dgv.Columns[dgv.Columns.Count - 1].Width = 30;
            }

            for (int a = 0; a < sizeY; a++)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[dgv.Rows.Count - 1].HeaderCell.Value = a + "";

            }
        }
    }
}
