using System;
using System.Linq;
using EmpireRecords.Models;
using System.Collections.Generic;

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
    public int ReturnSongId(string songTitle)
    {
      var db = new DatabaseContext();
      var songId = db.Songs.First(song => song.Title == songTitle);
      return songId.Id;
    }
    public void NewSong(int albumId, string songTitle, TimeSpan length, string lyrics)
    {
      var db = new DatabaseContext();
      var newSong = new Song
      {
        AlbumId = albumId,
        Title = songTitle,
        Length = length,
        Lyrics = lyrics
      };
      db.Songs.Add(newSong);
      db.SaveChanges();
    }
    public void UpdateSongGenre(int songID, string genre)
    {
      var db = new DatabaseContext();
      var songGenre = new SongGenre
      {
        SongId = songID,
        Genre = genre
      };
      db.SongGenres.Add(songGenre);
      db.SaveChanges();
    }

    public void AddNewMusician(string name, string instrument)
    {
      var db = new DatabaseContext();
      var newMusician = new Musician
      {
        Name = name,
        Instrument = instrument
      };
      db.Musicians.Add(newMusician);
      db.SaveChanges();
    }
    public void AddMusicianToBand(int bandId, int musicianId)
    {
      var db = new DatabaseContext();
      var newBandMusician = new BandMusician
      {
        BandId = bandId,
        MusicianId = musicianId,
      };
      db.BandMusicians.Add(newBandMusician);
      db.SaveChanges();
    }
    public int ReturnMusicianId(string name)
    {
      var db = new DatabaseContext();
      var musicianId = db.Musicians.First(musician => musician.Name == name);
      return musicianId.Id;
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


    public void SignBand(string name, string countryOfOrigin, int numberOfMembers, string website, string personOfContact, string phoneNumber)
    {
      var db = new DatabaseContext();
      var newBand = new Band
      {
        Name = name,
        CountryOfOrigin = countryOfOrigin,
        NumberOfMembers = numberOfMembers,
        Website = website,
        PersonOfContact = personOfContact,
        PhoneNumber = phoneNumber,
        IsSigned = true
      };
      db.Bands.Add(newBand);
      db.SaveChanges();
    }
    public void UpdateBandStyle(int bandId, string style)
    {
      var db = new DatabaseContext();
      var bandStyle = new BandStyle
      {
        BandId = bandId,
        Style = style
      };
      db.BandStyles.Add(bandStyle);
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
      Console.WriteLine("Press enter to exit.");
      Console.ReadLine();
    }
    public void AlbumsByDate()
    {
      var db = new DatabaseContext();
      var orderByDate = db.Albums.OrderByDescending(album => album.ReleaseDate);
      foreach (var b in orderByDate)
      {
        Console.WriteLine($"{b.Title}, released on: {b.ReleaseDate}, is explicit: {b.IsExplicit}");
      }
      Console.WriteLine("Press enter to exit.");
      Console.ReadLine();
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
        Console.WriteLine($"{s.Title}, length:{s.Length}, genre:, catchiest lyric: {s.Lyrics} ");
      }
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
    public void SignedBandList()
    {
      var db = new DatabaseContext();
      var signedBands = db.Bands.Where(band => band.IsSigned == true);
      foreach (var b in signedBands)
      {
        Console.WriteLine($"{b.Name}");
      }
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
    public void UnSignedBandList()
    {
      var db = new DatabaseContext();
      var unsignedBands = db.Bands.Where(band => band.IsSigned == false);
      foreach (var b in unsignedBands)
      {
        Console.WriteLine($"{b.Name}");
      }
      Console.WriteLine("Press enter to exit");
      Console.ReadLine();
    }
    public void DisplayGenres()
    {
      var db = new DatabaseContext();
      var genres = db.SongGenres.First(ge => ge.Genre);
      foreach (var g in genres)
      {
        Console.WriteLine($"|-------------|");
        Console.WriteLine($"|  {g.Genre}  |");
        Console.WriteLine($"|-------------|");
      }

    }
    public List<int> GetSongIdList(string genre)
    {
      var db = new DatabaseContext();
      var songGenre = db.SongGenres.Where(song => song.Genre == genre);
      var songIds = new List<int>();
      foreach (var s in songGenre)
      {
        songIds.Add(s.SongId);

      }
      return songIds;
    }
    public List<int> GetAlbumListFromSongIdList(List<int> songIds)
    {
      var db = new DatabaseContext();
      var albumIdList = new List<int>();
      foreach (var a in songIds)
      {
        Console.WriteLine($"{a} ");
      }
    }
  }
}








