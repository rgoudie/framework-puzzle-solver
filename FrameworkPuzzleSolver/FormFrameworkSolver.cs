using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FrameworkPuzzleSolver
{
    public partial class FormFrameworkSolver : Form
    {
        private bool disposed;
        private List<string> words;
        private int columns;
        private int rows;
        private char[][] puzzleGrid;
        private bool dimensionsChanged;
        bool solving;
        bool puzzleLoad;
        bool puzzleLoaded;

        public FormFrameworkSolver()
        {
            InitializeComponent();
            disposed = false;
            words = new List<string>();
            dimensionsChanged = true;
            solving = false;
            puzzleLoad = puzzleLoaded = false;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (!disposed)
            {
                disposed = true;
                words.Clear();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Take note when any dimension is changed.
        /// </summary>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            dimensionsChanged = true;
        }

        /// <summary>
        /// Draw puzzle grid with the given dimensions.
        /// </summary>
        private void buttonDrawPuzzleGrid_Click(object sender, EventArgs e)
        {
            if (!dimensionsChanged) return;
            Cursor = Cursors.WaitCursor;
            GetPuzzleGridDimensions();
            DrawPuzzleGrid();
            Cursor = Cursors.Default;
            groupBoxWords.Enabled = groupBoxPuzzleGrid.Enabled = buttonSolve.Enabled = true;
            textBoxWord.Focus();

            if (puzzleLoad)
            {
                CopyCharArray2TableLayoutPanel();
                System.Media.SystemSounds.Beep.Play();
                puzzleLoad = false;
                puzzleLoaded = true;
            }
        }

        private void GetPuzzleGridDimensions()
        {
            columns = (int)numericUpDownColumns.Value;
            rows = (int)numericUpDownRows.Value;
        }

        /// <summary>
        /// Draw the puzzle grid.
        /// </summary>
        private void DrawPuzzleGrid()
        {
            if (!dimensionsChanged) return;
            tableLayoutPanelPuzzleGrid.Visible = false;
            tableLayoutPanelPuzzleGrid.SuspendLayout();
            tableLayoutPanelPuzzleGrid.Controls.Clear();
            tableLayoutPanelPuzzleGrid.ColumnCount = columns;
            float percentage = 100F / columns;
            tableLayoutPanelPuzzleGrid.ColumnStyles.Clear();
            for (int c = 0; c < columns; ++c)
                tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentage));
            tableLayoutPanelPuzzleGrid.RowCount = rows;
            percentage = 100F / rows;
            tableLayoutPanelPuzzleGrid.RowStyles.Clear();
            for (int r = 0; r < rows; ++r)
                tableLayoutPanelPuzzleGrid.RowStyles.Add(new RowStyle(SizeType.Percent, percentage));
            DrawLabels();
            tableLayoutPanelPuzzleGrid.ResumeLayout();
            tableLayoutPanelPuzzleGrid.Visible = true;
            dimensionsChanged = false;
        }

        /// <summary>
        /// Draw the labels to fit in each cell of the puzzle grid.
        /// </summary>
        private void DrawLabels()
        {
            int currentTabIndex = 10;
            Font font = new Font("Verdana", GetFontSize(), FontStyle.Regular, GraphicsUnit.Point, 0);
            Point point = new Point(1, 1);
            Padding padding = new Padding(0);
            Size size = new Size(10, 10);
            Label label;
            for (int c = 0; c < columns; ++c)
            {
                for (int r = 0; r < rows; ++r)
                {
                    label = new Label();
                    label.AutoSize = true;
                    label.BackColor = SystemColors.ControlLightLight;
                    label.Dock = DockStyle.Fill;
                    label.Font = font;
                    label.Location = point;
                    label.Margin = padding;
                    label.Name = string.Format("label_{0:00}_{1:00}", c, r);
                    label.Size = size;
                    label.TabIndex = currentTabIndex++;
                    label.Text = string.Empty;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.MouseClick += new MouseEventHandler(this.label_MouseClick);
                    tableLayoutPanelPuzzleGrid.Controls.Add(label, c, r);
                }
            }
        }

        /// <summary>
        /// Adds a new word to the list of words.
        /// </summary>
        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            string word = textBoxWord
                .Text
                .Trim()
                .ToUpperInvariant();
            if (!words.Contains(word))
            {
                words.Add(word);
                words = words
                    .OrderBy(w => w.Length)
                    .ThenBy(w => w)
                    .ToList();
                SetDataSource(words);
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("The entered word is already in the word list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ClearWordTextBox();
        }

        private void SetDataSource(List<string> words)
        {
            dataGridViewWords.SuspendLayout();
            dataGridViewWords.Cursor = Cursors.WaitCursor;
            dataGridViewWords.Rows.Clear();
            foreach (string w in words)
                dataGridViewWords.Rows.Add(w);
            dataGridViewWords.Cursor = Cursors.Default;
            dataGridViewWords.ResumeLayout();
        }

        /// <summary>
        /// Solve the puzzle.
        /// </summary>
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            solving = true;
            groupBoxDimensions.Enabled = textBoxWord.Enabled = buttonAddWord.Enabled = buttonSolve.Enabled = false;

            if (!puzzleLoaded)
            {
                puzzleGrid = new char[columns][];
                CopyTableLayoutPanel2CharArray();
            }

            // Solve the puzzle
            groupBoxPuzzleGrid.Cursor = Cursors.WaitCursor;
            FrameworkSolver frameworkSolver = new FrameworkSolver(puzzleGrid, words);
            puzzleGrid = frameworkSolver.SolvePuzzle();
            if (puzzleGrid == null) return;
            frameworkSolver = null;
            groupBoxPuzzleGrid.Cursor = Cursors.Default;

            CopyCharArray2TableLayoutPanel();
        }

        /// <summary>
        /// Copy TableLayoutPanel to char array.
        /// </summary>
        private void CopyTableLayoutPanel2CharArray()
        {
            Cursor = Cursors.WaitCursor;
            for (int column = 0; column < columns; ++column)
            {
                puzzleGrid[column] = new char[rows];
                for (int row = 0; row < rows; ++row)
                {
                    Label label = tableLayoutPanelPuzzleGrid.GetControlFromPosition(column, row) as Label;
                    puzzleGrid[column][row] = IsLetter(label) ? FrameworkSolver.SPACE : FrameworkSolver.BLOCK;
                }
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Copy char array to TableLayoutPanel.
        /// </summary>
        private void CopyCharArray2TableLayoutPanel()
        {
            Cursor = Cursors.WaitCursor;
            for (int column = 0; column < columns; ++column)
            {
                for (int row = 0; row < rows; ++row)
                {
                    Label label = tableLayoutPanelPuzzleGrid.GetControlFromPosition(column, row) as Label;
                    char ch = puzzleGrid[column][row];
                    if (ch != FrameworkSolver.BLOCK)
                        label.Text = new string(ch, 1);
                    else if (!solving)
                        ToggleCellStatus(label);
                }
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Determine whether the label is a letter or a block.
        /// </summary>
        /// <param name="label">Target label.</param>
        /// <returns>True if the label is a letter, otherwise false.</returns>
        private bool IsLetter(Label label)
        {
            return label.BackColor == SystemColors.ControlLightLight;
        }

        /// <summary>
        /// Capture mouse right click events.
        /// </summary>
        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            if (!solving && e.Button == MouseButtons.Right && e.Clicks == 1)
                ToggleCellStatus((Label)sender);
        }

        /// <summary>
        /// Toggle the status of the cell.
        /// </summary>
        /// <param name="label">Label control to toggle.</param>
        private void ToggleCellStatus(Label label)
        {
            if (label.BackColor == SystemColors.ControlDark)
            {
                label.BackColor = SystemColors.ControlLightLight;
            }
            else
            {
                label.BackColor = SystemColors.ControlDark;
                label.Text = string.Empty;
            }
        }

        /// <summary>
        /// Return an appropriate font size for the current cell size.
        /// </summary>
        /// <returns>Font size.</returns>
        private float GetFontSize()
        {
            return (tableLayoutPanelPuzzleGrid.Size.Height / rows) * 0.5f;
        }

        /// <summary>
        /// Clear word text box and set focus.
        /// </summary>
        private void ClearWordTextBox()
        {
            textBoxWord.Text = string.Empty;
            textBoxWord.Focus();
        }

        private void loadPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "puz",
                FileName = string.Empty,
                Filter = "Puzzle files (*.puz)|*.puz|All files (*.*)|*.*",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Multiselect = false,
                RestoreDirectory = true,
                ShowReadOnly = false,
                Title = "Select Framework puzzle file"
            };
            DialogResult result = open.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (!File.Exists(open.FileName))
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string json = File.ReadAllText(open.FileName);
                Tuple<char[][], List<string>> tuple = Newtonsoft.Json.JsonConvert.DeserializeObject<Tuple<char[][], List<string>>>(json);
                puzzleGrid = tuple.Item1;
                numericUpDownColumns.Value = puzzleGrid.Length;
                numericUpDownRows.Value = puzzleGrid[0].Length;
                words = tuple.Item2;
                SetDataSource(words);
                puzzleLoad = true;
                buttonDrawPuzzleGrid.PerformClick();
            }
            open.Dispose();
        }

        private void savePuzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                AddExtension = true,
                DefaultExt = "puz",
                FileName = string.Empty,
                Filter = "Puzzle files (*.puz)|*.puz|All files (*.*)|*.*",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                OverwritePrompt = true,
                RestoreDirectory = true,
                Title = "Save Frameword puzzle"
            };
            DialogResult result = save.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                GetPuzzleGridDimensions();
                puzzleGrid = new char[columns][];
                CopyTableLayoutPanel2CharArray();
                Tuple<char[][], List<string>> tuple = new Tuple<char[][], List<string>>(puzzleGrid, words);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(tuple);
                File.WriteAllText(save.FileName, json);
                System.Media.SystemSounds.Beep.Play();
            }
            save.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
