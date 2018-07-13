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
            backpack = new List<Animal>(animals);
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
