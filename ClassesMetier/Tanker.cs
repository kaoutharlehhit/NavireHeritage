using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Tanker : Navire
    {
        private String typeFluide;

        public Tanker(string imo, string nom, string latitude, string longitude, double tonnageActuel, double tonnageGT, double tonnageDWT, string typeFluide) : base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.TypeFluide = typeFluide;
        }

        public string TypeFluide { get => typeFluide; set => typeFluide = value; }
    }
}
