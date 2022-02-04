using System;
namespace CodingProblems
{
    public class Numbers
    {
        // Problem statement
        // Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.

        // Example 1:
        // Input: 13
        // Output 6

        // Example 2:
        // Input: 0
        // Output = 0;
        public static int CountDigitOne(int number)
        {
            int counter = 0;

            for(int i = 1;i<=number;i *= 10)
            {
                int divider = i * 10;

                counter += (number / divider) * i + Math.Min(Math.Max(number % divider - i + 1, 0), i);
            }

            return counter;
        }

        public static void TestCountDigitOne()
        {
            var input = 13;
            Console.WriteLine("{0}: {1}", input, CountDigitOne(input));
            input = 20;
            Console.WriteLine("{0}: {1}", input, CountDigitOne(input));
            input = 111;
            Console.WriteLine("{0}: {1}", input, CountDigitOne(input));
        }
    }
}