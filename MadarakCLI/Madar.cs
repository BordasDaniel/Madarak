using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadarakCLI
{
    public class Madar
    {

        public int Sorszam { get; set; }
        public string MagyarNev { get; set; }
        public string LatinNev { get; set; }
        public int Ertek { get; set; }
        public int Ev { get; set; }

        public Madar() { }

        public Madar(int sorszam, string magyarNev, string latinNev, int ertek, int ev)
        {
            Sorszam = sorszam;
            MagyarNev = magyarNev;
            LatinNev = latinNev;
            Ertek = ertek;
            Ev = ev;
        }

        public Madar(string adatSor)
        {
            string[] adatTomb = adatSor.Split(';');
            Sorszam = int.Parse(adatTomb[0]);
            MagyarNev = adatTomb[1];
            LatinNev = adatTomb[2];
            Ertek = int.Parse(adatTomb[3]);
            Ev = int.Parse(adatTomb[4]);
        }

    }
}
