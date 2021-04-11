using System.Collections.Generic;

using System.Linq;
namespace CodingProblems
{
    public class TransactionLogs
    {
        // Problem statement 
        public static List<string> ListUserIds(string[] logs, int max)
        {
            var counters = new Dictionary<string, int>();

            foreach (var log in logs)
            {
                var items = log.Split(' ');

                if (counters.ContainsKey(items[0]))
                {
                    counters[items[0]] += 1;
                }
                else
                {
                    counters.Add(items[0], 1);
                }

                if (items[0] != items[1])
                {
                    if (counters.ContainsKey(items[1]))
                    {
                        counters[items[1]] += 1;
                    }
                    else
                    {
                        counters.Add(items[1], 1);
                    }
                }
            }

            var selectedIds = new List<string>();
            foreach (var kvPair in counters)
            {
                if (kvPair.Value >= max)
                {
                    selectedIds.Add(kvPair.Key);
                }
            }

            return selectedIds;
        }
    }
}