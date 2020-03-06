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
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\ProjectAutomat\TeoriGjuheProjekt\Prov\Gjendje.txt");
            while ((line = file.ReadLine()) != null)
            {
                gjendje.Add(line);
                counter++;
            }

            file.Close();
        }



        public void lexofundore()
        {
            gjendje = new ArrayList();

            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\ProjectAutomat\TeoriGjuheProjekt\Prov\GjendjeFundore.txt");
            while ((line = file.ReadLine()) != null)
            {
                gjendje.Add(line);
            }

            file.Close();
        }

        public void Zbraz()
        {
            gjendje.Clear();
        }

        public string getgjendja(int i)
        {
            string bosh = " ";
            if(i>gjendje.Count)
            {
                Console.WriteLine($"i={i}= gjendja {gjendje.Count}");
                return bosh;
            }
            else
            {
                string gjendja = gjendje[i].ToString();//ketu ma nxjerr errorin
                return gjendja;
            }

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
