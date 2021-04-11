namespace CodingProblems
{
    public class Graph
    {
        //https://www.geeksforgeeks.org/union-find/
        public static bool CheckIsCycleWithUnionFind(int[][] pairs, int vCount)
        {
            int[] parents = new int[vCount];

            for (var i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            foreach (var pair in pairs)
            {
                var x1 = Find(parents, pair[0]);

                var y1 = Find(parents, pair[1]);

                if (x1 == y1)
                {
                    return true;
                }
                Union(parents, x1, y1);
            }

            return false;

        }

        private static int Find(int[] parents, int x)
        {
            if (parents[x] == -1)
                return x;

            return Find(parents, parents[x]);
        }

        private static void Union(int[] parents, int x, int y)
        {
            parents[x] = y;
        }
    }
}