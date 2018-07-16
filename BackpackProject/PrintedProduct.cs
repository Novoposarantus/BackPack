using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackpackProject {
    abstract class PrintedProduct : IWeight {
        protected string name;
        protected uint countOfPages;
        public string Name => name;
        public double Weight { get => countOfPages * 0.0035; set => countOfPages = (uint)(value / 0.35); }

        public PrintedProduct(string name, uint countOfPAges) {
            this.name = name;
            this.countOfPages = countOfPAges;
        }
    }
}
