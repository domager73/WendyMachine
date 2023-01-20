using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wendy
{
    struct Drink
    {
        public int id;
        public string Name;
        public int Prise;
    }

    enum Prise 
    {
        Coffe = 100,
        Latte = 150,
        Macchiato = 130,
        DoubleEx = 160,
        Americano = 120,
        Cappuccino = 170
    }
}
