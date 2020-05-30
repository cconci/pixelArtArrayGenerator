using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pixelArtArrayGenerator
{
    public class UserWorkspace
    {
        public int axisX;
        public int axisY;

        private DataGridView pixelGrid;

        public UserWorkspace()
        {
            this.axisX = 0;
            this.axisY = 0;
            this.pixelGrid = null;
        }

        public UserWorkspace(int axisX,int axisY,DataGridView pixelGrid)
        {
            this.axisX = axisX;
            this.axisY = axisY;
            this.pixelGrid = pixelGrid;
        }

        public bool SaveWorkspace(String textFilePathAndName)
        {
            try
            {
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(textFilePathAndName, false))
                {
                    file.WriteLine("AxisX:" + this.axisX);
                    file.WriteLine("AxisY:" + this.axisY);
                    
                    for (int a = 0; a < this.pixelGrid.Rows.Count; a++)
                    {
                        for (int b = 0; b < this.pixelGrid.Columns.Count; b++)
                        {
                            file.WriteLine("Grid:"+a+":"+b+":"+this.pixelGrid.Rows[a].Cells[b].Style.BackColor.ToArgb()+"\n");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
                return false;
            }
            return true;
        }

        public static UserWorkspace LoadWorkspace(String textFilePathAndName,DataGridView dgv)
        {
            

            int sizeX = 0;
            int sizeY = 0;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(textFilePathAndName);

                for (int a = 0; a < lines.Count(); a++)
                {
                    if (lines[a].Contains("AxisX"))
                    {
                        sizeX = System.Convert.ToInt32(lines[a].Split(':')[1]);
                    }
                    else if (lines[a].Contains("AxisY"))
                    {
                        sizeY = System.Convert.ToInt32(lines[a].Split(':')[1]);
                        
                        //got what we need to build the grid
                        GenericGridFunctions.InitPixelGrid(dgv, sizeX, sizeY);
                    }
                    else if (lines[a].Contains("Grid"))
                    {
                        String[] gridrow = lines[a].Split(':');

                        int row = System.Convert.ToInt32(gridrow[1]);
                        int cell = System.Convert.ToInt32(gridrow[2]);
                        int argb = System.Convert.ToInt32(gridrow[3]);

                        dgv.Rows[row].Cells[cell].Style.BackColor = Color.FromArgb(argb);
                    }
                }

            }
            catch (Exception ex)
            {

            }

            //force an update
            dgv.Invalidate();
            dgv.Refresh();

            UserWorkspace nWorkspace = new UserWorkspace(sizeX, sizeY,dgv);

            return nWorkspace;
        }
    }
}
