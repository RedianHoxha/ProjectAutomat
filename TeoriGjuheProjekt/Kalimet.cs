using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TeoriGjuheProjekt.Gjendje;
//using TeoriGjuheProjekt.Alfabet;


namespace TeoriGjuheProjekt
{
    class Kalimet
    {
        public int IdKalimi { get; set; }

        public string gjendjanisjes { get; set; }
        public string alfabetkalimi { get; set; }
        public string gjendjemberritjes { get; set; }

        public Kalimet(){ }
        public Kalimet(int id,string gjendjenisjes, string alfabet ,string gjendjemberritje)
        {
            IdKalimi = id;
            gjendjanisjes = gjendjenisjes;
            alfabetkalimi = alfabet;
            gjendjemberritjes = gjendjemberritje;
        }

        //Gjendje gj = new Gjendje();
        //Alfabet alfa = new Alfabet();
        //public void KrijoKalim(int id,string gj1, string alf, string gje2)
        //{
        //    IdKalimi = id;
        //    gjendjanisjes = gj.getgjendja(gj1);
        //    alfabetkalimi = alfa.getshkronja(alf);
        //    gjendjemberritjes = gj.getgjendja(gje2);
        //}

        public void KrijoKalim(int id, string gj1, string alf, string gj2)
        {
            IdKalimi = id;
            gjendjanisjes = gj1;
            alfabetkalimi = alf;
            gjendjemberritjes = gj2;
        }

        public string afisho()
        {
            return "Id : " + IdKalimi + " Gjendja1 : " + gjendjanisjes + " Alfabet : " + alfabetkalimi + " Gjendjafund : " + gjendjemberritjes;
        }

    }

   
}
