namespace pixelArtArrayGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_version = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_sizeInBytes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_author = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arraysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRGBMultiDimenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cWRGBMultidimensionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rowModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_pixelGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_gridSizeX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_gridSizeY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_generateGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_selectedColour = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_selectColour = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pixelGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_version,
            this.toolStripStatusLabel_sizeInBytes,
            this.toolStripStatusLabel_author});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Version:";
            // 
            // toolStripStatusLabel_version
            // 
            this.toolStripStatusLabel_version.Name = "toolStripStatusLabel_version";
            this.toolStripStatusLabel_version.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel_version.Text = "NA";
            // 
            // toolStripStatusLabel_sizeInBytes
            // 
            this.toolStripStatusLabel_sizeInBytes.Name = "toolStripStatusLabel_sizeInBytes";
            this.toolStripStatusLabel_sizeInBytes.Size = new System.Drawing.Size(673, 17);
            this.toolStripStatusLabel_sizeInBytes.Spring = true;
            this.toolStripStatusLabel_sizeInBytes.Text = "...";
            // 
            // toolStripStatusLabel_author
            // 
            this.toolStripStatusLabel_author.Name = "toolStripStatusLabel_author";
            this.toolStripStatusLabel_author.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel_author.Text = "NA";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arraysToolStripMenuItem,
            this.toolStripSeparator1,
            this.rowModeToolStripMenuItem,
            this.columnModeToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // arraysToolStripMenuItem
            // 
            this.arraysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cRGBMultiDimenToolStripMenuItem,
            this.cWRGBMultidimensionalToolStripMenuItem});
            this.arraysToolStripMenuItem.Name = "arraysToolStripMenuItem";
            this.arraysToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arraysToolStripMenuItem.Text = "Arrays";
            // 
            // cRGBMultiDimenToolStripMenuItem
            // 
            this.cRGBMultiDimenToolStripMenuItem.Name = "cRGBMultiDimenToolStripMenuItem";
            this.cRGBMultiDimenToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.cRGBMultiDimenToolStripMenuItem.Text = "C RGB Multidimensional";
            this.cRGBMultiDimenToolStripMenuItem.Click += new System.EventHandler(this.cRGBMultiDimenToolStripMenuItem_Click);
            // 
            // cWRGBMultidimensionalToolStripMenuItem
            // 
            this.cWRGBMultidimensionalToolStripMenuItem.Name = "cWRGBMultidimensionalToolStripMenuItem";
            this.cWRGBMultidimensionalToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.cWRGBMultidimensionalToolStripMenuItem.Text = "C WRGB Multidimensional";
            this.cWRGBMultidimensionalToolStripMenuItem.Click += new System.EventHandler(this.cWRGBMultidimensionalToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // rowModeToolStripMenuItem
            // 
            this.rowModeToolStripMenuItem.Name = "rowModeToolStripMenuItem";
            this.rowModeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.rowModeToolStripMenuItem.Text = "Row Mode";
            this.rowModeToolStripMenuItem.Click += new System.EventHandler(this.rowModeToolStripMenuItem_Click);
            // 
            // columnModeToolStripMenuItem
            // 
            this.columnModeToolStripMenuItem.Checked = true;
            this.columnModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columnModeToolStripMenuItem.Name = "columnModeToolStripMenuItem";
            this.columnModeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.columnModeToolStripMenuItem.Text = "Column Mode";
            this.columnModeToolStripMenuItem.Click += new System.EventHandler(this.columnModeToolStripMenuItem_Click);
            // 
            // dataGridView_pixelGrid
            // 
            this.dataGridView_pixelGrid.AllowUserToAddRows = false;
            this.dataGridView_pixelGrid.AllowUserToDeleteRows = false;
            this.dataGridView_pixelGrid.AllowUserToResizeColumns = false;
            this.dataGridView_pixelGrid.AllowUserToResizeRows = false;
            this.dataGridView_pixelGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_pixelGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_pixelGrid.Location = new System.Drawing.Point(12, 55);
            this.dataGridView_pixelGrid.MultiSelect = false;
            this.dataGridView_pixelGrid.Name = "dataGridView_pixelGrid";
            this.dataGridView_pixelGrid.ReadOnly = true;
            this.dataGridView_pixelGrid.ShowCellErrors = false;
            this.dataGridView_pixelGrid.ShowCellToolTips = false;
            this.dataGridView_pixelGrid.ShowEditingIcon = false;
            this.dataGridView_pixelGrid.ShowRowErrors = false;
            this.dataGridView_pixelGrid.Size = new System.Drawing.Size(760, 472);
            this.dataGridView_pixelGrid.TabIndex = 3;
            this.dataGridView_pixelGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_pixelGrid_CellClick);
            this.dataGridView_pixelGrid.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_pixelGrid_ColumnAdded);
            this.dataGridView_pixelGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_pixelGrid_RowsAdded);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_gridSizeX,
            this.toolStripLabel2,
            this.toolStripTextBox_gridSizeY,
            this.toolStripButton_generateGrid,
            this.toolStripLabel3,
            this.toolStripTextBox_selectedColour,
            this.toolStripButton_selectColour});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Grid X:";
            // 
            // toolStripTextBox_gridSizeX
            // 
            this.toolStripTextBox_gridSizeX.Name = "toolStripTextBox_gridSizeX";
            this.toolStripTextBox_gridSizeX.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox_gridSizeX.Text = "10";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel2.Text = "Grid Y:";
            // 
            // toolStripTextBox_gridSizeY
            // 
            this.toolStripTextBox_gridSizeY.Name = "toolStripTextBox_gridSizeY";
            this.toolStripTextBox_gridSizeY.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox_gridSizeY.Text = "10";
            // 
            // toolStripButton_generateGrid
            // 
            this.toolStripButton_generateGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_generateGrid.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_generateGrid.Image")));
            this.toolStripButton_generateGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_generateGrid.Name = "toolStripButton_generateGrid";
            this.toolStripButton_generateGrid.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_generateGrid.Text = "toolStripButton1";
            this.toolStripButton_generateGrid.Click += new System.EventHandler(this.toolStripButton_generateGrid_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel3.Text = "Selected Colour:";
            // 
            // toolStripTextBox_selectedColour
            // 
            this.toolStripTextBox_selectedColour.Enabled = false;
            this.toolStripTextBox_selectedColour.Name = "toolStripTextBox_selectedColour";
            this.toolStripTextBox_selectedColour.ReadOnly = true;
            this.toolStripTextBox_selectedColour.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton_selectColour
            // 
            this.toolStripButton_selectColour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_selectColour.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_selectColour.Image")));
            this.toolStripButton_selectColour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_selectColour.Name = "toolStripButton_selectColour";
            this.toolStripButton_selectColour.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_selectColour.Text = "toolStripButton1";
            this.toolStripButton_selectColour.Click += new System.EventHandler(this.toolStripButton_selectColour_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Enabled = false;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView_pixelGrid);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Pixel Art Array Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pixelGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_version;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_sizeInBytes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_author;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arraysToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_pixelGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_gridSizeX;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_gridSizeY;
        private System.Windows.Forms.ToolStripButton toolStripButton_generateGrid;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton_selectColour;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_selectedColour;
        private System.Windows.Forms.ToolStripMenuItem cRGBMultiDimenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cWRGBMultidimensionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rowModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
    }
}

