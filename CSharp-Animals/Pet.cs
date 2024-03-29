using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public abstract class Pet
    {
        public string Name { get; }

        public Pet(string name)
        {
            Name = name;
        }
    }
}
