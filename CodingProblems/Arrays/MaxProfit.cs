using System;
namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        // You are given an array prices where prices[i] is the price of a given stock on the ith day.

        // You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

        // Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

 
        private static int MaxProfit(int[] prices)
        {
            int minLow = int.MaxValue;
            int sum = 0;

            for(var i = 0;i<prices.Length;i++)
            {
                if (minLow > prices[i])
                {
                    minLow = prices[i];
                }

                if((prices[i] - minLow) > sum)
                {
                    sum = prices[i] - minLow;
                }
            }

            return sum < 0 ? 0 : sum;
        }

        public static void TestMaxProfit()
        {
            var arr = new [] {7,6,5,4,3};
            var result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new [] {80, 2, 6, 3, 100};
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit With Diff: {0}", result);

            arr = new [] {5,5,5,5,5};
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);


            arr = new [] {1,2,3};
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new [] {2,3};
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new [] {3,2};
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 2, 1, 2, 0, 1 };
            result = MaxProfit(arr);

            Console.WriteLine("Max Profit: {0}", result);
        }
    }
}