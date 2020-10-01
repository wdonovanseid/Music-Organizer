using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  {

    public void Dispose()
    {
      // Category.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_ReturnsInstance_Artist()
    {
      //Arrange
      Artist newArtist = new Artist();
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }
  }
}