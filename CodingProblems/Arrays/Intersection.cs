namespace CodingProblems.Arrays
{
    public partial class Arrays
    {

        // Given two integer arrays nums1 and nums2, return an array of their intersection. 
        // Each element in the result must be unique and you may return the result in any order.

        // Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        // Output: [9,4]
        // Explanation: [4,9] is also accepted.
        public static int[] FindIntersection(int[] nums1, int[] nums2)
        {
            var hSet = new HashSet<int>();
            var list = new List<int>();
            foreach (var num in nums1)
            {
                hSet.Add(num);
            }

            foreach (var num in nums2)
            {
                if (hSet.Contains(num))
                {
                    hSet.Remove(num);
                    list.Add(num);
                }
            }

            return list.ToArray();
        }

        public static void TestIntersection()
        {
            var nums1 = new int[] { 4, 9, 5 };

            var nums2 = new int[] { 9, 4, 9, 8, 4 };

            var result = FindIntersection(nums1, nums2);

            Common.PrintArray(result);
        }
    }
}