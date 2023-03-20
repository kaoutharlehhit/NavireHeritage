using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;

namespace NavireHeritage.classesMetier
{
    class Cargo : Navire
    {
        private string typeFret;

        public Cargo(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, string typeFret) : base(imo, nom, latitude, longitude,tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeFret = typeFret;
        }

        public string TypeFret { get => typeFret; set => typeFret = value; }



    }

}
