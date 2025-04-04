using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIZSGA_KOROM
{
    public class Auto
    {

        public int Sorszam { get; set; }
        public string Marka { get; set; }
        public string Modell { get; set; }
        public int GyartasiEv { get; set; }
        public string Szin { get; set; }
        public int EladottDarabszam { get; set; }
        public int AtlagosEladásiAr { get; set; }

        public Auto(string line)
        {
            var data = line.Split(';');
            Sorszam = int.Parse(data[0]);
            Marka = data[1];
            Modell = data[2];
            GyartasiEv = int.Parse(data[3]);
            Szin = data[4];
            EladottDarabszam = int.Parse(data[5]);
            AtlagosEladásiAr = int.Parse(data[6]);
        }

    }
}
