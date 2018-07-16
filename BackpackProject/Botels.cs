using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    struct Botels : IWeight
    {
        public double weight;
        public double Weight { get => weight; set => weight = value; }
        public Botels(double weight)
        {
            this.weight = weight;
        }
    }
}
