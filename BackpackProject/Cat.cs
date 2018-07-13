using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Cat : Animal
    {
        public Cat(string name, double weight, double ammount = 0.01875) : base("Cat " + name, weight, ammount,KindsOfAnimal.Cat)
        {
        }
    }
}
