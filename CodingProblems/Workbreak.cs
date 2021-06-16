using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingProblems
{
    public class Wordbreak
    {
        private static List<string> answer = new List<string>();
        public static List<string> WordBreak(string s, List<string> wordDict)
        {
            var set = wordDict.ToHashSet();

            var indexMap = new Dictionary<string, int>();

            for (int i = 0; i < wordDict.Count; i++)
            {
                indexMap.Add(wordDict[i], i);
            }

            var result = new List<string>();

            // WordBreakUtil(s, wordDict, new List<string>(), result);

            GetWords(s, wordDict, result);

            return answer;
            // return GetWords(s, "", 0, 1, wordDict, indexMap);
            // return new List<string>{ GetWord(s, "", 0, 1, wordDict, indexMap)};
        }

        private static void GetWords(string s, List<string> wordDict, List<string> result)
        {
            if (s.Length == 0)
            {
                answer.Add(string.Join(' ', result));
            }

            for (int i = 1; i <= s.Length; i++)
            {
                var part1 = s.Substring(0, i);

                if (wordDict.Contains(part1))
                {
                    result.Add(part1);
                    GetWords(s.Substring(i), wordDict, result);

                    result.Remove(result[result.Count - 1]);
                }
            }

            // var str = s.Substring(start, end);

            // if (indexMap.ContainsKey(str))
            // {
            //     result.Add(str);
            //     var part2 = s.Substring(end, s.Length - end);

            //     result.AddRange(GetWords(part2, str, 0, 1, wordDict, indexMap));

            //     if (indexMap.ContainsKey(part2))
            //     {
            //         result.Add(part2);
            //     }

            //     result = new List<string> { string.Join(' ', result) };
            // }

            // end++;
            // var temp = GetWords(s, "", start, end, wordDict, indexMap);
            // result.AddRange(temp);

            // return result;
        }

        private static void WordBreakUtil(String s, List<String> dict, List<String> temp, List<string> result)
        {
            if (s.Length == 0)
            { // base condition to add temp in result
                StringBuilder sb = new StringBuilder();

                foreach (var t in temp)
                {
                    sb.Append(t).Append(" ");
                }
                result.Add(sb.ToString().Trim()); // trim because we alread appen last space character
                return;
            }

            foreach (var word in dict)
            {
                if (s.StartsWith(word))
                {
                    temp.Add(word); //adding in temp result set
                    WordBreakUtil(s.Substring(word.Length), dict, temp, result); // recursively call the same function with remaining input string 
                    temp.Remove(temp[temp.Count - 1]); // removing last word for backtracking
                }
            }
        }

        public static void TestWorkdBreak()
        {
            // var dict = new List<string>
            // {
            //     "cat",
            //     "cats",
            //     "and",
            //     "sand",
            //     "dog",
            //     // "andd",
            //     // "og"
            // };

            // var s = "catsanddog";

            var s = "pineapplepenapple";
            var dict = new List<string> { "apple", "pen", "applepen", "pine", "pineapple" };
            var result = WordBreak(s, dict);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}