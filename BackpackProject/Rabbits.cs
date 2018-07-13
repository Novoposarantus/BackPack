using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Rabbit : Animal
    {
        public Rabbit(string name, double weight, double ammount = 0.00525) : base("Rabbit " + name, weight, ammount,KindsOfAnimal.Rabbit)
        {
        }
    }
}
