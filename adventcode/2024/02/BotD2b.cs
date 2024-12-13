using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventcode._2024
{
    public class BotD2b :  Bot
    {

        public override long Compute(IEnumerable<string> datas)
        {
            

            int nbSafeLines = 0;

            foreach (var data in datas)
            {
                int[] levels = data.Split(' ').Select(int.Parse).ToArray();
                if (IsSafeLine(levels))
                {
                    nbSafeLines += 1;
                }
                else
                {
                    for (int i = 0; i < levels.Count(); i++)
                    {
                        // Créer une nouvelle liste en copiant l'originale
                        List<int> sousListe = new List<int>(levels);

                        // Supprimer l'élément à l'index i
                        sousListe.RemoveAt(i);

                        if (IsSafeLine(sousListe.ToArray()))
                        {
                            nbSafeLines += 1;
                            break;
                        }
                    }
                }
            }

            return nbSafeLines;
        }

        private bool IsSafeLine(int[] levels)
        {
            
            bool isIncrease = levels[0] < levels[1];
            int diff = Math.Abs(levels[0] - levels[1]);
            if (diff < 1 || diff > 3) return false;
            for (int i=2;i<levels.Length;i++)
            {
                if (isIncrease != levels[i-1] < levels[i]) return false;

                diff = Math.Abs(levels[i - 1] - levels[i]);
                if (diff < 1 || diff > 3) return false;
            }
            return true;
        }
    }
}
