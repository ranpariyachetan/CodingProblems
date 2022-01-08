using System.Collections.Generic;

namespace CodingProblems
{
    public class SingleNumber
    {
        // Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
        // You must implement a solution with a linear runtime complexity and use only constant extra space.
        // Constraints
        // 1. 1 <= nums.length <= 3 * 104
        // 2. -3 * 104 <= nums[i] <= 3 * 104
        // 4. Each element in the array appears twice except for one element which appears only once.
        private static int GetSingleNumber1(int[] nums)
        {
            var sum = 0;
            HashSet<int> set = new HashSet<int>();

            foreach(var num in nums)
            {
                if(!set.Contains(num))
                {
                    sum += num;
                    set.Add(num);
                }
                else
                {
                    set.Remove(num);
                    sum -= num;
                }
            }

            return sum;
        }

        // Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.
        // You must implement a solution with a linear runtime complexity and use only constant extra space.
        // Constraints : 
        // 1. 1 <= nums.length <= 3 * 104
        // 2. -231 <= nums[i] <= 231 - 1
        // 3. Each element in nums appears exactly three times except for one element which appears once.
        // Example - Input: nums = [2,2,3,2], Output: 3

        private static int GetSingleNumber2(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            long sum = 0;
            long setSum = 0;
            foreach (var num in nums)
            {
                if (!set.Contains(num))
                {
                    set.Add(num);
                    sum += num;
                }
                setSum += num;
            }

            var rem = 3 * sum - setSum;

            return (int)(rem / 2);
        }

        // Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. 
        // Find the two elements that appear only once. You can return the answer in any order.
        // You must write an algorithm that runs in linear runtime complexity and uses only constant extra space.
        // Constraints :
        // 1. 2 <= nums.length <= 3 * 104
        // 2. -231 <= nums[i] <= 231 - 1
        // 3. Each integer in nums will appear twice, only two integers will appear once.
        // Example:
        // Input: nums = [1,2,1,3,2,5]
        // Output: [3,5]
        // Explanation:  [5, 3] is also a valid answer.
        private static int[] GetSingleNumber3(int[] nums)
        {
            return new int[] {};
        }
    }
}