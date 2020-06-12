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
            this.toolStripStatusLabel_version.Text = "V01.03.00A";
            this.toolStripStatusLabel_author.Text = "cconci";

            this.dataGridView_pixelGrid.ColumnHeadersVisible = true;
            this.dataGridView_pixelGrid.ColumnHeadersVisible = true;
            this.dataGridView_pixelGrid.AllowUserToOrderColumns = false;

            this.dataGridView_pixelGrid.RowTemplate.Height = 30;
            this.dataGridView_pixelGrid.RowHeadersWidth = 100;

            //generate grid
            this.toolStripButton_generateGrid_Click(sender, e);

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

            //Menu - stop from closing on click
            this.exportToolStripMenuItem.DropDown.Closing += OnToolStripDropDownClosing;

            //no selection 
            this.dataGridView_pixelGrid.ClearSelection();
        }

        private void toolStripButton_generateGrid_Click(object sender, EventArgs e)
        {
            try
            {
                int sizeX = System.Convert.ToInt32(this.toolStripTextBox_gridSizeX.Text);
                int sizeY = System.Convert.ToInt32(this.toolStripTextBox_gridSizeY.Text);

                GenericGridFunctions.InitPixelGrid(this.dataGridView_pixelGrid, sizeX, sizeY);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }

        }

        private void toolStripButton_selectColour_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();

            this.toolStripTextBox_selectedColour.BackColor = this.colorDialog1.Color;
        }

        private void dataGridView_pixelGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                //error
                return;
            }

            if (e.ColumnIndex < 0)
            {
                //error
                return;
            }
            this.dataGridView_pixelGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = this.colorDialog1.Color;

            this.dataGridView_pixelGrid.ClearSelection();

            System.Diagnostics.Debug.Print("dataGridView_pixelGrid_CellClick()");
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
                arrayDataString += "{" + enteredColours[a].R + "," + enteredColours[a].G + "," + enteredColours[a].B + "},\n";
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

            int row = 1;

            if (this.rowModeToolStripMenuItem.Checked == true)
            {
                if (this.mirrorGridXToolStripMenuItem.Checked == true)
                {
                    for (int b = (this.dataGridView_pixelGrid.RowCount -1); b >= 0; b--)
                    {
                        addToListRows(ref colours, b, row);

                        row++;
                    }
                }
                else
                {
                    for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
                    {
                        addToListRows(ref colours, b, row);

                        row++;
                    }
                }
            }
            else if (this.columnModeToolStripMenuItem.Checked == true)
            {
                if (this.mirrorGridYToolStripMenuItem.Checked == true)
                {
                    for (int a = (this.dataGridView_pixelGrid.ColumnCount - 1); a >= 0 ; a--)
                    {
                        addToListColoumns(ref colours, a, row);

                        row++;
                    }
                }
                else
                {
                    for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
                    {
                        addToListColoumns(ref colours, a, row);

                        row++;
                    }
                }
                
            }

            return colours;
        }

        private void addToListRows(ref List<Color> colours, int rowIndex, int currentRow)
        {
            if (this.zigZagGridToolStripMenuItem.Checked == true
                && ((currentRow % 2) == 0)  //every second row will be the zag and needs to be reversed 
)
            {
                if (this.mirrorGridYToolStripMenuItem.Checked == true)
                {
                    addToListGridColourRowColLineBaseLeftRight(ref colours, rowIndex, this.dataGridView_pixelGrid.ColumnCount);
                }
                else
                {
                    addToListGridColourRowColLineMirrorRightLeft(ref colours, rowIndex, this.dataGridView_pixelGrid.ColumnCount);
                }

            }
            else
            {
                if (this.mirrorGridYToolStripMenuItem.Checked == true)
                {
                    addToListGridColourRowColLineMirrorRightLeft(ref colours, rowIndex, this.dataGridView_pixelGrid.ColumnCount);
                }
                else
                {
                    addToListGridColourRowColLineBaseLeftRight(ref colours, rowIndex, this.dataGridView_pixelGrid.ColumnCount);
                }

            }
        }

        private void addToListColoumns(ref List<Color> colours,int colIndex,int currentRow)
        {
            if (this.zigZagGridToolStripMenuItem.Checked == true
                        && ((currentRow % 2) == 0)  //every second row will be the zag and needs to be reversed 
                    )
            {
                if (this.mirrorGridXToolStripMenuItem.Checked == true)
                {
                    addToListGridColourColRowLineBaseUpDown(ref colours, colIndex, this.dataGridView_pixelGrid.RowCount);
                }
                else
                {
                    addToListGridColourColRowLineMirrorDownUp(ref colours, colIndex, this.dataGridView_pixelGrid.RowCount);
                }

            }
            else
            {
                if (this.mirrorGridXToolStripMenuItem.Checked == true)
                {
                    addToListGridColourColRowLineMirrorDownUp(ref colours, colIndex, this.dataGridView_pixelGrid.RowCount);
                }
                else
                {
                    addToListGridColourColRowLineBaseUpDown(ref colours, colIndex, this.dataGridView_pixelGrid.RowCount);
                }

            }
        }

        private void addToListGridColourRowColLineBaseLeftRight(ref List<Color> colours, int rowIndex, int colCount)
        {
            //Col Row is going left/right
            for (int a = 0; a < colCount; a++)
            {
                Color cellColour = this.dataGridView_pixelGrid.Rows[rowIndex].Cells[a].Style.BackColor;
                colours.Add(cellColour);
            }
        }

        private void addToListGridColourRowColLineMirrorRightLeft(ref List<Color> colours, int colIndex, int colCount)
        {
            //Col Row is going right/left
            for (int a = (colCount - 1); a >= 0; a--)
            {
                Color cellColour = this.dataGridView_pixelGrid.Rows[colIndex].Cells[a].Style.BackColor;
                colours.Add(cellColour);
            }
        }

        private void addToListGridColourColRowLineBaseUpDown(ref List<Color> colours,int colIndex, int rowCount)
        {
            //Col Row is going up/down
            for (int b = 0; b < rowCount; b++)
            {
                Color cellColour = this.dataGridView_pixelGrid.Rows[b].Cells[colIndex].Style.BackColor;
                colours.Add(cellColour);
            }
        }

        private void addToListGridColourColRowLineMirrorDownUp(ref List<Color> colours, int colIndex, int rowCount)
        {
            //Col Row is going down/up
            for (int b = (rowCount - 1); b >= 0; b--)
            {
                Color cellColour = this.dataGridView_pixelGrid.Rows[b].Cells[colIndex].Style.BackColor;
                colours.Add(cellColour);
            }
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
            try
            {
                int sizeX = System.Convert.ToInt32(this.toolStripTextBox_gridSizeX.Text);
                int sizeY = System.Convert.ToInt32(this.toolStripTextBox_gridSizeY.Text);

                UserWorkspace nUserWorkspace = new UserWorkspace(sizeX, sizeY, this.dataGridView_pixelGrid);

                nUserWorkspace.SaveWorkspace(fileNameAndPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
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
            if (this.openFileDialog1.FileName != "")
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
                this.Text = "Pixel Art Array Generator (" + this.currentWorkspaceFileNameAndPath + ")";
            }

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //save back to the open file
            if (currentWorkspaceFileNameAndPath != ""
                && this.saveToolStripMenuItem1.Enabled == true
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

        private void zigZagGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.zigZagGridToolStripMenuItem.Checked == true)
            {
                this.zigZagGridToolStripMenuItem.Checked = false;
            }
            else
            {
                this.zigZagGridToolStripMenuItem.Checked = true;
            }
        }

        private void mirrorGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mirrorGridXToolStripMenuItem.Checked == true)
            {
                this.mirrorGridXToolStripMenuItem.Checked = false;
            }
            else
            {
                this.mirrorGridXToolStripMenuItem.Checked = true;
            }
        }

        private void mirrorGridYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.mirrorGridYToolStripMenuItem.Checked == true)
            {
                this.mirrorGridYToolStripMenuItem.Checked = false;
            }
            else
            {
                this.mirrorGridYToolStripMenuItem.Checked = true;
            }

        }

        private void OnToolStripDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ToolStripDropDown tToolStripDropDown = sender as ToolStripDropDown;
            //use pointer location to see if the user is inside the menu item
            Point p = tToolStripDropDown.PointToClient(MousePosition);
            if (tToolStripDropDown.DisplayRectangle.Contains(p))
            {
                e.Cancel = true;  // stop the auto closing on click
            }
                
        }

        private void dataGridView_pixelGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Right Click is  colour Picker
            if (e.Button == MouseButtons.Right)
            {
                this.colorDialog1.Color = this.dataGridView_pixelGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;

                this.toolStripTextBox_selectedColour.BackColor = this.colorDialog1.Color;
            }


            System.Diagnostics.Debug.Print("dataGridView_pixelGrid_CellMouseClick()");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit program 
            this.Close();
        }

        private void toolStripButton_ShiftLeft_Click(object sender, EventArgs e)
        {
            //shift coloumn data left 1 coloumn
            DataGridView shadowDgv = GenericGridFunctions.DataGridViewColAndRowDataCopy(this.dataGridView_pixelGrid);

            for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
            {
                for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
                {
                    if (a == (this.dataGridView_pixelGrid.ColumnCount - 1))
                    {
                        //get the first column data
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b].Cells[0].Style.BackColor;
                    }
                    else
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b].Cells[a + 1].Style.BackColor;
                    }    
                }
            }
        }

        private void toolStripButton_ShiftRight_Click(object sender, EventArgs e)
        {
            DataGridView shadowDgv = GenericGridFunctions.DataGridViewColAndRowDataCopy(this.dataGridView_pixelGrid);

            for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
            {
                for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
                {
                    if (a == 0)
                    {
                        //get the first column data
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b].Cells[(this.dataGridView_pixelGrid.ColumnCount-1)].Style.BackColor;
                    }
                    else
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b].Cells[a - 1].Style.BackColor;
                    }
                }
            }
        }

        private void toolStripButton_ShiftUp_Click(object sender, EventArgs e)
        {
            DataGridView shadowDgv = GenericGridFunctions.DataGridViewColAndRowDataCopy(this.dataGridView_pixelGrid);

            for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++) 
            {
                for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
                {
                    if (b == (this.dataGridView_pixelGrid.RowCount-1))
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[0].Cells[a].Style.BackColor;
                    }
                    else
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b+1].Cells[a].Style.BackColor;
                    }
                }
            }
        }

        private void toolStripButton_ShiftDown_Click(object sender, EventArgs e)
        {
            DataGridView shadowDgv = GenericGridFunctions.DataGridViewColAndRowDataCopy(this.dataGridView_pixelGrid);

            for (int b = 0; b < this.dataGridView_pixelGrid.RowCount; b++)
            {
                for (int a = 0; a < this.dataGridView_pixelGrid.ColumnCount; a++)
                {
                    if (b == 0)
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[(this.dataGridView_pixelGrid.RowCount - 1)].Cells[a].Style.BackColor;
                    }
                    else
                    {
                        this.dataGridView_pixelGrid.Rows[b].Cells[a].Style.BackColor = shadowDgv.Rows[b - 1].Cells[a].Style.BackColor;
                    }
                }
            }
        }
    }
}
