using System.Collections.Generic;
using System;
namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        private static int[] IntersectArrays(int[] nums1, int[] nums2)
        {
            var result = new List<int>();

            var map = new Dictionary<int, int>();
            for (var i = 0; i < nums1.Length; i++)
            {
                if(map.ContainsKey(nums1[i]))
                {
                    map[nums1[i]]++;
                }
                else
                {
                    map.Add(nums1[i], 1);
                }
            }

            for (var i = 0; i < nums2.Length; i++)
            {
                if (map.ContainsKey(nums2[i]))
                {
                    if(map[nums2[i]] > 0)
                    {
                        result.Add(nums2[i]);
                        map[nums2[i]]--;
                    }
                }
            }

            return result.ToArray();
        }

        public static void TestArrayIntersect()
        {
            var nums1 = new int[] { 1, 2, 2, 1 };
            var nums2 = new int[] { 2, 2 };

            var result = IntersectArrays(nums1, nums2);

            PrintArray(result);

            nums1 = new int[] { 4, 9, 5 };
            nums2 = new int[] { 9, 4, 9, 8, 4 };

            result = IntersectArrays(nums1, nums2);

            PrintArray(result);

            nums1 = new int[] { };
            nums2 = new int[] { 9, 4, 9, 8, 4 };

            result = IntersectArrays(nums1, nums2);

            PrintArray(result);

            nums1 = new int[] {1,2,3 };
            nums2 = new int[] { };

            result = IntersectArrays(nums1, nums2);

            PrintArray(result);

            nums1 = new int[] {1,2,1,2,3,4 };
            nums2 = new int[] { 1,2,4};

            result = IntersectArrays(nums1, nums2);

            PrintArray(result);
        }

        private static void PrintArray(int[] arr)
        {
            var r = string.Join(',', arr);
            Console.WriteLine($"[{r}]");
        }
    }
}