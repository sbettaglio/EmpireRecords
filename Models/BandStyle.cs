namespace EmpireRecords.Models
{
  public class BandStyle
  {
    public int Id { get; set; }
    public string Style { get; set; }
    public int BandId { get; set; }
    public Band Band { get; set; }
  }
}