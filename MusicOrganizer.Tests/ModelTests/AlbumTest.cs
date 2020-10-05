using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class AlbumTest : IDisposable
  {
    public void Dispose()
    {
      Album.ClearAll();
    }
    public AlbumTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_AlbumList()
    {
      //Arrange
      List<Album> newList = new List<Album> { };

      //Act
      List<Album> result = Album.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Album()
    {
      // Arrange, Act
      Album firstAlbum = new Album("Mow the lawn", "here", 0, 0);
      Album secondAlbum = new Album("Mow the lawn", "here", 0, 0);

      // Assert
      Assert.AreEqual(firstAlbum, secondAlbum);
    }
    // [TestMethod]
    // public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    // {
    //   Album newAlbum = new Album("test", "test");
    //   Assert.AreEqual(typeof(Album), newAlbum.GetType());
    // }
    // [TestMethod]
    // public void GetName_ReturnsName_String()
    // {
    //   //Arrange
    //   string name = "Walk the dog.";
    //   string type = "CD";

    //   //Act
    //   Album newAlbum = new Album(name, type);
    //   string result1 = newAlbum.Name;
    //   string result2 = newAlbum.Type;

    //   //Assert
    //   Assert.AreEqual(name, result1);
    //   Assert.AreEqual(type, result2);
    // }
    // public void SetName_SetName_String()
    // {
    //   //Arrange
    //   string name = "Walk the dog.";
    //   Album newAlbum = new Album(name, "CD");

    //   //Act
    //   string updatedName = "Do the dishes";
    //   newAlbum.Name = updatedName;
    //   string result = newAlbum.Name;

    //   //Assert
    //   Assert.AreEqual(updatedName, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_ItemList()
    // {
    //   // Arrange
    //   List<Album> newList = new List<Album> { };

    //   // Act
    //   List<Album> result = Album.GetAll();

    //   // Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }
    // [TestMethod]
    // public void GetAll_ReturnsAlbums_AlbumList()
    // {
    //   //Arrange
    //   string name1 = "Walk the dog";
    //   string name2 = "Wash the dishes";
    //   Album newAlbum1 = new Album(name1, "CD");
    //   Album newAlbum2 = new Album(name2, "Tape");
    //   List<Album> newList = new List<Album> { newAlbum1, newAlbum2 };

    //   //Act
    //   List<Album> result = Album.GetAll();

    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }
    // [TestMethod]
    // public void GetId_AlbumsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string name = "Walk the dog.";
    //   Album newAlbum = new Album(name, "CD");

    //   //Act
    //   int result = newAlbum.Id;

    //   //Assert
    //   Assert.AreEqual(1, result);
    // }
    // [TestMethod]
    // public void Find_ReturnsCorrectAlbum_Album()
    // {
    //   //Arrange
    //   string name1 = "Walk the dog";
    //   string name2 = "Wash the dishes";
    //   Album newAlbum1 = new Album(name1, "CD");
    //   Album newAlbum2 = new Album(name2, "Tape");

    //   //Act
    //   Album result = Album.Find(2);

    //   //Assert
    //   Assert.AreEqual(newAlbum2, result);
    // }
  }
}