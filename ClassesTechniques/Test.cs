using NavireHeritage.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionNavire.Exceptions;

namespace NavireHeritage.ClassesTechniques
{
    public abstract class Test
    {
        public static void ChargementInitial(Port port)
        {
            try
            {
                //Cargos
                port.EnregistrerArriveePrevue(new Cargo("IMO9780859", "CMA CGM A. LINCOLN", "43.43279 N", "134.76258 W", 140872, 148992, 123000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9250098", "CONTAINERSHIPS VII", "54.35412 N", "5.3644 E", 10499, 13965, 11000, "Matériel de loisirs"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9502910", "MAERSK EMERALD", "54.72202 N", "170.54304 W", 141754, 141189, 137000, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9755933", "MSC DIANA", "39.74224 N", "5.99304 E", 193489, 202036, 176000, "Matériel industriel"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9204506", "HOLANDIA", "41.74844 N", "6.87008 E", 8737, 9113, 7500, "marchandises diverses"));
                port.EnregistrerArriveePrevue(new Cargo("IMO9305893", "VENTO DI ZEFIRO", "41.50706 N", "11.41972 E", 17665, 22033, 0, "Matériel industriel"));
               

            }
            catch(GestionPortExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void AfficheAttendus(Port port)
        {
            Console.WriteLine("Liste des bateaux en attente de leur arrivée:");
            foreach(Navire navire in port.NavireAttendus.Values)
            {
                Console.WriteLine($"{navire.Imo}    {navire.Nom} : {navire.GetType().Name}");
            }
        }


        internal static void testEnregistrerDepart(Port port, string v)
        {
            //throw new NotImplementedException();
        }
    }
}
