namespace CodingProblems.Arrays
{
    public class JumpGame
    {
        // https://leetcode.com/problems/jump-game/

        // You are given an integer array nums. 
        // You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
        // Return true if you can reach the last index, or false otherwise.

        public static bool CanJump(int[] nums)
        {
            var max = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var current = nums[i];

                if (i > max) return false;

                max = max < current + i ? current + i : max;
            }

            return max >= nums.Length - 1;
        }

        public static void TestCanJump()
        {
            var arr = new int[] { 2, 3, 1, 1, 4 };

            Console.WriteLine(CanJump(arr));

            arr = new int[] { 3, 2, 1, 0, 4 };

            Console.WriteLine(CanJump(arr));
        }
    }
}