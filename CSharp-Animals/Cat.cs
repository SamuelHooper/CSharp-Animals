using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public class Cat : Pet, ITalkable
    {
        public int MiceKilled { get; private set; }

        public Cat(int miceKilled, string name) : base(name)
        {
            MiceKilled = miceKilled;
        }

        public void AddMouse()
        {
            MiceKilled++;
        }

        public string Talk()
        {
            return "Meow";
        }

        public string GetName()
        {
            return Name;
        }

        override
        public string ToString()
        {
            return $"Cat: Name={Name} MiceKilled={MiceKilled}";
        }
    }
}
