using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace CSharp_Animals
{
    internal class Program
    {
        private static readonly FileOutput OutFile = new FileOutput("animals.txt");

        static void Main(string[] args)
        {
            List<ITalkable> zoo = new();

            // Lines to Replace Begin Here
            UserInput input = new(zoo);
            input.PopulateZoo();
            // End Lines to Replace

            foreach (ITalkable thing in zoo)
            {
                PrintOut(thing);
            }
            OutFile.FileClose();

            /*Could not find a way to let both the FileInput and FileOutput class have access to the same file simultaneously
            So this is a hack-y fix to open, use, and then close each one.*/
            FileInput inFile = new FileInput("animals.txt");
            inFile.FileRead();
            inFile.FileClose();

            FileInput inData = new FileInput("animals.txt");
            string line;
            while ((line = inData.FileReadLine()) != null) {
                Console.WriteLine(line);
            }
        }

        public static void PrintOut(ITalkable thing)
        {
            Console.WriteLine($"{thing.GetName()} says: {thing.Talk()}");
            OutFile.FileWrite($"{thing.GetName()} | {thing.Talk()}");
        }
    }
}