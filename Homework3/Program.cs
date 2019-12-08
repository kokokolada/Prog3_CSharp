using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int guessMe = rand.Next(1, 50);

            Console.WriteLine("I have thought of a number between 1 and 100. Please try to guess it. If you cannot guess it, press ENTER twice");

            CompareInput(guessMe);
        }

        private static void CompareInput(int guessMe)
        {
            int count = 0;
            while (true)
            {
                string userValue = Console.ReadLine();                

                if (string.IsNullOrEmpty(userValue))
                {
                    Console.WriteLine($"You lose. You guessed {count} times");
                    break;
                }

                count++;

                int number = Int32.Parse(userValue);

                if (number == guessMe)
                {
                    Console.WriteLine($"Wow you guessed it! You guessed {count} times");
                    return;
                }
                else if (number > guessMe)
                {
                    Console.WriteLine("Think of a smaller number ;)");
                }
                else if (number < guessMe)
                {
                    Console.WriteLine("Think of a larger number ;)");
                }

            }
        }
    }
}
