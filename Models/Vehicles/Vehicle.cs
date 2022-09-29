using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models
{
    public abstract class Vehicle
    {
        public enum Engine
        {
            Combustion = 1,
            Electrict = 2
        }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public Engine EngineType { get; set; }

        public abstract string GetBrandModel();
    }
}