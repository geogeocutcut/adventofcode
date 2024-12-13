using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD7b : Bot
    {
        List<(long, long[])> equations = new List<(long, long[])>();
        public override long Compute(IEnumerable<string> datas)
        {
            InitData(datas);
            long result = 0;
            foreach (var item in equations)
            {
                if (isCalibrationPossible(item))
                    result += item.Item1;
            }
            return result;
        }

        private bool isCalibrationPossible((long, long[]) item)
        {
            var total = item.Item1;
            var numbers = item.Item2;

            HashSet<long> resultats = new HashSet<long>();
            resultats.Add(numbers[0]);
            int i = 1;

            while (resultats.Count() > 0 && i < numbers.Count())
            {
                HashSet<long> tmp = new HashSet<long>();
                foreach (var res in resultats)
                {
                    if (res + numbers[i] <= total) tmp.Add(res + numbers[i]);
                    if (res * numbers[i] <= total) tmp.Add(res * numbers[i]);
                    long resconcat = long.Parse($"{res}{numbers[i]}");
                    if (resconcat <= total) tmp.Add(resconcat);
                }
                resultats = tmp;
                i++;
            }
            return resultats.Count(r=>r==total) > 0;
        }

        private void InitData(IEnumerable<string> datas)
        {
            foreach (var data in datas)
            {
                try
                {
                    string[] equation = data.Split(':');
                    long total = long.Parse(equation[0]);
                    long[] numbers = equation[1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(long.Parse).ToArray();

                    equations.Add((total, numbers));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
