using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Employee
    {
        public int Code { get; set;  }
        public char Name { get; set;  }


        public void Print()
        {
            Console.WriteLine("Code: " + Code + " Name: " + Name);
        }
    }
}
