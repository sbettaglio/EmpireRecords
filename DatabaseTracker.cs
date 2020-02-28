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

    public string DuplicateEntry(string name)
    {
      var db = new DatabaseContext();
      var duplicateEntry = db.Bands.Any(b => b.Name == name);
      while (duplicateEntry == true)
      {
        Console.WriteLine($"{name} is already in the system. Did you mean a different name?");
        name = Console.ReadLine().ToLower();
        duplicateEntry = db.Bands.Any(b => b.Name == name);
        return name;
      }
      return name;
    }
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
    public string ViewChoiceValidation(string viewChoice)
    {
      while (viewChoice != "all" && viewChoice != "date" && viewChoice != "songs" && viewChoice != "are" && viewChoice != "not")
      {
        Console.WriteLine($"Invalid input. Please input(ALL), (DATE,) (SONGS), (ARE) or (NOT) ");
        viewChoice = Console.ReadLine().ToLower();
        return viewChoice;
      }
      return viewChoice;
    }
    public bool HasAnAlbum(int bandId)
    {
      var db = new DatabaseContext();
      var hasAnAlbum = db.Albums.Any(album => album.BandId == bandId);
      return hasAnAlbum;
    }
    public void ViewBandAlbumList(int bandId)
    {
      var db = new DatabaseContext();
      var albumList = db.Albums.Where(album => album.BandId == bandId);
      foreach (var b in albumList)
      {
        Console.WriteLine($"{b.Title}, released on: {b.ReleaseDate}, is explicit: {b.IsExplicit}");
      }

    }
    public void AlbumsByDate()
    {
      var db = new DatabaseContext();
      var orderByDate = db.Albums.OrderByDescending(album => album.ReleaseDate);
      foreach (var b in orderByDate)
      {
        Console.WriteLine($"{b.Title}, released on: {b.ReleaseDate}, is explicit: {b.IsExplicit}");
      }
    }
    public string AlbumInSystem(string title)
    {
      var db = new DatabaseContext();
      var albumInSystem = db.Albums.Any(album => album.Title == title);
      while (albumInSystem == false)
      {
        Console.WriteLine($"That {title} is not in the system. Please try again");
        title = Console.ReadLine().ToLower();
        albumInSystem = db.Albums.Any(album => album.Title == title);
        return title;
      }
      if (albumInSystem == true)
      {
        return title;
      }
      return title;
    }
    public void SongsInAlbum(int albumId)
    {
      var db = new DatabaseContext();
      var displaySongs = db.Songs.Where(song => song.AlbumId == albumId);
      foreach (var s in displaySongs)
      {
        Console.WriteLine($"{s.Title}, length:{s.Length}, genre: {s.Genre}, catchiest lyric: {s.Lyrics} ");
      }
    }
    public void SignedBandList()
    {
      var db = new DatabaseContext();
      var signedBands = db.Bands.Where(band => band.IsSigned == true);
      foreach (var b in signedBands)
      {
        Console.WriteLine($"{b.Name}");
      }
    }
    public void UnSignedBandList()
    {
      var db = new DatabaseContext();
      var unsignedBands = db.Bands.Where(band => band.IsSigned == false);
      foreach (var b in unsignedBands)
      {
        Console.WriteLine($"{b.Name}");
      }
    }

  }
}

