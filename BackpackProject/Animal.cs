using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    abstract class Animal : IWeight
    {
        protected string name;
        protected double amount;
        public string Name => name;
        public double Amount => amount;

        public double Weight { get; set; }

        protected Animal(string name,double weight,double amount)
        {
            this.name = name;
            Weight = weight;
            this.amount = amount;
        }
    }
}
