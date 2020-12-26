namespace FrameworkPuzzleSolver
{
    partial class FormFrameworkSolver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrameworkSolver));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxPuzzleGrid = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPuzzle = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelPuzzleGrid = new System.Windows.Forms.TableLayoutPanel();
            this.label_01_01 = new System.Windows.Forms.Label();
            this.labelPuzzleGridInstructions = new System.Windows.Forms.Label();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDimensions = new System.Windows.Forms.GroupBox();
            this.buttonDrawPuzzleGrid = new System.Windows.Forms.Button();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelColumns = new System.Windows.Forms.Label();
            this.groupBoxWords = new System.Windows.Forms.GroupBox();
            this.dataGridViewWords = new System.Windows.Forms.DataGridView();
            this.Word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePuzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxPuzzleGrid.SuspendLayout();
            this.tableLayoutPanelPuzzle.SuspendLayout();
            this.tableLayoutPanelPuzzleGrid.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.groupBoxDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.groupBoxWords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxPuzzleGrid, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(12, 40);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1447, 743);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // groupBoxPuzzleGrid
            // 
            this.groupBoxPuzzleGrid.Controls.Add(this.tableLayoutPanelPuzzle);
            this.groupBoxPuzzleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPuzzleGrid.Enabled = false;
            this.groupBoxPuzzleGrid.Location = new System.Drawing.Point(273, 3);
            this.groupBoxPuzzleGrid.Name = "groupBoxPuzzleGrid";
            this.groupBoxPuzzleGrid.Size = new System.Drawing.Size(1171, 737);
            this.groupBoxPuzzleGrid.TabIndex = 1;
            this.groupBoxPuzzleGrid.TabStop = false;
            this.groupBoxPuzzleGrid.Text = "Puzzle grid";
            // 
            // tableLayoutPanelPuzzle
            // 
            this.tableLayoutPanelPuzzle.ColumnCount = 1;
            this.tableLayoutPanelPuzzle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPuzzle.Controls.Add(this.tableLayoutPanelPuzzleGrid, 0, 0);
            this.tableLayoutPanelPuzzle.Controls.Add(this.labelPuzzleGridInstructions, 0, 1);
            this.tableLayoutPanelPuzzle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPuzzle.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanelPuzzle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPuzzle.Name = "tableLayoutPanelPuzzle";
            this.tableLayoutPanelPuzzle.RowCount = 2;
            this.tableLayoutPanelPuzzle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPuzzle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelPuzzle.Size = new System.Drawing.Size(1165, 715);
            this.tableLayoutPanelPuzzle.TabIndex = 1;
            // 
            // tableLayoutPanelPuzzleGrid
            // 
            this.tableLayoutPanelPuzzleGrid.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelPuzzleGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelPuzzleGrid.ColumnCount = 10;
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanelPuzzleGrid.Controls.Add(this.label_01_01, 0, 0);
            this.tableLayoutPanelPuzzleGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanelPuzzleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPuzzleGrid.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPuzzleGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPuzzleGrid.Name = "tableLayoutPanelPuzzleGrid";
            this.tableLayoutPanelPuzzleGrid.RowCount = 10;
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPuzzleGrid.Size = new System.Drawing.Size(1165, 680);
            this.tableLayoutPanelPuzzleGrid.TabIndex = 0;
            this.tableLayoutPanelPuzzleGrid.Visible = false;
            // 
            // label_01_01
            // 
            this.label_01_01.AutoSize = true;
            this.label_01_01.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_01_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_01_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_01_01.Font = new System.Drawing.Font("Courier New", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_01_01.Location = new System.Drawing.Point(1, 1);
            this.label_01_01.Margin = new System.Windows.Forms.Padding(0);
            this.label_01_01.Name = "label_01_01";
            this.label_01_01.Size = new System.Drawing.Size(478, 254);
            this.label_01_01.TabIndex = 0;
            this.label_01_01.Text = "Z";
            this.label_01_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_01_01.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_MouseClick);
            // 
            // labelPuzzleGridInstructions
            // 
            this.labelPuzzleGridInstructions.AutoSize = true;
            this.labelPuzzleGridInstructions.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelPuzzleGridInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPuzzleGridInstructions.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPuzzleGridInstructions.Location = new System.Drawing.Point(3, 680);
            this.labelPuzzleGridInstructions.Name = "labelPuzzleGridInstructions";
            this.labelPuzzleGridInstructions.Size = new System.Drawing.Size(1159, 35);
            this.labelPuzzleGridInstructions.TabIndex = 0;
            this.labelPuzzleGridInstructions.Text = "Right-click on a square to toggle between a letter square and a void square.";
            this.labelPuzzleGridInstructions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.groupBoxDimensions, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.groupBoxWords, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.buttonSolve, 0, 2);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 3;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(270, 743);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // groupBoxDimensions
            // 
            this.groupBoxDimensions.Controls.Add(this.buttonDrawPuzzleGrid);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownRows);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownColumns);
            this.groupBoxDimensions.Controls.Add(this.labelRows);
            this.groupBoxDimensions.Controls.Add(this.labelColumns);
            this.groupBoxDimensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDimensions.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDimensions.Name = "groupBoxDimensions";
            this.groupBoxDimensions.Size = new System.Drawing.Size(264, 154);
            this.groupBoxDimensions.TabIndex = 0;
            this.groupBoxDimensions.TabStop = false;
            this.groupBoxDimensions.Text = "Dimensions";
            // 
            // buttonDrawPuzzleGrid
            // 
            this.buttonDrawPuzzleGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDrawPuzzleGrid.Location = new System.Drawing.Point(60, 103);
            this.buttonDrawPuzzleGrid.Name = "buttonDrawPuzzleGrid";
            this.buttonDrawPuzzleGrid.Size = new System.Drawing.Size(145, 31);
            this.buttonDrawPuzzleGrid.TabIndex = 4;
            this.buttonDrawPuzzleGrid.Text = "Create puzzle grid";
            this.buttonDrawPuzzleGrid.UseVisualStyleBackColor = true;
            this.buttonDrawPuzzleGrid.Click += new System.EventHandler(this.ButtonDrawPuzzleGrid_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDownRows.Location = new System.Drawing.Point(139, 59);
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(67, 23);
            this.numericUpDownRows.TabIndex = 3;
            this.numericUpDownRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownRows.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDownColumns.Location = new System.Drawing.Point(139, 29);
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(67, 23);
            this.numericUpDownColumns.TabIndex = 1;
            this.numericUpDownColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownColumns.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // labelRows
            // 
            this.labelRows.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(58, 61);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(48, 16);
            this.labelRows.TabIndex = 2;
            this.labelRows.Text = "Rows:";
            // 
            // labelColumns
            // 
            this.labelColumns.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelColumns.AutoSize = true;
            this.labelColumns.Location = new System.Drawing.Point(58, 31);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new System.Drawing.Size(68, 16);
            this.labelColumns.TabIndex = 0;
            this.labelColumns.Text = "Columns:";
            // 
            // groupBoxWords
            // 
            this.groupBoxWords.Controls.Add(this.dataGridViewWords);
            this.groupBoxWords.Controls.Add(this.buttonAddWord);
            this.groupBoxWords.Controls.Add(this.textBoxWord);
            this.groupBoxWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWords.Enabled = false;
            this.groupBoxWords.Location = new System.Drawing.Point(3, 163);
            this.groupBoxWords.Name = "groupBoxWords";
            this.groupBoxWords.Size = new System.Drawing.Size(264, 512);
            this.groupBoxWords.TabIndex = 1;
            this.groupBoxWords.TabStop = false;
            this.groupBoxWords.Text = "Words";
            // 
            // dataGridViewWords
            // 
            this.dataGridViewWords.AllowUserToAddRows = false;
            this.dataGridViewWords.AllowUserToResizeColumns = false;
            this.dataGridViewWords.AllowUserToResizeRows = false;
            this.dataGridViewWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWords.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewWords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewWords.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWords.ColumnHeadersVisible = false;
            this.dataGridViewWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Word});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWords.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewWords.Location = new System.Drawing.Point(9, 51);
            this.dataGridViewWords.MultiSelect = false;
            this.dataGridViewWords.Name = "dataGridViewWords";
            this.dataGridViewWords.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWords.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWords.ShowEditingIcon = false;
            this.dataGridViewWords.Size = new System.Drawing.Size(246, 455);
            this.dataGridViewWords.TabIndex = 2;
            // 
            // Word
            // 
            this.Word.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Word.DataPropertyName = "Word";
            this.Word.HeaderText = "Word";
            this.Word.MaxInputLength = 15;
            this.Word.Name = "Word";
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddWord.Location = new System.Drawing.Point(180, 22);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddWord.TabIndex = 1;
            this.buttonAddWord.Text = "Add";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.ButtonAddWord_Click);
            // 
            // textBoxWord
            // 
            this.textBoxWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxWord.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWord.Location = new System.Drawing.Point(9, 22);
            this.textBoxWord.MaxLength = 15;
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(157, 22);
            this.textBoxWord.TabIndex = 0;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSolve.Enabled = false;
            this.buttonSolve.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSolve.Location = new System.Drawing.Point(31, 687);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(207, 47);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "Solve puzzle";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1468, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPuzzleToolStripMenuItem,
            this.savePuzzleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadPuzzleToolStripMenuItem
            // 
            this.loadPuzzleToolStripMenuItem.Name = "loadPuzzleToolStripMenuItem";
            this.loadPuzzleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.loadPuzzleToolStripMenuItem.Text = "Load puzzle";
            this.loadPuzzleToolStripMenuItem.Click += new System.EventHandler(this.LoadPuzzleToolStripMenuItem_Click);
            // 
            // savePuzzleToolStripMenuItem
            // 
            this.savePuzzleToolStripMenuItem.Name = "savePuzzleToolStripMenuItem";
            this.savePuzzleToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.savePuzzleToolStripMenuItem.Text = "Save puzzle";
            this.savePuzzleToolStripMenuItem.Click += new System.EventHandler(this.SavePuzzleToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FormFrameworkSolver
            // 
            this.AcceptButton = this.buttonAddWord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1468, 795);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormFrameworkSolver";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Framework Puzzle Solver";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupBoxPuzzleGrid.ResumeLayout(false);
            this.tableLayoutPanelPuzzle.ResumeLayout(false);
            this.tableLayoutPanelPuzzle.PerformLayout();
            this.tableLayoutPanelPuzzleGrid.ResumeLayout(false);
            this.tableLayoutPanelPuzzleGrid.PerformLayout();
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.groupBoxDimensions.ResumeLayout(false);
            this.groupBoxDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.groupBoxWords.ResumeLayout(false);
            this.groupBoxWords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.GroupBox groupBoxDimensions;
        private System.Windows.Forms.GroupBox groupBoxWords;
        private System.Windows.Forms.GroupBox groupBoxPuzzleGrid;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelColumns;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.DataGridView dataGridViewWords;
        private System.Windows.Forms.Button buttonDrawPuzzleGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPuzzleGrid;
        private System.Windows.Forms.Label label_01_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn Word;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPuzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePuzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPuzzle;
        private System.Windows.Forms.Label labelPuzzleGridInstructions;
    }
}

