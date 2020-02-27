using System;
using System.Linq;
using EmpireRecords.Models;

namespace EmpireRecords
{
  public class DatabaseTracker
  {

    //public static db DatabaseContext { get; set; } = new  DatabaseContext();
    public string GreetingInput(string choice)
    {
      while (choice != "sign" && choice != "produce" && choice != "fire" && choice != "re" && choice != "view" && choice != "quit")
      {
        Console.WriteLine($"Invalid entry. Please input (SIGN), (PRODUCE), (FIRE), (RE), (VIEW) or (QUIT)");
        choice = Console.ReadLine().ToLower();
        return choice;
      }
      return choice;
    }
    public string BandInSystem(string name)
    {
      var db = new DatabaseContext();
      var bandInSystem = db.Bands.Any(band => band.Name.ToLower() == name);
      while (bandInSystem == false)
      {
        Console.WriteLine($"{name} is not in the system. Please try again.");
        name = Console.ReadLine().ToLower();
        bandInSystem = db.Bands.Any(band => band.Name.ToLower() == name);
        return name;
      }
      return name;
    }
    public int ReturnBandId(string name)
    {
      var db = new DatabaseContext();
      var bandId = db.Bands.First(band => band.Name.ToLower() == name);
      return bandId.Id;
    }
    public int ReturnAlbumId(string title)
    {
      var db = new DatabaseContext();
      var albumId = db.Albums.First(album => album.Title == title);
      return albumId.Id;
    }
    public void NewRecord(int bandId, string title, DateTime releasedDate, bool explicitContent)
    {
      var db = new DatabaseContext();
      var newRecord = new Album
      {
        Title = title,
        ReleaseDate = releasedDate,
        BandId = bandId,
        IsExplicit = explicitContent,
      };
      db.Albums.Add(newRecord);
      db.SaveChanges();
    }
    public void NewSong(int albumId, string songTitle, TimeSpan length, string genre, string lyrics)
    {
      var db = new DatabaseContext();
      var newSong = new Song
      {
        AlbumId = albumId,
        Title = songTitle,
        Length = length,
        Genre = genre,
        Lyrics = lyrics
      };
      db.Songs.Add(newSong);
      db.SaveChanges();
    }

    // public string DuplicateEntry(string name)
    // {
    //   var db = new DatabaseContext();
    //   var duplicateEntry = db.Bands.Any(b => b.Name == name);
    //   while (duplicateEntry == true)
    //   {
    //     Console.WriteLine($"{name} is already in the system. Did you mean a different name?")
    //   }
    // }
    public void SignBand(string name, string countryOfOrigin, int numberOfMembers, string website, string style, string personOfContact, string phoneNumber)
    {
      var db = new DatabaseContext();
      var newBand = new Band
      {
        Name = name,
        CountryOfOrigin = countryOfOrigin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        Style = style,
        PersonOfContact = personOfContact,
        PhoneNumber = phoneNumber,
        IsSigned = true
      };
      db.Bands.Add(newBand);
      db.SaveChanges();
    }
    public void FireBand(string name)
    {
      var db = new DatabaseContext();
      var fireBand = db.Bands.First(band => band.Name.ToLower() == name);
      fireBand.IsSigned = false;
      db.SaveChanges();

    }
    public void ReSignBand(string name)
    {
      var db = new DatabaseContext();
      var reSignBand = db.Bands.First(band => band.Name.ToLower() == name);
      reSignBand.IsSigned = true;
      db.SaveChanges();
    }

  }
}