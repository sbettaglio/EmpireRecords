namespace EmpireRecords.Models
{
  public class SongGenre
  {
    public int Id { get; set; }
    public string Genre { get; set; }
    public int SongId { get; set; }
    public Song Song { get; set; }

  }
}