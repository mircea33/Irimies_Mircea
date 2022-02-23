using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irimies_Mircea.Models
{
    public class Conferinta
    {
        public int ConferintaID { get; set; }
        public string nume_divizie { get; set; }

        public ICollection<Echipa> Echipe { get; set; }
    }
}