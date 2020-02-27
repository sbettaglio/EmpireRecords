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
