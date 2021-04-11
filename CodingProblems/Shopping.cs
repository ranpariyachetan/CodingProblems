using System;
using System.Collections.Generic;

namespace CodingProblems
{
    public class Shopping 
    {
        public static int MinProductScore(int productNodes, int[] productsFrom, int[] productsTo)
        {
            Dictionary<int, HashSet<int>> neighbors = new Dictionary<int, HashSet<int>>(); 

            for(int i = 0;i<productsFrom.Length;i++)
            {
                var o = productsFrom[i];
                var t = productsTo[i];

                if(!neighbors.ContainsKey(o))
                {
                    neighbors.Add(o, new HashSet<int>());
                }

                if(!neighbors.ContainsKey(t))
                {
                    neighbors.Add(t, new HashSet<int>());
                }

                neighbors[o].Add(t);
                neighbors[t].Add(o);
            }

            int minScore = int.MinValue;

            foreach(var neighbor in neighbors)
            {
                var u = neighbor.Key;
                var u_ns = neighbor.Value;
                foreach(var v in u_ns)
                {
                    if(v < u)
                    {
                        continue;
                    }
                    foreach(var w in u_ns)
                    {
                        var v_ns = neighbors[v];
                        if(w < u || !v_ns.Contains(v))
                        {
                            continue;
                        }

                        var w_ns = neighbors[w];

                        int curSum = u_ns.Count + v_ns.Count + w_ns.Count - 6;

                        minScore = Math.Min(minScore, curSum);
                    }
                }
            }
            return minScore != int.MinValue ? minScore : -1;
        }
    }
}