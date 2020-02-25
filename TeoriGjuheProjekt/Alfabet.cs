using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TeoriGjuheProjekt
{
   class Alfabet
    {

        public ArrayList alfabeti { get; set; }

        public Alfabet(ArrayList alfabet)
        {
            alfabeti = alfabet;
        }

        public Alfabet() { }
        public void MbushMeShkronja()
        {
            alfabeti = new ArrayList();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\TeoriGjuhesh\TeoriGjuheProjekt\Prov\Alfabet.txt");
            while ((line = file.ReadLine()) != null)
            {
                alfabeti.Add(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("Alfabeti i Automatit ka {0} Shkronja.", counter);
      

        }

        public  string getshkronja(int i)
        {
            string shkronjaalfa = alfabeti[i].ToString();
            return shkronjaalfa;
        }

    //    public void Afisho(Alfabet alf)
    //    {
    ////       return alf.getshkronja();
    //    }
 
        public void AfishoAlfabet()
        {

            foreach (var i in alfabeti)
            {
                Console.WriteLine(i);
            }
        }
    }
}

