using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers 
{

    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
    

    // GET: /Store/
    public ActionResult Index()
    {
        var genres = storeDB.Genres.ToList();
        // var genres = new List<Genre>
        // {
        //       new Genre { Name = "Disco"},
        //        new Genre { Name = "Jazz"},
        //        new Genre { Name = "Rock"}
        //     };
        return View(genres);
    }


    public ActionResult Browse(string genre)
    {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

    // GET: /Store/Details/5
    public ActionResult Details(int id)
    {
            //var album = new Album { Title = "Album " + id };
            var album = storeDB.Albums.Find(id);

            return View(album);
    }
}
}
