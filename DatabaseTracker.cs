using System;
using EmpireRecords.Models;

namespace EmpireRecords
{
  public class DatabaseTracker
  {
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
  }

}