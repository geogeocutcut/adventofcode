using System;
using System.Collections;
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
    public class BotD12b : Bot
    {
        char[,] map;
        List<HashSet<(int,int)>> Zones = new List<HashSet<(int, int)>>();

        public override long Compute(IEnumerable<string> datas)
        {
            map = ConvertToGrid(datas.ToArray());
            BuildZones();
            return Zones.Sum(x => x.Count()*CalculBounderies(x));
        }

        private int CalculBounderies(HashSet<(int, int)> zone)
        {
            int segCount = 0;
            List<(char,int, int)> bounderies = new List<(char, int, int)>();
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };
            foreach (var cel in zone)
            {
                for (int k = 0; k < 4; k++)
                {
                    char dir = dRow[k] == 0 ? 'V' : 'H';

                    int newRow = cel.Item1 + dRow[k];
                    int newCol = cel.Item2 + dCol[k];
                    if(!zone.Contains((newRow, newCol)))
                    {
                        //if(!bounderies.Contains((dir, newRow, newCol)))
                            bounderies.Add((dir, newRow, newCol));
                    }
                }
            }
            //return bounderies.Count();
            var boundsH = bounderies.Where(b => b.Item1 == 'H').OrderBy(b=>b.Item2).ThenBy(b=>b.Item3);
            (char, int, int) previous = ('X',-9,-9);
            foreach (var b in boundsH)
            {
                if(!(previous.Item2 == b.Item2 && previous.Item3 == b.Item3-1))
                {
                    segCount += 1;
                }
                previous = b;
            }

            var boundsV = bounderies.Where(b => b.Item1 == 'V').OrderBy(b => b.Item3).ThenBy(b => b.Item2);
            previous = ('X', -9, -9);
            foreach (var b in boundsV)
            {
                if (!(previous.Item2 == b.Item2-1 && previous.Item3 == b.Item3))
                {
                    segCount += 1;
                }
                previous = b;
            }
            return segCount;
        }

        private void BuildZones()
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);

            // Directions pour se déplacer (haut, bas, gauche, droite)
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            void exploreZone(HashSet<(int, int)> zone,int i, int j)
            {
                // Explorer les voisins
                for (int k = 0; k < 4; k++)
                {
                    int newRow = i + dRow[k];
                    int newCol = j + dCol[k];

                    // Vérifier les limites de la carte
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        // Vérifier si le voisin est valide pour continuer le chemin
                        if (!visited.Contains((newRow, newCol)) && map[i, j] == map[newRow, newCol])
                        {
                            zone.Add((newRow, newCol));
                            visited.Add((newRow, newCol));
                            exploreZone(zone,newRow, newCol);
                        }
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!visited.Contains((i, j)))
                    {
                        var zone = new HashSet<(int, int)>();
                        zone.Add((i, j));
                        visited.Add((i, j));
                        exploreZone(zone, i, j);
                        Zones.Add(zone);
                    }
                }
            }
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
