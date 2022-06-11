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

        public static void MergeSortedArraysInPlace(int[] nums1, int m, int[] nums2, int n)
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

            MergeSortedArraysInPlace(nums1, m, nums2, n);

            Common.PrintArray(nums1);
        }

        private static int[] MergeSortedArray(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int m1 = 0;
            int m2 = 0;

            if (m == 0)
                return nums2;
            if (n == 0)
                return nums1;

            int count = 0;
            var tmp = new int[m + n];

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

            return tmp;
        }

        // https://leetcode.com/problems/median-of-two-sorted-arrays/
        // Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
        // The overall run time complexity should be O(log (m+n)).
        private static double FindMedianSortedArraysV1(int[] nums1, int[] nums2)
        {
            var merged = MergeSortedArray(nums1, nums2);

            var l = merged.Length;

            if (l % 2 != 0)
            {
                return Convert.ToDouble(merged[(l - 1) / 2]);
            }
            else
            {
                return (Convert.ToDouble(merged[l / 2]) + merged[(l / 2) - 1]) / 2;
            }
        }

        
        public static void TestMedianSortedArray()
        {
            var nums1 = new int[] {4};

            var nums2 = new int[] {
                1,2,3,5,6
            };

            var result = FindMedianSortedArraysV1(nums1, nums2);

            Console.WriteLine(result);
        }
    }
}