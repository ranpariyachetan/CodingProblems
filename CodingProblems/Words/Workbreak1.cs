using System;

namespace CodingProblems.Words
{
    public partial class WordBreak
    {
        // Given a string s and a dictionary of strings wordDict, 
        // return true if s can be segmented into a space-separated sequence of one or more dictionary words.

        public static bool CanBreakWord(string s, string[] wordDict)
        {
            bool result = false;
            for (var i = 1; i <= s.Length; i++)
            {
                var part1 = s.Substring(0, i);
                var part2 = s.Substring(i);

                if (wordDict.Contains(part1))
                {
                    if (wordDict.Contains(part2))
                    {
                        return true;
                    }
                    else
                    {
                        result = CanBreakWord(part2, wordDict);
                    }
                }
            }

            return result;
        }

        public static void TestCanWordBreak()
        {
            var s = "applepenapple";

            var wordDict = new string[] { "apple", "pen" };

            var r = CanBreakWord(s, wordDict);

            Console.WriteLine(r);

            s = "goalspecial";
            wordDict = new string[] { "go", "goal", "goals", "special" };
            r = CanBreakWord(s, wordDict);

            Console.WriteLine(r);

            s = "abcd";
            wordDict = new string[] { "a", "abc", "b", "cd" };
            r = CanBreakWord(s, wordDict);

            Console.WriteLine(r);
        }

        // https://leetcode.com/problems/concatenated-words/
        // Given an array of strings words (without duplicates), return all the concatenated words in the given list of words.
        // A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.
        // Input: words = ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
        // Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
        // Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
        //              "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
        //              "ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
        private static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var set = new HashSet<string>(words);
            var result = new List<string>();
            var map = new Dictionary<string, bool>();
            foreach (var word in words)
            {
                set.Remove(word);
                var canBreak = CanWordBreak(word, set, map);// CanWordBreak(word, set, result);
                if (canBreak)
                    result.Add(word);

                set.Add(word);
            }

            return result;
        }

        private static bool CanWordBreak(string s, HashSet<string> words, Dictionary<string, bool> map)
        {
            if (map.ContainsKey(s))
                return map[s];

            for (var idx = 1; idx <= s.Length; idx++)
            {
                var subStr = s.Substring(0, idx);
                if (words.Contains(subStr))
                {
                    var restStr = s.Substring(idx);
                    if (words.Contains(restStr) || CanWordBreak(restStr, words, map))
                    {
                        map[s] = true;
                        return true;
                    }
                }
            }

            map[s] = false;
            return false;

            // if (s.Length == 0)
            //     return true;

            // var res = new List<string>();
            // for (var idx = 0; idx < words.Length; idx++)// (var word in words)
            // {
            //     var word = words[idx];
            //     // if (idx != indexToSkip)
            //     // {
            //         if (s.IndexOf(word) == 0)
            //         {
            //             var x = CanWordBreakII(s.Substring(word.Length), words, map, indexToSkip);
            //             if (x)
            //             {
            //                 map[s] = true;
            //                 return true;
            //             }
            //         }
            //     // }
            // }

            // map[s] = false;
            // return map[s];
        }

        public static void TestFindAllConcatenatedWords()
        {
            var arr = new string[] { "leet", "code", "leetcode" };

            var r = FindAllConcatenatedWordsInADict(arr);

            Common.PrintCollection(r);

            arr = new string[] { "cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"};
            r = FindAllConcatenatedWordsInADict(arr);

            Common.PrintCollection(r);
        }
    }
}