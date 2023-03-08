using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    class Croisière : Navire
    {
        private String typeNavireCroisière;
        private int nbPassagersMaxi;
        private Dictionary<String, Passager> Passagers;

        public Croisière(string imo, string nom, double latitude, double longitude, double tonnageActuel, double tonnageGT, double tonnageDWT,string typeNavireCroisière, int nbPassagersMaxi, Dictionary<string, Passager> passagers) :base(imo, nom, latitude, longitude, tonnageActuel, tonnageGT, tonnageDWT)
        {
            this.typeNavireCroisière = typeNavireCroisière;
            this.nbPassagersMaxi = nbPassagersMaxi;
            Passagers = passagers;
        }

        public string TypeNavireCroisière { get => typeNavireCroisière; set => typeNavireCroisière = value; }
        public int NbPassagersMaxi { get => nbPassagersMaxi; set => nbPassagersMaxi = value; }
        internal Dictionary<string, Passager> Passagers1 { get => Passagers; set => Passagers = value; }
    }
}
