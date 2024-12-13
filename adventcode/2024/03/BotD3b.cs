using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventcode._2024
{
    public class BotD3b :  Bot
    {
        string mulPattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        string doPattern = @"do\(\)";
        string dontPattern = @"don't\(\)";

        public override long Compute(IEnumerable<string> datas)
        {
            int resultat = 0;
            string memory = datas.ElementAt(0);
            int index = 0;
            bool mulEnabled = true;

            while (index < memory.Length)
            {
                // Check for a don't() instruction
                Match dontMatch = Regex.Match(memory.Substring(index), dontPattern);
                if (dontMatch.Success && dontMatch.Index == 0)
                {
                    mulEnabled = false; // Disable mul instructions
                    index += dontMatch.Length;
                    continue;
                }
                // Check for a do() instruction
                Match doMatch = Regex.Match(memory.Substring(index), doPattern);
                if (doMatch.Success && doMatch.Index == 0)
                {
                    mulEnabled = true; // Enable mul instructions
                    index += doMatch.Length;
                    continue;
                }
                // Check for a valid mul(X,Y) instruction
                Match mulMatch = Regex.Match(memory.Substring(index), mulPattern);
                if (mulMatch.Success && mulMatch.Index == 0)
                {
                    if (mulEnabled) // Process the mul only if enabled
                    {
                        int x = int.Parse(mulMatch.Groups[1].Value);
                        int y = int.Parse(mulMatch.Groups[2].Value);
                        resultat += x * y;
                    }
                    index += mulMatch.Length;
                    continue;
                }

                // Move to the next character if no match
                index++;
            }
            return resultat;

        }

        
    }
}
