using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD8b : Bot
    {
        char[,] _map ; 
        List<Antenne> Antennes = new List<Antenne>();
        HashSet<string> positionsPossibles = new HashSet<string>();

        public override long Compute(IEnumerable<string> datas)
        {
            ConvertToGrid(datas.ToArray());

            // trouver les zones 
            foreach (var a in Antennes)
            {
                positionsPossibles.Add($"({a.Position.X},{a.Position.Y})");
                foreach (var b in Antennes)
                {
                    if (a != b && a.Hz==b.Hz)
                    {
                        (int, int) vp = (b.Position.X - a.Position.X, b.Position.Y - a.Position.Y);
                        (int, int) vptmp = (b.Position.X - a.Position.X, b.Position.Y - a.Position.Y);
                        while ((a.Position.X - vptmp.Item1) >= 0 && (a.Position.X - vptmp.Item1) < _map.GetLength(0)
                            && (a.Position.Y - vptmp.Item2) >= 0 && (a.Position.Y - vptmp.Item2) < _map.GetLength(1))
                        {
                            positionsPossibles.Add($"({a.Position.X - vptmp.Item1},{a.Position.Y - vptmp.Item2})");
                            vptmp.Item1 += vp.Item1;
                            vptmp.Item2 += vp.Item2;
                        }


                    }
                }
            }
            return positionsPossibles.OrderBy(x=>x).Count(); ;
        }

        private void ConvertToGrid(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            _map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _map[i, j] = input[i][j];
                    if (_map[i,j]!='.')
                    {
                        // c est une antenne
                        var ant = new Antenne(new Position(i,j), _map[i, j]);
                        Antennes.Add(ant);
                    }
                }
            }

        }

        public class Antenne
        {
            public char Hz { get; set; }
            public Position Position { get; set; }
            public Antenne(Position pos, char hz)
            { 
                Position = pos;
                Hz = hz;
            }
        }

        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }


    }
}
