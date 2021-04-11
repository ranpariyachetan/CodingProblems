using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingProblems
{
    public class MinimumSpanninTree
    {
        // Problem statement : https://aonecode.com/amazon-online-assessment-oa2-min-cost-to-add-new-roads
        // https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/

        public static int CalculateMinimumCost(int[][] connections, int n)
        {
            var edgeLen = connections.Length;
            var edges = new Edge[edgeLen];

            Dictionary<int, Subset> subsets = new Dictionary<int, Subset>();

            var results = new List<Edge>();

            for (int i = 0; i < edgeLen; i++)
            {
                edges[i] = new Edge { Src = connections[i][0], Dest = connections[i][1], Cost = connections[i][2] };

                if (!subsets.ContainsKey(edges[i].Src))
                {
                    subsets.Add(edges[i].Src, new Subset { Parent = edges[i].Src, Rank = edges[i].Cost });
                }

                if (!subsets.ContainsKey(edges[i].Dest))
                {
                    subsets.Add(edges[i].Dest, new Subset { Parent = edges[i].Dest, Rank = edges[i].Cost });
                }
            }

            edges = edges.OrderBy(e => e.Cost).ToArray();

            foreach (var edge in edges)
            {
                var x = Find(subsets, edge.Src);
                var y = Find(subsets, edge.Dest);

                if (x != y)
                {
                    results.Add(edge);
                    Union(subsets, x, y);
                }
            }

            var minCost = 0;

            foreach (var edge in results)
            {
                minCost += edge.Cost;
            }

            return minCost;
        }

        private static int Find(Dictionary<int, Subset> subsets, int x)
        {
            // if(subsets[x].Parent == -1)
            // {
            //     return x;
            // }
            // return Find(subsets, subsets[x].Parent);
            if (subsets[x].Parent != x)
            {
                subsets[x].Parent = Find(subsets, subsets[x].Parent);
            }
            return subsets[x].Parent;
        }

        private static void Union(Dictionary<int, Subset> subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
            {
                subsets[xroot].Parent = yroot;
            }
            else if (subsets[yroot].Rank < subsets[xroot].Rank)
            {
                subsets[yroot].Parent = xroot;
            }
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }
        }

        public class Subset
        {
            public int Rank { get; set; }
            public int Parent { get; set; }
        }

        class Edge
        {
            public int Src { get; set; }
            public int Dest { get; set; }
            public int Cost { get; set; }
        }
    }
    // C# Code for above approach

    public class GraphClass
    {

        // A class to represent a graph edge
        class Edge : IComparable<Edge>
        {
            public int src, dest, weight;

            // Comparator function used for sorting edges
            // based on their weight
            public int CompareTo(Edge compareEdge)
            {
                return this.weight
                    - compareEdge.weight;
            }
        }

        // A class to represent
        // a subset for union-find
        public class subset
        {
            public int parent, rank;
        };

        int V, E; // V-> no. of vertices & E->no.of edges
        Edge[] edge; // collection of all edges

        // Creates a graph with V vertices and E edges
        GraphClass(int v, int e)
        {
            V = v;
            E = e;
            edge = new Edge[E];
            for (int i = 0; i < e; ++i)
                edge[i] = new Edge();
        }

        // A utility function to find set of an element i
        // (uses path compression technique)
        int find(subset[] subsets, int i)
        {
            // find root and make root as
            // parent of i (path compression)
            if (subsets[i].parent != i)
                subsets[i].parent
                    = find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        // A function that does union of
        // two sets of x and y (uses union by rank)
        void Union(subset[] subsets, int x, int y)
        {
            int xroot = find(subsets, x);
            int yroot = find(subsets, y);

            // Attach smaller rank tree under root of
            // high rank tree (Union by Rank)
            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;
            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            // If ranks are same, then make one as root
            // and increment its rank by one
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

        // The main function to construct MST
        // using Kruskal's algorithm
        void KruskalMST()
        {
            // This will store the
            // resultant MST
            Edge[] result = new Edge[V];
            int e = 0; // An index variable, used for result[]
            int i
                = 0; // An index variable, used for sorted edges
            for (i = 0; i < V; ++i)
                result[i] = new Edge();

            // Step 1: Sort all the edges in non-decreasing
            // order of their weight. If we are not allowed
            // to change the given graph, we can create
            // a copy of array of edges
            Array.Sort(edge);

            // Allocate memory for creating V ssubsets
            subset[] subsets = new subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new subset();

            // Create V subsets with single elements
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0; // Index used to pick next edge

            // Number of edges to be taken is equal to V-1
            while (e < V - 1 && i<edge.Length)
            {
                // Step 2: Pick the smallest edge. And increment
                // the index for next iteration
                Edge next_edge = new Edge();
                next_edge = edge[i++];

                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                // If including this edge does't cause cycle,
                // include it in result and increment the index
                // of result for next edge
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge
            }

            // print the contents of result[] to display
            // the built MST
            Console.WriteLine("Following are the edges in "
                            + "the constructed MST");

            int minimumCost = 0;
            for (i = 0; i < e; ++i)
            {
                Console.WriteLine(result[i].src + " -- "
                                + result[i].dest
                                + " == " + result[i].weight);
                minimumCost += result[i].weight;
            }

            Console.WriteLine("Minimum Cost Spanning Tree"
                            + minimumCost);
            // Console.ReadLine();
        }

        // Driver Code
        public static void UseKruskalMST()
        {

            /* Let us create following weighted graph
                    10
                0--------1
                | \ |
            6| 5\ |15
                | \ |
                2--------3
                    4 */
            int V = 4; // Number of vertices in graph
            int E = 2; // Number of edges in graph
            GraphClass graph = new GraphClass(V, E);

            // add edge 0-1
            graph.edge[0].src = 0;
            graph.edge[0].dest = 1;
            graph.edge[0].weight = 3;

            // add edge 0-2
            graph.edge[1].src = 2;
            graph.edge[1].dest = 3;
            graph.edge[1].weight = 4;

            // add edge 0-3
            // graph.edge[2].src = 0;
            // graph.edge[2].dest = 3;
            // graph.edge[2].weight = 5;

            // // add edge 1-3
            // graph.edge[3].src = 1;
            // graph.edge[3].dest = 3;
            // graph.edge[3].weight = 15;

            // // add edge 2-3
            // graph.edge[4].src = 2;
            // graph.edge[4].dest = 3;
            // graph.edge[4].weight = 4;

            // Function call
            graph.KruskalMST();
        }
    }

    // This code is contributed by Aakash Hasija

}