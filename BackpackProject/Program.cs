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
            var groupWeights = GetGroupByWeight(backpack, 3);
            var groupIndex = GetGroup(backpack, 3);
        }
        static public (IEnumerable<Cat>, IEnumerable<Bottle>, IEnumerable<Book>) GetDistruction(IEnumerable<IWeight> enumerable)
        {
            var group = (from item in enumerable
                         group item by item.GetType() into grouping
                         select new { grouping.Key, items = grouping.Select(g => g) }).ToDictionary(e => e.Key, e => e.items);
            return (group[typeof(Cat)].Cast<Cat>(), group[typeof(Bottle)].Cast<Bottle>(), group[typeof(Book)].Cast<Book>());
        }
        static public Dictionary<int,IEnumerable<IWeight>> GetGroupByWeight(IEnumerable<IWeight> enumerable, int count)
        {
            if (count == 0 || count == 1)
            {
                var d = new Dictionary<int, IEnumerable<IWeight>>();
                d.Add(0, enumerable);
                return d;
            }

            var numEven = enumerable.Aggregate((min: double.PositiveInfinity, max: 0d), (acc, current) =>
                                              (current.Weight < acc.min ? current.Weight : acc.min,
                                               current.Weight > acc.max ? current.Weight : acc.max));
            double length = (numEven.max - numEven.min) / count;

            int GetRegion(IWeight item)
            {
                double min = numEven.min + length;
                for (var i = 1; i <= count; ++i, min += length)
                {
                    if (item.Weight < min) return i - 1;
                }
                return count - 1;
            }

            var group = (from item in enumerable
                         let region = GetRegion(item)
                         group item by region into grouping
                          select new { grouping.Key, items = grouping.Select(g => g) }).ToDictionary(e => e.Key, e => e.items);
            for (int i = 0; i < count; ++i)
            {
                if (!group.ContainsKey(i)) group.Add(i, Enumerable.Empty<IWeight>());
            }
            return group;
        }
        static public IEnumerable<IEnumerable<IWeight>> GetGroup(IEnumerable<IWeight> enumerable, int countGroups)
        {
            if (countGroups == 0 || countGroups == 1)
            {
                return new IEnumerable<IWeight>[1] { enumerable };
            }

            var arr = new IEnumerable<IWeight>[countGroups];
            return  (from item in enumerable.Select((item, i) => new {item, i})
                         group item.item by Math.Min(item.i/(enumerable.Count()/countGroups),countGroups-1) into grouping
                         select grouping);
        }
    }
    
}
