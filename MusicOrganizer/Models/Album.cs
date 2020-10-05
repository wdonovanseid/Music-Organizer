using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{

  public class Album
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public int Id { get; set; }
    public virtual int ArtistId { get; set; }

    public Album(string name, string type, int artistId)
    {
      Name = name;
      Type = type;
      ArtistId = artistId;
    }

    public Album(string name, string type, int albumId, int artistId)
    {
      Name = name;
      Type = type;
      Id = albumId;
      ArtistId = artistId;
    }

    public static List<Album> GetAll()
    {
      List<Album> allAlbum = new List<Album> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM albums;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int albumId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string type = rdr.GetString(2);
        int artistId= rdr.GetInt32(3);
        Album newAlbum = new Album(name,type,albumId,artistId);
        allAlbum.Add(newAlbum);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allAlbum;
    }
    public override bool Equals(System.Object otherAlbum)
    {
      if (!(otherAlbum is Album))
      {
        return false;
      }
      else
      {
        Album newAlbum = (Album) otherAlbum;
        bool nameEquality = (this.Name == newAlbum.Name);
        bool typeEquality = (this.Type == newAlbum.Type);
        bool artistIdEquality = (this.ArtistId == newAlbum.ArtistId);
        bool idEquality = (this.Id == newAlbum.Id);
        return (nameEquality && typeEquality && artistIdEquality && idEquality);
      }
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"Delete FROM albums;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO albums (name, type, artistId) VALUES (@Name, @Type, @ArtistId);";
      MySqlParameter name = new MySqlParameter();
      MySqlParameter type = new MySqlParameter();
      MySqlParameter artistId = new MySqlParameter();
      name.ParameterName = "@Name";
      type.ParameterName = "@Type";
      artistId.ParameterName = "@artistId";
      name.Value = this.Name;
      type.Value = this.Type;
      artistId.Value = this.ArtistId;
      cmd.Parameters.Add(name);
      cmd.Parameters.Add(type);
      cmd.Parameters.Add(artistId);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Album Find(int searchId)
    {
      Album placeholderItem = new Album("placeholder item", "Here", 0, 0);
      return placeholderItem;
    }
  }
}