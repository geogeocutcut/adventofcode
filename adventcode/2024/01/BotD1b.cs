using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventcode._2024
{
    public class BotD1b : Bot
    {
        IList<int> ints1 = new List<int>();
        IDictionary<int,int> ints2 = new Dictionary<int,int>();



        public override long Compute (IEnumerable<string> datas)
        {
            DeserializeDatas(datas);

            long distTotal = 0;
            int coeff = 0;
            for (int i = 0; i < ints1.Count; i++) {
                coeff = ints2.ContainsKey(ints1[i]) ? ints2[ints1[i]] : 0;
                distTotal += ints1[i]*coeff;
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
                    if (!ints2.ContainsKey(int.Parse(lineSplit[3])))
                        ints2[int.Parse(lineSplit[3])] = 0;
                    ints2[int.Parse(lineSplit[3])] += 1;
                }

            }
        }
    }
}
