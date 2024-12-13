using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD7a : Bot
    {
        List<(int, int[])> equations = new List<(int, int[])>();
        public override int Compute(IEnumerable<string> datas)
        {
            InitData(datas);
            throw new NotImplementedException();
        }

        private void InitData(IEnumerable<string> datas)
        {
            foreach (var data in datas)
            {
                string[] equation = data.Split(':');
                int total = int.Parse(equation[0]);
                int[] numbers = equation[1].Split(' ').Where(s=>!string.IsNullOrEmpty(s)).Select(int.Parse).ToArray();
                HashSet<int> resultats = new HashSet<int>();
                resultats.Add(numbers[0]);
                bool end = false;
                while(resultats.Count()>0)
                { 

                }
            }
        }
    }
}
