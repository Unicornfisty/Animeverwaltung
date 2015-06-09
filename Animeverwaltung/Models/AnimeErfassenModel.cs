using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Animeverwaltung.DataAccess;

namespace Animeverwaltung.Models
{
    public class AnimeErfassenModel
    {
        public Anime einAnime { get; set; }
        public List<Kategorie> alleKategorien { get; set; }
    }
}