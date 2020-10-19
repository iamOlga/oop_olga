using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6lab
{
    abstract partial class PO
    { 
        public void PrintInfo()
        {
            Console.WriteLine("PO name: " + Name);
        }
        public override string ToString()
        {
            return $"Type: {this.GetType()}, Name: {Name}";
        }
    }
}
