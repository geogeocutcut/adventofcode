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
    public class BotD11b : Bot
    {
        Dictionary<long, long> stonesCount = new Dictionary<long, long>();
        public override long Compute(IEnumerable<string> datas)
        {
            stonesCount = datas.ElementAt(0).Split(' ').Select(long.Parse).ToDictionary(x => x, x => (long)1);
            for(int i = 0; i < 75; i++)
            {
                split();
            }
            return stonesCount.Values.Sum();
        }

        private void split()
        {
            Dictionary<long, long> stonesCountTmp = new Dictionary<long, long>();
            foreach (var s in stonesCount)
            {
                var nb = stonesCount[s.Key];
                var strg = s.Key.ToString();
                if (s.Key == 0)
                    if (!stonesCountTmp.ContainsKey(1))
                        stonesCountTmp[1] = nb;
                    else
                        stonesCountTmp[1] += nb;
                else if (strg.Length % 2 == 0)
                {
                    if (!stonesCountTmp.ContainsKey(long.Parse(strg.Substring(0, strg.Length / 2))))
                        stonesCountTmp[long.Parse(strg.Substring(0, strg.Length / 2))] = nb;
                    else
                        stonesCountTmp[long.Parse(strg.Substring(0, strg.Length / 2))]+=nb;

                    if (!stonesCountTmp.ContainsKey(long.Parse(strg.Substring(strg.Length / 2))))
                        stonesCountTmp[long.Parse(strg.Substring(strg.Length / 2))] = nb;
                    else
                        stonesCountTmp[long.Parse(strg.Substring(strg.Length / 2))]+=nb;
                }
                else {
                    if (!stonesCountTmp.ContainsKey(s.Key * 2024))
                        stonesCountTmp[s.Key * 2024] = nb;
                    else
                        stonesCountTmp[s.Key * 2024] += nb;
                }
            }
            stonesCount = stonesCountTmp;
        }
    }
}
