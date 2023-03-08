using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;
using NavireHeritage.classesMetier;

namespace NavireHeritage.classesMetier
{
    class Port
    {
        private String nom;
        private String latitude;
        private String longitude;
        private int nbPortique;
        private int nbQuaisPassager;
        private int nbQuaisTanker;
        private int nbQuaisSuperTanker;
        private Dictionary<String, Navire> navireAttendus;
        private Dictionary<String, Navire> navireArrives;
        private Dictionary<String, Navire> navirePartis;
        private Dictionary<String, Navire> navireEnAttente;

        public Port(string nom, string latitude, string longitude, int nbPortique, int nbQuaisPassager, int nbQuaisTanker, int nbQuaisSuperTanker)
        {
            this.nom = nom;
            this.latitude = latitude;
            this.longitude = longitude;
            this.nbPortique = nbPortique;
            this.nbQuaisPassager = nbQuaisPassager;
            this.nbQuaisTanker = nbQuaisTanker;
            this.nbQuaisSuperTanker = nbQuaisSuperTanker;
            this.navireAttendus = new Dictionary<string, Navire>();
            this.navireArrives = new Dictionary<string, Navire>();
            this.navirePartis = new Dictionary<string, Navire>();
            this.navireEnAttente = new Dictionary<string, Navire>();
        }

        public string Nom { get => nom; set => nom = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public int NbPortique { get => nbPortique; set => nbPortique = value; }
        public int NbQuaisPassager { get => nbQuaisPassager; set => nbQuaisPassager = value; }
        public int NbQuaisTanker { get => nbQuaisTanker; set => nbQuaisTanker = value; }
        public int NbQuaisSuperTanker { get => nbQuaisSuperTanker; set => nbQuaisSuperTanker = value; }
        internal Dictionary<string, Navire> NavireAttendus { get => navireAttendus; set => navireAttendus = value; }
        internal Dictionary<string, Navire> NavireArrives { get => navireArrives; set => navireArrives = value; }
        internal Dictionary<string, Navire> NavirePartis { get => navirePartis; set => navirePartis = value; }
        internal Dictionary<string, Navire> NavireEnAttente { get => navireEnAttente; set => navireEnAttente = value; }

        public void EnregistrerArrivee(Stri)
        {
            try
            {
                if (this.navireAttendus.Count < this.NbPortique)
                {
                    this.navireAttendus.Add(navirePortique.Imo, navirePortique);
                }
                else
                {
                    throw new GestionPortExceptions("Ajout impossible");
                }
            }
            catch
            {
                throw new GestionPortExceptions("Le navire " + navirePortique.Imo + " est déjà enregistré");
            }
        }


        public void EnregistrerArrivee(Navire navirePassager)
        {
            try
            {
                if (this.navireAttendus.Count < this.NbQuaisPassager)
                {
                    this.navireAttendus.Add(navirePassager.Imo, navirePassager);
                }
                else
                {
                    throw new GestionPortExceptions("Ajout impossible");
                }
            }
            catch
            {
                throw new GestionPortExceptions("Le navire " + navirePassager.Imo + " est déjà enregistré");
            }
        }
    }
}
