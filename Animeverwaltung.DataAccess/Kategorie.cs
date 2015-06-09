using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animeverwaltung.DataAccess
{
    public class Kategorie
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public virtual ICollection<Anime> Animes { get; set; }
    }
}
