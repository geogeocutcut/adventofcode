using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD6a : Bot
    {
        Cell[,] _map;

        Guard _guard = new Guard(); 

        public override int Compute(IEnumerable<string> datas)
        {
            _map=ConvertToGrid(datas.ToArray());

            HashSet<Cell> visitedCell = new HashSet<Cell>();
            HashSet<string> parcouru = new HashSet<string>();
            var pos = _map[_guard.Pos.X, _guard.Pos.Y];
            visitedCell.Add(pos);
            while (pos != null)
            {
                _guard.Pos = pos;

                if (parcouru.Contains(_guard.Pos.X + "_" + _guard.Pos.Y + "_" + _guard.VecteurInitial))
                    break;

                visitedCell.Add(pos);
                parcouru.Add(_guard.Pos.X + "_" + _guard.Pos.Y + "_" + _guard.VecteurInitial);

                if (pos.Neighbourg[_guard.VecteurInitial]!=null && pos.Neighbourg[_guard.VecteurInitial].isNotUsable)
                {
                    _guard.VecteurInitial =  (_guard.VecteurInitial + 1)%4;
                }
                else 
                {
                    pos = pos.Neighbourg[_guard.VecteurInitial];
                }

            }
            return visitedCell.Count;
        }

        private Cell[,] ConvertToGrid(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            Cell[,] grid = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {

                    grid[i, j] = new Cell(i, j);
                    if (input[i][j] == '#')
                    {
                        grid[i, j].isNotUsable = true;
                    }
                    if (i > 0)
                    {
                        grid[i, j].Neighbourg[0] = grid[i - 1, j];
                        grid[i - 1, j] .Neighbourg[2] = grid[i, j];
                    }
                        
                    if (j > 0)
                    {
                        grid[i, j].Neighbourg[3] = grid[i, j - 1];
                        grid[i, j - 1].Neighbourg[1] = grid[i, j];
                    }
                    if (new[] { '^', '>', 'v', '<' }.Contains(input[i][j]))
                    {
                        _guard.Pos = grid[i, j];

                        _guard.VecteurInitial = (input[i][j] == '^' ? 0
                                                    : input[i][j] == '>' ? 1
                                                    : input[i][j] == 'v' ? 2
                                                    : 3);
                    }
                }
            }

            return grid;
        }
    }

    public class Guard
    {
        public Cell Pos;

        public int VecteurInitial = 0;

        public Guard()
        {
        }
    }

    public class Cell
    {
        public int X;
        public int Y;



        public bool isNotUsable=false;

        public Cell(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Neighbourg = new Cell[4];
        }
        public Cell[] Neighbourg
        { get; set; }

    }
}
