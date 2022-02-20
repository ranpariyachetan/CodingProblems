using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingProblems.Arrays
{

    public partial class Arrays
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

        private static int[] RemoveDuplicates(int[] arr)
        {
            var result = new int[arr.Length];

            int i = 1;
            int countter = 1;

            result[0] = arr[0];

            while(i < arr.Length)
            {
                if(arr[i - 1] != arr[i])
                {
                    result[countter] = arr[i];
                    countter++;
                }
                i++;
            }
            return result;
        }

        // Given an array of integers nums and an integer k, return the total number of continuous subarrays whose sum equals to k.
        private static int GetSubArraySum(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);
            int sum = 0;
            var count = 0;
            for(int i = 0;i<nums.Length;i++)
            {
                sum += nums[i];

                if(map.ContainsKey(sum - k)) {
                    count += map[sum - k];
                }

                if (map.ContainsKey(sum))
                {
                    map[sum] ++;
                }
                else
                {
                    map.Add(sum , 1);
                }
            }

            return count;
        }

        // https://leetcode.com/problems/two-sum/
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.

        public static int[] TwoSum(int[] arr, int target)
        {
            var hSet = new Dictionary<int, int>();

            for(var i = 0;i<arr.Length;i++)
            {
                if(hSet.ContainsKey(arr[i]))
                {
                    return new int[] {hSet[arr[i]], i};
                }
                else
                {
                    hSet[target - arr[i]] = i;
                }
            }

            return new int[0];
        }

        public static void TestTwoSum()
        {
            var input = new int[] {1, 2, 3};
            var target = 3;
            var result = TwoSum(input, target);
            //Console.WriteLine($"Expected: [0, 1], Actual: [{result[0]}, {result[1]}]");

            input = new int[] {4,23,2,7};
            target = 9;
            result = TwoSum(input, target);
            //Console.WriteLine($"Expected: [0, 1], Actual: [{result[0]}, {result[1]}]");

            input = new int[] {1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1};
            target = 11;
            result = TwoSum(input, target);
            Console.WriteLine($"Expected: [0, 1], Actual: [{result[0]}, {result[1]}]");
        }

        public static void TestSubArraySum()
        {
            var input = new int[] { 1, 1, 1 };

            var result = GetSubArraySum(input, 2);

            Console.WriteLine(result);

            result = GetSubArraySum(new int[] { 5, 1, 2, 3 }, 3);

            Console.WriteLine(result);

            result = GetSubArraySum(new int[] { 2, 2, 2, 2, 2, 6 }, 6);

            Console.WriteLine(result);

            result = GetSubArraySum(new int[] { -1, -1, 1 }, 0);

            Console.WriteLine(result);

            result = GetSubArraySum(new int[] { 1, 1, 0, -1, 2, 1 }, 2);

            Console.WriteLine(result);

            result = GetSubArraySum(new int[] { 5, -5, 4 }, 0);

            Console.WriteLine(result);
        }

        public static void TestRemoveDuplicates()
        {
            int[] a = new int[] {1, 2, 2, 3, 4, 4, 4, 5, 5};

            var r = RemoveDuplicates(a);

            foreach(var x in r)
            {
                Console.WriteLine(x);
            }
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

            Console.WriteLine("completed");
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