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
            //Backpack backpack = new Backpack(new Cat("Rose", 0.5), new Cat("Robin", 1), new Rabbit("Fuzzy", 0.15), new Dog("Garry", 5.5),new Book("C#",1000));
            var backpack = Enumerable.Range(0, 100).Select(a =>
            {
                switch (a % 3)
                {
                    case 0:
                        return (IWeight)(new Cat($"{a}", 1));
                    case 1:
                        return (new Bottle(0.2));
                    case 2:
                        return (new Book($"{a}", 100));
                }
                return new Bottle(0.3);
            });
            double weightDogs = (from dog in backpack.OfType<Dog>() select dog.Weight).Sum(); ;
            double weightRabbits = (from rabbit in backpack.OfType<Rabbit>() select rabbit.Weight).Sum(); ;
            double weightCats = (from cat in backpack.OfType<Cat>() select cat.Weight).Sum();
            double weightBooks = (from book in backpack.OfType<Book>() select book.Weight).Sum();
            double weightAnimals = (from book in backpack.OfType<Animal>() select book.Weight).Sum();
            double weightBotels = backpack.OfType<Bottle>().Select(n => n.Weight).Sum();
            double wieghtPrintedProduct = (from book in backpack.OfType<PrintedProduct>() select book.Weight).Sum();
            double takeWeight = backpack.Take(3).Sum(n=>n.Weight);
            double skipWeight = backpack.Skip(3).Take(2).Sum(n => n.Weight);
            Console.WriteLine($"Dog : {weightDogs}\nRabbit : {weightRabbits}\nCat : {weightCats}\nBook : {weightBooks}\nBotels: {weightBotels}");
            Console.WriteLine($"Weight Animal: {weightAnimals}\nWeight Printed Product : {wieghtPrintedProduct}");
            Console.WriteLine($"Take Weight : {takeWeight}; SkipTake Weight : {skipWeight}");
            (IEnumerable<Cat> cats, IEnumerable<Bottle> bottles, IEnumerable<Book> books) = GetDistruction(backpack);
            var lisCats = cats.ToList();
            var listBotteles = bottles.ToList();
            var listBooks = books.ToList();
        }
        static public Tuple<IEnumerable<Cat>, IEnumerable<Bottle>, IEnumerable<Book>> GetDistruction(IEnumerable<IWeight> enumerable)
        {

            var groupingCats =
                from items in enumerable
                group items by items.GetType() into grouping
                from g in grouping
                where (g.GetType() == typeof(Cat))
                select g as Cat;

            var groupingBottles =
                from items in enumerable
                group items by items.GetType() into grouping
                from g in grouping
                where (g.GetType() == typeof(Bottle))
                select g as Bottle;

            var groupingBooks =
                from items in enumerable
                group items by items.GetType() into grouping
                from g in grouping
                where (g.GetType() == typeof(Book))
                select g as Book;

            return Tuple.Create(groupingCats, groupingBottles, groupingBooks);
        }
    }
    
}
