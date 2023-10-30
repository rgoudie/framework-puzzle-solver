using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FrameworkPuzzleSolver;

public partial class FormFrameworkSolver : Form
{
    private bool _disposed;
    private List<string> _words;
    private int _columns;
    private int _rows;
    private char[][] _puzzleGrid;
    private bool _dimensionsChanged;
    private bool _solving;
    private bool _puzzleLoad;
    private bool _puzzleLoaded;

    public FormFrameworkSolver()
    {
        InitializeComponent();

        _disposed = false;
        _words = new List<string>();
        _dimensionsChanged = true;
        _solving = false;
        _puzzleLoad = _puzzleLoaded = false;
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        if (!_disposed)
        {
            _disposed = true;
            _words.Clear();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Determine whether the label is a letter or a block.
    /// </summary>
    /// <param name="label">Target label.</param>
    /// <returns>True if the label is a letter, otherwise false.</returns>
    private static bool IsLetter(Label label)
    {
        return label.BackColor == SystemColors.ControlLightLight;
    }

    /// <summary>
    /// Take note when any dimension is changed.
    /// </summary>
    private void NumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        _dimensionsChanged = true;
    }

    /// <summary>
    /// Draw puzzle grid with the given dimensions.
    /// </summary>
    private void ButtonDrawPuzzleGrid_Click(object sender, EventArgs e)
    {
        if (!_dimensionsChanged) return;

        Cursor = Cursors.WaitCursor;

        GetPuzzleGridDimensions();
        DrawPuzzleGrid();

        Cursor = Cursors.Default;

        groupBoxWords.Enabled = groupBoxPuzzleGrid.Enabled = buttonSolve.Enabled = true;
        textBoxWord.Focus();

        if (_puzzleLoad)
        {
            CopyCharArray2TableLayoutPanel();
            System.Media.SystemSounds.Beep.Play();
            _puzzleLoad = false;
            _puzzleLoaded = true;
        }
    }

    private void GetPuzzleGridDimensions()
    {
        _columns = (int)numericUpDownColumns.Value;
        _rows = (int)numericUpDownRows.Value;
    }

    /// <summary>
    /// Draw the puzzle grid.
    /// </summary>
    private void DrawPuzzleGrid()
    {
        if (!_dimensionsChanged) return;

        tableLayoutPanelPuzzleGrid.Visible = false;
        tableLayoutPanelPuzzleGrid.SuspendLayout();
        tableLayoutPanelPuzzleGrid.Controls.Clear();
        tableLayoutPanelPuzzleGrid.ColumnCount = _columns;
        var percentage = 100F / _columns;
        tableLayoutPanelPuzzleGrid.ColumnStyles.Clear();
        for (var c = 0; c < _columns; ++c)
            tableLayoutPanelPuzzleGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentage));
        tableLayoutPanelPuzzleGrid.RowCount = _rows;
        percentage = 100F / _rows;
        tableLayoutPanelPuzzleGrid.RowStyles.Clear();
        for (var r = 0; r < _rows; ++r)
            tableLayoutPanelPuzzleGrid.RowStyles.Add(new RowStyle(SizeType.Percent, percentage));
        DrawLabels();
        tableLayoutPanelPuzzleGrid.ResumeLayout();
        tableLayoutPanelPuzzleGrid.Visible = true;
        _dimensionsChanged = false;
    }

    /// <summary>
    /// Draw the labels to fit in each cell of the puzzle grid.
    /// </summary>
    private void DrawLabels()
    {
        var currentTabIndex = 10;
        var font = new Font("Verdana", GetFontSize(), FontStyle.Regular, GraphicsUnit.Point, 0);
        var point = new Point(1, 1);
        var padding = new Padding(0);
        var size = new Size(10, 10);
        for (var c = 0; c < _columns; ++c)
        {
            for (var r = 0; r < _rows; ++r)
            {
                var label = new Label
                {
                    AutoSize = true,
                    BackColor = SystemColors.ControlLightLight,
                    Dock = DockStyle.Fill,
                    Font = font,
                    Location = point,
                    Margin = padding,
                    Name = $"label_{c:00}_{r:00}",
                    Size = size,
                    TabIndex = currentTabIndex++,
                    Text = string.Empty,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                label.MouseClick += Label_MouseClick;
                tableLayoutPanelPuzzleGrid.Controls.Add(label, c, r);
            }
        }
    }

    /// <summary>
    /// Adds a new word to the list of words.
    /// </summary>
    private void ButtonAddWord_Click(object sender, EventArgs e)
    {
        var word = textBoxWord
            .Text
            .Trim()
            .ToUpperInvariant();

        if (!_words.Contains(word))
        {
            _words.Add(word);
            _words = _words
                .OrderBy(w => w.Length)
                .ThenBy(w => w)
                .ToList();
            SetDataSource(_words);
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
        foreach (var w in words)
            dataGridViewWords.Rows.Add(w);
        dataGridViewWords.Cursor = Cursors.Default;
        dataGridViewWords.ResumeLayout();
    }

    /// <summary>
    /// Solve the puzzle.
    /// </summary>
    private void ButtonSolve_Click(object sender, EventArgs e)
    {
        _solving = true;
        groupBoxDimensions.Enabled = textBoxWord.Enabled = buttonAddWord.Enabled = buttonSolve.Enabled = false;

        if (!_puzzleLoaded)
        {
            _puzzleGrid = new char[_columns][];
            CopyTableLayoutPanel2CharArray();
        }

        // Solve the puzzle
        groupBoxPuzzleGrid.Cursor = Cursors.WaitCursor;
        var frameworkSolver = new FrameworkSolver(_puzzleGrid, _words);
        _puzzleGrid = frameworkSolver.SolvePuzzle();
        if (_puzzleGrid == null) return;
        groupBoxPuzzleGrid.Cursor = Cursors.Default;

        CopyCharArray2TableLayoutPanel();
    }

    /// <summary>
    /// Copy TableLayoutPanel to char array.
    /// </summary>
    private void CopyTableLayoutPanel2CharArray()
    {
        Cursor = Cursors.WaitCursor;
        for (var column = 0; column < _columns; ++column)
        {
            _puzzleGrid[column] = new char[_rows];
            for (var row = 0; row < _rows; ++row)
            {
                var label = tableLayoutPanelPuzzleGrid.GetControlFromPosition(column, row) as Label;
                _puzzleGrid[column][row] = IsLetter(label) ? FrameworkSolver.SPACE : FrameworkSolver.BLOCK;
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
        for (var column = 0; column < _columns; ++column)
        {
            for (var row = 0; row < _rows; ++row)
            {
                if (!(tableLayoutPanelPuzzleGrid.GetControlFromPosition(column, row) is Label label))
                {
                    throw new Exception("Label is null.");
                }

                var ch = _puzzleGrid[column][row];
                if (ch != FrameworkSolver.BLOCK)
                    label.Text = new string(ch, 1);
                else if (!_solving)
                    ToggleCellStatus(label);
            }
        }
        Cursor = Cursors.Default;
    }

    /// <summary>
    /// Capture mouse right click events.
    /// </summary>
    private void Label_MouseClick(object sender, MouseEventArgs e)
    {
        if (!_solving && e.Button == MouseButtons.Right && e.Clicks == 1)
            ToggleCellStatus((Label)sender);
    }

    /// <summary>
    /// Toggle the status of the cell.
    /// </summary>
    /// <param name="label">Label control to toggle.</param>
    private static void ToggleCellStatus(Label label)
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
        return (float)tableLayoutPanelPuzzleGrid.Size.Height / _rows * 0.5f;
    }

    /// <summary>
    /// Clear word text box and set focus.
    /// </summary>
    private void ClearWordTextBox()
    {
        textBoxWord.Text = string.Empty;
        textBoxWord.Focus();
    }

    private void LoadPuzzleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var open = new OpenFileDialog();
        open.AddExtension = true;
        open.CheckFileExists = true;
        open.CheckPathExists = true;
        open.DefaultExt = "puz";
        open.FileName = string.Empty;
        open.Filter = "Puzzle files (*.puz)|*.puz|All files (*.*)|*.*";
        open.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        open.Multiselect = false;
        open.RestoreDirectory = true;
        open.ShowReadOnly = false;
        open.Title = "Select Framework puzzle file";

        var result = open.ShowDialog(this);
        if (result != DialogResult.OK) return;

        if (!File.Exists(open.FileName))
        {
            System.Media.SystemSounds.Beep.Play();
            MessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var json = File.ReadAllText(open.FileName);
        (_puzzleGrid, _words) = JsonConvert.DeserializeObject<(char[][], List<string>)>(json);
        numericUpDownColumns.Value = _puzzleGrid.Length;
        numericUpDownRows.Value = _puzzleGrid[0].Length;

        SetDataSource(_words);

        _puzzleLoad = true;
        buttonDrawPuzzleGrid.PerformClick();
    }

    private void SavePuzzleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var save = new SaveFileDialog();
        save.AddExtension = true;
        save.DefaultExt = "puz";
        save.FileName = string.Empty;
        save.Filter = "Puzzle files (*.puz)|*.puz|All files (*.*)|*.*";
        save.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        save.OverwritePrompt = true;
        save.RestoreDirectory = true;
        save.Title = "Save Framework puzzle";
        var result = save.ShowDialog(this);
        if (result == DialogResult.OK)
        {
            GetPuzzleGridDimensions();
            _puzzleGrid = new char[_columns][];
            CopyTableLayoutPanel2CharArray();
            var tuple = new Tuple<char[][], List<string>>(_puzzleGrid, _words);
            var json = JsonConvert.SerializeObject(tuple);
            File.WriteAllText(save.FileName, json);
            System.Media.SystemSounds.Beep.Play();
        }
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }
}
