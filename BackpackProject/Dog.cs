using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Dog : Animal
    {
        public Dog(string name, double weight, double ammount = 0.525) : base("Dog " + name, weight, ammount,KindsOfAnimal.Dog)
        {
        }
    }
}
