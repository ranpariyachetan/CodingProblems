using System.Collections.Generic;

namespace CodingProblems
{
    // Problem statement
    // Given a non-empty list of words, return the k most frequent elements.
    // Your answer should be sorted by frequency from highest to lowest. 
    // If two words have the same frequency, then the word with the lower alphabetical order comes first.
    // Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
    // Output: ["the", "is", "sunny", "day"]
    // Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
    // with the number of occurrence being 4, 3, 2 and 1 respectively.
    public class TopKFrequent
    {
        public static IList<string> GetTopKFrequent(string[] words, int k) {
        
        var map= new Dictionary<string, int>();
        
        foreach(var word in words)
        {
            if(map.ContainsKey(word))
            {
                map[word]++;
            }
            else
            {
                map.Add(word, 1);
            }
        }
        
        var counters = new Dictionary<int, SortedSet<string>>();
        var maxCount = 0;
        var sortedCount = new SortedSet<int>();
        foreach(var kvPair in map)
        {
            var val = kvPair.Value;
            
            if(val >maxCount)
            {
                maxCount = val;
            }

            sortedCount.Add(val);
            
            if(!counters.ContainsKey(val))
            {
                counters.Add(val, new SortedSet<string>());
            }
            
            counters[val].Add(kvPair.Key);
        }
        
        var result = new List<string>();
        foreach(var count in sortedCount.Reverse())
        {
            var list = counters[count];
            
            if(list.Count <= k)
            {
                result.AddRange(list);
            }
            else
            {
                var c=0;
                foreach(var i in list)
                {
                    result.Add(i);
                    c++;
                    if(c >= k)
                        break;
                }
            }
            
            k = k - list.Count;
            
            if(k <= 0)
            {
                break;
            }
        }
        
        return result;
    }
    public static void TestGetTopKFrequent()
    {
        var input = new string[] {"the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"};
        var k = 4;

        var result = GetTopKFrequent(input, k);


    }
    }
}