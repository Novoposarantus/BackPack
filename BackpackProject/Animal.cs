using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    abstract class Animal : Items
    {
        protected string name;
        protected double weight;
        protected double amount;
        public string Name => name;
        public double Weight => weight;
        public double Amount => amount;
        protected Animal(string name,double weight,double amount)
        {
            this.name = name;
            this.weight = weight;
            this.amount = amount;
        }
    }
}
