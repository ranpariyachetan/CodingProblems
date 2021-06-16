using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingProblems
{

    public class Arrays
    {
        public static int FindPairs(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            var result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    map[arr[i]]++;
                }
                else
                {
                    map.Add(arr[i], 1);
                }
            }

            foreach (var kvPair in map)
            {
                var count = kvPair.Value;
                result += (count * (count - 1)) / 2;
            }

            return result;
        }

        public static int GetMO3(int a, int b, int c)
        {
            return a + b + c - Math.Max(a, Math.Max(b, c)) - Math.Min(a, Math.Min(b, c));
        }

        public static int GetMO4(int a, int b, int c, int d)
        {
            int max = Math.Max(a, Math.Max(b, Math.Max(c, d)));
            int min = Math.Min(a, Math.Min(b, Math.Min(c, d)));

            return (a + b + c + d - max - min) / 2;
        }

        public static List<List<string>> FindCompounds(List<string> inputList)
        {
            var indexMap = new Dictionary<string, int>();
            var wordMap = new Dictionary<string, List<List<string>>>();

            List<List<string>> result = new List<List<string>>();

            for (var i = 0; i < inputList.Count; i++)
            {
                indexMap.Add(inputList[i], i);
            }

            foreach (var word in inputList)
            {
                FindWords(word, 0, 1, indexMap, wordMap);
            }

            var output = new List<List<string>>();

            foreach(var item in wordMap)
            {
                output.AddRange(item.Value);
            }

            return output;
        }

        private static void FindWords(string word, int start, int end, Dictionary<string, int> indexMap, Dictionary<string, List<List<string>>> wordMap)
        {
            if (start >= word.Length || end >= word.Length)
                return;

            var part1 = word.Substring(start, end);
            var part2 = word.Substring(end, word.Length - end);

            if (indexMap.ContainsKey(part1) && indexMap.ContainsKey(part2))
            {
                if (wordMap.ContainsKey(word))
                {
                    wordMap[word].Add(new List<string>{part1, part2});
                }
                else
                {
                    wordMap.Add(word, new List<List<string>>{ new List<string> { part1, part2 }});
                    var res = FindWordsForSubString(part1, 0, 1, indexMap);
                    if (res != null)
                    {
                        var lst = new List<string>(res);
                        lst.Add(part2);
                        wordMap[word].Add(lst);
                    }
                    res = FindWordsForSubString(part2, 0, 1, indexMap);
                    if (res != null)
                    {
                        var lst = new List<string>{part1};
                        lst.AddRange(res);
                        wordMap[word].Add(lst);
                    }
                }
            }

            FindWords(word, start, end + 1, indexMap, wordMap);
        }

        private static List<string> FindWordsForSubString(string word, int start, int end, Dictionary<string, int> indexMap)
        {
            if (start >= word.Length || end >= word.Length)
                return null;

            var part1 = word.Substring(start, end);
            var part2 = word.Substring(end, word.Length - end);

            if (indexMap.ContainsKey(part1) && indexMap.ContainsKey(part2))
            {
                return new List<string> { part1, part2 };
            }

            return FindWordsForSubString(word, start, end + 1, indexMap);
        }

        public static void TestFindCompounds()
        {
            // var inputList = new List<string>
            // {
            //     "startrack",
            //     "star",
            //     "track",
            //     "start",
            //     "rack"
            // };

            var inputList = new List<string>
            {
                "catsanddog",
                "cat",
                "cats",
                "and",
                "sand",
                "dog"
                // "sunlight",
                // "sun",
                // "lig",
                // "ht",
                // "startrack",
                // "star",
                // "track",
                // "start",
                // "rack",
                // "superhighway",
                // "super",
                // "highway",
                // "high",
                // "way",
                // "brightstar"
            };

            var output = FindCompounds(inputList);

            Console.WriteLine();
            foreach (var list in output)
            {
                PrintList(list);
            }
        }

        private static void PrintList(List<string> input)
        {
            Console.Write("[ ");
            foreach (var item in input)
            {
                Console.Write("{0}, ", item);
            }
            Console.Write("]");
        }
    }
}