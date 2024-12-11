using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventcode
{
    public abstract class Bot : IBot
    {
        public abstract int Compute(IEnumerable<string> datas);

        public IEnumerable<string> LoadData(string path)
        {
            return System.IO.File.ReadLines(path);
        }
    }
}
