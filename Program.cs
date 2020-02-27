using System;
using EmpireRecords.Models;
using System.Linq;

namespace EmpireRecords
{
  class Program
  {
    static void Main(string[] args)
    {
      var tracker = new DatabaseTracker();
      var sexyRexy = true;
      Console.WriteLine($"Welcome to Empire Records!");
      while (sexyRexy)
      {
        //asks user what they want to do?
        Console.WriteLine($"Do you want to (SIGN) a band, (PRODUCE) and album, (FIRE) a band, (RE)-sign a band, (VIEW) our database or (QUIT) the program?");
        var choice = Console.ReadLine().ToLower();
        //sends to validation method. returns valid input if not a valid initial input
        choice = tracker.GreetingInput(choice);
        if (choice == "sign")
        {
          //input band details
          Console.WriteLine($"What's the band's name?");
          var name = Console.ReadLine();
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
          tracker.SignBand(name, countryOfOrigin, numberOfMembers, website, style, personOfContact, phoneNumber);
        }
        else if (choice == "quit")
        {
          sexyRexy = false;
        }

      }
    }
  }
}
