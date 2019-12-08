using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta hunnik numbreid ja lõpetamiseks ENTER x 2: ");

            List<int> nums = ReadNums();

            OutputResults(nums);
        }

        private static List<int> ReadNums()
        {
             List<int> numbers = new List<int>();

            while (true)
            {
                string userValue = Console.ReadLine();

                if (string.IsNullOrEmpty(userValue))
                break;
                    
                for (int j = 0; j <= userValue.Length-1; j++)
                {
                    string number;
                    number = userValue[j].ToString();

                    numbers.Add(Int32.Parse(number));
                }
            }
            return numbers;
        }
        
    private static void OutputResults(List<int> nums)
    {
        int numSum= 0;

        foreach (int num in nums)
        {
            numSum = numSum + num;                
        }
            int minNum = nums.Min();
            int maxNum = nums.Max();

            Console.WriteLine($"The sum of these inputs is {numSum}. The maximum value is {maxNum}. The minimum value is {minNum}");
        }
    }
}