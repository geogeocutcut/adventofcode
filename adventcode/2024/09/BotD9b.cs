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
    public class BotD9b : Bot
    {
        Dictionary<int, (int,string)> disk = new Dictionary<int, (int, string)>();
        public override long Compute(IEnumerable<string> datas)
        {
            computeDisk(datas);
            fragmentDisk();
            return checksumDisk();
        }

        private long checksumDisk()
        {
            long result = 0;
            for(int i=0;i< disk.Count;i++)
            {
                if (disk[i] == ".")
                    break;
                result += i * long.Parse(disk[i].ToString());
            }
            return result;
        }

        private void fragmentDisk()
        {
            int i = 0;
            int j = disk.Count()-1;
            while (i < j)
            {
                if(disk[i] ==".")
                {
                    // c'est un espace libre
                    while (i < j && disk[j] == ".")
                    {
                        j--;
                    }
                    disk[i] = disk[j];
                    disk[j] = ".";
                }
                i++;
            }
        }

        private void computeDisk(IEnumerable<string> datas)
        {
            int id = 0;
            int k = 0;
            var l = 0;
            foreach (var c in datas.ElementAt(0))
            {
                var length = int.Parse(c.ToString());

                for (int i = 0; i < length; i++)
                {
                    if (k % 2 == 0)
                        disk[l]= id.ToString();
                    else
                        disk[l]= ".";

                    l++;
                }
                if (k % 2 == 0)
                {
                    indexation[id] = (l, length);
                    id++;
                }
                k++;
            }
        }

        public class Block
        {
            public int length;

        }
    }
}
