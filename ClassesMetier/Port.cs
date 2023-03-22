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
            try
            {
                if (EstAttendu(id))
                {
                    if (GetUnAttendu(id) is Croisière && this.GetNbCroisiereArrives() < this.nbQuaisPassager)
                    {
                        this.AjoutNavireArrivee(GetUnAttendu(id));
                    }
                    else if (GetUnAttendu(id) is Cargo)
                    {
                        if (this.GetNbCargoArrives() < this.nbPortique)
                        {
                            this.AjoutNavireArrivee(GetUnAttendu(id));
                        }
                        else
                        {
                            this.AjoutNavireEnAttente(GetUnAttendu(id));
                        }
                    }
                    else
                    {
                        Tanker tanker = (Tanker)GetUnAttendu(id);
                        if (tanker.TonnageGT <= 130000 && this.GetNbTankerArrives() >= this.nbQuaisTanker)
                        {
                            this.AjoutNavireEnAttente(tanker);
                        }
                        else if (tanker.TonnageGT > 130000 && this.GetNbSuperTankerArrives() >= this.nbQuaisSuperTanker)
                        {
                            this.AjoutNavireEnAttente(tanker);
                        }
                        else
                        {
                            this.AjoutNavireArrivee(tanker);
                        }
                    }
                }
                else
                {
                    throw new Exception($"Le navire {id} n'est pas attendu ou est déja arrivée dans le port");
                }
            }
            catch (Exception ex)
            {
                throw new GestionPortExceptions(ex.Message);
            }
        }

        public void EnregistrerArriveePrevue(Object objet)
        {
            if (objet is Navire)
            {

                // on va caster l'objet en navire
                Navire navire = (Navire)objet;
                if (!this.navireAttendus.ContainsKey(navire.Imo))

                    this.navireAttendus.Add(navire.Imo, navire);
                else
                {
                    throw new GestionPortExceptions
                        ("Le navire" + navire.Imo + "est déja attendus");
                }


            }
            else
            {
                throw new GestionPortExceptions("Veuillez mettre un bâteau");
            }

        }

        public void EnregistrerDepart(String id)
        {
            if (EstPresent(id))
            {
                Navire navire = (Navire)GetUnArrive(id);
                this.NavirePartis.Add(id, navire);
                this.NavireArrives.Remove(id);
                bool placePrise = false;
                int i = 0;
                while(!placePrise && i < this.NavireEnAttente.Count)
                {
                    Navire unNavireEnAttente = this.navireEnAttente.ElementAt(i).Value;
                    if (unNavireEnAttente.GetType() == navire.GetType())
                    {
                        placePrise = true;
                        //this.EnregistrerArrivee(unNavireEnAttente.Key);
                        //this.NavireEnAttente.Remove(unNavireEnAttente.Key);
                    }
                    i++;
                }
                Console.WriteLine($"Le navire {id} est partit");
            }
            else
            {
                throw new GestionPortExceptions("Enregistrement départ impossible pour" + id + ", le navire n'est pas dans le port");
            }

        }

        public void Chargement(String imo, int qte)
        {

        }
        public void Dechargement(String imo, int qte)
        {

        }

        private void AjoutNavireEnAttente(Object objet)
        {
            Navire navire = (Navire)objet;
            this.navireEnAttente.Add(navire.Imo, navire);
            this.navireAttendus.Remove(navire.Imo);
        }
        private void AjoutNavireArrivee(Object objet)
        {
            Navire navire = (Navire)objet;
            this.navireArrives.Add(navire.Imo, navire);
            this.navireAttendus.Remove(navire.Imo);
        }

        public bool EstEnAttente(String imo)
        {
            return this.navireEnAttente.ContainsKey(imo);
        }

        public bool EstAttendu(String imo)
        {
            return this.navireAttendus.ContainsKey(imo);
        }

        public bool EstPresent(String imo)
        {
            return this.navireArrives.ContainsKey(imo); 
        }

        public int GetNbCroisiereArrives()
        {
            //on met un compteur pour compter le nombre de cargo et on return nb 
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Croisière)
                {
                    nb++;
                }
            }
            return nb;
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
        public int GetNbTankerArrives()
        {
            //on met un compteur pour compter le nombre de cargo et on return nb 
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT <= 130000)
                {
                    nb++;
                }
            }
            return nb;
        }
        public int GetNbSuperTankerArrives()
        {
            //on met un compteur pour compter le nombre de cargo et on return nb 
            int nb = 0;
            foreach (Navire navire in this.navireArrives.Values)
            {
                if (navire is Tanker && navire.TonnageGT > 130000)
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
            return this.navireAttendus[id];
        }

        public object GetUnArrive(string id)
        {
            return this.NavireArrives[id];
        }

        public object GetUnParti(string id)
        {
            throw new NotImplementedException();
        }

        public object GetUnEnAttente(string imo)
        {
            return this.navireEnAttente[imo];
        }
        public override String ToString()
        {
            return "Port de " + this.nom
                + "\n Coordonnées GPS : " + this.latitude + "  /  " + this.longitude
                + "\n       Nb portiques : " + this.nbPortique
                + "\n       Nb quais crosière : " + this.nbQuaisPassager
                + "\n       Nb quais tankers : " + this.nbQuaisTanker
                + "\n       Nb quais super tankers : " + this.nbQuaisSuperTanker
                + "\n       Nb Navires à quai : " + this.navireArrives.Count
                + "\n       Nb Navirre attendus: " + this.navireAttendus.Count
                + "\n       Nb Navires à partis : " + this.navirePartis.Count
                + "\n       Nb Navires en attente : " + this.navireEnAttente.Count

                + "\n Nombre de cargos dans le port : " + this.GetNbCargoArrives()
                + "\n Nombre de tankers dans le port : " + this.GetNbTankerArrives()
                + "\n Nombre de super tankers dans le port : " + this.GetNbSuperTankerArrives();

        }

    }
}
