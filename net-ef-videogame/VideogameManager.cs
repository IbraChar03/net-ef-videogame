using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class VideogameManager
    {
        public void InserisciSoftwareHouse(VideogameContext db,string name, string city, string country)
        {
            SoftwareHouse softwarehouse = new SoftwareHouse { Name = name, City = city, Country = country };
            db.SoftwareHouses.Add(softwarehouse);
            db.SaveChanges();

        }
        public void InserisciVideogame(VideogameContext db, string name, string overview, string data,int softwarehouseid)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            Videogame videogame = new Videogame { Name = name, Overview = overview, Release_date = DateTime.ParseExact(data, "dd/MM/yyyy", provider), SoftwareHouseId = softwarehouseid };
            db.Videogames.Add(videogame);
            db.SaveChanges();

        }
        public void RimuoviVideogame(VideogameContext db,Videogame vd)
        {
            db.Videogames.Remove(vd);
            db.SaveChanges();
        }
        public void AggiornaVideogioco(VideogameContext db, Videogame vd)
        {
            db.Videogames.Update(vd);
            db.SaveChanges();
        }
    }
}
