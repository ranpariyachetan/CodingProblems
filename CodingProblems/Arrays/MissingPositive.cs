using System;
using System.Collections.Generic;
namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        // https://leetcode.com/problems/first-missing-positive/
        // Given an unsorted integer array nums, return the smallest missing positive integer.
        // You must implement an algorithm that runs in O(n) time and uses constant extra space.

        private static int FindFirstMissingPositiveV1(int[] arr)
        {
            Array.Sort(arr);
            var min = 1;

            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0 && min == arr[i])
                {
                    min = arr[i] + 1;
                }
            }

            return min;
        }

        private static int FindFirstMissingPositiveV2(int[] arr)
        {
            var set = new HashSet<int>();
            var min = 1;

            for (var i = 0; i < arr.Length; i++)
            {
                set.Add(arr[i]);
                while (set.Contains(min))
                {
                    min++;
                }
            }

            return min;
        }

        public static void TestFindFirstMissingPositive()
        {
            var nums = new int[] { 1, 2, 0 };

            var result = FindFirstMissingPositiveV1(nums);

            Console.WriteLine(result);

            nums = new int[] { 3, 4, -1, 1 };

            result = FindFirstMissingPositiveV1(nums);

            Console.WriteLine(result);

            nums = new int[] { 7, 8, 9, 11, 12 };

            result = FindFirstMissingPositiveV1(nums);

            Console.WriteLine(result);

            nums = new int[] { 1, 2, 3, 4, 5, 7 };

            result = FindFirstMissingPositiveV1(nums);

            Console.WriteLine(result);

            nums = new int[] { 2, 1 };

            result = FindFirstMissingPositiveV1(nums);

            Console.WriteLine(result);
        }
    }
}