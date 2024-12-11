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
    public class BotD4b :  Bot
    {

        string[] patterns =
        {
            "MSAMS",
            "SMASM",
            "SSAMM",
            "MMASS"
        };


        public override int Compute(IEnumerable<string> datas)
        {
            char[,] grid = ConvertToGrid(datas.ToArray());

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int count = 0;

            // Search for the word in all directions
            for (int r = 0; r < rows-2; r++)
            {
                for (int c = 0; c < cols-2; c++)
                {
                    if (IsXMasFound(grid, r, c))
                       count++;
                }
            }
            return count;
        }

        private bool IsXMasFound(char[,] grid, int r, int c)
        {
            string strToValid = new string(new []{ grid[r, c],grid[r,c+2],grid[r+1,c+1],grid[r+2, c],grid[r+2,c+2]});
            for (int i = 0; i < patterns.Length; i++)
            {
                if (strToValid == patterns[i])
                    return true;
            }
            return false;
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
