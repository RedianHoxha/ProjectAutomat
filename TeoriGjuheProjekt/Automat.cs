using System;
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

        public void KrijoAutomat()//Metoda per te mbushur arrayn e Automatit me kalime.
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


                Kalimet k = new Kalimet(id, gj1, alf, gj2);
                Automati.Add(k);
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

        public void MbushmeKalime()// Metoda per te mbushur Automatin me kalime duke lexuar nga nje skedar.
        {
            Automati = new ArrayList();
                  int counter = 0;
                  string line;

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Github\ProjectAutomat\TeoriGjuheProjekt\Prov\Minimizim\Kalimet.txt");
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
                }
        }

        //Medoda e kontrollit (Gabim)

        //public void Konverto(Gjendje gjendjetautomatit,Alfabet alfabetiautomatit)
        //{
        //    int count=0;
        //    //kshu do jet alfabeti per kalimin epsilon
        //   string epsi="e";
        //    bool ndryshoi = true;
        //    Alfabet alfabetobjekt = new Alfabet();
        //    ArrayList kontrollieps1 = KontrollEpsilon1(gjendjetautomatit,epsi);//kontrolli 1
        //    ArrayList kontrollpasperseritje;
        //    do/
        //    {
        //        Gjendje gjendje = new Gjendje(kontrollieps1);
        //        kontrollpasperseritje = KontrollEpsilonperseritje(gjendje, epsi);
        //        if(kontrollieps1.Equals(kontrollpasperseritje))
        //        {
        //            ndryshoi = false;
        //        }

        //    } while (ndryshoi);

        //    Gjendje gjendjeperkontrollalfabeti = new Gjendje(kontrollpasperseritje);//arraylista me gjendjet fillesatre

        //    foreach(var i in alfabetiautomatit.alfabeti)
        //    {
        //        count++;
        //    }


        //    foreach(var i in alfabetiautomatit.alfabeti)//per cdo shkornje te alfabettit 
        //    {

        //        alfabetobjekt = (Alfabet)i;
        //        //string alfabet = alfabetobjekt.

        //       //  ArrayList gjendjepasalfabetiti = Kontrollalfabet(alfabet, gjendjeperkontrollalfabeti);
        //    }


        //}   

        public void Konvertohappashapi(Gjendje gjendjetautomatit, Alfabet alfabetiautomatit)
        {
            string eps = "e";
            Kalimet kalimetObject = new Kalimet();
            ArrayList gjendjeperfundimtare = new ArrayList();
            int count=0;
            string gje = "";
            int gjendjapozicion = 0;

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
                                Console.WriteLine(gjendjeperf);
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
            ArrayList tmp = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Alfabet alfabetiim = new Alfabet();
            ArrayList Arraiperfundimtarpershkronje = new ArrayList();

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

                ndryshoi = false;

                int pozicperseri = 0;
                while(pozicperseri<c)
                {
                    gjedjapaseps = gjendje.getgjendja(pozicperseri);
                    foreach (var i in Automati)
                    {
                        kalimetObject = (Kalimet)i;
                        if (gjedjapaseps == kalimetObject.gjendjanisjes)
                        {
                            if (eps == kalimetObject.alfabetkalimi && !gjendjeeeee.Contains(kalimetObject.gjendjemberritjes))
                            {
                                gjendjeeeee.Add(kalimetObject.gjendjemberritjes.ToString());
                                ndryshoi = true;
                            }

                        }
                    }
                    pozicperseri++;

                }
               gjendje = new Gjendje(gjendjeeeee);

            } while (ndryshoi);

                foreach (var i in alfabetiautomatit.alfabeti)//per cdo dhkronje alfabeti kontrollojme nese rgjendje te arrayt t kthyer shkojne diku me kete shkronje alfabeti
                {
                    if ((string)i != "e")
                    {
                        pasalfabetit = Kontrollalfabet((string)i, gjendje);

                    //kontrolli me shkronj alfabeti

                        foreach (var gjendjepasalfabetit in pasalfabetit)//per cdo gjendje te kthyer nga kontrolli siper kontrollojme nese ashkojne diku m eepsilon 
                        {
                            string shkronje = (string)gjendjepasalfabetit;
                            pasepsilon2 = Kontrollopasalf(shkronje, eps);//letu esht ekontrolli i dyte me epsilon mbyllje
                            for (int k = 0; k < pasepsilon2.Count; k++)
                                {
                                    if(!tmp.Contains(pasepsilon2[k]))
                                    {
                                           tmp.Add(pasepsilon2[k]);                            
                                    }
                                }
                        }

                        //Arraiperfundimtarpershkronje.Add(gjen);
                        //Arraiperfundimtarpershkronje.Add(" ");
                        Arraiperfundimtarpershkronje.AddRange(tmp);
                        Arraiperfundimtarpershkronje.Add((string)i);
                        tmp = new ArrayList();
                    }
                }

            return Arraiperfundimtarpershkronje;

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
                for (int i=0;i<arr.Count;i++)
                {
                    nryshoiprap = false;
                    gjend = (string)arr[i];
                    foreach (var j in Automati)
                    {
                        kalimetObject = (Kalimet)j;
                        if (gjend == kalimetObject.gjendjanisjes)
                        {
                            if (epsilon == kalimetObject.alfabetkalimi && !arr.Contains(kalimetObject.gjendjemberritjes))
                            {
                                arr.Add(kalimetObject.gjendjemberritjes.ToString());
                                nryshoiprap = true;
                            }
                        }
                    }
                }

            } while (nryshoiprap);

           return arr;//mendoij qe ketu ne fund pasi kemi mbaruar pune me kontroll te shtojme shkronjen e alfabetit pasi do me duhet tek afishimi ne fillim 
        }


        public void KonvertoneAFD(Gjendje gjendjetautomatit, Alfabet alfabetiautomatit)
         {
            Kalimet kalimetObject = new Kalimet();
            ArrayList arrayrastiq0 = new ArrayList();
            ArrayList arraytemporare = new ArrayList();
            ArrayList Arrayperfundimtar = new ArrayList();
            ArrayList arraypasafd = new ArrayList();
            ArrayList historiku = new ArrayList();

            string gjendjafillestare = gjendjetautomatit.getgjendja(0);
            string eps = "e";
            List <string> gjendje = new List<string>();
            string gjendjepaalfabetit="";

            arrayrastiq0 = kontrollpernjegjendje(gjendjafillestare, eps, alfabetiautomatit);

            Arrayperfundimtar.Add("q0");
            historiku.Add("q0");
            foreach (var i in arrayrastiq0)//konverton ne stringje dy gjenjdet qe dalin nga q0 me a dhe b dhe kthen i  shton ato ne nje array temporare.
            {
                string gjendjeperf = (string)i;

                if (gjendjeperf == "a" || gjendjeperf=="b")
                {

                    gjendje.Sort();
                    string gjendjenew = string.Join("", gjendje);
                    arraytemporare.Add(gjendjenew);
                    historiku.Add(gjendjenew);
                    gjendje = new List<string>();
                }
                else
                {
                    gjendje.Add(gjendjeperf);
                }

            }

           

           
                for (int i=0;i<arraytemporare.Count;i++)
                {
                    //arraytemporare = konvertolisttostring(arraytemporare);

                    string gjendja = (string)arraytemporare[i];
                    int gjatesia = gjendja.Length;
                    int poz = 0;
                    List <string> gjendjereqeformohet = new List<string>();

                    if (Arrayperfundimtar.Contains(gjendja))
                    {
                        arraytemporare.Remove(gjendja);
                        i--;
                    }
                    else
                    {
                        foreach (var j in alfabetiautomatit.alfabeti)//per cdo dhkronje alfabeti kontrollojme nese rgjendje te arrayt t kthyer shkojne diku me kete shkronje alfabeti
                        {
                            if ((string)j != "e")
                            {
                                poz = 0;
                                string shkronja = (string)j;
                                while (poz < gjatesia)
                                {
                                    string gjen = gjendja.Substring(poz, 2);

                                    arraypasafd = kontrollpernjegjendjeAFD(gjen, eps, (string)j);//kthejme afd per gjendjen e dhene.

                                    gjendjereqeformohet = Kthenefjale(gjendjereqeformohet, arraypasafd);//arrayne kthyer e kthejme ne string

                                    poz = poz + 2;
                                }
                                string gjendjaqeformohetnew = string.Join("", gjendjereqeformohet);
                                arraytemporare.Add(gjendjaqeformohetnew);
                                historiku.Add(gjendja);
                                historiku.Add((string)j);
                                historiku.Add(gjendjaqeformohetnew);
                                gjendjereqeformohet = new List<string>();

                            }
                        }
                        Arrayperfundimtar.Add(gjendja);
                        arraytemporare.Remove(gjendja);

                        i--;
                    }
                   

                }




                 foreach(var i in historiku)
                 {
                        Console.WriteLine((string)i);
                 }
        }


        //public ArrayList konvertolisttostring(ArrayList arraytemporare)
        //{

        //    for (int i = 0; i < arraytemporare.Count; i++)
        //    {
        //        List<string> gjendjalist = (List<string>)arraytemporare[i];
        //        string gjendja = string.Join("", gjendjalist);
        //        arraytemporare[i] = gjendja;
        //    }

        //    return arraytemporare;
        //}

        public ArrayList kontrollpernjegjendjeAFD(string gjen, string eps, string alfabetiautomatit)
        {
            Gjendje gjendje;
            ArrayList gjendjeeeee = new ArrayList();
            ArrayList pasalfabetit = new ArrayList();
            ArrayList pasepsilon2 = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            Alfabet alfabetiim = new Alfabet();
            ArrayList Arraiperfundimtarpershkronje = new ArrayList();

            bool ndryshoi = false;
            string gjedjapaseps = "";

            foreach (var i in Automati)//per cdo kalim te automatit shikojme nese gjendja  kalon diku me epsilon
            {
                kalimetObject = (Kalimet)i;
                if (gjen == kalimetObject.gjendjanisjes)
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

                ndryshoi = false;

                int pozicperseri = 0;
                while (pozicperseri < c)
                {
                    gjedjapaseps = gjendje.getgjendja(pozicperseri);
                    foreach (var i in Automati)
                    {
                        kalimetObject = (Kalimet)i;
                        if (gjedjapaseps == kalimetObject.gjendjanisjes)
                        {
                            if (eps == kalimetObject.alfabetkalimi && !gjendjeeeee.Contains(kalimetObject.gjendjemberritjes))
                            {
                                gjendjeeeee.Add(kalimetObject.gjendjemberritjes.ToString());
                                ndryshoi = true;
                                
                            }

                        }
                    }
                    pozicperseri++;

                }
                gjendje = new Gjendje(gjendjeeeee);

            } while (ndryshoi);

           
                    pasalfabetit = Kontrollalfabet(alfabetiautomatit, gjendje);

                    //kontrolli me shkronj alfabeti

                    foreach (var gjendjepasalfabetit in pasalfabetit)//per cdo gjendje te kthyer nga kontrolli siper kontrollojme nese ashkojne diku m eepsilon 
                    {
                        string shkronje = (string)gjendjepasalfabetit;
                        pasepsilon2 = Kontrollopasalf(shkronje, eps);//letu esht ekontrolli i dyte me epsilon mbyllje
                        Arraiperfundimtarpershkronje.AddRange(pasepsilon2);
                    }

                    Arraiperfundimtarpershkronje.Add(alfabetiautomatit);
                
            

            return Arraiperfundimtarpershkronje;

        }

        public List<string> Kthenefjale( List<string> fjale,ArrayList gjendjet)//metoda e cila do kthej ne string arrayn qe ktheht nga afjd e njeres gjendje.
        {
           
            foreach (var i in gjendjet)
            {
                string gjendjeperf = (string)i;
                if(!fjale.Contains(gjendjeperf))
                {
                    if (gjendjeperf == "a" || gjendjeperf == "b")
                    {
                        break;
                    }
                    else
                    {
                        fjale.Add(gjendjeperf);
                    }
                }
            }
            fjale.Sort();
            return fjale;
        }







        public void Minimizo(Gjendje gjendjefundore, Gjendje gjendjeautomati, Alfabet alfabetautomati)
        {
            bool ushtua = false;
            ArrayList GjendjeFundore = new ArrayList();
            ArrayList GjendjeJoFundore = new ArrayList();
            ArrayList GjithGjendjet = new ArrayList();
            ArrayList gjendjeshenjuara = new ArrayList();
            string gjendja1, gjendja2,gjendjadyshe,gjendjaqeshenjohet;
            //GjendjeJoFundore.AddRange(gjendjeautomati.gjendje);//kopjojme gjith gjendjet
            GjendjeFundore = KtheFundore(gjendjefundore);//kemi gjendjet fundore
            GjithGjendjet=HiqtePaArritshme(gjendjeautomati);//gjendjet e arritshme
            GjendjeJoFundore = Kthejofundore(GjendjeFundore, gjendjeautomati);//gjendjet jo fundore
            gjendjeshenjuara = GjendjeShenjuara(GjendjeFundore, GjendjeJoFundore);//gjendjet e shenjuara

            do
            {
                ushtua = false;

                for (int rresht = 0; rresht < GjithGjendjet.Count; rresht++)
                {
                    for (int kolon = 0; kolon < GjithGjendjet.Count; kolon++)
                    {
                        if (kolon != rresht)
                        {
                            foreach (var i in alfabetautomati.alfabeti)//per cdo dhkronje alfabeti kontrollojme nese rgjendje te arrayt t kthyer shkojne diku me kete shkronje alfabeti
                            {
                                
                                    gjendja1 = gjendjamberritjes((string)GjithGjendjet[rresht], (string)i);
                                    gjendja2 = gjendjamberritjes((string)GjithGjendjet[kolon], (string)i);
                                    gjendjadyshe = gjendja1 + gjendja2;

                                    if (gjendjeshenjuara.Contains(gjendjadyshe))
                                    {

                                        gjendjaqeshenjohet = (string)GjithGjendjet[rresht] + (string)GjithGjendjet[kolon];

                                            if (!gjendjeshenjuara.Contains(gjendjaqeshenjohet))
                                            {
                                                    gjendjeshenjuara.Add(gjendjaqeshenjohet);
                                                    ushtua = true;
                                            }
                                    }
                            }
                        }
                    }
                }
            } while (ushtua);

            //afisho(gjendjeshenjuara);


            ArrayList gjithciftetemundshme = new ArrayList();
            ArrayList gjendjetepashenjuara = new ArrayList();
            ArrayList gjendjebashkohet = new ArrayList();
            string p1, p2;
            gjithciftetemundshme = Gjithgjendjet(gjendjeautomati);

            foreach(var i in gjithciftetemundshme)
            {
                string gjen = (string)i;
                if(!gjendjeshenjuara.Contains(gjen))
                {
                    gjendjetepashenjuara.Add(gjen);
                }
            }

            foreach(string fjal in gjendjetepashenjuara)
            {
                p1 = fjal.Substring(0, 2);
                p2 = fjal.Substring(2, 2);
                if(!gjendjebashkohet.Contains(p1))
                {
                    gjendjebashkohet.Add(p1);
                }
                if(!gjendjebashkohet.Contains(p2))
                {
                    gjendjebashkohet.Add(p2);
                }
                p1 = "";
                p2 = "";
            }
            afisho(gjendjebashkohet);
        }





        public ArrayList Gjithgjendjet(Gjendje gjendjeautomati)
        {
            ArrayList arr = new ArrayList();
            string ciftgjendje = "";
            for(int rresht=0;rresht< gjendjeautomati.gjendje.Count;rresht++)
            {
                for(int kolon=0;kolon< gjendjeautomati.gjendje.Count;kolon++)
                {
                    if(rresht!=kolon)
                    {
                        ciftgjendje = gjendjeautomati.getgjendja(rresht) + gjendjeautomati.getgjendja(kolon);
                        arr.Add(ciftgjendje);
                        ciftgjendje = "";
                    }
                }
            }

            return arr;
        }

        public void afisho(ArrayList arr)

        {
            string fjale = "";
            Console.WriteLine("Gjith ciftet e mundshme jane:");
            for (int i = 0; i < arr.Count; i++)
            {
                fjale = fjale + arr[i].ToString();
            }
           Console.Write(fjale);
        }

        public string bashkoarraylist (ArrayList arr)
        {
            string fjale = "";
            Console.WriteLine("Gjith ciftet e mundshme jane:");
            for (int i = 0; i < arr.Count; i++)
            {
                fjale = fjale + arr[i].ToString();
            }
           return fjale;
        }


        public ArrayList GjendjeShenjuara(ArrayList fundore,ArrayList jofundore)
        {
            ArrayList shenjuara = new ArrayList();
            string gjen = "";
            for (int rresht = 0; rresht < fundore.Count; rresht++)
            {
                for (int kolon = 0; kolon < jofundore.Count; kolon++)
                {
                    gjen = gjen + fundore[rresht] + jofundore[kolon];
                    shenjuara.Add(gjen);
                    gjen = "";
                }

            }

            for (int rresht = 0; rresht < jofundore.Count; rresht++)
            {
                for (int kolon = 0; kolon < fundore.Count; kolon++)
                {
                    gjen = gjen + jofundore[rresht] + fundore[kolon];
                    shenjuara.Add(gjen);
                    gjen = "";
                }

            }


            return shenjuara;
        }
        


        public ArrayList Kthejofundore(ArrayList fundore,Gjendje gjendjeautomati)
        {
            ArrayList arrayjofundore = new ArrayList();

            foreach(var i in gjendjeautomati.gjendje)
            {
                string gjendja = (string)i;
                if(!fundore.Contains(gjendja))
                {
                    arrayjofundore.Add(gjendja);
                }
            }


            return arrayjofundore;
        }
        public string gjendjamberritjes(string gjendjanisjes, string shkronjalf)
        {
            string mberritje = "";
            Kalimet kalimetObject = new Kalimet();

            foreach (var i in Automati)
            {
                kalimetObject = (Kalimet)i;
                if(kalimetObject.gjendjanisjes== gjendjanisjes && kalimetObject.alfabetkalimi== shkronjalf)
                {
                    mberritje = kalimetObject.gjendjemberritjes;
                }
            }
                return mberritje;
        }



        public ArrayList HiqtePaArritshme(Gjendje gjithgjendjet)//heq gjenjdet e pa arritshme dhe kthen arrayn me gjendje te arritshme
        {
            ArrayList gjendjetekapshme = new ArrayList();
            ArrayList tmp = new ArrayList();
            tmp.AddRange(gjithgjendjet.gjendje);

            Kalimet kalimetObject = new Kalimet();

            foreach (var i in Automati)
            {
                kalimetObject = (Kalimet)i;
                if(tmp.Contains(kalimetObject.gjendjemberritjes))
                {
                    if(!gjendjetekapshme.Contains(kalimetObject.gjendjemberritjes))
                    {
                          gjendjetekapshme.Add(kalimetObject.gjendjemberritjes);
                         
                    }
                }
            }

               return gjendjetekapshme;
        }




        public void AfishoFundore(Gjendje gjendjefundore)//afishon gjendjet fundore
        {
            ArrayList arrparafundore = new ArrayList();
            ArrayList arrPerfundimtare = new ArrayList();

            arrparafundore = Gjejfundore(gjendjefundore);
            arrPerfundimtare = Kontrolloperseri(arrparafundore);

            Console.WriteLine("Gjendjet fundore jane:");
            for(int i=0;i< arrPerfundimtare.Count;i++)
            {
                Console.WriteLine(arrPerfundimtare[i].ToString());
            }
        }


        public ArrayList KtheFundore(Gjendje gjendjefundore)//kthen arrayn me gjenjdet fundore
        {
            ArrayList arrparafundore = new ArrayList();
            ArrayList arrPerfundimtare = new ArrayList();

            arrparafundore = Gjejfundore(gjendjefundore);
            arrPerfundimtare = Kontrolloperseri(arrparafundore);
            return arrPerfundimtare;
        }

        public ArrayList Kontrolloperseri(ArrayList arraymegjendje)//kthen arrayn me gjendje te shtuara nga e fundit
        {
            ArrayList arr = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            string eps = "e";
            bool ushtuan = false;

            do {
                ushtuan = false;
                foreach (var i in Automati)
                {
                    kalimetObject = (Kalimet)i;
                    if (arraymegjendje.Contains(kalimetObject.gjendjemberritjes) && kalimetObject.alfabetkalimi==eps)
                    {
                        if(!arraymegjendje.Contains(kalimetObject.gjendjanisjes))
                        {
                            arraymegjendje.Add(kalimetObject.gjendjanisjes);
                            ushtuan = true;
                        }
                    }
                }
            } while (ushtuan);

            arr.AddRange(arraymegjendje);

            return arr;
        }

        public ArrayList Gjejfundore(Gjendje arraymegjendje)//kthen arrain e pare me gjendje qe shkojn ne fundore
        {
            ArrayList arrgjendjesh = new ArrayList();
            Kalimet kalimetObject = new Kalimet();
            string eps = "e";

            foreach(var i in arraymegjendje.gjendje)
            {
                string gjen = (string)i;
                arrgjendjesh.Add(gjen);
            }

            foreach(var i in Automati)
            {
                kalimetObject = (Kalimet)i;
                if(arraymegjendje.gjendje.Contains(kalimetObject.gjendjemberritjes)&& kalimetObject.alfabetkalimi==eps)
                {
                    arrgjendjesh.Add(kalimetObject.gjendjanisjes);
                }
            }
            return arrgjendjesh;

        }


        //public string Kontrollocdogjenjde(string gjendjare,string alfabeti)
        //{
        //    //ArrayList gjendjetereja = new ArrayList();
        //    Kalimet kalimetObject = new Kalimet();

        //    string gjendjaqefutet = "";
        //    foreach (var i in Automati)
        //    {
        //        kalimetObject = (Kalimet)i;

        //        if ((string)gjendjare == kalimetObject.gjendjanisjes && alfabeti == kalimetObject.alfabetkalimi)
        //        {
        //            if(!gjendjare.Contains(kalimetObject.gjendjemberritjes))
        //            {
        //                string.Concat(gjendjaqefutet, kalimetObject.gjendjemberritjes);
        //            }
                    
        //        }

        //    }
           
        //    return gjendjaqefutet;
        //}


    }

}
