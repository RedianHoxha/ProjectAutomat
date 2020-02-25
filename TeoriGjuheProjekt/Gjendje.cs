using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Gjendje
    {

        public ArrayList gjendje { get; set; }
       /// public IEnumerator enumerator{get; set;}

        public Gjendje(ArrayList gjendjet)
        {
            gjendje = gjendjet;
        }
        public Gjendje(){}
        public void FutGJendjet()
        {
            gjendje = new ArrayList();

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\TeoriGjuhesh\TeoriGjuheProjekt\Prov\Gjendje.txt");
            while ((line = file.ReadLine()) != null)
            {
                gjendje.Add(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("Automati jone ka {0} Gjendje.", counter);


        }
        public void Zbraz()
        {
            gjendje.Clear();
        }
        public string getgjendja(int i)
        {
            string gjendja = gjendje[i].ToString();//ketu ma nxjerr errorin
            return gjendja;
        }

        public void AfishoGjendjet()
            {

                foreach (var i in gjendje)
                {
                    Console.WriteLine(i);
                }
            }
     }
}
