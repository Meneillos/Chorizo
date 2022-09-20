using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models
{
    public class Airplane : Vehicle
    {
        public override string GetBrandModel()
        {
            return Brand + " " + Model;
        }
    }
}