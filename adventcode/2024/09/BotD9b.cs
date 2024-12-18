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
        (int,string[])[] disk ;
        public override long Compute(IEnumerable<string> datas)
        {
            computeDisk(datas);
            fragmentDisk();
            return checksumDisk();
        }

        private long checksumDisk()
        {
            long result = 0;
            long ind = 0;
            for(int i=0;i< disk.Count();i++)
            {
                for (int j = 0; j < disk[i].Item2.Length; j++)
                {
                    if (disk[i].Item2[j] != ".")
                    {
                        result += ind * int.Parse(disk[i].Item2[j]);
                    }
                    ind++;
                }
            }
            return result;
        }

        private void fragmentDisk()
        {
            int i = disk.Count() - 1;
            while (i >= 0)
            {
                var bloc = disk[i];
                // c'est de la data
                if(bloc.Item1==1)
                {
                    int j = 0;
                    while(j< disk.Count() && j<i )
                    {
                        var free = disk[j];
                        if(free.Item1 == 0 && free.Item2.Length >= bloc.Item2.Length)
                        {
                            disk[j] = bloc;

                            var temp = new List<string>();
                            for (int k=0;k< bloc.Item2.Length;k++)
                            {
                                temp.Add(".");
                            }

                            disk[i] = new(0, temp.ToArray());

                            if (free.Item2.Length - bloc.Item2.Length > 0)
                            {
                                temp = new List<string>();
                                for (int k= 0; k< free.Item2.Length - bloc.Item2.Length; k++)
                                {
                                    temp.Add(".");
                                }
                                free.Item2 = temp.ToArray();
                                InsertBloc(j + 1, free);
                            }
                            break;
                        }
                        j++;
                    }
                }
                i--;
            }

            
        }

        private void InsertBloc(int v, (int, string[]) elt)
        {
            Array.Resize(ref disk, disk.Length + 1);
            Array.Copy(disk, v, disk, v + 1, disk.Length - v - 1);
            disk[v] = elt;
        }

        private void computeDisk(IEnumerable<string> datas)
        {
            int id = 0;
            int k = 0;
            disk = new (int, string[])[datas.ElementAt(0).Length];
            foreach (var c in datas.ElementAt(0))
            {
                var length = int.Parse(c.ToString());
                var data = new string[length];
                for (int i = 0; i < length; i++)
                {
                    if (k % 2 == 0)
                        data[i] = id.ToString();
                    else
                        data[i] = ".";


                    
                }
                if (k % 2 == 0)
                {
                    disk[k] = (1, data);
                    id++;
                }
                else
                    disk[k] = (0, data);
                k++;
            }
        }
    }
}
