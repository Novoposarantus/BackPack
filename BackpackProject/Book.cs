using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject
{
    class Book : PrintedProduct {
        public Book(string name, uint countOfPages) : base(name, countOfPages) 
        {
        }
    }
}
