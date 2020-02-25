using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.  
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(@"c:\Prov\test.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    System.Console.WriteLine(line);
            //    counter++;
            //}

            //file.Close();
            //System.Console.WriteLine("There were {0} lines.", counter);
            //// Suspend the screen.  
            //System.Console.ReadLine();

            Alfabet a1 = new Alfabet();
            a1.MbushMeShkronja();
           // a1.AfishoAlfabet();
            //string a=a1.getshkronja(0);
            //Console.WriteLine(a);
            //System.Console.ReadLine();

            Gjendje gj1 = new Gjendje();
            gj1.FutGJendjet();
            //gj1.AfishoGjendjet();
            //System.Console.ReadLine();

            Automat a = new Automat();
            a.MbushmeKalime();
            //a.AfishoKalime();

            //a.Konverto(gj1,a1);
            a.Konvertohappashapi(gj1,a1);

             System.Console.ReadLine();
        }
    }
}
