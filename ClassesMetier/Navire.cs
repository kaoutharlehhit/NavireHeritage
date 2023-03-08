using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavireHeritage.classesMetier
{
    abstract class Navire
    {
        private readonly String imo;
        private readonly String nom;
        private Double latitude;
        private Double longitude;
        private Double tonnageActuel;
        private Double tonnageGT;
        private Double tonnageDWT;

        
        protected Navire(string imo, string nom, double latitude, double longitude, double tonnageActuel, double tonnageGT, double tonnageDWT)
        {
            this.imo = imo;
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.tonnageActuel = tonnageActuel;
            this.tonnageGT = tonnageGT;
            this.tonnageDWT = tonnageDWT;
        }

        public string Imo => imo;

        public string Nom => nom;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public double TonnageActuel { get => tonnageActuel; set => tonnageActuel = value; }
        public double TonnageGT { get => tonnageGT; set => tonnageGT = value; }
        public double TonnageDWT { get => tonnageDWT; set => tonnageDWT = value; }
    }
}
