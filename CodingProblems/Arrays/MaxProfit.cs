using System;
namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        // https://www.geeksforgeeks.org/maximum-difference-between-two-elements/?ref=lbp
        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

        // You are given an array prices where prices[i] is the price of a given stock on the ith day.

        // You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

        // Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.


        private static int MaxProfitV1(int[] prices)
        {
            int minLow = int.MaxValue;
            int sum = 0;

            for (var i = 0; i < prices.Length; i++)
            {
                if (minLow > prices[i])
                {
                    minLow = prices[i];
                }

                if ((prices[i] - minLow) > sum)
                {
                    sum = prices[i] - minLow;
                }
            }

            return sum < 0 ? 0 : sum;
        }

        public static void TestMaxProfit()
        {
            var arr = new[] { 7, 6, 5, 4, 3 };
            var result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 80, 2, 6, 3, 100 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 5, 5, 5, 5, 5 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);


            arr = new[] { 1, 2, 3 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 2, 3 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 3, 2 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

            arr = new[] { 2, 1, 2, 0, 1 };
            result = MaxProfitV1(arr);

            Console.WriteLine("Max Profit: {0}", result);

        }

        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        // You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
        // On each day, you may decide to buy and/or sell the stock. 
        //You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.
        // Find and return the maximum profit you can achieve.
        private static int MaxProfitV2(int[] prices)
        {
            var maxProfit = 0;

            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit < 0 ? 0 : maxProfit;
        }

        public static void TestMaxProfitV2()
        {
            var prices = new int[] { 1, 2, 3, 4, 5 };

            var res = MaxProfitV2(prices);
            Console.WriteLine(res);

            prices = new int[] { 7,1,5,3,6,4};

            res = MaxProfitV2(prices);
            Console.WriteLine(res);
        }
    }
}