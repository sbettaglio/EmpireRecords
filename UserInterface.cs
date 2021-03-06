using System;
using System.Collections.Generic;

namespace EmpireRecords
{
  public class UserInterface
  {
    // public static void Tracker()
    // {
    //     pu
    // }

    public void SignBandInput()
    {
      var tracker = new DatabaseTracker();
      var styles = new List<string>();
      //input all band info
      Console.WriteLine($"What's the band's name?");
      var name = Console.ReadLine();
      name = tracker.DuplicateEntry(name);
      Console.WriteLine($"Where are the from?");
      var countryOfOrigin = Console.ReadLine().ToLower();
      Console.WriteLine($"How many members?");
      var numberOfMembers = int.Parse(Console.ReadLine());
      Console.WriteLine($"What is their website?");
      var website = Console.ReadLine().ToLower();
      Console.WriteLine($"What kind of style?");
      var style = Console.ReadLine().ToLower();
      Console.WriteLine($"Does the band have more than one style? y/n");
      var moreStyles = Console.ReadLine().ToLower();
      while (moreStyles != "y" && moreStyles != "n")
      {
        Console.WriteLine($"Invalid input. Please input (Y) or (N) ");
        moreStyles = Console.ReadLine().ToLower();
      }
      if (moreStyles == "y")
      {
        var more = true;
        while (more)
        {
          Console.WriteLine($"Please input another style. once done input (DONE) ");
          var addAnotherStyle = Console.ReadLine().ToLower();
          if (addAnotherStyle == "done")
          {
            more = false;
          }
          else
          {
            styles.Add(addAnotherStyle);
          }
        }
      }
      Console.WriteLine($"Who is the primary contact?");
      var personOfContact = Console.ReadLine().ToLower();
      Console.WriteLine($"What is their phone number?");
      var phoneNumber = Console.ReadLine();
      //call method that adds to database
      tracker.SignBand(name, countryOfOrigin, numberOfMembers, website, personOfContact, phoneNumber);
      var bandId = tracker.ReturnBandId(name);
      tracker.UpdateBandStyle(bandId, style);
      foreach (var s in styles)
      {
        tracker.UpdateBandStyle(bandId, s);
      }
    }



    public void NewRecordInput()
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"What band is producing a new record?");
      var name = Console.ReadLine().ToLower();
      //validates band name exists in the database and returns correct band name if initial input was incorrect
      name = tracker.BandInSystem(name);
      //method that takes band name and returns band id
      var bandId = tracker.ReturnBandId(name);
      Console.WriteLine($"What is the title?");
      var title = Console.ReadLine().ToLower();
      Console.WriteLine($"When was it released?");
      var releasedDate = DateTime.Parse(Console.ReadLine());
      Console.WriteLine($"Does it have explicit content?");
      var explicitContent = bool.Parse(Console.ReadLine());
      //calls method that creates the new record
      tracker.NewRecord(bandId, title, releasedDate, explicitContent);
      //method that takes album name and returns album id
      var albumId = tracker.ReturnAlbumId(title);
      // calls methos that inputs songs
      NewSongInput(albumId);
    }
    public void NewSongInput(int albumId)
    {
      var tracker = new DatabaseTracker();
      var genres = new List<string>();
      Console.WriteLine($"What is the title of the song?");
      var songTitle = Console.ReadLine().ToLower();
      Console.WriteLine($"What are the lyrics?");
      var lyrics = Console.ReadLine().ToLower();
      Console.WriteLine($"How long is it?");
      var length = TimeSpan.Parse(Console.ReadLine());
      Console.WriteLine($"What's the genre?");
      var genre = Console.ReadLine().ToLower();
      Console.WriteLine($"Does the song have more than one genre? y/n");
      var moreGenres = Console.ReadLine().ToLower();
      while (moreGenres != "y" && moreGenres != "n")
      {
        Console.WriteLine($"Invalid input. Please input (Y) or (N) ");
        moreGenres = Console.ReadLine().ToLower();
      }
      if (moreGenres == "y")
      {
        var more = true;
        while (more)
        {
          Console.WriteLine($"Please input another genre. once done input (DONE) ");
          var addAnotherGenre = Console.ReadLine().ToLower();
          if (addAnotherGenre == "done")
          {
            more = false;
          }
          else
          {
            genres.Add(addAnotherGenre);
          }
        }
      }
      //calls method that adds a new song
      tracker.NewSong(albumId, songTitle, length, lyrics);
      var songId = tracker.ReturnSongId(songTitle);
      tracker.UpdateSongGenre(songId, genre);
      foreach (var g in genres)
      {
        tracker.UpdateSongGenre(songId, g);
      }
      var moreSongs = true;
      //keeps running and adding songs until the user says not to
      while (moreSongs)
      {
        Console.WriteLine($"Add another song? y/n");
        var add = Console.ReadLine().ToLower();
        while (add != "y" && add != "n")
        {
          Console.WriteLine($"Invalid input. Please input (Y) or (N) ");
          add = Console.ReadLine().ToLower();
        }
        if (add == "y")
        {
          var genres1 = new List<string>();
          Console.WriteLine($"What is the title of the song?");
          songTitle = Console.ReadLine().ToLower();
          Console.WriteLine($"What are the lyrics?");
          lyrics = Console.ReadLine().ToLower();
          Console.WriteLine($"How long is it?");
          length = TimeSpan.Parse(Console.ReadLine());
          Console.WriteLine($"What's the genre?");
          genre = Console.ReadLine().ToLower();
          Console.WriteLine($"Does the song have more than one genre? y/n");
          var moreGenres1 = Console.ReadLine().ToLower();
          while (moreGenres1 != "y" && moreGenres1 != "n")
          {
            Console.WriteLine($"Invalid input. Please input (Y) or (N) ");
            moreGenres1 = Console.ReadLine().ToLower();
          }
          if (moreGenres1 == "y")
          {
            var more = true;
            while (more)
            {
              Console.WriteLine($"Please input another genre. once done input (DONE) ");
              var addAnotherGenre = Console.ReadLine().ToLower();
              if (addAnotherGenre == "done")
              {
                more = false;
              }
              else
              {
                genres1.Add(addAnotherGenre);
              }
            }
          }
          tracker.NewSong(albumId, songTitle, length, lyrics);
          songId = tracker.ReturnSongId(songTitle);
          tracker.UpdateSongGenre(songId, genre);
          foreach (var g in genres1)
          {
            tracker.UpdateSongGenre(songId, g);
          }
        }
        else if (add == "n")
        {
          moreSongs = false;
        }
      }
    }
    public void FireBandInput()
    {
      var tracker = new DatabaseTracker();
      //select what band you're firing
      Console.WriteLine($"What band are you fireing?");
      var name = Console.ReadLine().ToLower();
      //verifies band is in the system
      name = tracker.BandInSystem(name);
      //calls method to fire the band
      tracker.FireBand(name);
    }
    public void ReSignInput()
    {
      var tracker = new DatabaseTracker();
      //select what band you're re-signing
      Console.WriteLine($"What band are you re-signing?");
      var name = Console.ReadLine().ToLower();
      //verifies band is in the system
      name = tracker.BandInSystem(name);
      //calls methos to re-sign the band
      tracker.ReSignBand(name);
    }

    public void SongsInAlbumInput()
    {
      var tracker = new DatabaseTracker();
      //ask what album the user wants to view all the songs for
      Console.WriteLine($"What album do you want to see the song list for?");
      var title = Console.ReadLine().ToLower();
      //validates the album is in the system
      title = tracker.AlbumInSystem(title);
      //finds album id for for title user requested. user doesnt see this
      var albumId = tracker.ReturnAlbumId(title);
      //calls method that returns all the albums ordered by release date
      Console.WriteLine($"Below is the track list for {title}");
      tracker.SongsInAlbum(albumId);
    }
    public void ViewAllInput()
    {
      var tracker = new DatabaseTracker();
      //ask user what band they want to view an album list of
      Console.WriteLine($"What band do you want to see an album list for?");
      var name = Console.ReadLine().ToLower();
      //verifies band is actually in the system
      name = tracker.BandInSystem(name);
      //calls method to return album id. User doesn't see this
      var bandId = tracker.ReturnBandId(name);
      //calls method to verify if the band has any albums
      var hasAnAlbum = tracker.HasAnAlbum(bandId);
      if (hasAnAlbum == false)
      {
        //displays if the band doesn't have any albums
        Console.Write($"This band doesn't have any albums.");
      }
      else if (hasAnAlbum == true)
      {
        //calls method to display all the band's albums
        Console.WriteLine($"These are all of {name}'s albums. ");
        tracker.ViewBandAlbumList(bandId);
      }
    }
    public void ViewAlbumsInAGenre()
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"Song genres in our system");

      Console.WriteLine($"Which genre do you want to see an album list for?");
      var genre = Console.ReadLine().ToLower();
      var songIds = tracker.GetSongIdList(genre);
      var albumIdList = tracker.GetAlbumListFromSongIdList(songIds);
      tracker.DisplayAlbumGenres(albumIdList, genre);
      Console.ReadLine();
    }


    public void NewMusicianInput()
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"What's the musician's name?");
      var name = Console.ReadLine().ToLower();
      Console.WriteLine($"What instrument does the musician play?");
      var instrument = Console.ReadLine().ToLower();
      tracker.AddNewMusician(name, instrument);
      var musicianId = tracker.ReturnMusicianId(name);
      Console.WriteLine($"Add the {name} to a band? y/n");
      var addToBand = Console.ReadLine().ToLower();
      while (addToBand != "y" && addToBand != "n")
      {
        Console.WriteLine($"Invalid input. Please input (Y) or (N)");
        addToBand = Console.ReadLine().ToLower();
      }
      if (addToBand == "y")
      {
        AddNewMusicianToBandInput(name, musicianId);

      }

    }
    public void AddNewMusicianToBandInput(string name, int musicianId)
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"What band are you adding {name} to?");
      var bandName = Console.ReadLine().ToLower();
      var bandId = tracker.ReturnBandId(bandName);
      tracker.AddMusicianToBand(bandId, musicianId);

    }
    public void ExistingMusicianToBandInput()
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"What musician are you adding?");
      var musicianName = Console.ReadLine().ToLower();
      var musicianId = tracker.ReturnMusicianId(musicianName);
      Console.WriteLine($"What band are you adding{musicianName} to?");
      var bandName = Console.ReadLine().ToLower();
      var bandId = tracker.ReturnBandId(bandName);
      tracker.AddMusicianToBand(bandId, musicianId);
    }

  }


}