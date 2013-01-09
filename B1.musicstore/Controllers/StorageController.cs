using B1.musicstore.Models;
using B1.musicstore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B1.musicstore.Controllers
{
    public class StorageController : Controller
    {
        MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /Storage/

        public ActionResult Index()
        {
            var genres = db.Genres.ToList();

            return View(genres);
        }

        //
        // GET: /Storage/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = db.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Storage/Details/5

        public ActionResult Details(int id)
        {
            var album = db.Albums.Find(id);

            return View(album);
        }

        //
        // GET: /Storage/Search?searchString=Unplugg

        public ActionResult Search(string searchString, string category)
        {
            var result = new SearchResults();

            if (category == "All" || category == "Genre")
                result.Genres = db.Genres.Where(g => g.Name.Contains(searchString)).ToList();
            if (category == "All" || category == "Album")
                result.Albums = db.Albums.Where(g => g.Title.Contains(searchString)).ToList();
            if (category == "All" || category == "Artist")
                result.Artists = db.Artists.Where(g => g.Name.Contains(searchString)).ToList();

            ViewBag.searchString = searchString;

            return View(result);
        }

        //
        // GET: /Storage/Genres

        [ChildActionOnly]
        public ActionResult Genres()
        {
            var genres = db.Genres.ToList();

            return PartialView("_Genres", genres);
        }       

    }
}