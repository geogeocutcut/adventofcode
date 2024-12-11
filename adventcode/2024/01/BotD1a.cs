using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventcode._2024
{
    public class BotD1a :  Bot
    {
        IList<int> ints1 = new List<int>();
        IList<int> ints2 = new List<int>();

        


        public override int Compute(IEnumerable<string> datas)
        {
            DeserializeDatas(datas);

            int distTotal = 0;
            for (int i = 0; i < ints1.Count; i++) {
                distTotal += Math.Abs(ints1[i] - ints2[i]);
            }

            return distTotal;
        }

        private void DeserializeDatas(IEnumerable<string> datas)
        {
            foreach (string line in datas)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var lineSplit = line.Split(' ');
                    ints1.Add(int.Parse(lineSplit[0]));
                    ints2.Add(int.Parse(lineSplit[3]));
                }

            }
            ints1 = ints1.OrderBy(x => x).ToList();
            ints2 = ints2.OrderBy(x => x).ToList();
        }
    }
}
