using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class BackpackForAnimals : IEnumerable<Animal>
    {
        public List<Animal> backpack;
        public BackpackForAnimals(params Animal[] animals)
        {
            if (animals.Length < 1)
            {
                return;
            }
            backpack = new List<Animal>();
            for (var i = 0; i < animals.Length; ++i)
            {
                backpack.Add(animals[i]);
            }
        }
        public Animal this[int index] => backpack[index];

        public IEnumerator<Animal> GetEnumerator()
        {
            return backpack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return backpack.GetEnumerator();
        }
    }
}
