using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2_NRT4416
{
    class Grupa
    {
        private int id_artikla;
        private int id_grupa;

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

        public int Id_grupa
        {
            get
            {
                return id_grupa;
            }

            set
            {
                id_grupa = value;
            }
        }
    }
}
