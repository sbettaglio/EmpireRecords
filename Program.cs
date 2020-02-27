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
      var user = new UserInterface();
      var sexyRexy = true;
      Console.WriteLine($"Welcome to Empire Records!");
      while (sexyRexy)
      {
        //asks user what they want to do?
        Console.WriteLine($"Do you want to (SIGN) a band, (PRODUCE) an album, (FIRE) a band, (RE)-sign a band, (VIEW) our database or (QUIT) the program?");
        var choice = Console.ReadLine().ToLower();
        //sends to validation method. returns valid input if not a valid initial input
        choice = tracker.GreetingInput(choice);
        if (choice == "sign")
        {
          //call Sign band input method
          user.SignBandInput();

        }
        else if (choice == "produce")
        {
          // Calls new record input method
          user.NewRecordInput();
        }
        else if (choice == "fire")
        {
          // Calls methord to fire a band from the label
          user.FireBandInput();
        }
        else if (choice == "quit")
        {
          sexyRexy = false;
        }

      }
    }
  }

}
