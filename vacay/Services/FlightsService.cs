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

        // Can you extend methods...?
        internal Flight AuthGet(int flightId, string userId)
        {
            System.Console.WriteLine("flightId: " + flightId.ToString());
            System.Console.WriteLine("userId: " + userId);
            Flight found = _repo.GetById(flightId);
            if (found == null) // C# doesn't have automatic truthy/falsey
            {
                throw new Exception("Invalid ID");
            }
            if (found.CreatorId != userId)
            {
                throw new Exception("Nacho vacay!!!");
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
    }
}