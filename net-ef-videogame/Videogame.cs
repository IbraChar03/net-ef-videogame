using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal class Videogame
    {
        public int VideogameID { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime release_date {  get; set; }
        public int SoftwareHouseID { get; set; }
    }
}
