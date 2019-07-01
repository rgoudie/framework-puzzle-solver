using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkPuzzleSolver
{
    public enum Direction { Across, Down };

    public class FrameworkSolver
    {
        public const char SPACE = ' ';
        public const char BLOCK = '#';

        private char[][] puzzleGrid;
        private List<string> words;

        private Dictionary<int, List<string>> lengthGroups;
        private List<WordSpace> wordSpaces;
        private List<Intersection> intersections;

        public FrameworkSolver(char[][] puzzleGrid, List<string> words)
        {
            this.puzzleGrid = puzzleGrid;
            this.words = words;

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
            if (words.Count != wordSpaces.Count)
            {
                System.Windows.Forms.MessageBox.Show("The number of given words is different than the number of word spaces found in the grid!", "Error", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }

            GenerateWordIntersections();
            IntersectionIterations();

            return puzzleGrid;
        }

        /// <summary>
        /// Group word list by string length.
        /// </summary>
        private void GroupByWordLength()
        {
            lengthGroups = new Dictionary<int, List<string>>();
            int minLength = words
                .Min(w => w.Length);
            int maxLength = words
                .Max(w => w.Length);
            for (int length = minLength; length <= maxLength; ++length)
            {
                List<string> wordsLength = words
                    .Where(w => w.Length == length)
                    .OrderBy(w => w)
                    .ToList();
                lengthGroups.Add(length, wordsLength);
            }
        }

        /// <summary>
        /// Generate the list of across word spaces.
        /// </summary>
        private void GenerateAcrossWordSpaces()
        {
            wordSpaces = new List<WordSpace>();
            int startColumn;
            int endColumn;

            for (int row = 0; row < puzzleGrid[0].Length; ++row)
            {
                startColumn = endColumn = 0;
                do
                {
                    if (puzzleGrid[endColumn][row] != BLOCK)
                    {
                        // Read word space.
                        while (endColumn < puzzleGrid.Length && puzzleGrid[endColumn][row] != BLOCK)
                            ++endColumn;
                        int length = endColumn - startColumn;
                        if (lengthGroups.ContainsKey(length))
                        {
                            // We have an across word space.
                            WordSpace word = new WordSpace()
                            {
                                Direction = Direction.Across,
                                EndPoint = new Cell(endColumn - 1, row),
                                Filled = false,
                                Length = length,
                                PossibleWords = lengthGroups.ContainsKey(length) ? new List<string>(lengthGroups[length]) : new List<string>(),
                                StartPoint = new Cell(startColumn, row)
                            };
                            wordSpaces.Add(word);
                        }
                    }
                    else
                    {
                        // Skip over block sequence.
                        while (endColumn < puzzleGrid.Length && puzzleGrid[endColumn][row] == BLOCK)
                            ++endColumn;
                        startColumn = endColumn;
                    }
                } while (endColumn < puzzleGrid.Length);
            }
        }

        /// <summary>
        /// Generate the list of down word spaces.
        /// </summary>
        private void GenerateDownWordSpaces()
        {
            int startRow;
            int endRow;

            for (int column = 0; column < puzzleGrid.Length; ++column)
            {
                startRow = endRow = 0;
                do
                {
                    if (puzzleGrid[column][endRow] == SPACE)
                    {
                        // Read word space.
                        while (endRow < puzzleGrid[0].Length && puzzleGrid[column][endRow] != BLOCK)
                            ++endRow;
                        int length = endRow - startRow;
                        if (lengthGroups.ContainsKey(length))
                        {
                            // We have an across word space.
                            WordSpace wordSpace = new WordSpace()
                            {
                                Direction = Direction.Down,
                                EndPoint = new Cell(column, endRow - 1),
                                Filled = false,
                                Length = length,
                                PossibleWords = lengthGroups.ContainsKey(length) ? new List<string>(lengthGroups[length]) : new List<string>(),
                                StartPoint = new Cell(column, startRow)
                            };
                            wordSpaces.Add(wordSpace);
                        }
                    }
                    else // (puzzleGrid[column][endRow] == BLOCK)
                    {
                        // Skip over block sequence.
                        while (endRow < puzzleGrid[0].Length && puzzleGrid[column][endRow] == BLOCK)
                            ++endRow;
                        startRow = endRow;
                    }
                } while (endRow < puzzleGrid[0].Length);
            }
        }

        /// <summary>
        /// Generate the list of intersections between the across word spaces and the down word spaces.
        /// </summary>
        private void GenerateWordIntersections()
        {
            // Generate list of intersections.
            intersections = new List<Intersection>();
            foreach (WordSpace wordspace in wordSpaces)
            {
                if (wordspace.Direction == Direction.Across)
                {
                    List<Intersection> i = wordSpaces
                        .Where(ws => ws.Direction == Direction.Down)
                        .Where(ws => ws.StartPoint.Row <= wordspace.StartPoint.Row && wordspace.StartPoint.Row <= ws.EndPoint.Row)
                        .Where(ws => wordspace.StartPoint.Column <= ws.StartPoint.Column && ws.StartPoint.Column <= wordspace.EndPoint.Column)
                        .Select(ws => new Intersection()
                        {
                            WordAcross = wordspace,
                            Column = ws.StartPoint.Column,
                            WordDown = ws,
                            Row = wordspace.StartPoint.Row
                        })
                        .ToList();
                    intersections.AddRange(i);
                }
                else // (wordspace.Direction == Direction.Down)
                {
                    List<Intersection> i = wordSpaces
                        .Where(ws => ws.Direction == Direction.Across)
                        .Where(ws => ws.StartPoint.Column <= wordspace.StartPoint.Column && wordspace.StartPoint.Column <= ws.EndPoint.Column)
                        .Where(ws => wordspace.StartPoint.Row <= ws.StartPoint.Row && ws.StartPoint.Row <= wordspace.EndPoint.Row)
                        .Select(ws => new Intersection()
                        {
                            WordAcross = ws,
                            Column = wordspace.StartPoint.Column,
                            WordDown = wordspace,
                            Row = ws.StartPoint.Row
                        })
                        .ToList();
                    intersections.AddRange(i);
                }
            }
        }

        /// <summary>
        ///  Iterate through all of the solving logic until all word spaces are uniquely filled.
        /// </summary>
        private void IntersectionIterations()
        {
            int sanity = 0,
                sanityLimit = 100;

            do
            {
                AnalyzeIntersections();
                SearchForSingleRemainingWords();

                ++sanity;
            } while (sanity < sanityLimit && !AreWeDone());

            if (sanity == sanityLimit)
                throw new OverflowException("Intersection iterations surpassed " + sanity + " iterations!");
        }

        /// <summary>
        /// Analyze word space intersections, to determine whether any intersections result
        /// in a single word possibility for either word spaces.
        /// </summary>
        private void AnalyzeIntersections()
        {
            // Process each intersection that still has unfilled word spaces.
            IEnumerable<Intersection> unfilledIntersections = intersections
                .Where(i => !i.WordAcross.Filled || !i.WordDown.Filled);
            foreach (Intersection intersection in unfilledIntersections)
            {
                int wordAcrossNdx = intersection.Column - intersection.WordAcross.StartPoint.Column;
                int wordDownNdx = intersection.Row - intersection.WordDown.StartPoint.Row;

                if (!intersection.WordAcross.Filled)
                {
                    // Reduce across word space possibilites.
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
                    // Reduce down word space possibilites.
                    var join = intersection.WordDown.PossibleWords
                        .Join(intersection.WordAcross.PossibleWords,
                                wd => wd[wordDownNdx],
                                wa => wa[wordAcrossNdx],
                                (wd, wa) => new { Wd = wd, Wa = wa })
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
            IEnumerable<WordSpace> singleWordSpaces = null;
            do
            {
                // Generate the list of word spaces that have one possible remaining word.
                singleWordSpaces = wordSpaces
                    .Where(ws => !ws.Filled)
                    .Where(ws => ws.PossibleWords.Count == 1);

                // Process each resulting word space.
                foreach (WordSpace wordspace in singleWordSpaces)
                {
                    // Copy the remaining word to the puzzle grid.
                    string word = wordspace.PossibleWords
                        .Single();

                    if (wordspace.Direction == Direction.Across)
                    {
                        for (int ndx = 0; ndx < word.Length; ++ndx)
                            puzzleGrid[wordspace.StartPoint.Column + ndx][wordspace.StartPoint.Row] = word[ndx];
                    }
                    else // wordspace.Direction == Direction.Down
                    {
                        for (int ndx = 0; ndx < word.Length; ++ndx)
                            puzzleGrid[wordspace.StartPoint.Column][wordspace.StartPoint.Row + ndx] = word[ndx];
                    }
                    wordspace.Filled = true;

                    // Remove word from all other, unfilled word spaces.
                    var otherUnfilledWordSpaces = wordSpaces
                        .Where(ws => !ws.Filled)
                        .Where(ws => ws != wordspace);
                    foreach (WordSpace ws in otherUnfilledWordSpaces)
                    {
                        ws.PossibleWords
                            .Remove(word);

                        if (ws.Length == 0) InvalidOperation(ws, "SearchForSingleRemainingWords");
                    }
                }
            } while (singleWordSpaces.Count() > 0);
        }

        private bool AreWeDone()
        {
            return wordSpaces
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

    public struct Cell
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public Cell(int column, int row)
        {
            Column = column;
            Row = row;
        }
    }
}
