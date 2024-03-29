using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public class Dog : Pet, ITalkable
    {
        public bool Friendly { get; }

        public Dog(bool friendly, string name) : base(name)
        {
            Friendly = friendly;
        }

        public string Talk()
        {
            return "Bark";
        }

        public string GetName()
        {
            return Name;
        }

        override
        public string ToString()
        {
            return $"Dog: Name={Name} Friendly={Friendly}";
        }
    }
}
