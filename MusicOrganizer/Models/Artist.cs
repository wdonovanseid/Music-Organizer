using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{

  public class Artist
  {
    public string Name { get; set; }
    public int Id { get; }

    public Artist(string name, int artistId)
    {
      Name = name;
      Id = artistId;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"Delete FROM artists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Artist> GetAll()
    {
      List<Artist> allArtist = new List<Artist> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM artists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int artistId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Artist newArtist = new Artist(name, artistId);
        allArtist.Add(newArtist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allArtist;
    }
    public static Artist Find(int searchId)
    {
      Artist placeholderItem = new Artist("placeholder item", 0);
      return placeholderItem;
    }
    // public void AddAlbum(Album album)
    // {
    //   Albums.Add(album);
    // }
  }
}