using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class FlightsRepository
    {

//           public class BurgersRepository : IRepo<Burger>
// no extensions if i don't use interfaces
//   {
//     private readonly IDbConnection _db;

//     public BurgersRepository(IDbConnection db)
//     {
//       _db = db;
//     }

        private readonly IDbConnection _db;

        public FlightsRepository(IDbConnection db)
        {
            _db = db;
        }


    // public Burger Create(Burger burgerData)
    // {
    //   string sql = @"
    //   INSERT INTO burgers
    //   (name, description, price, creatorId)
    //   VALUES
    //   (@Name, @Description, @Price, @CreatorId);
    //   SELECT LAST_INSERT_ID();
    //   ";

    //   int id = _db.ExecuteScalar<int>(sql, burgerData);
    //   burgerData.Id = id;
    //   return burgerData;
    // }






        public Flight Create(Flight flightData)
        {
            string sql = @"
            INSERT INTO flights
            (creatorId, type, destination, price,
            departingAirport, arrivingAirport, flightNumber, aircraftModel, seatNumber, seatClass)
            VALUES
            (@CreatorId, @Type, @Destination, @Price,
            @DepartingAirport, @ArrivingAirport, @FlightNumber, @AircraftModel, @SeatNumber, @SeatClass);
            SELECT LAST_INSERT_ID();
            ";

            int id = _db.ExecuteScalar<int>(sql, flightData);
            flightData.Id = id;
            return flightData;
        }



        public Flight GetById(int id)
        {
            // TODO there should probably be some logic to make sure it's only pulling YOUR flights...
            // also this code is basically going to be the same for the other vacation subtypes...
            string sql = @"
            SELECT *
            FROM flights
            WHERE flights.id = @id"; // TODO, seriously this is bad... fix it.
            return _db.Query<Flight>(sql, new { id }).FirstOrDefault();
        }

    // public Burger GetById(int id)
    // {
    //   string sql = @"
    //   SELECT
    //     a.*,
    //     b.*
    //   FROM burgers b
    //   JOIN accounts a ON a.id = b.creatorId
    //   WHERE b.id = @id";
    // this is Dapper mapping table to list of models

    // last type is always return type
    // first two types are how Dapper interprets the table
    // sql is query to be executed
    //   return _db.Query<Profile, Burger, Burger>(sql, (prof, burg) =>
    //   {
    //     burg.Creator = prof;
    //     return burg;
    // // defines what @id is
    // // @id = id
    // // just take new as given because... reasons
    // // use commas for multiples
    // // firstordefault - only grab first one
    //   }, new { id }).FirstOrDefault();
    // }


        public void Update(Flight original)
        {
            string sql = @"
            UPDATE flights
            SET
              type = @Type,
              destination = @Destination,
              price = @Price,
              departingAirport = @DepartingAirport,
              arrivingAirport = @ArrivingAirport,
              flightNumber = @FlightNumber,
              aircraftModel = @AircraftModel,
              seatNumber = @SeatNumber,
              seatClass = @SeatClass
            WHERE id = @Id;";
            _db.Execute(sql, original);
        }

            // original.Type = flightData.Type ?? original.Type;
            // original.Destination = flightData.Destination ?? original.Destination;
            // original.Price = flightData.Price > 0 ? flightData.Price : original.Price;
            // original.DepartingAirport = flightData.DepartingAirport ?? original.DepartingAirport;
            // original.ArrivingAirport = flightData.ArrivingAirport ?? original.ArrivingAirport;
            // original.FlightNumber = flightData.FlightNumber ?? original.FlightNumber;
            // original.AircraftModel = flightData.AircraftModel ?? original.AircraftModel;
            // original.SeatNumber = flightData.SeatNumber ?? original.SeatNumber;
            // original.SeatClass = flightData.SeatClass ?? original.SeatClass;



    // public void Edit(Burger original)
    // {
    //   string sql = @"
    //   UPDATE burgers
    //   SET
    //     name = @Name,
    //     description = @Description,
    //     price = @Price
    //   WHERE id = @Id;";
    //   _db.Execute(sql, original);

    // }


    public void Remove(int id)
    {
        string sql = "DELETE FROM flights WHERE id = @id LIMIT 1";
        _db.Execute(sql, new {id});
    }






    // public void Delete(int id)
    // {
    //   string sql = "DELETE FROM burgers WHERE id = @id LIMIT 1";
    //   _db.Execute(sql, new { id });
    // }
    }
}