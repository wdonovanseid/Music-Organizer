using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName, 0);
      newArtist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Album> artistAlbums = Album.GetAlbums(id); // selectedArtist.Albums;
      model.Add("artist", selectedArtist);
      model.Add("albums", artistAlbums);
      return View(model);
    }

    // This one creates new Album within a given Artist, not new Artists:
    [HttpPost("/artists/{artistId}/albums")]
    public ActionResult Create(int artistId, string name, string type)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Album newAlbum = new Album(name, type, artistId);
      newAlbum.Save();
      // foundArtist.AddAlbum(newAlbum);
      List<Album> artistAlbums = Album.GetAlbums(artistId);//foundArtist.Albums;
      model.Add("albums", artistAlbums);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }
  }
}