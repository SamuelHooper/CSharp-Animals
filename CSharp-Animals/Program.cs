using System.Diagnostics;

namespace CSharp_Animals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITalkable> zoo = new();

            // Lines to Replace Begin Here
            UserInput input = new(zoo);
            input.PopulateZoo();
            // End Lines to Replace

            foreach(ITalkable thing in zoo)
            {
                PrintOut(thing);
            }
        }

        public static void PrintOut(ITalkable thing)
        {
            Console.WriteLine($"{thing.GetName()} says: {thing.Talk()}");
        }
    }
}