﻿using System;
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
            Backpack backpack = new Backpack(new Cat("Rose", 0.5), new Cat("Robin", 1), new Rabbit("Fuzzy", 0.15), new Dog("Garry", 5.5),new Book("C#",1000));
            double weightDogs = (from dog in backpack.OfType<Dog>() select dog.Weight).Sum(); ;
            double weightRabbits = (from rabbit in backpack.OfType<Rabbit>() select rabbit.Weight).Sum(); ;
            double weightCats = (from cat in backpack.OfType<Cat>() select cat.Weight).Sum();
            double weightBooks = (from book in backpack.OfType<Book>() select book.Weight).Sum();
            double weightAnimals = (from book in backpack.OfType<Animal>() select book.Weight).Sum();
            double wieghtPrintedProduct = (from book in backpack.OfType<PrintedProduct>() select book.Weight).Sum();
            Console.WriteLine($"Dog : {weightDogs}\nRabbit : {weightRabbits}\nCat : {weightCats}\nBook : {weightBooks}");
            Console.WriteLine($"Weight Animal: {weightAnimals}\nWeight Printed Product : {wieghtPrintedProduct}");
        }
    }
}
