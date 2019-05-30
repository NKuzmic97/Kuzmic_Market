using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2_NRT4416
{
   public class Artikal
    {
        private int id_artikla;
        private string naziv;
        private int cena;
        private int popust;

        public int Id_artikla
        {
            get
            {
                return id_artikla;
            }

            set
            {
                id_artikla = value;
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
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

        public int Popust
        {
            get
            {
                return popust;
            }

            set
            {
                popust = value;
            }
        }
    }
}
