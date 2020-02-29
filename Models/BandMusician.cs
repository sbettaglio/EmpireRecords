namespace EmpireRecords.Models
{
  public class BandMusician
  {
    public int Id { get; set; }
    public int BandId { get; set; }
    public Band Band { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
  }
}