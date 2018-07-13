using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    abstract class Animal
    {
        public enum KindsOfAnimal { Cat, Dog, Rabbit }
        protected KindsOfAnimal kindOfAnimal;
        protected string name;
        protected double weight;
        protected double amount;
        public string Name => name;
        public double Weight => weight;
        public double Amount => amount;
        public KindsOfAnimal KindOfAnimal => kindOfAnimal;
        protected Animal(string name,double weight,double amount, KindsOfAnimal kindOfAnimal)
        {
            this.name = name;
            this.weight = weight;
            this.amount = amount;
            this.kindOfAnimal = kindOfAnimal;
        }
    }
}
