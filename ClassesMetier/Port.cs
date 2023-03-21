using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;
using NavireHeritage.classesMetier;
using Station.Interfaces;

namespace NavireHeritage.classesMetier
{
    public class Port : Istationable

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

        public void EnregistrerArrivee(String id)
        {
            //try
            //{
            //    if (this.navireAttendus.Count < this.NbPortique)
            //    {
            //        this.navireAttendus.Add(navirePortique.Imo, navirePortique);
            //    }
            //    else
            //    {
            //        throw new GestionPortExceptions("Ajout impossible");
            //    }
            //}
            //catch
            //{
            //    throw new GestionPortExceptions("Le navire " + navirePortique.Imo + " est déjà enregistré");
            //}
        }

        public void EnregistrerArriveePrevue(Object objet)
        {
            if(objet is Navire)
            {
               
                // on va caster l'objet en navire
                Navire navire = (Navire)objet;
                if(this.navireAttendus.ContainsKey(navire.Imo))

                    this.navireAttendus.Add(navire.Imo, navire);
                //else
                //{
                //    throw new Exception
                //        ("Le navire" + navire.Imo + "est déja attendus");
                //}

          
            }
            
        }

        public void EnregistrerDepart(String id)
        {

        }

        //public void EnregistrerArrivee(Navire navirePassager)
        //{
        //    try
        //    {
        //        if (this.navireAttendus.Count < this.NbQuaisPassager)
        //        {
        //            this.navireAttendus.Add(navirePassager.Imo, navirePassager);
        //        }
        //        else
        //        {
        //            throw new GestionPortExceptions("Ajout impossible");
        //        }
        //    }
        //    catch
        //    {
        //        throw new GestionPortExceptions("Le navire " + navirePassager.Imo + " est déjà enregistré");
        //    }
        //}
        public void Chargement(String imo, int qte)
        {

        }
        public void Dechargement(String imo, int qte)
        {

        }

        private void AjoutNavireEnAttente(Object objet)
        {

        }

        public bool EstEnAttente(String imo)
        {
            return true;
        }

        public bool EstAttendu(String imo)
        {
            return true;
        }

        public bool EstPresent(String imo)
        {
            return true;
        }

        public int GetNbCargoArrives()
        {
            //on met un compteur pour compter le nombre de cargo et on return nb 
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Cargo)
                {
                    nb++;
                }
            }
            return nb;
        }

        public bool EstParti(string id)
        {
            throw new NotImplementedException();
        }

        public object GetUnAttendu(string id)
        {
            throw new NotImplementedException();
        }

        public object GetUnArrive(string id)
        {
            throw new NotImplementedException();
        }

        public object GetUnParti(string id)
        {
            throw new NotImplementedException();
        }

        public object GetUnEnAttente(string imo)
        {
            return new object();
        }
        public override String ToString()
        {
            return "Port de " + this.nom 
                + "\n Coordonnées GPS : " + this.latitude + "  /  " + this.longitude 
                + "\n       Nb portiques : " + this.nbPortique 
                + "\n       Nb quais tankers :" + this.nbQuaisTanker 
                + "\n       Nb quais super tankers :" + this.nbQuaisSuperTanker 
                + "\n       Nb Navires à quai : " + this.navireArrives.Count
                + "\n       Nb Navirre attendus: " + this.navireAttendus
                + "\n       Nb Navires à partis : " + this.navirePartis
                + "\n       Nb Navires en attente : " + this.navireEnAttente

                + "\n Nombre de cargos dans le port : " this.GetNbCargoArrives
                + "\n Nombre de tankers dans le port : " this.nbQuaisTanker

        }

    }
}
