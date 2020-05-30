using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pixelArtArrayGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_version.Text = "V01.00.00A";
            this.toolStripStatusLabel_author.Text = "cconci";

            this.dataGridView_pixelGrid.ColumnHeadersVisible = true;
            this.dataGridView_pixelGrid.ColumnHeadersVisible = true;
            this.dataGridView_pixelGrid.AllowUserToOrderColumns = false;


            this.dataGridView_pixelGrid.RowTemplate.Height = 30;

            //generate grid
            this.toolStripButton_generateGrid_Click(sender,e);
        }

        private void toolStripButton_generateGrid_Click(object sender, EventArgs e)
        {
            int sizeX = System.Convert.ToInt32(this.toolStripTextBox_gridSizeX.Text);
            int sizeY = System.Convert.ToInt32(this.toolStripTextBox_gridSizeY.Text);

            this.dataGridView_pixelGrid.Rows.Clear();
            this.dataGridView_pixelGrid.Columns.Clear();

            for (int a = 0; a < sizeX; a++)
            {
                this.dataGridView_pixelGrid.Columns.Add(""+a, ""+a);
                this.dataGridView_pixelGrid.Columns[this.dataGridView_pixelGrid.Columns.Count - 1].Width = 30;
            }

            for (int a = 0; a < sizeY; a++)
            {
                int rowIndex = this.dataGridView_pixelGrid.Rows.Add();
                this.dataGridView_pixelGrid.Rows[this.dataGridView_pixelGrid.Rows.Count - 1].HeaderCell.Value = a+"";
                
            }

            this.toolStripStatusLabel_sizeInBytes.Text = "RGB:" + (sizeX * sizeY * 3) + " WRGB:" + (sizeX * sizeY * 4);

        }

        private void toolStripButton_selectColour_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();

            this.toolStripTextBox_selectedColour.BackColor = this.colorDialog1.Color;
        }

        private void dataGridView_pixelGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView_pixelGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = this.colorDialog1.Color;

            this.dataGridView_pixelGrid.ClearSelection();
        }

        private void rowModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.rowModeToolStripMenuItem.Checked == true)
            {
                this.columnModeToolStripMenuItem.Checked = true;
                this.rowModeToolStripMenuItem.Checked = false;
            }
            else
            {
                this.columnModeToolStripMenuItem.Checked = false;
                this.rowModeToolStripMenuItem.Checked = true;
            }
        }

        private void columnModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.columnModeToolStripMenuItem.Checked == true)
            {
                this.columnModeToolStripMenuItem.Checked = false;
                this.rowModeToolStripMenuItem.Checked = true;
            }
            else
            {
                this.columnModeToolStripMenuItem.Checked = true;
                this.rowModeToolStripMenuItem.Checked = false;
            }
        }

        private void cRGBMultiDimenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RGB rows
            String arrayDataString;
            List<Color> enteredColours = this.getColourDataFromPixelGrid();

            arrayDataString = "unsigned char pixelArtArrayGenerator[" + enteredColours.Count + "][3] = \n";
            arrayDataString += "{\n";

            for (int a = 0; a < enteredColours.Count; a++)
            {
                arrayDataString += "{"+ enteredColours[a].R+ ","+ enteredColours[a].G + ","+ enteredColours[a].B + "},\n";
            }

            arrayDataString += "};\n";

            Clipboard.SetText(arrayDataString);
        }

        private void cWRGBMultidimensionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WRGB Rows
            String arrayDataString;
            List<Color> enteredColours = this.getColourDataFromPixelGrid();

            arrayDataString = "unsigned char pixelArtArrayGenerator[" + enteredColours.Count + "][4] = \n";
            arrayDataString += "{\n";

            for (int a = 0; a < enteredColours.Count; a++)
            {
                arrayDataString += "{" + enteredColours[a].A + "," + enteredColours[a].R + "," + enteredColours[a].G + "," + enteredColours[a].B + "},\n";
            }

            arrayDataString += "};\n";

            Clipboard.SetText(arrayDataString);
        }

        private List<Color> getColourDataFromPixelGrid()
        {
            List<Color> colours = new List<Color>();

            
            if (this.rowModeToolStripMenuItem.Checked == true)
            {
                for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
                {
                    for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
                    {
                        Color cellColour = this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor;

                        colours.Add(cellColour);
                    }
                }
            }
            else if (this.columnModeToolStripMenuItem.Checked == true)
            {
                for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++) 
                {
                    for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
                    {
                        Color cellColour = this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor;

                        colours.Add(cellColour);
                    }
                }
            }

            return colours;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //read from a file
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //write to a file
        }
    }
}
