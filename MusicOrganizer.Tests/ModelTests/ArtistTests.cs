// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MusicOrganizer.Models;
// using System.Collections.Generic;
// using System;

// namespace MusicOrganizer.Tests
// {
//   [TestClass]
//   public class ArtistTest : IDisposable
//   {

//     public void Dispose()
//     {
//       Artist.ClearAll();
//     }

//     [TestMethod]
//     public void ArtistConstructor_ReturnsInstance_Artist()
//     {
//       //Arrange
//       Artist newArtist = new Artist("test");
//       Assert.AreEqual(typeof(Artist), newArtist.GetType());
//     }

//     [TestMethod]
//     public void GetName_ReturnsName_String()
//     {
//       //Arrange
//       string name = "Test Artist";
//       Artist newArtist = new Artist(name);

//       //Act
//       string result = newArtist.Name;

//       //Assert
//       Assert.AreEqual(name, result);
//     }

//     [TestMethod]
//     public void GetId_ReturnsArtistId_Int()
//     {
//       //Arrange
//       string name = "Test Artist";
//       Artist newArtist = new Artist(name);

//       //Act
//       int result = newArtist.Id;

//       //Assert
//       Assert.AreEqual(1, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsAllArtistObjects_ArtistList()
//     {
//       //Arrange
//       string name01 = "Work";
//       string name02 = "School";
//       Artist newArtist1 = new Artist(name01);
//       Artist newArtist2 = new Artist(name02);
//       List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };

//       //Act
//       List<Artist> result = Artist.GetAll();

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void Find_ReturnsCorrectArtist_Artist()
//     {
//       //Arrange
//       string name01 = "Hi";
//       string name02 = "Bye";
//       Artist newArtist1 = new Artist(name01);
//       Artist newArtist2 = new Artist(name02);

//       //Act
//       Artist result = Artist.Find(2);

//       //Assert
//       Assert.AreEqual(newArtist2, result);
//     }
//     [TestMethod]
//     public void AddAlbum_AssociatesAlbumWithArtist_AlbumList()
//     {
//       //Arrange
//       string name1 = "Walk the dog.";
//       Album newAlbum = new Album(name1, "CD");
//       List<Album> newList = new List<Album> { newAlbum };
//       string name2 = "Work";
//       Artist newArtist = new Artist(name2);
//       newArtist.AddAlbum(newAlbum);

//       //Act
//       List<Album> result = newArtist.Albums;

//       //Assert
//       CollectionAssert.AreEqual(newList, result);
//     }
//   }
// }