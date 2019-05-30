using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2_NRT4416
{
    class Racun
    {
        private int id_racun;
        private int cena;
        private DateTime datum;
        private DateTime vreme;

        public int Id_racun
        {
            get
            {
                return id_racun;
            }

            set
            {
                id_racun = value;
            }
        }

        public int Cena
        {
            get
            {
                return cena;
            }

            set
            {
                cena = value;
            }
        }

        public DateTime Datum
        {
            get
            {
                return datum;
            }

            set
            {
                datum = value;
            }
        }

        public DateTime Vreme
        {
            get
            {
                return vreme;
            }

            set
            {
                vreme = value;
            }
        }
    }
}
