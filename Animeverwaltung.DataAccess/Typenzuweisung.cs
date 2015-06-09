using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animeverwaltung.DataAccess
{
    public class Typenzuweisung
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int TypId { get; set; }
        public int? Seiten { get; set; }
        public int? Staffeln { get; set; }
        public int? Folgen { get; set; }
        public int? Minuten { get; set; }
        public virtual Typ Typ { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
