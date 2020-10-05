using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{

  public class Artist
  {
    public string Name { get; set; }
    public int Id { get; }

    public Artist(string name)
    {
      Name = name;
    }
    public static void ClearAll()
    {
    }
    public static List<Artist> GetAll()
    {
      List<Artist> allArtists = new List<Artist> { };
      MySqlConnection conn = DB.Connection
    }
    public static Artist Find(int searchId)
    {
      return _instances[searchId - 1];
    }
    public void AddAlbum(Album album)
    {
      Albums.Add(album);
    }
  }
}