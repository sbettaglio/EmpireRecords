using System.Collections.Generic;

namespace EmpireRecords.Models
{
  public class Musician
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
    public List<BandMusician> BandMusicians { get; set; } = new List<BandMusician>();

  }
}