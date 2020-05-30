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
        const String lastWorkspaceFile = "workspace_backup.pgn";
        String currentWorkspaceFileNameAndPath = "";

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
            this.dataGridView_pixelGrid.RowHeadersWidth = 100;

            //generate grid
            this.toolStripButton_generateGrid_Click(sender,e);

            //Load a last work space
            this.setCurrentWorkspaceFromFile(lastWorkspaceFile);

            //set up Save file Dialog
            this.saveFileDialog1.Filter = "Pixel Gen| *.pgn";//| Text File | *.txt";
            this.saveFileDialog1.Title = "Save Workspace";
            this.saveFileDialog1.RestoreDirectory = true;

            //open
            this.openFileDialog1.Filter = "Pixel Gen| *.pgn|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Open Workspace";
            this.openFileDialog1.RestoreDirectory = true;
        }

        private void toolStripButton_generateGrid_Click(object sender, EventArgs e)
        {
            int sizeX = System.Convert.ToInt32(this.toolStripTextBox_gridSizeX.Text);
            int sizeY = System.Convert.ToInt32(this.toolStripTextBox_gridSizeY.Text);

            GenericGridFunctions.InitPixelGrid(this.dataGridView_pixelGrid ,sizeX, sizeY);

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
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //write to a file
            this.saveFileDialog1.FileName = "";
            this.saveFileDialog1.ShowDialog();
        }

        private void saveCurrentWorkspace(String fileNameAndPath)
        {
            int sizeX = System.Convert.ToInt32(this.toolStripTextBox_gridSizeX.Text);
            int sizeY = System.Convert.ToInt32(this.toolStripTextBox_gridSizeY.Text);

            UserWorkspace nUserWorkspace = new UserWorkspace(sizeX,sizeY,this.dataGridView_pixelGrid);

            nUserWorkspace.SaveWorkspace(fileNameAndPath);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.saveCurrentWorkspace(lastWorkspaceFile);
        }

        private void updateGridSizeText()
        {
            this.toolStripStatusLabel_sizeInBytes.Text = "RGB:" + (this.dataGridView_pixelGrid.RowCount * this.dataGridView_pixelGrid.ColumnCount * 3) 
                + " WRGB:" + (this.dataGridView_pixelGrid.RowCount * this.dataGridView_pixelGrid.ColumnCount * 4);
        }

        private void dataGridView_pixelGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            this.updateGridSizeText();
        }

        private void dataGridView_pixelGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.updateGridSizeText();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //load the file
            if(this.openFileDialog1.FileName != "")
            {
                this.setCurrentWorkspaceFromFile(this.openFileDialog1.FileName);

                //now we have a file for our workspace
                this.currentWorkspaceFileNameAndPath = this.openFileDialog1.FileName;
                this.saveToolStripMenuItem1.Enabled = true;
                this.Text = "Pixel Art Array Generator (" + this.currentWorkspaceFileNameAndPath + ")";
            }

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //save current to file
            if (this.saveFileDialog1.FileName != "")
            {
                this.saveCurrentWorkspace(this.saveFileDialog1.FileName);

                //now we have a file for our workspace
                this.currentWorkspaceFileNameAndPath = this.saveFileDialog1.FileName;
                this.saveToolStripMenuItem1.Enabled = true;
                this.Text = "Pixel Art Array Generator ("+ this.currentWorkspaceFileNameAndPath + ")";
            }
            
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //save back to the open file
            if(     currentWorkspaceFileNameAndPath != "" 
                &&  this.saveToolStripMenuItem1.Enabled == true
            )
            {
                this.saveCurrentWorkspace(currentWorkspaceFileNameAndPath);
                
            }
            
        }

        private void setCurrentWorkspaceFromFile(String fileNameAndPath)
        {
            UserWorkspace lspace = UserWorkspace.LoadWorkspace(fileNameAndPath, this.dataGridView_pixelGrid);
            this.toolStripTextBox_gridSizeX.Text = lspace.axisX + "";
            this.toolStripTextBox_gridSizeY.Text = lspace.axisY + "";
            this.dataGridView_pixelGrid.Invalidate();

        }
    }
}
