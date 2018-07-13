using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BackpackForAnimals backpack = new BackpackForAnimals(new Cat("Rose", 0.5), new Cat("Robin", 1), new Rabbit("Fuzzy", 0.15), new Dog("Garry", 5.5));
            double weightCats = 0;
            double weightDogs = 0;
            double weightRabbits = 0;
            foreach (var animal in backpack)
            {
                if (animal.KindOfAnimal == Animal.KindsOfAnimal.Cat)
                {
                    weightCats += animal.Weight;
                }
                else if (animal.KindOfAnimal == Animal.KindsOfAnimal.Dog)
                {
                    weightDogs += animal.Weight;
                }
                else
                {
                    weightRabbits += animal.Weight;
                }
            }
            Console.WriteLine($"Cats weight = {weightCats}\nDogs weight = {weightDogs}\nRabbits weight = {weightRabbits}");
        }
    }
}
