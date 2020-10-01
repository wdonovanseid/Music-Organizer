using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Controllers
{
  public class AlbumsController : Controller
  {
    [HttpGet("/artists/{artistId}/albums/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpGet("/artists/{artistId}/albums/{albumId}")]
    public ActionResult Show(int artistId, int albumId)
    {
      Album albums = Album.Find(albumId);
      Artist artists = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", albums);
      model.Add("artist", artists);
      return View(model);
    }

    [HttpPost("/albums/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }
  }
}