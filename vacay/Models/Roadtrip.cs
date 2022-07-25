namespace vacay.Models;
public class Roadtrip : Vacation
{
  public float MilesPerGallon { get; set; }
  public int NumberOfStops { get; set; }
  public float Miles { get; set; }
  public string Highway { get; set; }
  public float MilesPerHour { get; set; }
}