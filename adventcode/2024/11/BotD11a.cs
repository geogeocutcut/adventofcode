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
    public class BotD11a : Bot
    {
        long[] stones;
        public override long Compute(IEnumerable<string> datas)
        {
            stones = datas.ElementAt(0).Split(' ').Select(long.Parse).ToArray();
            for(int i = 0; i < 25; i++)
            {
                stones = split(stones);
            }
            return stones.Length;
        }

        private long[] split(long[] stones)
        {
            List<long>tmp = new List<long>();
            for (int i = 0; i < stones.Length; i++)
            {
                var strg = stones[i].ToString();
                if (stones[i] == 0) tmp.Add(1);
                else if (strg.Length%2 ==0)
                {
                    tmp.Add(long.Parse(strg.Substring(0, strg.Length / 2)));
                    tmp.Add(long.Parse(strg.Substring(strg.Length / 2)));
                }
                else { tmp.Add(stones[i] * 2024); }
            }
            return tmp.ToArray();
        }
    }
}
