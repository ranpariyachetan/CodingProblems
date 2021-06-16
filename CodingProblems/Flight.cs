using System;
using System.Collections.Generic;
using System.Linq;
namespace CodingProblems
{
    public class Flight
    {
        public static List<int> GetMovies(int flightDuration, List<int> movieDurations)
        {
            var targetDuration = flightDuration - 30;
            var sum = 0;
            var maxDuration = 0;
            var result = new List<int>();
            var max1 = int.MinValue;
            var max2 = int.MinValue;

            for (int i = 0; i < movieDurations.Count; i++)
            {
                for (int j = i + 1; j < movieDurations.Count; j++)
                {
                    // System.Console.WriteLine($"Comparing [{i}]: {movieDurations[i]} and [{j}]: {movieDurations[j]}");
                    sum = movieDurations[i] + movieDurations[j];

                    if (sum <= targetDuration && sum >= maxDuration)
                    {
                        if (max1 < movieDurations[i] || max2 < movieDurations[j])
                        {
                            max1 = movieDurations[i];
                            max2 = movieDurations[j];
                            result = new List<int> { i, j };
                        }
                        maxDuration = sum;
                    }
                }
            }

            return result;
        }

        public static List<int> GetMoviesWithHashTable(int flightDuration, List<int> movieDurations)
        {
            var map = new HashSet<int>();
            var targetDuration = flightDuration - 30;

            var orderedList = movieDurations.OrderBy(item => item).ToList();

            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int start = 0;
            int end = orderedList.Count - 1;
            int maxDuration = int.MinValue;

            while (start <= end)
            {
                var sum = orderedList[start] + orderedList[end];

                if (sum == targetDuration)
                {
                    return new List<int> { orderedList[start], orderedList[end] };
                }
                else if (sum < targetDuration && sum > maxDuration)
                {
                    Console.WriteLine($"[{start}]: {orderedList[start]}, [{end}]: {orderedList[end]}");
                    if (max1 < orderedList[start] || max2 < orderedList[end])
                    {
                        max1 = orderedList[start];
                        max2 = orderedList[end];
                    }

                    maxDuration = sum;
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return new List<int> { max1, max2 };
        }
    }
}