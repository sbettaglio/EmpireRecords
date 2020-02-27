using System;

namespace EmpireRecords
{
  public class UserInterface
  {
    public void SignBandInput()
    {
      var tracker = new DatabaseTracker();
      //input all band info
      Console.WriteLine($"What's the band's name?");
      var name = Console.ReadLine();
      // name = tracker.DuplicateEntry(name);
      Console.WriteLine($"Where are the from?");
      var countryOfOrigin = Console.ReadLine().ToLower();
      Console.WriteLine($"How many members?");
      var numberOfMembers = int.Parse(Console.ReadLine());
      Console.WriteLine($"What is their website?");
      var website = Console.ReadLine().ToLower();
      Console.WriteLine($"What kind of style?");
      var style = Console.ReadLine().ToLower();
      Console.WriteLine($"Who is the primary contact?");
      var personOfContact = Console.ReadLine().ToLower();
      Console.WriteLine($"What is their phone number?");
      var phoneNumber = Console.ReadLine();
      //call method that adds to database
      tracker.SignBand(name, countryOfOrigin, numberOfMembers, website, style, personOfContact, phoneNumber);
    }
    public void NewRecordInput()
    {
      var tracker = new DatabaseTracker();
      Console.WriteLine($"What bad is producing a new record?");
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
      Console.WriteLine($"What is the title of the song?");
      var songTitle = Console.ReadLine().ToLower();
      Console.WriteLine($"What are the lyrics?");
      var lyrics = Console.ReadLine().ToLower();
      Console.WriteLine($"How long is it?");
      var length = TimeSpan.Parse(Console.ReadLine());
      Console.WriteLine($"What's the genre?");
      var genre = Console.ReadLine().ToLower();
      //calls method that adds a new song
      tracker.NewSong(albumId, songTitle, length, genre, lyrics);
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
          Console.WriteLine($"What is the title of the song?");
          songTitle = Console.ReadLine().ToLower();
          Console.WriteLine($"What are the lyrics?");
          lyrics = Console.ReadLine().ToLower();
          Console.WriteLine($"How long is it?");
          length = TimeSpan.Parse(Console.ReadLine());
          Console.WriteLine($"What's the genre?");
          genre = Console.ReadLine().ToLower();
          tracker.NewSong(albumId, songTitle, length, genre, lyrics);
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
      //calls methos to fire the band
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

  }
}