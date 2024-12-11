using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventcode
{
    public interface IBot
    {
        public IEnumerable<string> LoadData(string path);
        public int Compute(IEnumerable<string> datas);
    }
}
