using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public static class ChangeDispenser
    {
        public static int DispenseMinimumCoinsBottomUp(int[] coins, int amount)
        {
            var map = new int[amount + 1];

            Array.Sort(coins);
            Array.Fill(map, amount + 1);

            map[0] = 0;
            for(var i = 0;i<=amount;i++)
            {
                for(var j = 0;j<coins.Length;j++)
                {
                    if(i >= coins[j])
                    {
                        map[i] = Math.Min(map[i], 1 + map[i - coins[j]]);
                    } 
                    else
                    {
                        break;
                    }
                }
            }

            return map[amount] > amount ? -1 : map[amount];
        }

        public static int DispenseMinimumCoinsTopDown(int[] coins, int amount)
        {
           var map = new Dictionary<int, int>();

           Array.Sort(coins);
           Array.Reverse(coins);

           var count = GetCoins(coins, amount, map);

           return count < 0 || count == int.MaxValue ? -1 : count;
        }

        private static int GetCoins(int[] coins, int amount, Dictionary<int, int> map)
        {
            if(amount < 0)
            {
                return int.MinValue;
            }

            if(amount == 0)
            {
                return 0;
            }

            if(map.ContainsKey(amount))
            {
                return map[amount];
            }

            int min = int.MaxValue;
            for(var i = 0;i<coins.Length;i++)
            {
                int count = GetCoins(coins, amount - coins[i], map) + 1;

                if(count >= 0)
                {
                    min = count < min ? count : min;
                }
            }

            map.Add(amount, min);

            return min;
        }

        private static int GetNumberOfPossibleCombinations(int[] coins, int amount)
        {
            var map = new Dictionary<int, int>();

            var result = new int[amount + 1];

            Array.Fill(result, 0);

            result[0] = 1;

            for(var i = 0;i<coins.Length;i++)
            {
                for(var j = 0;j<=amount;j++)
                {
                    if(coins[i] <= j)
                    {
                        result[j]= result[j - coins[i]] + result[j];
                    }
                }
            }

            return result[amount];
        }

        public static void TestCoinDispenser()
        {
            int amount = 10;
            int[] coins = new int[] { 1, 5 };

            // var answer = DispenseMinimumCoinsBottomUp(coins, amount);

            // Console.WriteLine(answer);

            var answer = DispenseMinimumCoinsBottomUp(coins, amount);

            Console.WriteLine(answer);
        }
    }
}