using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        public void inserisciSoftwareHouse(VideogameContext db,string name, string city, string country)
        {
            SoftwareHouse softwarehouse = new SoftwareHouse { Name = name, City = city, Country = country };
            db.SoftwareHouses.Add(softwarehouse);
            db.SaveChanges();

        }
    }
}
