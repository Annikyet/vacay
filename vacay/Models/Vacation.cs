using System;


namespace vacay.Models;
// 'abstract' means it can't be instantiated alone
// not strictly necessary - like for big teams or something
public abstract class Vacation
{
  public int Id { get; set; }
  public string CreatorId { get; set; }
  public string Type { get; set; }
  public string Destination { get; set; }
  public int Price { get; set; } // price in cents
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }


}