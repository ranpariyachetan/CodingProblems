using System;
using System.Collections.Generic;
namespace CodingProblems.Strings
{
    // https://leetcode.com/problems/ransom-note/
    // Given two strings ransomNote and magazine, return true if ransomNote can be constructed from magazine and false otherwise.
    // Each letter in magazine can only be used once in ransomNote.

    public class RansomNote
    {
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            var map = new Dictionary<char, int>();

            foreach(var c in ransomNote)
            {
                if(!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                map[c]++;
            }

            foreach(var c in magazine)
            {
                if(map.ContainsKey(c))
                {
                    map[c]--;
                    if(map[c] == 0)
                    {
                        map.Remove(c);
                    }
                }
            }

            return map.Count == 0;
        }

        public static void TestCanConstructRansomNote()
        {
            var r = "a";
            var m = "b";

            var result = CanConstruct(r, m);

            Console.WriteLine(result);
        }
    }
}