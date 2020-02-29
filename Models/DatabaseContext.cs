using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpireRecords.Models
{
  public partial class DatabaseContext : DbContext
  {
    public DbSet<Album> Albums { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<SongGenre> SongGenres { get; set; }
    public DbSet<BandStyle> BandStyles { get; set; }
    public DbSet<BandMusician> BandMusicians { get; set; }
    public DbSet<Musician> Musicians { get; set; }
    // Add Database tables here
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {

        optionsBuilder.UseNpgsql("server=localhost;database=EmpireRecords");
      }
    }
  }
}
