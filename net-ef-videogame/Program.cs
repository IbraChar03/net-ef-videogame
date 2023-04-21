using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (VideogameContext db = new VideogameContext())
            {
                Console.WriteLine("Scegli tra le seguenti opzioni : ");
                Console.WriteLine("Inserisci software house");
                Console.WriteLine("Inserisci videogioco");
                Console.WriteLine("Rimuovi videogioco");
                Console.WriteLine("Aggiorna videogioco");
                Console.WriteLine("Cerca videogioco tramite id ");
                Console.WriteLine("Cerca videogiochi");
                Console.WriteLine("Cerca videogiochi di una software house");
                Console.WriteLine("Esci");
                Console.Write("Scrivi la tua scelta : ");
                string scelta = Console.ReadLine();
                VideogameManager vd = new VideogameManager();

                switch (scelta)
                {
                    case "Inserisci software house":
                        try
                        {
                            Console.Write("Inserisci il nome della software house : ");
                            string nomeSoftwarehouse = Console.ReadLine();
                            Console.Write("Inserisci la città della software house : ");
                            string cittaSoftwarehouse = Console.ReadLine();
                            Console.Write("Inserisci il paese della software house : ");
                            string paeseSoftwarehouse = Console.ReadLine();
                            vd.InserisciSoftwareHouse( nomeSoftwarehouse, cittaSoftwarehouse, paeseSoftwarehouse);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Inserisci videogioco":
                        try
                        {
                            Console.Write("Inserisci nome del videogioco : ");
                            string name = Console.ReadLine();
                            Console.Write("Inserisci riassunto del videogioco : ");
                            string overview = Console.ReadLine();
                            Console.Write("Inserisci data del videogioco (dd/MM/yyy) : ");
                            string date = Console.ReadLine();
                            Console.Write("Inserisci il nome della software house : ");
                            string nomesoftwarehouse = Console.ReadLine();
                            SoftwareHouse softwarehouse = db.SoftwareHouses.Where(s => s.Name == nomesoftwarehouse).First();
                            vd.InserisciVideogame(name, overview, date,softwarehouse.SoftwareHouseId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Rimuovi videogioco":
                        try
                        {
                            Console.Write("Inserisci il nome del videogioco da rimuovere : ");
                            string nomeVideogiocoRim = Console.ReadLine();
                            Videogame videogame = db.Videogames.Where(v => v.Name == nomeVideogiocoRim).First();
                            vd.RimuoviVideogame(videogame);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Aggiorna videogioco":
                        try
                        {
                            Console.Write("Inserisci il nome del videogioco da aggiornare : ");
                            string nomeVideogiocoAgg = Console.ReadLine();
                            Videogame videogame = db.Videogames.Where(v => v.Name == nomeVideogiocoAgg).First();
                            Console.Write("Inserisci un nuovo riassunto per il videogioco : ");
                            string overviewVd = Console.ReadLine();
                            videogame.Overview = overviewVd;
                            vd.AggiornaVideogioco(videogame);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Cerca videogioco tramite id":
                        try
                        {
                            Console.Write("Inserisci l`id del videogioco da cercare : ");
                            int idVideogioco = Convert.ToInt32(Console.ReadLine());
                            Videogame videogame = db.Videogames.Where(v => v.VideogameId == idVideogioco).First();
                            SoftwareHouse softwarehouse = db.SoftwareHouses.Where(s => s.SoftwareHouseId == videogame.SoftwareHouseId).First();
                            vd.StampaVideogame(videogame,softwarehouse);


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Cerca videogiochi":
                        try
                        {
                            Console.Write("Inserisci la parola : ");
                            string parola = Console.ReadLine();
                            List<Videogame> listavideogames = db.Videogames.Where(v => v.Name.Contains(parola)).ToList();
                            vd.StampaListaVideogames(listavideogames);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
               
                    case "Cerca videogiochi di una software house":
                        try
                        {
                            Console.Write("Inserisci il nome della software house : ");
                            string nomesoftwarehouse = Console.ReadLine();
                            SoftwareHouse softwarehouse = db.SoftwareHouses.Where(software => software.Name == nomesoftwarehouse).Include(software => software.Videogames).First();
                            vd.StampaListaVideogames(softwarehouse.Videogames);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Esci":
                        Console.Write("Arrivederci");
                        break;
                }
            }
        }
    }
}