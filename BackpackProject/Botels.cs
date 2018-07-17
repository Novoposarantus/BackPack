using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Bottle : IWeight
    {
        public double weight;
        public double Weight { get => weight; set => weight = value; }
        public Bottle(double weight)
        {
            this.weight = weight;
        }
    }
}
