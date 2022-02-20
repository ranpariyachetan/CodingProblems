using System;
using System.Collections.Generic;

namespace CodingProblems.Arrays
{
    public partial class Arrays
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length <= 1)
            {
                return s.Length;
            }
            var idxMap = new Dictionary<char, int>();

            var maxLen = 0;
            var start = 0;
            var end = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (!idxMap.ContainsKey(s[i]))
                {
                    idxMap.Add(s[i], i);
                    end = i;
                }
                else
                {
                    if ((end - start + 1) > maxLen)
                    {
                        maxLen = end - start + 1;
                    }

                    if (idxMap[s[i]] >= start)
                    {
                        start = idxMap[s[i]] + 1;
                    }
                    end = i;
                    idxMap[s[i]] = i;
                }
            }

            if ((end - start + 1) > maxLen)
            {
                maxLen = end - start + 1;
            }

            return maxLen;
        }

        public static void TestLengthOfLongestSubstring()
        {
            var s = "aab";

            Console.WriteLine($"Expected: 2, Actual: {LengthOfLongestSubstring(s)}");

            s = " ";
            Console.WriteLine($"Expected: 1, Actual: {LengthOfLongestSubstring(s)}");

            s = "";
            Console.WriteLine($"Expected: 0, Actual: {LengthOfLongestSubstring(s)}");

            s = "au";
            Console.WriteLine($"Expected: 2, Actual: {LengthOfLongestSubstring(s)}");

            s = "aabb";
            Console.WriteLine($"Expected: 2, Actual: {LengthOfLongestSubstring(s)}");

            s = "dvdf";
            Console.WriteLine($"Expected: 3, Actual: {LengthOfLongestSubstring(s)}");

            s = "dvcfcpqrst";
            Console.WriteLine($"Expected: 7, Actual: {LengthOfLongestSubstring(s)}");

            s = "addba";
            Console.WriteLine($"Expected: 3, Actual: {LengthOfLongestSubstring(s)}");

            s = "rose";
            Console.WriteLine($"Expected: 4, Actual: {LengthOfLongestSubstring(s)}");

            s = "roseesorb";
            Console.WriteLine($"Expected: 5, Actual: {LengthOfLongestSubstring(s)}");

            s = "abcabcbb";
            Console.WriteLine($"Expected: 3, Actual: {LengthOfLongestSubstring(s)}");

            s = "bbbbb";
            Console.WriteLine($"Expected: 1, Actual: {LengthOfLongestSubstring(s)}");

            s = "pwwkew";
            Console.WriteLine($"Expected: 3, Actual: {LengthOfLongestSubstring(s)}");
        }
    }
}