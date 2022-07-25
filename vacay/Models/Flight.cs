namespace vacay.Models;
public class Flight : Vacation
{
public string DepartingAirport { get; set; }
public string ArrivingAirport { get; set; }
public string FlightNumber { get; set; }
public string AircraftModel { get; set; }
public string SeatNumber { get; set; }
public string SeatClass { get; set; }
}