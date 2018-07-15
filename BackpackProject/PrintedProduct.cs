using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject {
    abstract class PrintedProduct : Items {
        protected string name;
        protected uint countOfPages;
        public string Name => name;
        public double Weight => countOfPages * 0.0035;

        public PrintedProduct(string name, uint countOfPAges) {
            this.name = name;
            this.countOfPages = countOfPAges;
        }
    }
}
