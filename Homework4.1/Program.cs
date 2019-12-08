using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework4._1
{
        
    class TicTacToe
    {
        int numRows = 3;
        int numCols = 3;
        int turnCount = 0;
        Dictionary<string, int> shadowSquares = new Dictionary<string, int>();
        Dictionary<string, string> chosenSquares = new Dictionary<string, string>();

        public void CreateSquares()
        {
            IEnumerable<int> rows = Enumerable.Range(1, numRows);
            IEnumerable<int> cols = Enumerable.Range(1, numCols);

            foreach (var row in rows)
            {
                foreach (var col in cols)
                {
                    var position = row.ToString() + col.ToString();
                    chosenSquares[position] = " ";
                    shadowSquares[position] = 0;
                }
            }
            DrawBoard();
        }
        
        public void DrawBoard()
        {
            if (turnCount.Equals(0))
            {
                Console.WriteLine("Welcome to TicTacToe. Input row and column coordinates of your selected square separated by comma");
            }
            else 
            {
            Console.Clear();
            }

            IEnumerable<int> rows = Enumerable.Range(1, numRows);
            IEnumerable<int> cols = Enumerable.Range(1, numCols);
            
            foreach (int row in rows)
            {
                Console.Write("|");
                foreach (int col in cols)
                {
                    Console.Write($" {chosenSquares[row.ToString() + col.ToString()]} |");
                }
                Console.WriteLine("");
            }
            ChooseTurn();
        }

        public void ChooseTurn()
        {
            while (chosenSquares.ContainsValue(" ") && !(CheckWin()))
            {
                turnCount++;

                if ((turnCount % 2) == 0)
                {
                    AskInput("X");
                }
                else
                {
                    AskInput("O");
                }
            }
            if (!chosenSquares.ContainsValue(" "))
            {
                Console.WriteLine("It's a tie");
            }
        }

        public void AskInput(string selection)
        {
            Console.WriteLine($"Player {selection} please make your selection");

            string chosenLoc = Console.ReadLine().Replace(",", "");

            if (string.IsNullOrEmpty(chosenLoc))
            {
                Console.WriteLine("You lose");
                System.Environment.Exit(1);
            }

            if (!chosenSquares.ContainsKey(chosenLoc) || chosenSquares[chosenLoc] != " ")
            {
                Console.WriteLine("Try again, location is not valid or is taken");
                chosenLoc = "";
                AskInput(selection);
            }
            else
            {
                chosenSquares[chosenLoc] = selection;
                shadowSquares[chosenLoc] = selection == "X" ? 1 : -1;
                DrawBoard();
            }
        }

        private bool CheckWin()
        {
            if ((Math.Abs(shadowSquares["11"] + shadowSquares["12"] + shadowSquares["13"]) == 3) ||
                (Math.Abs(shadowSquares["21"] + shadowSquares["22"] + shadowSquares["23"]) == 3) ||
                (Math.Abs(shadowSquares["31"] + shadowSquares["32"] + shadowSquares["33"]) == 3) ||
                (Math.Abs(shadowSquares["11"] + shadowSquares["21"] + shadowSquares["31"]) == 3) ||
                (Math.Abs(shadowSquares["12"] + shadowSquares["22"] + shadowSquares["32"]) == 3) ||
                (Math.Abs(shadowSquares["13"] + shadowSquares["23"] + shadowSquares["33"]) == 3) ||
                (Math.Abs(shadowSquares["31"] + shadowSquares["22"] + shadowSquares["33"]) == 3) ||
                (Math.Abs(shadowSquares["13"] + shadowSquares["22"] + shadowSquares["31"]) == 3))

            { 
                Console.WriteLine("You have won!");
                System.Environment.Exit(1);
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {            
            TicTacToe t = new TicTacToe();
            t.CreateSquares();
        }
    }
}
