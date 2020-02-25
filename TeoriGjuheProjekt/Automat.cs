﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriGjuheProjekt
{
    class Automat
    {
        public ArrayList Automati { get; set; }
        public Alfabet alfabetiAutomatit { get; set; }
        public Gjendje gjendjeAutomatit { get; set; }
        public Automat(ArrayList automat,Alfabet alfabetautomati,Gjendje gjendjeautomati)
        {
            Automati = automat;
            alfabetiAutomatit = alfabetautomati;
            gjendjeAutomatit = gjendjeautomati;
          
        }

        public Automat()
        {
        }

        public void KrijoAutomat()
        { 
            bool mbaroi = true;
            int id = 1;
            Automati = new ArrayList();
            do
            {
             
                Console.WriteLine("Fusni gjendjen e nisjes");
                string gj1= Console.ReadLine();

                Console.WriteLine("Fusni shkronjene  alfabetit");
                string alf = Console.ReadLine();

                Console.WriteLine("Fusni gjendjen e mberritjes");
                string gj2 = Console.ReadLine();


                //k.KrijoKalim(id, gj1, alf, gj2);
                Kalimet k = new Kalimet(id, gj1, alf, gj2);
                Automati.Add(k);
                //k.afisho();
                id++;

                Console.WriteLine("Deshironi te fusni kalim tjt?");
                Console.WriteLine("Nqs po shtyp 'Y' perndryshe 'N'");
                string Pergjigje = Console.ReadLine();
                if(Pergjigje.ToUpper()=="N")
                {
                    mbaroi = false;
                }

            } while (mbaroi);

        }

        public void MbushmeKalime(){
                  Automati = new ArrayList();
                  int counter = 0;
                  string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\TeoriGjuhesh\TeoriGjuheProjekt\Prov\Kalimet.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                string gjendje1, shkralfabet, gjendjefund;
                gjendje1 = line.Substring(0, 2);
                shkralfabet = line.Substring(2, 1);
                gjendjefund = line.Substring(3,2);
                Kalimet kalim = new Kalimet(counter, gjendje1, shkralfabet, gjendjefund);
                        Automati.Add(kalim);
                        counter++;
                    }

            file.Close();

        }


        public void AfishoKalime()
        {
            Kalimet kalimetObject = new Kalimet();
            
                foreach( var i in Automati)
                {
                kalimetObject = (Kalimet)i;
               Console.WriteLine(kalimetObject.afisho());
                //Console.WriteLine (kalimetObject.gjendjanisjes);

             
                }
            
        }
        public void Konverto(Gjendje gjendjetautomatit,Alfabet alfabetiautomatit)
        {
            int count=0;
            //kshu do jet alfabeti per kalimin epsilon
           string epsi="e";
            bool ndryshoi = true;
            Alfabet alfabetobjekt = new Alfabet();
            ArrayList kontrollieps1 = KontrollEpsilon1(gjendjetautomatit,epsi);//kontrolli 1
            ArrayList kontrollpasperseritje;
            do
            {
                Gjendje gjendje = new Gjendje(kontrollieps1);
                kontrollpasperseritje = KontrollEpsilonperseritje(gjendje, epsi);
                if(kontrollieps1.Equals(kontrollpasperseritje))
                {
                    ndryshoi = false;
                }

            } while (ndryshoi);

            Gjendje gjendjeperkontrollalfabeti = new Gjendje(kontrollpasperseritje);//arraylista me gjendjet fillesatre

            foreach(var i in alfabetiautomatit.alfabeti)
            {
                count++;
            }


            foreach(var i in alfabetiautomatit.alfabeti)//per cdo shkornje te alfabettit 
            {

                alfabetobjekt = (Alfabet)i;
                //string alfabet = alfabetobjekt.

               //  ArrayList gjendjepasalfabetiti = Kontrollalfabet(alfabet, gjendjeperkontrollalfabeti);
            }
       

        }

        public void Konvertohappashapi(Gjendje gjendjetautomatit, Alfabet alfabetiautomatit)
        {
            string eps = "e";
            Kalimet kalimetObject = new Kalimet();
            ArrayList gjendjeperfundimtare = new ArrayList();
            Gjendje gjendje;
            int count=0;
            string gje = "";
            int gjendjapozicion = 1;
            foreach(var i in gjendjetautomatit.gjendje)
            {
                count++;
            }

       
            while(gjendjapozicion<count)
            {
                gje = gjendjetautomatit.getgjendja(gjendjapozicion);//per cdo gjendje te automatit bejme 
                {
                    gjendjeperfundimtare= kontrollpernjegjendje(gje, eps, alfabetiautomatit);
                      
                    foreach(var i in gjendjeperfundimtare)
                    {
                        string gjendjeperf = (string)i;
                        Console.WriteLine(gje + "----"+ gje + "----" + gjendjeperf);
                    }

                    gjendjapozicion++;
                }
            }
        }

        public ArrayList kontrollpernjegjendje(string gjen, string eps, Alfabet alfabetiautomatit)
        {
            Gjendje gjendje;
            ArrayList gjendjeeeee = new ArrayList();
            ArrayList pasalfabetit = new ArrayList();
            ArrayList pasepsilon2 = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Alfabet alfabetiim = new Alfabet();
            bool ndryshoi = false;
            string gjedjapaseps = "";
            foreach (var i in Automati)//per cdo kalim te automatit shikojme nese gjendja  kalon diku me epsilon
            {
                kalimetObject = (Kalimet)i;
                if ( gjen == kalimetObject.gjendjanisjes )
                {
                    if (eps == kalimetObject.alfabetkalimi)
                    {
                        gjendjeeeee.Add(kalimetObject.gjendjemberritjes.ToString());
                    }    

                }
            }
            gjendje = new Gjendje(gjendjeeeee);

            do//kontrollojme nese gjendjet e gjetura shkojne diku me epsilon perseri nqs po shtojme gjenjdet e reja ne array
            {
                int c = 0;
                foreach (var i in gjendje.gjendje)
                {
                    c++;
                }

                int pozicperseri = 1;
                while(pozicperseri<=c)
                {
                    gjedjapaseps = gjendje.getgjendja(pozicperseri);
                    foreach (var i in Automati)
                    {
                        kalimetObject = (Kalimet)i;
                        if (gjedjapaseps == kalimetObject.gjendjanisjes && !gjendjeeeee.Contains(gjedjapaseps))
                        {
                            if (eps == kalimetObject.alfabetkalimi)
                            {
                                gjendjeeeee.Add(kalimetObject.gjendjemberritjes.ToString());
                                ndryshoi = true;
                                gjendje.Zbraz();//fshim objektin dhe e mbushim perseri me arraylistene  re te krijuar me ndryshime
                            }

                        }
                    }

                }
               gjendje = new Gjendje(gjendjeeeee);

            } while (ndryshoi);

          // gjendje.AfishoGjendjet();
            foreach (var i in alfabetiautomatit.alfabeti)//per cdo dhkronje alfabeti kontrollojme nese rgjendje te arrayt t kthyer shkojne diku me kete shkronje alfabeti
            {
                pasalfabetit = Kontrollalfabet((string)i, gjendje);//kontrolli me shkronj alfabeti

                foreach(var gjendjepasalfabetit in pasalfabetit)//per cdo gjendje te kthyer nga kontrolli siper kontrollojme nese ashkojne diku m eepsilon 
                {
                   string  shkronje = (string)gjendjepasalfabetit;
                    pasepsilon2 = Kontrollopasalf(shkronje, eps);//letu esht ekontrolli i dyte me epsilon mbyllje
                }


            }

            return pasepsilon2;

        }
        public ArrayList Kontrollalfabet( string alfabet,Gjendje Gjdjeepsienlon)
        {
            ArrayList gjendjealfabet = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();
           

                   foreach(var gje in Gjdjeepsienlon.gjendje)
                    {
                        foreach (var i in Automati)
                        {
                            kalimetObject = (Kalimet)i;

                             if((string)gje==kalimetObject.gjendjanisjes && alfabet == kalimetObject.alfabetkalimi)
                              {
                                  gjendjealfabet.Add(kalimetObject.gjendjemberritjes.ToString());                                
                              }

                        }
                    }
           

                return gjendjealfabet;
            
        }

        public ArrayList Kontrollopasalf(string gjend,string epsilon)
        {
            ArrayList arr = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            bool nryshoiprap = false;
            foreach (var i in Automati)//per cdo kalim shikojme nese shkon diku 
            {
                kalimetObject = (Kalimet)i;
                if (gjend == kalimetObject.gjendjanisjes)
                {
                    if (epsilon == kalimetObject.alfabetkalimi)
                    {
                        arr.Add(kalimetObject.gjendjemberritjes.ToString());
                    }

                }
            }

            do//kontrollojme nese array i kthyer shkon persri diku me epsioln
            {
                foreach (var i in arr)

                    foreach (var j in Automati)
                    {
                        kalimetObject = (Kalimet)i;
                        if (gjend == kalimetObject.gjendjanisjes)
                        {
                            if (epsilon == kalimetObject.alfabetkalimi && !arr.Contains(gjend))
                            {
                                arr.Add(kalimetObject.gjendjemberritjes.ToString());
                                nryshoiprap = true;
                            }
                        }
                    }      
            } while (nryshoiprap);

           return arr;//mendoij qe ketu ne fund pasi kemi mbaruar pune me kontroll te shtojme shkronjen e alfabetit pasi do me duhet tek afishimi ne fillim 
        }

        public ArrayList KontrollEpsilon1(Gjendje GjendjeteAutomatit,string epsilon)
        {
            ArrayList gjendjeepsilon1 = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();

            foreach(var gjen in GjendjeteAutomatit.gjendje)
            {
                foreach(var i in Automati)
                {
                    kalimetObject = (Kalimet)i;
                    if(gjen==kalimetObject.gjendjanisjes&& epsilon==kalimetObject.alfabetkalimi)
                    {
                        gjendjeepsilon1.Add(kalimetObject.gjendjemberritjes.ToString());

                    }
                }
            }

            return gjendjeepsilon1;

        }


        //public ArrayList KontrollEpsilon1prov(string gj, string epsilon)
        //{
        //    ArrayList gjendjeepsilon1prov = new ArrayList();
        //    Kalimet kalimetObject = new Kalimet();
        //    Gjendje gjendje = new Gjendje();

         
        //        foreach (var i in Automati)
        //        {
        //            kalimetObject = (Kalimet)i;
        //            if (gj == kalimetObject.gjendjanisjes && epsilon == kalimetObject.alfabetkalimi)
        //            {
        //                gjendjeepsilon1prov.Add(kalimetObject.gjendjemberritjes);

        //            }
        //        }
            

        //    return gjendjeepsilon1prov;

        //}

        public ArrayList KontrollEpsilonperseritje(Gjendje gjendjetepsilon1, string epsilon)
        {
            ArrayList gjendjeepsilonndryshime = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Gjendje gjendje = new Gjendje();

            foreach (var gjen in gjendjetepsilon1.gjendje)
            {
                foreach (var i in Automati)
                {
                    kalimetObject = (Kalimet)i;
                    if (gjen == kalimetObject.gjendjanisjes) 
                    {
                        if(epsilon == kalimetObject.alfabetkalimi)
                        {
                            string gjendjare = kalimetObject.gjendjemberritjes;
                            if (gjendjetepsilon1.gjendje.Contains(gjendjare))
                            {
                                gjendjeepsilonndryshime.Add(kalimetObject.gjendjemberritjes);
                            }
                        }
                        else
                        {
                            gjendjeepsilonndryshime.Add(gjen);

                        }

                    }
                 
                }
            }

            return gjendjeepsilonndryshime;

        }
 
    }
    
}
