using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkPuzzleSolver;

public enum Direction { Across, Down };

public class FrameworkSolver
{
    public const char SPACE = ' ';
    public const char BLOCK = '#';

    private readonly char[][] _puzzleGrid;
    private readonly List<string> _words;

    private Dictionary<int, List<string>> _lengthGroups;
    private List<WordSpace> _wordSpaces;
    private List<Intersection> _intersections;

    public FrameworkSolver(char[][] puzzleGrid, List<string> words)
    {
        _puzzleGrid = puzzleGrid;
        _words = words;

        if (puzzleGrid == null || words == null)
            throw new Exception("Solve parameters may not be null.");
    }

    /// <summary>
    /// Solve the Framework puzzle and return the char array solution.
    /// </summary>
    /// <returns>Char array containing solution.</returns>
    public char[][] SolvePuzzle()
    {
        GroupByWordLength();
        GenerateAcrossWordSpaces();
        GenerateDownWordSpaces();

        // Are there as many word spaces as there are given words?
        if (_words.Count != _wordSpaces.Count)
        {
            System.Windows.Forms.MessageBox.Show("The number of given words is different than the number of word spaces found in the grid!", "Error",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            return null;
        }

        GenerateWordIntersections();
        IntersectionIterations();

        return _puzzleGrid;
    }

    /// <summary>
    /// Group word list by string length.
    /// </summary>
    private void GroupByWordLength()
    {
        _lengthGroups = new Dictionary<int, List<string>>();
        var minLength = _words
            .Min(w => w.Length);
        var maxLength = _words
            .Max(w => w.Length);
        for (var length = minLength; length <= maxLength; ++length)
        {
            var wordsLength = _words
                .Where(w => w.Length == length)
                .OrderBy(w => w)
                .ToList();

            _lengthGroups.Add(length, wordsLength);
        }
    }

    /// <summary>
    /// Generate the list of across word spaces.
    /// </summary>
    private void GenerateAcrossWordSpaces()
    {
        _wordSpaces = new List<WordSpace>();

        for (var row = 0; row < _puzzleGrid[0].Length; ++row)
        {
            int endColumn;
            var startColumn = endColumn = 0;
            do
            {
                if (_puzzleGrid[endColumn][row] != BLOCK)
                {
                    // Read word space.
                    while (endColumn < _puzzleGrid.Length && _puzzleGrid[endColumn][row] != BLOCK)
                        ++endColumn;

                    var length = endColumn - startColumn;

                    if (!_lengthGroups.ContainsKey(length)) continue;

                    // We have an across word space.
                    var word = new WordSpace
                    {
                        Direction = Direction.Across,
                        EndPoint = new Cell(endColumn - 1, row),
                        Filled = false,
                        Length = length,
                        PossibleWords = _lengthGroups.ContainsKey(length)
                            ? new List<string>(_lengthGroups[length])
                            : new List<string>(),
                        StartPoint = new Cell(startColumn, row)
                    };
                    _wordSpaces.Add(word);
                }
                else
                {
                    // Skip over block sequence.
                    while (endColumn < _puzzleGrid.Length && _puzzleGrid[endColumn][row] == BLOCK)
                        ++endColumn;

                    startColumn = endColumn;
                }
            } while (endColumn < _puzzleGrid.Length);
        }
    }

    /// <summary>
    /// Generate the list of down word spaces.
    /// </summary>
    private void GenerateDownWordSpaces()
    {
        for (var column = 0; column < _puzzleGrid.Length; ++column)
        {
            int endRow;
            var startRow = endRow = 0;
            do
            {
                if (_puzzleGrid[column][endRow] == SPACE)
                {
                    // Read word space.
                    while (endRow < _puzzleGrid[0].Length && _puzzleGrid[column][endRow] != BLOCK)
                        ++endRow;

                    var length = endRow - startRow;

                    if (!_lengthGroups.ContainsKey(length)) continue;

                    // We have an across word space.
                    var wordSpace = new WordSpace
                    {
                        Direction = Direction.Down,
                        EndPoint = new Cell(column, endRow - 1),
                        Filled = false,
                        Length = length,
                        PossibleWords = _lengthGroups.ContainsKey(length)
                            ? new List<string>(_lengthGroups[length])
                            : new List<string>(),
                        StartPoint = new Cell(column, startRow)
                    };
                    _wordSpaces.Add(wordSpace);
                }
                else // (puzzleGrid[column][endRow] == BLOCK)
                {
                    // Skip over block sequence.
                    while (endRow < _puzzleGrid[0].Length && _puzzleGrid[column][endRow] == BLOCK)
                        ++endRow;

                    startRow = endRow;
                }
            } while (endRow < _puzzleGrid[0].Length);
        }
    }

    /// <summary>
    /// Generate the list of intersections between the across word spaces and the down word spaces.
    /// </summary>
    private void GenerateWordIntersections()
    {
        // Generate list of intersections.
        _intersections = new List<Intersection>();

        foreach (var wordspace in _wordSpaces)
        {
            if (wordspace.Direction == Direction.Across)
            {
                var i = _wordSpaces
                    .Where(ws => ws.Direction == Direction.Down)
                    .Where(ws => ws.StartPoint.Row <= wordspace.StartPoint.Row && wordspace.StartPoint.Row <= ws.EndPoint.Row)
                    .Where(ws => wordspace.StartPoint.Column <= ws.StartPoint.Column && ws.StartPoint.Column <= wordspace.EndPoint.Column)
                    .Select(ws => new Intersection
                    {
                        WordAcross = wordspace,
                        Column = ws.StartPoint.Column,
                        WordDown = ws,
                        Row = wordspace.StartPoint.Row
                    })
                    .ToList();
                _intersections.AddRange(i);
            }
            else // (wordspace.Direction == Direction.Down)
            {
                var i = _wordSpaces
                    .Where(ws => ws.Direction == Direction.Across)
                    .Where(ws => ws.StartPoint.Column <= wordspace.StartPoint.Column && wordspace.StartPoint.Column <= ws.EndPoint.Column)
                    .Where(ws => wordspace.StartPoint.Row <= ws.StartPoint.Row && ws.StartPoint.Row <= wordspace.EndPoint.Row)
                    .Select(ws => new Intersection
                    {
                        WordAcross = ws,
                        Column = wordspace.StartPoint.Column,
                        WordDown = wordspace,
                        Row = ws.StartPoint.Row
                    })
                    .ToList();
                _intersections.AddRange(i);
            }
        }
    }

    /// <summary>
    ///  Iterate through all of the solving logic until all word spaces are uniquely filled.
    /// </summary>
    private void IntersectionIterations()
    {
        var sanity = 0;
        const int SANITY_LIMIT = 100;

        do
        {
            AnalyzeIntersections();
            SearchForSingleRemainingWords();

            ++sanity;
        } while (sanity < SANITY_LIMIT && !AreWeDone());

        if (sanity == SANITY_LIMIT)
            throw new OverflowException("Intersection iterations surpassed " + sanity + " iterations!");
    }

    /// <summary>
    /// Analyze word space intersections, to determine whether any intersections result
    /// in a single word possibility for either word spaces.
    /// </summary>
    private void AnalyzeIntersections()
    {
        // Process each intersection that still has unfilled word spaces.
        var unfilledIntersections = _intersections
            .Where(i => !i.WordAcross.Filled || !i.WordDown.Filled);

        foreach (var intersection in unfilledIntersections)
        {
            var wordAcrossNdx = intersection.Column - intersection.WordAcross.StartPoint.Column;
            var wordDownNdx = intersection.Row - intersection.WordDown.StartPoint.Row;

            if (!intersection.WordAcross.Filled)
            {
                // Reduce across word space possibilities.
                var join = intersection.WordAcross.PossibleWords
                    .Join(intersection.WordDown.PossibleWords,
                        wa => wa[wordAcrossNdx],
                        wd => wd[wordDownNdx],
                        (wa, wd) => new { Wa = wa, Wd = wd })
                    .Where(a => a.Wa != a.Wd);

                intersection.WordAcross.PossibleWords = join
                    .Select(j => j.Wa)
                    .Distinct()
                    .ToList();

                if (intersection.WordAcross.PossibleWords.Count == 0)
                    InvalidOperation(intersection.WordAcross, "AnalyzeIntersections");
            }

            if (!intersection.WordDown.Filled)
            {
                // Reduce down word space possibilities.
                var join = intersection.WordDown.PossibleWords
                    .Join(intersection.WordAcross.PossibleWords,
                        wd => wd[wordDownNdx],
                        wa => wa[wordAcrossNdx],
                        (wd, wa) => new { Wa = wa, Wd = wd })
                    .Where(a => a.Wd != a.Wa);

                intersection.WordDown.PossibleWords = join
                    .Select(j => j.Wd)
                    .Distinct()
                    .ToList();

                if (intersection.WordDown.PossibleWords.Count == 0)
                    InvalidOperation(intersection.WordDown, "AnalyzeIntersections");
            }
        }
    }

    /// <summary>
    /// Determine whether there are any word spaces with one possible remaining word.
    /// If so, then apply the word.
    /// </summary>
    private void SearchForSingleRemainingWords()
    {
        IEnumerable<WordSpace> singleWordSpaces;
        do
        {
            // Generate the list of word spaces that have one possible remaining word.
            singleWordSpaces = _wordSpaces
                .Where(ws => !ws.Filled)
                .Where(ws => ws.PossibleWords.Count == 1)
                .ToList();

            // Process each resulting word space.
            foreach (var wordspace in singleWordSpaces)
            {
                // Copy the remaining word to the puzzle grid.
                var word = wordspace.PossibleWords
                    .Single();

                if (wordspace.Direction == Direction.Across)
                {
                    for (var ndx = 0; ndx < word.Length; ++ndx)
                        _puzzleGrid[wordspace.StartPoint.Column + ndx][wordspace.StartPoint.Row] = word[ndx];
                }
                else // wordspace.Direction == Direction.Down
                {
                    for (var ndx = 0; ndx < word.Length; ++ndx)
                        _puzzleGrid[wordspace.StartPoint.Column][wordspace.StartPoint.Row + ndx] = word[ndx];
                }
                wordspace.Filled = true;

                // Remove word from all other, unfilled word spaces.
                var otherUnfilledWordSpaces = _wordSpaces
                    .Where(ws => !ws.Filled)
                    .Where(ws => ws != wordspace);
                foreach (var ws in otherUnfilledWordSpaces)
                {
                    ws.PossibleWords
                        .Remove(word);

                    if (ws.Length == 0) InvalidOperation(ws, "SearchForSingleRemainingWords");
                }
            }
        } while (singleWordSpaces.Any());
    }

    private bool AreWeDone()
    {
        return _wordSpaces
            .All(ws => ws.Filled);
    }

    private void InvalidOperation(WordSpace wordSpace, string methodName)
    {
        throw new InvalidOperationException(methodName + " | All possible words were eliminated for word space at (" +
                                            wordSpace.StartPoint.Column + "," + wordSpace.StartPoint.Row + ") to (" +
                                            wordSpace.EndPoint.Column + "," + wordSpace.EndPoint.Row + ").");
    }
}

public class WordSpace
{
    public Direction Direction { get; set; }
    public int Length { get; set; }
    public Cell StartPoint { get; set; }
    public Cell EndPoint { get; set; }
    public List<string> PossibleWords { get; set; }
    public bool Filled { get; set; }
}

public class Intersection
{
    public int Column { get; set; }
    public int Row { get; set; }
    public WordSpace WordAcross { get; set; }
    public WordSpace WordDown { get; set; }
}

public readonly struct Cell
{
    public int Column { get; }
    public int Row { get; }

    public Cell(int column, int row)
    {
        Column = column;
        Row = row;
    }
}
