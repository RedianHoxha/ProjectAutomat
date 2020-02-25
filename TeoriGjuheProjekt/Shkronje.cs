using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Shkronje : IEnumerable
    {
        public string shkronja { get; set; }

        Shkronje() { }
        Shkronje(string shk)
        {
            shkronja = shk;
        }
        public string afishoShkronjen()
        {
            return "Shkrona eshte : " + shkronja;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
