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
    public class BotD5a : Bot
    {
        IList<(int, int)> _rules = new List<(int, int)>();

        IList<IList<int>> _factories = new List<IList<int>>();
        public void InitData(IEnumerable<string> datas)
        {
            foreach (string line in datas)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (line.Contains('|'))
                {
                    var number = line.Split('|').Select(int.Parse).ToArray();
                    _rules.Add((number[0], number[1]));
                }
                else
                {
                    var fact = line.Split(',').Select(int.Parse).ToList();
                    _factories.Add(fact);
                }
            }
        }
        public override long Compute(IEnumerable<string> datas)
        {
            InitData(datas);
            var goodFactory = 0;
            foreach (var fact in _factories)
            {
                if (IsValidUpdate(fact))
                {
                    goodFactory += FindMiddlePage(fact);
                }
            }
            return goodFactory;
        }
        private bool IsValidUpdate(IList<int> pages)
        {
            var pageIndex = pages.Select((page, index) => (page, index)).ToDictionary(p => p.page, p => p.index);

            foreach (var (X, Y) in _rules)
            {
                if (pageIndex.ContainsKey(X) && pageIndex.ContainsKey(Y))
                {
                    if (pageIndex[X] >= pageIndex[Y])
                        return false;
                }
            }

            return true;
        }

        private int FindMiddlePage(IList<int> pages)
        {
            int middleIndex = pages.Count / 2;
            return pages[middleIndex];
        }
    }
}
