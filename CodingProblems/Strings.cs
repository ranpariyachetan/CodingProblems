using System;
using System.Collections.Generic;

namespace CodingProblems
{

    public class Strings
    {
        // Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".
        // The testcases will be generated such that the answer is unique.
        // A substring is a contiguous sequence of characters within the string.

        // Input: s = "ADOBECODEBANC", t = "ABC"
        // Output: "BANC"
        // Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
        
        // static int CharCount = 256;
        public static string FindMinimumWindowsSubstring(string str, string pattern)
        {
            int len1 = str.Length;
            int len2 = pattern.Length;

            if (len1 < len2)
            {
                return "";
            }

            int minLength = int.MaxValue;
            Dictionary<char, int> strMap = new Dictionary<char, int>();

            Dictionary<char, int> patternMap = new Dictionary<char, int>();

            for (int i = 0; i < len2; i++)
            {
                if(patternMap.ContainsKey(pattern[i]))
                {
                    patternMap[pattern[i]]++;
                }
                else
                {
                    patternMap.Add(pattern[i], 1);
                }
                
            }

            int start = 0;
            int startIndex = -1;
            int count = 0;
            for (int j = 0; j < len1; j++)
            {
                if(!patternMap.ContainsKey(str[j])) 
                {
                    continue;
                }

                if (strMap.ContainsKey(str[j]))
                {
                    strMap[str[j]]++;
                }
                else
                {
                    strMap.Add(str[j], 1);
                };

                if (strMap[str[j]] <= patternMap[str[j]])
                {
                    count++;
                }

                if (count == len2)
                {
                    while (!patternMap.ContainsKey(str[start]) || strMap[str[start]] > patternMap[str[start]])
                    {
                        if (patternMap.ContainsKey(str[start]) && strMap[str[start]] > patternMap[str[start]])
                        {
                            strMap[str[start]]--;
                        }
                        start++;
                    }

                    int windowLength = j - start + 1;

                    if (minLength > windowLength)
                    {
                        minLength = windowLength;
                        startIndex = start;
                    }
                }
            }

            if (startIndex == -1)
            {
                return "";
            }

            return str.Substring(startIndex, minLength);
        }

        public static void TestFindMinimumWindowsSubstring()
        {
            var str = "this is a test string";
            var pattern = "tist";

            var output = FindMinimumWindowsSubstring(str, pattern);

            Console.WriteLine(output);

            str = "ADOBECOBDEBNC";
            pattern = "ABC";

            output = FindMinimumWindowsSubstring(str, pattern);

            Console.WriteLine(output);
        }
    }
}