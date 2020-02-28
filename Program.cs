using System;
using EmpireRecords.Models;
using System.Linq;
using ConsoleTools;

namespace EmpireRecords
{
  class Program
  {
    static void Main(string[] args)
    {
      var tracker = new DatabaseTracker();
      var user = new UserInterface();
      //var sexyRexy = true;
      Console.WriteLine($"Welcome to Empire Records!");
      var subMenu = new ConsoleMenu(args, level: 1)
        .Add("All albums for a band", () => user.ViewAllInput())
        .Add("Every album sorted by release date", () => tracker.AlbumsByDate())
        .Add("An album with all it's songs", () => user.SongsInAlbumInput())
        .Add("Signed Bands", () => tracker.SignedBandList())
        .Add("Bands not signed", () => tracker.UnSignedBandList())
        .Add("Sub_Close", ConsoleMenu.Close)
    .Configure(config =>
        {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Submenu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
        });
      var menu = new ConsoleMenu(args, level: 0)
        .Add("Sign a band", () => user.SignBandInput())
        .Add("New album", () => user.NewRecordInput())
        .Add("Fire a band", () => user.FireBandInput())
        .Add("Re-sign a band", () => user.ReSignInput())
        .Add("View database", subMenu.Show)
        .Add("Exit", () => Environment.Exit(0))
        .Configure(config =>
        {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Main menu";
          config.EnableWriteTitle = true;
          config.EnableBreadcrumb = true;
        });
      menu.Show();
    }
  }
}








