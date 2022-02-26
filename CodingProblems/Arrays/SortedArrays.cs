using System;
namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        // You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, 
        // and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

        // Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        // The final sorted array should not be returned by the function, but instead be stored inside the array nums1. 
        // To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

        public static void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            var tmp = new int[m + n];

            var count = 0;
            var m1 = 0;
            var m2 = 0;

            if (n == 0)
                return;

            if (m == 0)
            {
                while (count < n)
                {
                    tmp[count] = nums2[count];
                    count++;
                }
            }

            Common.PrintArray(nums1);
            Common.PrintArray(nums2);

            while (count < m + n)
            {
                while (m1 < m && nums1[m1] <= nums2[m2])
                {
                    tmp[count] = nums1[m1];
                    count++;
                    m1++;
                }

                if (m1 == m)
                {
                    while (m2 < n)
                    {
                        tmp[count] = nums2[m2];
                        count++;
                        m2++;
                    }
                }

                while (m2 < n && nums2[m2] <= nums1[m1])
                {
                    Console.WriteLine($"m2: {m2}, nums2[{m2}]: {nums2[m2]}");
                    tmp[count] = nums2[m2];
                    count++;
                    m2++;
                }

                if (m2 == n)
                {
                    while (m1 < m)
                    {
                        tmp[count] = nums1[m1];
                        count++;
                        m1++;
                    }
                }
            }

            for (var i = 0; i < tmp.Length; i++)
            {
                nums1[i] = tmp[i];
            }
        }

        public static void TestMergeSortedArray()
        {
            var nums1 = new int[] {
                4,0,0,0,0,0
                            };

            var nums2 = new int[] {
                1,2,3,5,6
            };

            var m = 1;
            var n = 5;

            MergeSortedArrays(nums1, m, nums2, n);

            Common.PrintArray(nums1);

        }

    }
}