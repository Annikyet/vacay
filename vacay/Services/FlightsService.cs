using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class FlightsService
    {
        private readonly FlightsRepository _repo; // declares the label for the instance of flights repository

        public FlightsService(FlightsRepository repo) // import already instantiated persistent singleton of flights repository
        {
            _repo = repo;
        }

        internal Flight Create(Flight flightData)
        {
            return _repo.Create(flightData);
        }

        internal Flight Get(int id)
        {
            Flight found = _repo.GetById(id);
            if (found == null) // C# doesn't have automatic truthy/falsey
            {
                throw new Exception("Invalid ID");
            }
            return found;
        }

        internal Flight Update(Flight flightData)
        {
            Flight original = Get(flightData.Id);
            if (original.CreatorId != flightData.CreatorId)
            {
                throw new Exception("Nacho vacay!!!");
            }
            original.Type = flightData.Type ?? original.Type;
            original.Destination = flightData.Destination ?? original.Destination;
            original.Price = flightData.Price > 0 ? flightData.Price : original.Price;
            original.DepartingAirport = flightData.DepartingAirport ?? original.DepartingAirport;
            original.ArrivingAirport = flightData.ArrivingAirport ?? original.ArrivingAirport;
            original.FlightNumber = flightData.FlightNumber ?? original.FlightNumber;
            original.AircraftModel = flightData.AircraftModel ?? original.AircraftModel;
            original.SeatNumber = flightData.SeatNumber ?? original.SeatNumber;
            original.SeatClass = flightData.SeatClass ?? original.SeatClass;

            _repo.Update(original);
            return original;
            
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



    // internal Burger Edit(Burger burgerData)
    // {
    //   Burger original = Get(burgerData.Id);
    //   if (original.CreatorId != burgerData.CreatorId)
    //   {
    //     throw new Exception("Invalid Access");
    //   }
    //   original.Name = burgerData.Name ?? original.Name;
    //   original.Description = burgerData.Description ?? original.Description;
    //   original.Price = burgerData.Price > 0 ? burgerData.Price : original.Price;

    //   _repo.Edit(original);
    //   return original;
    // }



    internal Flight Remove(int id, string userId)
    {
        Flight original = Get(id);
        if (original.CreatorId != userId)
        {
            throw new Exception("Nacho vacay!!!");
        }
        _repo.Remove(id);
        return original;
    }





    // internal Burger Delete(int id, string userId)
    // {
    //   Burger original = Get(id);
    //   if (original.CreatorId != userId)
    //   {
    //     throw new Exception("Invalid Access");
    //   }
    //   _repo.Delete(id);
    //   return original;
    // }

    }
}