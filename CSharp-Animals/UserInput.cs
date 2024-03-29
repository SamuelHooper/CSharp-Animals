using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Animals
{
    public class UserInput
    {
        private List<ITalkable> _zoo;

        public UserInput(List<ITalkable> zoo)
        {
            _zoo = zoo;
        }

        public void PopulateZoo()
        {
            //Declarations
            int userOption;

            do
            {
                Console.WriteLine("\n=== Zoo Manager ===");
                Console.WriteLine("1. Cat");
                Console.WriteLine("2. Dog");
                Console.WriteLine("3. Teacher");
                Console.WriteLine("Press 4 to Exit");

                bool validOption;
                do //Loop for selecting a valid option
                {
                    userOption = GetIntWithPrompt("\nSelect an animal to add to the zoo: ","Please enter a number: "); //Gets and validates user input
                    if (userOption == 1)
                    {
                        validOption = true;
                        AddCat();
                    }
                    else if (userOption == 2)
                    {
                        validOption = true;
                        AddDog();
                    }
                    else if (userOption == 3)
                    {
                        validOption = true;
                        AddTeacher();
                    }
                    else if (userOption == 4)
                    {
                        validOption = true;
                    } else
                    {
                        validOption = false;
                        Console.Write("Please enter a valid option"); //Prompts and loops if user input isn't a valid option
                    }
                } while (!validOption);
            } while (userOption != 4);
        }

        //Method to Create a new Cat object
        public void AddCat()
        {
            string name = GetStringWithPrompt("Enter the Cat's name: ", "Please enter a name: ");
            int miceKilled = GetIntWithPrompt($"How many mice has {name} killed? ","Please enter a valid number: ");
            _zoo.Add(new Cat(miceKilled, name));
        }

        //Method to Create a new Dog object
        public void AddDog()
        {
            string name = GetStringWithPrompt("Enter the Dog's name: ", "Please enter a name: ");
            bool isFriendly = GetBoolWithPrompt($"Is {name} friendly? (Y/n) ", "Please enter a valid answer: (Y/n) ");
            _zoo.Add(new Dog(isFriendly, name));
        }

        //Method to Create a new Teacher object
        public void AddTeacher()
        {
            string name = GetStringWithPrompt("Enter the Teacher's name: ", "Please enter a name: ");
            int age = GetIntWithPrompt($"How old is {name}? ", "Please enter a valid age: ");
            _zoo.Add(new Teacher(age, name));
        }

        //Method to Get a Int from user input
        //Asks for a string that will be the prompt, and a string that will be the error message
        private int GetIntWithPrompt(string prompt, string promptError)
        {
            Console.Write(prompt);

            //Declarations
            int userAmount;
            bool validInput;
            do
            {
                string userInput = Console.ReadLine();
                validInput = Int32.TryParse(userInput, out userAmount);
                if (!validInput || userAmount < 0) //Data Validation Loop
                {
                    validInput = false;
                    Console.Write(promptError);
                }
            } while (!validInput);

            return userAmount;
        }

        //Method to Get a String from user input
        //Asks for a string that will be the prompt, and a string that will be the error message
        private string GetStringWithPrompt(string prompt, string promptError)
        {
            Console.Write(prompt);

            do //Loop to validate String
            {
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput)) //If string is true ends loop and returns userInput
                {
                    return userInput;
                }
                Console.Write(promptError);
            } while (true);
        }

        //Method to Get a Bool from a yes or no
        //Asks for a string that will be the prompt, and a string that will be the error message
        private bool GetBoolWithPrompt(string prompt, string promptError)
        {
            Console.Write(prompt);

            //Declarations
            bool isValid = false;
            char returnChar = ' ';

            do //Do-While loop to check for vaild char response
            {
                string userInput = Console.ReadLine();

                if (!String.IsNullOrEmpty(userInput))
                {
                    returnChar = userInput.ToLower()[0];
                    isValid = returnChar == 'y' || returnChar == 'n';
                }

                if (!isValid) 
                {
                    Console.Write(promptError);
                }
            } while (!isValid);

            return returnChar == 'y';
        }
    }
}
