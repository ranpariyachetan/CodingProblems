using System;
using System.Collections.Generic;
using System.Linq;
namespace CodingProblems
{
    public class MaxGCD
    {
        public static int FindMaxGCD(int[] arr,
                                 int n)
        {
            // Computing highest element
            int high = 0;
            for (int i = 0; i < n; i++)
                high = Math.Max(high, arr[i]);

            // Array to store the count of
            // divisors i.e. Potential GCDs
            int[] divisors = new int[high + 1];

            // Iterating over every element
            for (int i = 0; i < n; i++)
            {
                // Calculating all the divisors
                for (int j = 1; j <=
                     Math.Sqrt(arr[i]); j++)
                {
                    // Divisor found
                    if (arr[i] % j == 0)
                    {
                        // Incrementing count
                        // for divisor
                        divisors[j]++;

                        // Element / divisor is also
                        // a divisor Checking if both
                        // divisors are not same
                        if (j != arr[i] / j)
                            divisors[arr[i] / j]++;
                    }
                }
            }

            // Checking the highest potential GCD
            for (int i = high; i >= 1; i--)

                // If this divisor can divide at
                // least 2 numbers, it is a
                // GCD of at least 1 pair   
                if (divisors[i] > 1)
                    return i;
            return 1;
        }

        public static int CountLevelUpPlayers(int cutOffRank, int n, int[] scores)
        {
            int maxScore = 0;
            int[] numbers = new int[101];

            foreach (int score in scores)
            {
                numbers[score] += 1;
                if (score > maxScore)
                {
                    maxScore = score;
                }
            }

            int start = maxScore;

            int total = 0;

            while (total < cutOffRank)
            {
                total += numbers[start];
                start--;
            }

            return total;
        }

        public static int Packaging(int[] groups)
        {
            int n = groups.Length;
            int maxItems = 0;
            if (n == 0)
            {
                return 0;
            }
            else
            {
                foreach (int item in groups.OrderBy(i => i))
                {
                    if (item > maxItems)
                    {
                        maxItems = item;
                    }
                    else if (item == maxItems)
                    {
                        continue;
                    }
                    else
                    {
                        return maxItems;
                    }
                }

                return maxItems;
            }
        }

        public static int packaging(int[] arr)
        {
            arr = arr.OrderBy(i => i).ToArray();

            int numGroups = arr.Length;
            arr[0] = 1;

            for (int i = 1; i < numGroups; ++i)
            {
                if (arr[i] > arr[i - 1])
                {
                    arr[i] = arr[i - 1] + 1;
                }
            }

            return arr[numGroups - 1];
        }

        // public static int PackagingProblem(int[] arr)
        // {
        //     var n = arr.Length;
        //     var output = new int[n];

        //     arr = arr.OrderBy(i => i).ToArray();

        //     if(arr[0] != 1) {
        //         arr[0] = 1;
        //     }
        //     output = arr;

        //     for(var i = 1;i<n;i++)
        //     {
        //         if(arr[i]-output[i-1] > 1) {
        //             arr[i] = output[i-1] = 1;
        //         }
        //     }

        // }

        public static int packagingMine(int[] arr)
        {
            int[] freq = new int[190000];
            int max = 0;
            for (int ite = 0; ite < arr.Length; ite++)
            {
                freq[arr[ite]]++;
                max = Math.Max(max, arr[ite]);
            }
            int i = 1;
            int j = 0;
            while (i <= max)
            {
                if (freq[i] > 0 && j < i)
                {
                    arr[j++] = j;
                }
                freq[i]--;
                if (freq[i] < 1)
                {
                    i++;
                }
            }
            return arr[j - 1];
        }



        public static int MinContainerSize(int[] p, int days)
        {
            int end = p.Length + 1;
            int[] dp = new int[end];

            dp[0] = 0;

            for (int day = 1; day < days + 1; day++)
            {
                int[] dp_ = new int[end];

                for (int item = 1; item < end; item++)
                {
                    int max = int.MinValue;

                    for (int last = 1; last < item + 1; last++)
                    {
                        max = Math.Max(max, p[item - last]);
                        if (dp[item - last] != int.MaxValue)
                        {
                            dp_[item] = Math.Min(dp_[item], dp[item - last] + max);
                        }
                    }
                }
                dp = dp_;
            }

            return dp[dp.Length - 1];


        }
    }
}