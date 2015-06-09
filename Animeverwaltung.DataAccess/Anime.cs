using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animeverwaltung.DataAccess
{
    public class Anime
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int KategorieId { get; set; }
        public virtual Kategorie Kategorie { get; set; }
        public ICollection<Typenzuweisung> Typenzuweisungen { get; set; }
    }
}
