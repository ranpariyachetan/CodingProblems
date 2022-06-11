using System;
using System.Collections.Generic;

namespace CodingProblems.Numbers
{
    public class Fibonacci
    {
        public static int GetFibonacci(int n)
        {
            var cache = new Dictionary<int, int>();

            return GetFib(n, cache);
        }

        private static int GetFib(int n, Dictionary<int, int> cache)
        {
            if (n == 0 || n == 1)
                return n;

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            cache[n] = GetFib(n - 1, cache) + GetFib(n - 2, cache);

            Console.WriteLine(cache[n]);

            return cache[n];
        }

        public static void TestFibonacci()
        {
            var n = 8;

            Console.WriteLine(GetFibonacci(n));
        }

        // https://leetcode.com/problems/length-of-longest-fibonacci-subsequence/
        // A sequence x1, x2, ..., xn is Fibonacci-like if:
        // n >= 3
        // xi + xi+1 == xi+2 for all i + 2 <= n
        // Given a strictly increasing array arr of positive integers forming a sequence, return the length of the longest Fibonacci-like subsequence of arr. 
        // If one does not exist, return 0.

        // A subsequence is derived from another sequence arr by deleting any number of elements (including none) from arr, without changing the order of the remaining elements. 
        // For example, [3, 5, 8] is a subsequence of [3, 4, 5, 6, 7, 8].
        
        public static int LenLongestFibSequence(int[] arr)
        {
            var set = new HashSet<int>(arr);
            var maxLen = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = i +1; j < arr.Length; j++)
                {
                    var len = 2;
                    var x = arr[j];
                    var y = arr[i] + arr[j];

                    while (set.Contains(y))
                    {
                        len += 1;
                        var tmp = y;
                        y += x;
                        x = tmp;
                    }
                    maxLen = maxLen < len ? len : maxLen;
                }
            }

            return maxLen > 2 ? maxLen : 0;
        }

        public static void TestLongestFibonacciSequence()
        {
            var arr = new int[] { 1,2,3,4,5,6,7,8};

            Console.WriteLine(LenLongestFibSequence(arr));
        }
    }
}