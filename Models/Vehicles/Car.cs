using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chorizo.Models
{
    public class Car : Vehicle
    {
        public override string GetBrandModel()
        {
            return String.Format("{0} {1}", Brand, Model);
        }
    }
}