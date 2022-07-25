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

    }
}