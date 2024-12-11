using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adventcode._2024
{
    public class BotD5b : Bot
    {
        IList<(int, int)> _rules = new List<(int, int)>();

        IDictionary<int, List<int>> _graphdependance = new Dictionary<int, List<int>>();

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
            _graphdependance = _rules.GroupBy(r=>r.Item1,r=>r.Item2).ToDictionary(x => x.Key,x => x.ToList());
        }
        public override int Compute(IEnumerable<string> datas)
        {
            InitData(datas);
            var goodFactory = 0;
            foreach (var fact in _factories)
            {
                if (!IsValidUpdate(fact))
                {
                    var reorderfact=reorder(fact);
                    goodFactory += FindMiddlePage(reorderfact);
                }
            }
            return goodFactory;
        }

        private IList<int> reorder(IList<int> fact)
        {
            // montecarlo

            // algo de reorder
            //  on part du debut on vérifie les regles needBefore
            //  si une regle n'est pas vérfier on déplace le  
            var order = new List<int>();
            var visited = new HashSet<int>();
            var tempMark = new HashSet<int>();

            foreach (var page in fact)
            {
                if (!visited.Contains(page))
                    Visit(page, fact, visited, tempMark, order);
            }

            order.Reverse();
            return order.Where(fact.Contains).ToList();
        }

        private void Visit(int page, IList<int> fact, HashSet<int>  visited, HashSet<int>  tempMark, List<int> order)
        {
            if (visited.Contains(page)) return;
            if (tempMark.Contains(page))
                throw new InvalidOperationException("Cycle detected in rules.");

            tempMark.Add(page);

            if (_graphdependance.ContainsKey(page))
            {
                foreach (var neighbor in _graphdependance[page])
                {
                    if (fact.Contains(neighbor))
                        Visit(neighbor, fact, visited, tempMark, order);
                }
            }

            tempMark.Remove(page);
            visited.Add(page);
            order.Add(page);
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
