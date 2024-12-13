using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventcode._2024
{
    public class BotD3a :  Bot
    {

        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        public override long Compute(IEnumerable<string> datas)
        {
            MatchCollection matches = Regex.Matches(datas.ElementAt(0), pattern);

            return matches.Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)).Sum();
        }
    }
}
