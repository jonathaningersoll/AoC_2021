using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GiantSquid
{
    public class Board
    {
        public List<int> Spaces { get; set; } = new List<int>();
        public bool IsSolved { get; set; } = false;

        public int CalculateBoard()
        {
            return Spaces.Where(x => x < 100).Sum();
        }

        public bool CheckSpaceForDrawnNumber(int draw)
        {
            return Spaces.Contains(draw);
        }
        public void ApplyNumberToSpace(int draw)
        {
            Spaces[Spaces.IndexOf(draw)] = 100;
        }
        public bool CheckIfFiveInARow(List<int> spaces)
        {
            for (int i = 0; i < 25; i += 5)
            {
                if (spaces.GetRange(i, 5).ToList().Sum() == 500)
                {
                    if (!IsSolved)
                    {
                        IsSolved = !IsSolved;
                        return true;
                    }
                }
            }
                return false;
        }
        public List<int> RotateNinety(List<int> spaces)
        {
            var evalList = new List<int>();
            for (int j = 0; j < 5; j++)
            {
                for (int i = j; i < spaces.Count; i += 5)
                {
                    evalList.Add(spaces[i]);
                }
            }
            return evalList;
        }
    }

    public class GiantSquid
    {
        public int CurrentDraw { get; set; }
        public int RoundNumber { get; set; }
        public List<int> SolvedBoards { get; set; } = new List<int>();
        public int Board { get; set; }
        public List<Board> Boards { get; set; }
        public List<int> Deck { get; set; }
        public List<Board> BoardsToRemove { get; set; } = new List<Board>();

        public void Run()
        {
            Puzzle();
        }

        private void Puzzle()
        {
            PartOne();
            //PartTwo();
        }

        private void PartOne()
        {
            //var input = File.ReadAllLines(@"./testInput.txt").ToList();
            var input = File.ReadAllLines(@"./input.txt").ToList();

            // Create boards from the input
            Boards = CreateBoards(input);

            Deck = File.ReadAllText(@"./instructions.txt").Split(",").Select(x => int.Parse(x)).ToList();
            //Deck = File.ReadAllText(@"./testdeck.txt").Split(",").Select(x => int.Parse(x)).ToList();

            while (Boards.Count() > 1)
            {
                Deck.ForEach(x =>
                {
                    CurrentDraw = x;
                    Console.WriteLine("Current number: " + x);
                    Boards.ForEach(b =>
                    {
                        if (b.CheckSpaceForDrawnNumber(x))
                        {
                            b.ApplyNumberToSpace(x);
                            var rotatedBoard = b.RotateNinety(b.Spaces);
                            if (!b.CheckIfFiveInARow(b.Spaces))
                            {
                                b.CheckIfFiveInARow(rotatedBoard);
                            }
                            if (b.IsSolved)
                            {
                                SolvedBoards.Add(Boards.IndexOf(b));
                                Console.WriteLine("Board solved: " + (Boards.IndexOf(b) + 1));
                                Console.WriteLine("Score: " + b.CalculateBoard()*x);
                                BoardsToRemove.Add(b);
                            }
                        }
                    });
                    BoardsToRemove.ForEach(board => Boards.Remove(board));
                    BoardsToRemove.Clear();
                });
            }
        }

        private List<Board> CreateBoards(List<string> input)
        {
            var boardList = new List<Board>();
            var board = new Board();
            for(int i = 0; i < input.Count; i++)
            {
                if (input[i].Length > 0)
                {
                    // Maybe make a one-liner?
                    //var m = input.Select(a => a.Replace("  ", " ")).Select(b => b.Trim(' ')).Select(c => c.Split(" ")).ToList();
                    board.Spaces.AddRange(MakeLine(input[i]));
                }
                else
                {
                    boardList.Add(new Board {Spaces = new List<int>(board.Spaces)});
                    board.Spaces.Clear();
                }
            }
            return boardList;
        }

        private List<int> MakeLine(string line)
        {
            var replace = line.Replace("  ", " ");
            var trimOutsides = replace.Trim(' ');
            var split = trimOutsides.Split(" ");
            var trim = split.ToList().Select(x => x.Trim(' ')).ToList();
            var toInt = trim.Select(x => int.Parse(x)).ToList();

            return toInt;
        }
    }
}
