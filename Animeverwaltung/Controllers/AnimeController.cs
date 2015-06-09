using System;
using Animeverwaltung.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animeverwaltung.Models;

namespace Animeverwaltung.Controllers
{
    public class AnimeController : Controller
    {
        AnimeDb db = new AnimeDb();
        //
        // GET: /Anime/
        public ActionResult Verwaltung()
        {
            List<Anime> model = db.Anime.OrderBy(r => r.Bezeichnung).ToList();
            return View(model);
        }

        public ActionResult Editieren(int? id)
        {
            AnimeErfassenModel model = new AnimeErfassenModel();
            if (id != null)
            {
                model.einAnime = db.Anime.Where(a => a.Id == id).First();
                List<Kategorie> alleKategorien = db.Kategorie.OrderBy(k => k.Bezeichnung).ToList();
                ViewBag.AnimeKategorieId = new SelectList(alleKategorien, "Id", "Bezeichnung", model.einAnime.KategorieId);
                return View(model);
            }
            else
            {
                List<Kategorie> alleKategorien = db.Kategorie.OrderBy(k => k.Bezeichnung).ToList();
                ViewBag.AnimeKategorieId = new SelectList(alleKategorien, "Id", "Bezeichnung");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editieren([Bind(Include = "einAnime, alleKategorien, AnimeKategorieId")] AnimeErfassenModel model)
        {
            if (model != null)
            {
                if (model.einAnime.Id != 0)
                {
                    Anime ausgewaehlteAnime = db.Anime.Where(a => a.Id == model.einAnime.Id).First();
                    ausgewaehlteAnime.Bezeichnung = model.einAnime.Bezeichnung;
                    ausgewaehlteAnime.KategorieId = int.Parse(Request["AnimeKategorieId"]);
                    db.SaveChanges();
                }
                else
                {
                    Anime neueAnime = new Anime();
                    neueAnime.Bezeichnung = model.einAnime.Bezeichnung;
                    neueAnime.KategorieId = int.Parse(Request["AnimeKategorieId"]);
                    db.Anime.Add(neueAnime);
                    db.SaveChanges();   
                }
            }
            return RedirectToAction("Verwaltung", "Anime");
        }

        public ActionResult LoescheAnime(int? id)
        {
            if (id != null)
            {
                Anime zuloeschendeAnime = db.Anime.Where(a => a.Id == id).First();
                db.Anime.Remove(zuloeschendeAnime);
                db.SaveChanges();
   
            }
            return RedirectToAction("Verwaltung", "Anime");
        }
	}
}