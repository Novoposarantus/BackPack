using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Backpack: IEnumerable<Items>
    {
        public List<Items> backpack;
        public Backpack(params Items[] items)
        {
            backpack = new List<Items>(items);
        }
        public Items this[int index] => backpack[index];

        public IEnumerator<Items> GetEnumerator()
        {
            return backpack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return backpack.GetEnumerator();
        }
    }
}
