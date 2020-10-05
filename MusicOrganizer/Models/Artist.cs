using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{

  public class Artist
  {
    public string Name { get; set; }
    public int Id { get; set; }

    // public List<Album> Albums = new List<Album> { };

    public Artist(string name, int artistId)
    {
      Name = name;
      Id = artistId;
    }
    public Artist(string name)
    {
      Name = name;
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
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO artists (name) VALUES (@Name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = this.Name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Artist Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `artists` WHERE artistId = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int artistId = 0;
      string artistName = "";
      while (rdr.Read())
      {
        artistId = rdr.GetInt32(0);
        artistName = rdr.GetString(1);
      }
      Artist foundArtist= new Artist(artistName, artistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundArtist;
    }
    // public void AddAlbum(Album album)
    // {
    //   Albums.Add(album);
    // }
  }
}