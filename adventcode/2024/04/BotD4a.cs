using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD4a :  Bot
    {

        string word = "XMAS";
        // Directions for the 8 possible ways to move
        int[,] directions = {
            { 0, 1 },  // Right
            { 0, -1 }, // Left
            { 1, 0 },  // Down
            { -1, 0 }, // Up
            { 1, 1 },  // Down-right
            { -1, -1 },// Up-left
            { 1, -1 }, // Down-left
            { -1, 1 }  // Up-right
        };


        public override int Compute(IEnumerable<string> datas)
        {
            char[,] grid = ConvertToGrid(datas.ToArray());

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int count = 0;

            // Search for the word in all directions
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    for (int x = 0; x < directions.GetLength(0); x++)
                    {
                        if (IsWordFound(grid, word, r, c, directions[x,0], directions[x,1]))
                            count++;
                    }
                }
            }
            return count;
        }


        private bool IsWordFound(char[,] grid, string word, int row, int col, int dr, int dc)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int wordLength = word.Length;

            for (int i = 0; i < wordLength; i++)
            {
                int newRow = row + dr * i;
                int newCol = col + dc * i;

                if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow, newCol] != word[i])
                    return false;
            }

            return true;
        }

        private char[,] ConvertToGrid(string[] input)
        {
            
            int rows = input.Length;
            int cols = input[0].Length;
            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = input[i][j];
                }
            }

            return grid;
        }
    }
}
