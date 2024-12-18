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
    public class BotD10b : Bot
    {
        public override long Compute(IEnumerable<string> datas)
        {
            int[,] grid = ConvertToGrid(datas.ToArray());
            var result = CalculateTotalTrailheadScore(grid);
            return result;
        }

        private int CalculateTotalTrailheadScore(int[,] map)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            int totalScore = 0;

            // Parcourir chaque cellule de la carte
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Si la cellule est un trailhead (0)
                    if (map[r, c] == 0)
                    {
                        totalScore += CalculateTrailheadScore(map, r, c);
                    }
                }
            }

            return totalScore;
        }

        private int CalculateTrailheadScore(int[,] map, int startRow, int startCol)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);

            // Utilisation de BFS pour explorer les chemins
            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            queue.Enqueue((startRow, startCol));
            visited.Add((startRow, startCol));

            int reachableNines = 0;

            // Directions pour se déplacer (haut, bas, gauche, droite)
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            while (queue.Count > 0)
            {
                var (currentRow, currentCol) = queue.Dequeue();
                int currentHeight = map[currentRow, currentCol];

                // Si une position atteinte est un 9, l'ajouter au score
                if (currentHeight == 9)
                {
                    reachableNines++;
                    continue;
                }

                // Explorer les voisins
                for (int i = 0; i < 4; i++)
                {
                    int newRow = currentRow + dRow[i];
                    int newCol = currentCol + dCol[i];

                    // Vérifier les limites de la carte
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        int neighborHeight = map[newRow, newCol];

                        // Vérifier si le voisin est valide pour continuer le chemin
                        if (!visited.Contains((newRow, newCol)) && neighborHeight == currentHeight + 1)
                        {
                            queue.Enqueue((newRow, newCol));
                            //visited.Add((newRow, newCol));
                        }
                    }
                }
            }

            return reachableNines;
        }

        private int[,] ConvertToGrid(string[] input)
        {

            int rows = input.Length;
            int cols = input[0].Length;
            int[,] grid = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = int.Parse(input[i][j].ToString());
                }
            }

            return grid;
        }
    }
}
