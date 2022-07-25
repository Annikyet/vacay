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


//   id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
//   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
//   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
//   creatorId VARCHAR(255) NOT NULL COMMENT 'creator ID',
//   type VARCHAR(255) NOT NULL COMMENT 'Type of vacation',
//   destination VARCHAR(255) NOT NULL COMMENT 'Vacation destination',
//   price INT NOT NULL COMMENT 'Price in cents',
//   departingAirport VARCHAR(255) COMMENT 'ICAO Airport Code of Airport departed from',
//   arrivingAirport VARCHAR(255) COMMENT 'ICAO airport code of the airport arriving at',
//   flightNumber VARCHAR(255) COMMENT 'Airline flight number',
//   aircraftModel VARCHAR(255) COMMENT 'Model of aircraft flown on',
//   seatNumber VARCHAR(255) COMMENT 'Seat Number for your seat',
//   seatClass VARCHAR(255) COMMENT 'Class of your ticket'



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
    }
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