using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Slovar
    {
      public  string name { get; set; }
        public int count { get; set; }

        public override string ToString()
        {
            return "name = " + name + " count -> " + count;
        }
    }
}
